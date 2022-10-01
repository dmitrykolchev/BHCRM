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
    class ViewDataAdapterProxyGenerator
    {
        private DocumentView _view;
        private DocumentType _documentType;
        private CodeTypeDeclaration _dataAdapter;

        public ViewDataAdapterProxyGenerator(DocumentView view, TableDefinition table, DocumentType documentType)
        {
            this._view = view;
            this._documentType = documentType;
        }
        public DocumentView View
        {
            get { return this._view; }
        }

        public DocumentType DocumentType
        {
            get { return this._documentType; }
        }

        private void CreateTypeDeclaration()
        {
            this._dataAdapter = new CodeTypeDeclaration { Name = View.ViewName + "DataAdapterProxy", Attributes = MemberAttributes.Public, IsClass = true, IsPartial = true };
            this._dataAdapter.BaseTypes.Add(new CodeTypeReference(string.Format("ViewDataAdapterProxy<{0}, {1}Filter>", View.ViewName, DocumentType.ClassName)));
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
            string assemblyName = Helper.GetAssemblyName(this._documentType.DataAdapterTypeName);
            string path = @"..\..\..\" + assemblyName.Trim() + @"\Data";
            path = Path.Combine(path, View.ViewName + "DataAdapterProxy.cs");
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(builder.ToString());
            }
        }

    }

    public static class Helper
    {
        public static string GetAssemblyName(string typeName)
        {
            int index = typeName.IndexOf(',');
            return typeName.Substring(index + 1);
        }

    }
}
