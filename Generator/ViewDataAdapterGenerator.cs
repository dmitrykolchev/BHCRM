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
    public class ViewDataAdapterGenerator
    {
        private DocumentView _view;
        private TableDefinition _table;
        private DocumentType _documentType;

        public ViewDataAdapterGenerator(DocumentView view)
        {
            this._view = view;
        }

        public DocumentView View
        {
            get { return this._view; }
        }

        public TableDefinition Table
        {
            get { return this._table; }
        }

        public DocumentType DocumentType
        {
            get { return this._documentType; }
        }

        public void Generate()
        {
            using (SchemaModelContext db = new SchemaModelContext())
            {
                this._documentType = db.DocumentTypes.Where(t => t.ClassName == View.ClassName).SingleOrDefault();
                if (this._documentType == null)
                {
                    throw new InvalidOperationException(string.Format("Документ {0} не найден", Table.TableName));
                }
                this._table = db.Tables.Where(t => t.TableName == this.View.TableName && t.SchemaName == this.View.SchemaName).SingleOrDefault();
                if (this._table != null)
                    db.Entry(this._table).Collection(t => t.Columns).Load();
            }
            GenerateViewEntity();
            SqlReaderViewDataAdaperGenerator generator = new SqlReaderViewDataAdaperGenerator(View, Table, DocumentType);
            generator.Generate();
            ViewDataAdapterProxyGenerator proxyGenerator = new ViewDataAdapterProxyGenerator(View, Table, DocumentType);
            proxyGenerator.Generate();
        }

        public static IList<SqlColumnInfo> GetProcedureColumns(string procedureName)
        {
            using (SqlConnection connection = new SqlConnection(App.GetConnectionString()))
            {
                connection.Open();
                return SqlCommandResults.GetViewColumns(procedureName, connection);
            }
        }

        public void GenerateViewEntity()
        {
            bool isView = View.DataAdapterType == "View";
            string stateEnumName = "byte";
            if (isView && DocumentType != null)
                stateEnumName = DocumentType.ClassName + "State";

            IList<SqlColumnInfo> columns = GetProcedureColumns(string.Format("[dbo].[{0}Browse]", Table.TableName));

            string className = View.ViewName;

            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration(className) { Attributes = MemberAttributes.Public };

            if (isView)
                typeDeclaration.BaseTypes.Add(new CodeTypeReference("DataItemView"));
            else
                typeDeclaration.BaseTypes.Add(new CodeTypeReference("DocumentView"));

            typeDeclaration.IsClass = true;
            typeDeclaration.IsPartial = true;

            List<CodeMemberField> fields = new List<CodeMemberField>();
            List<CodeMemberProperty> properties = new List<CodeMemberProperty>();

            if (isView)
            {
                typeDeclaration.Members.Add(new CodeMemberField
                {
                    Attributes = MemberAttributes.Const | MemberAttributes.Public,
                    Name = "DataItemClassName",
                    Type = new CodeTypeReference(typeof(string)),
                    InitExpression = new CodeSnippetExpression("\"" + DocumentType.ClassName + "\"")
                });


                CodeMemberProperty classNameProperty = new CodeMemberProperty
                {
                    Name = "DataItemClass",
                    Attributes = MemberAttributes.Public | MemberAttributes.Override,
                    HasGet = true,
                    HasSet = false,
                    Type = new CodeTypeReference(typeof(string))
                };
                classNameProperty.GetStatements.Add(new CodeSnippetExpression("return DataItemClassName"));
                properties.Add(classNameProperty);
            }

            foreach (SqlColumnInfo column in columns)
            {
                if (!builtInFields.Contains(column.ColumnName) && !(!isView && column.ColumnName == "DocumentTypeId"))
                {
                    CodeMemberField field = new CodeMemberField { Attributes = MemberAttributes.Private };
                    field.Type = MapPropertyType(column);
                    field.Name = "_" + column.ColumnName + "Field";
                    fields.Add(field);

                    CodeMemberProperty property = new CodeMemberProperty
                    {
                        Name = column.ColumnName,
                        Type = field.Type,
                        HasSet = true,
                        HasGet = true,
                        Attributes = MemberAttributes.Public | MemberAttributes.Final
                    };
                    property.SetStatements.Add(new CodeSnippetExpression(string.Format("this.{0} = value", field.Name)));
                    property.GetStatements.Add(new CodeSnippetExpression(string.Format("return this.{0}", field.Name)));
                    properties.Add(property);
                }
                if (column.ColumnName == "State")
                {
                    if (isView)
                    {
                        CodeMemberProperty stateProperty = new CodeMemberProperty
                        {
                            Attributes = MemberAttributes.Public | MemberAttributes.Final,
                            Name = column.ColumnName,
                            HasGet = true,
                            HasSet = true,
                            Type = new CodeTypeReference(stateEnumName)
                        };
                        stateProperty.SetStatements.Add(new CodeSnippetExpression("((IDataItem)this).State = (byte)value"));
                        stateProperty.GetStatements.Add(new CodeSnippetExpression(string.Format("return ({0})((IDataItem)this).State", stateEnumName)));
                        properties.Add(stateProperty);
                    }
                }
            }
            fields.ForEach(t => typeDeclaration.Members.Add(t));
            properties.ForEach(t => typeDeclaration.Members.Add(t));

            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace("DykBits.Crm.Data");
            compileUnit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));

            ns.Types.Add(typeDeclaration);

            GenerateCode(className + ".cs", compileUnit);
        }


        private static readonly string[] builtInFields = { "Id", "State", "FileAs", "Comments", "Created", "CreatedBy", "Modified", "ModifiedBy", "RowVersion" };


        private void GenerateCode(string fileName, CodeCompileUnit compileUnit)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            {
                provider.GenerateCodeFromCompileUnit(compileUnit, writer, new CodeGeneratorOptions { BlankLinesBetweenMembers = false, IndentString = "    ", VerbatimOrder = true, BracingStyle = "C" });
            }
            string assemblyName = Helper.GetAssemblyName(this._documentType.ClrTypeName);
            string path = @"..\..\..\" + assemblyName.Trim() + @"\Data";
            path = Path.Combine(path, fileName);
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(builder.ToString());
            }
        }


        private static CodeTypeReference MapPropertyType(ColumnDefinition column)
        {
            if (column.ColumnName == "State")
            {
                return new CodeTypeReference(column.TableName + "State");
            }
            switch (column.DataType.ToLower())
            {
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                    return new CodeTypeReference(typeof(String));
                case "int":
                    if (column.IsNullable == "YES")
                        return new CodeTypeReference(typeof(Nullable<Int32>));
                    return new CodeTypeReference(typeof(Int32));
                case "tinyint":
                    if (column.IsNullable == "YES")
                        return new CodeTypeReference(typeof(Nullable<Byte>));
                    return new CodeTypeReference(typeof(Byte));
                case "datetime":
                case "date":
                    if (column.IsNullable == "YES")
                        return new CodeTypeReference(typeof(Nullable<DateTime>));
                    return new CodeTypeReference(typeof(DateTime));
                case "decimal":
                case "money":
                    if (column.IsNullable == "YES")
                        return new CodeTypeReference(typeof(Nullable<Decimal>));
                    return new CodeTypeReference(typeof(Decimal));
                case "timestamp":
                    return new CodeTypeReference(typeof(Byte[]));
                case "binary":
                case "varbinary":
                    return new CodeTypeReference(typeof(Byte[]));
                case "bit":
                    if (column.IsNullable == "YES")
                        return new CodeTypeReference(typeof(Nullable<Boolean>));
                    else
                        return new CodeTypeReference(typeof(Boolean));
                default:
                    throw new InvalidOperationException();
            }
        }

        private CodeTypeReference MapPropertyType(SqlColumnInfo column)
        {
            if (column.ColumnName == "State")
            {
                return new CodeTypeReference(Table.TableName + "State");
            }
            switch (column.DataType.ToLower())
            {
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                    return new CodeTypeReference(typeof(String));
                case "int":
                    if (column.IsNullable)
                        return new CodeTypeReference(typeof(Nullable<Int32>));
                    return new CodeTypeReference(typeof(Int32));
                case "tinyint":
                    if (column.IsNullable)
                        return new CodeTypeReference(typeof(Nullable<Byte>));
                    return new CodeTypeReference(typeof(Byte));
                case "datetime":
                case "date":
                    if (column.IsNullable)
                        return new CodeTypeReference(typeof(Nullable<DateTime>));
                    return new CodeTypeReference(typeof(DateTime));
                case "decimal":
                case "money":
                    if (column.IsNullable)
                        return new CodeTypeReference(typeof(Nullable<Decimal>));
                    return new CodeTypeReference(typeof(Decimal));
                case "timestamp":
                    return new CodeTypeReference(typeof(Byte[]));
                case "binary":
                case "varbinary":
                    return new CodeTypeReference(typeof(Byte[]));
                case "bit":
                    return new CodeTypeReference(typeof(Boolean));
                default:
                    throw new InvalidOperationException();
            }
        }

    }
}
