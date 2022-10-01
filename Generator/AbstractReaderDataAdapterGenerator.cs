using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Generator
{
    public abstract class AbstractReaderDataAdapterGenerator
    {
        private string _viewName;
        private string _className;
        private TableDefinition _table;
        private DocumentType _documentType;
        protected CodeTypeDeclaration _dataAdapter;

        protected AbstractReaderDataAdapterGenerator(string className, TableDefinition table, DocumentType documentType)
        {
            this._viewName = className + "View";
            this._className = className;
            this._table = table;
            this._documentType = documentType;
        }
        protected AbstractReaderDataAdapterGenerator(string viewName, string className, TableDefinition table, DocumentType documentType)
        {
            this._viewName = viewName;
            this._className = className;
            this._table = table;
            this._documentType = documentType;
        }

        public string ViewName
        {
            get { return this._viewName; }
        }

        public string ClassName
        {
            get { return this._className; }
        }
        public string FilterName
        {
            get { return this._className + "Filter"; }
        }

        public TableDefinition Table
        {
            get { return this._table; }
        }

        public DocumentType DocumentType
        {
            get { return this._documentType; }
        }

        protected static readonly string[] excludedCreateCommandColumns = { "Id", "State", "Created", "CreatedBy", "Modified", "ModifiedBy", "RowVersion" };
        protected static readonly string[] excludedUpdateCommandColumns = { "State", "Created", "CreatedBy", "Modified", "ModifiedBy" };


        private IList<SqlColumnInfo> _columns;

        protected CodeMemberMethod CreateInitializeBindBrowseResultToItem()
        {
            CodeMemberField initialized = new CodeMemberField { Name = "_initialized1", Attributes = MemberAttributes.Private, Type = new CodeTypeReference(typeof(Boolean)) };
            this._dataAdapter.Members.Add(initialized);

            this._columns = DataAdapterGenerator.GetProcedureColumns(string.Format("[dbo].[{0}Browse]", Table.TableName));

            foreach (var column in this._columns)
            {
                this._dataAdapter.Members.Add(new CodeMemberField { Name = "_ordinal1" + column.ColumnName, Attributes = MemberAttributes.Private, Type = new CodeTypeReference(typeof(Int32)) });
            }

            CodeMemberMethod initializeBindToItem = new CodeMemberMethod { Name = "InitializeBindBrowseResultToItem", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Private | MemberAttributes.Final };
            initializeBindToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "reader", Type = new CodeTypeReference("SqlDataReader") });

            initializeBindToItem.Statements.Add(new CodeSnippetExpression("if (this._initialized1) return"));
            foreach (var column in this._columns)
            {
                initializeBindToItem.Statements.Add(new CodeSnippetExpression(string.Format("this._ordinal1{0} = reader.GetOrdinal(\"{0}\")", column.ColumnName)));
            }
            initializeBindToItem.Statements.Add(new CodeSnippetExpression("this._initialized1 = true"));
            return initializeBindToItem;
        }
        private static readonly string[] notNullableFields = new string[] { "State", "Id" };
        protected CodeMemberMethod CreateBindBrowseResultToItemMethod()
        {
            CodeMemberMethod bindGetItemResultToItem = new CodeMemberMethod { Name = "BindBrowseResultToItem", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Family | MemberAttributes.Override };
            bindGetItemResultToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "item", Type = new CodeTypeReference(ViewName) });
            bindGetItemResultToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "reader", Type = new CodeTypeReference("SqlDataReader") });
            bindGetItemResultToItem.Statements.Add(new CodeSnippetExpression("InitializeBindBrowseResultToItem(reader)"));
            foreach (var column in this._columns)
            {
                string expression;
                if (column.IsNullable)
                {
                    if((DocumentType == null && column.ColumnName == "DocumentTypeId") || notNullableFields.Contains(column.ColumnName))
                        expression = string.Format("item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 1));
                    else
                        expression = string.Format("if(reader.IsDBNull(_ordinal1{0})) item.{0} = null; else item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 1));
                }
                else
                {
                    expression = string.Format("item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 1));
                }
                bindGetItemResultToItem.Statements.Add(new CodeSnippetExpression(expression));
            }
            return bindGetItemResultToItem;
        }

        private static readonly string[] IgnoreListColumns = new string[] { "Comments", "Created", "CreatedBy", "Modified", "ModifiedBy", "RowVersion" };


        protected CodeMemberMethod CreateInitializeBindListResultToItem()
        {
            CodeMemberField initialized = new CodeMemberField { Name = "_initialized2", Attributes = MemberAttributes.Private, Type = new CodeTypeReference(typeof(Boolean)) };
            this._dataAdapter.Members.Add(initialized);

            this._columns = DataAdapterGenerator.GetProcedureColumns(string.Format("[dbo].[{0}List]", Table.TableName));

            foreach (var column in this._columns.Where(t=> !IgnoreListColumns.Contains(t.ColumnName)).OrderBy(t=>t.ColumnOrdinal))
            {
                this._dataAdapter.Members.Add(new CodeMemberField { Name = "_ordinal2" + column.ColumnName, Attributes = MemberAttributes.Private, Type = new CodeTypeReference(typeof(Int32)) });
            }

            CodeMemberMethod initializeBindToItem = new CodeMemberMethod { Name = "InitializeBindListResultToItem", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Private | MemberAttributes.Final };
            initializeBindToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "reader", Type = new CodeTypeReference("SqlDataReader") });

            initializeBindToItem.Statements.Add(new CodeSnippetExpression("if (this._initialized2) return"));
            foreach (var column in this._columns.Where(t => !IgnoreListColumns.Contains(t.ColumnName)).OrderBy(t => t.ColumnOrdinal))
            {
                initializeBindToItem.Statements.Add(new CodeSnippetExpression(string.Format("this._ordinal2{0} = reader.GetOrdinal(\"{0}\")", column.ColumnName)));
            }
            initializeBindToItem.Statements.Add(new CodeSnippetExpression("this._initialized2 = true"));
            return initializeBindToItem;
        }
        protected CodeMemberMethod CreateBindListResultToItemMethod()
        {
            CodeMemberMethod bindGetItemResultToItem = new CodeMemberMethod { Name = "BindListResultToItem", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Family | MemberAttributes.Override };
            bindGetItemResultToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "item", Type = new CodeTypeReference(ViewName) });
            bindGetItemResultToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "reader", Type = new CodeTypeReference("SqlDataReader") });
            bindGetItemResultToItem.Statements.Add(new CodeSnippetExpression("InitializeBindListResultToItem(reader)"));
            foreach (var column in this._columns.Where(t => !IgnoreListColumns.Contains(t.ColumnName)).OrderBy(t => t.ColumnOrdinal))
            {
                string expression;
                if (column.IsNullable)
                {
                    if ((DocumentType == null && column.ColumnName == "DocumentTypeId") || notNullableFields.Contains(column.ColumnName))
                        expression = string.Format("item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 2));
                    else
                        expression = string.Format("if(reader.IsDBNull(_ordinal2{0})) item.{0} = null; else item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 2));
                }
                else
                {
                    expression = string.Format("item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 2));
                }
                bindGetItemResultToItem.Statements.Add(new CodeSnippetExpression(expression));
            }
            return bindGetItemResultToItem;
        }
        protected string GetReaderMethod(SqlColumnInfo column, int index)
        {
            if (column.ColumnName == "State")
            {
                if(DocumentType != null)
                    return string.Format("({0}State)reader.GetByte(this._ordinal{1}{2})", DocumentType.ClassName, index, column.ColumnName);
                return string.Format("reader.GetByte(this._ordinal{0}{1})", index, column.ColumnName);
            }
            switch (column.DataType.ToLower())
            {
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                    return string.Format("reader.GetString(this._ordinal{0}{1})", index, column.ColumnName);
                case "int":
                    return string.Format("reader.GetInt32(this._ordinal{0}{1})", index, column.ColumnName);
                case "tinyint":
                    return string.Format("reader.GetByte(this._ordinal{0}{1})", index, column.ColumnName);
                case "date":
                case "datetime":
                    return string.Format("reader.GetDateTime(this._ordinal{0}{1})", index, column.ColumnName);
                case "decimal":
                case "money":
                    return string.Format("reader.GetDecimal(this._ordinal{0}{1})", index, column.ColumnName);
                case "bit":
                    return string.Format("reader.GetBoolean(this._ordinal{0}{1})", index, column.ColumnName);
                case "timestamp":
                case "binary":
                case "varbinary":
                    return string.Format("reader.GetSqlBinary(this._ordinal{0}{1}).Value", index, column.ColumnName);
                case "time":
                    return string.Format("reader.GetTimeSpan(this._ordinal{0}{1})", index, column.ColumnName);
                case "xml":
                    return string.Format("reader.GetString(this._ordinal{0}{1})", index, column.ColumnName);
                default:
                    throw new InvalidOperationException();
            }
        }

        protected string GetReaderMethod(ColumnDefinition column, int index)
        {
            if (column.ColumnName == "State")
            {
                return string.Format("({0}State)reader.GetByte(this._ordinal{1}{2})", DocumentType.ClassName, index, column.ColumnName);
            }
            switch (column.DataType.ToLower())
            {
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                    return string.Format("reader.GetString(this._ordinal{0}{1})", index, column.ColumnName);
                case "int":
                    return string.Format("reader.GetInt32(this._ordinal{0}{1})", index, column.ColumnName);
                case "tinyint":
                    return string.Format("reader.GetByte(this._ordinal{0}{1})", index, column.ColumnName);
                case "date":
                case "datetime":
                    return string.Format("reader.GetDateTime(this._ordinal{0}{1})", index, column.ColumnName);
                case "decimal":
                case "money":
                    return string.Format("reader.GetDecimal(this._ordinal{0}{1})", index, column.ColumnName);
                case "bit":
                    return string.Format("reader.GetBoolean(this._ordinal{0}{1})", index, column.ColumnName);
                case "timestamp":
                case "binary":
                case "varbinary":
                    return string.Format("reader.GetSqlBinary(this._ordinal{0}{1}).Value", index, column.ColumnName);
                case "time":
                    return string.Format("reader.GetTimeSpan(this._ordinal{0}{1})", index, column.ColumnName);
                case "xml":
                    return string.Format("reader.GetString(this._ordinal{0}{1})", index, column.ColumnName);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
