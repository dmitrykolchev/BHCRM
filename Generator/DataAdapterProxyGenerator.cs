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
    class DataAdapterProxyGenerator
    {
        private string _className;
        private TableDefinition _table;
        private DocumentType _documentType;
        private CodeTypeDeclaration _dataAdapter;

        public DataAdapterProxyGenerator(string className, TableDefinition table, DocumentType documentType)
        {
            this._className = className;
            this._table = table;
            this._documentType = documentType;
        }
        public string ClassName
        {
            get { return this._className; }
        }

        public TableDefinition Table
        {
            get { return this._table; }
        }

        public DocumentType DocumentType
        {
            get { return this._documentType; }
        }

        private void CreateTypeDeclaration()
        {
            this._dataAdapter = new CodeTypeDeclaration { Name = Table.TableName + "DataAdapterProxy", Attributes = MemberAttributes.Public, IsClass = true, IsPartial = true };
            this._dataAdapter.BaseTypes.Add(new CodeTypeReference(string.Format("DataAdapterProxy<{0}View, {0}, {0}Filter>", Table.TableName)));
        }

        public void Generate()
        {
            CreateTypeDeclaration();
            CreateCompileUnitAndSave();
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
            path = Path.Combine(path, Table.TableName + "DataAdapterProxy.cs");
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(builder.ToString());
            }
        }

    }
}
