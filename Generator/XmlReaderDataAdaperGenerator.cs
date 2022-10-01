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
    class XmlReaderDataAdaperGenerator: AbstractReaderDataAdapterGenerator
    {
        public XmlReaderDataAdaperGenerator(string className, TableDefinition table, DocumentType documentType): base(className, table, documentType)
        {
        }

        private void CreateTypeDeclaration()
        {
            this._dataAdapter = new CodeTypeDeclaration { Name = Table.TableName + "DataAdapter", Attributes = MemberAttributes.Public, IsClass = true, IsPartial = true };
            this._dataAdapter.BaseTypes.Add(new CodeTypeReference(string.Format("XmlDataAdapterBase<{0}View, {0}, {0}Filter>", Table.TableName)));
        }

        public void Generate()
        {
            CreateTypeDeclaration();

            this._dataAdapter.Members.Add(CreateInitializeBindBrowseResultToItem());

            this._dataAdapter.Members.Add(CreateBindBrowseResultToItemMethod());

            this._dataAdapter.Members.Add(CreateInitializeBindListResultToItem());

            this._dataAdapter.Members.Add(CreateBindListResultToItemMethod());

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
            path = Path.Combine(path, Table.TableName + "DataAdapter.cs");
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(builder.ToString());
            }
        }

    }
}
