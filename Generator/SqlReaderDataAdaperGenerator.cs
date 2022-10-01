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
    class SqlReaderDataAdaperGenerator: AbstractReaderDataAdapterGenerator
    {
        public SqlReaderDataAdaperGenerator(string className, TableDefinition table, DocumentType documentType): base(className, table, documentType)
        {
        }

        private void CreateTypeDeclaration()
        {
            this._dataAdapter = new CodeTypeDeclaration { Name = ClassName + "DataAdapter", Attributes = MemberAttributes.Public, IsClass = true, IsPartial = true };
            this._dataAdapter.BaseTypes.Add(new CodeTypeReference(string.Format("DataAdapterBase<{0}, {1}, {2}>", ViewName, ClassName, FilterName)));
        }

        public void Generate()
        {
            CreateTypeDeclaration();

            this._dataAdapter.Members.Add(CreateInitializeBindBrowseResultToItem());

            this._dataAdapter.Members.Add(CreateBindBrowseResultToItemMethod());

            this._dataAdapter.Members.Add(CreateInitializeBindListResultToItem());

            this._dataAdapter.Members.Add(CreateBindListResultToItemMethod());

            this._dataAdapter.Members.Add(CreateInitializeBindGetItemResultToItem());

            this._dataAdapter.Members.Add(CreateBindGetItemResultToItemMethod());

            this._dataAdapter.Members.Add(CreateBindCreateCommandMethod());

            this._dataAdapter.Members.Add(CreateBindUpdateCommandMethod());

            CreateCompileUnitAndSave();
        }

        private IList<SqlColumnInfo> _columns;

        protected CodeMemberMethod CreateInitializeBindGetItemResultToItem()
        {
            CodeMemberField initialized = new CodeMemberField { Name = "_initialized0", Attributes = MemberAttributes.Private, Type = new CodeTypeReference(typeof(Boolean)) };
            this._dataAdapter.Members.Add(initialized);

            this._columns = DataAdapterGenerator.GetProcedureColumns(string.Format("[dbo].[{0}Get]", Table.TableName));

            foreach (var column in this._columns)
            {
                this._dataAdapter.Members.Add(new CodeMemberField { Name = "_ordinal0" + column.ColumnName, Attributes = MemberAttributes.Private, Type = new CodeTypeReference(typeof(Int32)) });
            }

            CodeMemberMethod initializeBindToItem = new CodeMemberMethod { Name = "InitializeBindGetItemResultToItem", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Private | MemberAttributes.Final };
            initializeBindToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "reader", Type = new CodeTypeReference("SqlDataReader") });

            initializeBindToItem.Statements.Add(new CodeSnippetExpression("if (this._initialized0) return"));
            foreach (var column in this._columns)
            {
                initializeBindToItem.Statements.Add(new CodeSnippetExpression(string.Format("this._ordinal0{0} = reader.GetOrdinal(\"{0}\")", column.ColumnName)));
            }
            initializeBindToItem.Statements.Add(new CodeSnippetExpression("this._initialized0 = true"));
            return initializeBindToItem;
        }

        private CodeMemberMethod CreateBindGetItemResultToItemMethod()
        {
            CodeMemberMethod bindGetItemResultToItem = new CodeMemberMethod { Name = "BindGetItemResultToItem", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Family | MemberAttributes.Override };
            bindGetItemResultToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "item", Type = new CodeTypeReference(ClassName) });
            bindGetItemResultToItem.Parameters.Add(new CodeParameterDeclarationExpression { Name = "reader", Type = new CodeTypeReference("SqlDataReader") });
            bindGetItemResultToItem.Statements.Add(new CodeSnippetExpression("InitializeBindGetItemResultToItem(reader)"));
            foreach (var column in this._columns)
            {
                string expression;
                if (column.IsNullable)
                {
                    expression = string.Format("if(reader.IsDBNull(_ordinal0{0})) item.{0} = null; else item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 0));
                }
                else
                {
                    expression = string.Format("item.{0} = {1}", column.ColumnName, GetReaderMethod(column, 0));
                }
                bindGetItemResultToItem.Statements.Add(new CodeSnippetExpression(expression));
            }
            return bindGetItemResultToItem;
        }

        private CodeMemberMethod CreateBindCreateCommandMethod()
        {
            CodeMemberMethod bindCreateCommand = new CodeMemberMethod { Name = "BindCreateCommand", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Family | MemberAttributes.Override };
            bindCreateCommand.Parameters.Add(new CodeParameterDeclarationExpression { Name = "command", Type = new CodeTypeReference("SqlCommand") });
            bindCreateCommand.Parameters.Add(new CodeParameterDeclarationExpression { Name = "item", Type = new CodeTypeReference(ClassName) });
            foreach (var column in this._columns)
            {
                if (!excludedCreateCommandColumns.Contains(column.ColumnName))
                {
                    if (column.CanBeNull())
                        bindCreateCommand.Statements.Add(new CodeSnippetExpression(string.Format("command.Parameters[\"@{0}\"].Value = DbValueConverter.Convert(item.{0})", column.ColumnName)));
                    else
                        bindCreateCommand.Statements.Add(new CodeSnippetExpression(string.Format("command.Parameters[\"@{0}\"].Value = item.{0}", column.ColumnName)));
                }
            }
            return bindCreateCommand;
        }

        private CodeMemberMethod CreateBindUpdateCommandMethod()
        {
            CodeMemberMethod bindUpdateCommand = new CodeMemberMethod { Name = "BindUpdateCommand", ReturnType = new CodeTypeReference(typeof(void)), Attributes = MemberAttributes.Family | MemberAttributes.Override };
            bindUpdateCommand.Parameters.Add(new CodeParameterDeclarationExpression { Name = "command", Type = new CodeTypeReference("SqlCommand") });
            bindUpdateCommand.Parameters.Add(new CodeParameterDeclarationExpression { Name = "item", Type = new CodeTypeReference(ClassName) });
            foreach (var column in this._columns)
            {
                if (!excludedUpdateCommandColumns.Contains(column.ColumnName))
                {
                    if (column.CanBeNull())
                        bindUpdateCommand.Statements.Add(new CodeSnippetExpression(string.Format("command.Parameters[\"@{0}\"].Value = DbValueConverter.Convert(item.{0})", column.ColumnName)));
                    else
                        bindUpdateCommand.Statements.Add(new CodeSnippetExpression(string.Format("command.Parameters[\"@{0}\"].Value = item.{0}", column.ColumnName)));
                }
            }
            return bindUpdateCommand;
        }

        private void CreateCompileUnitAndSave()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace("DykBits.Crm.Data");
            compileUnit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.Data"));
            ns.Imports.Add(new CodeNamespaceImport("System.Data.SqlClient"));

            ns.Types.Add(this._dataAdapter);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            {
                provider.GenerateCodeFromCompileUnit(compileUnit, writer, new CodeGeneratorOptions { BlankLinesBetweenMembers = false, IndentString = "    ", VerbatimOrder = true, BracingStyle = "C" });
            }
            string assemblyName = Helper.GetAssemblyName(this.DocumentType.DataAdapterTypeName);
            string path = @"..\..\..\" + assemblyName.Trim() + @"\Data";
            path = Path.Combine(path, ClassName + "DataAdapter.cs");
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(builder.ToString());
            }
        }

    }
}
