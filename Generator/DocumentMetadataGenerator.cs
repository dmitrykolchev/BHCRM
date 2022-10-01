using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace Generator
{
    public class DocumentMetadataGenerator
    {
        private class DocumentTypeId
        {
            public int Id { get; set; }
            public string ClassName { get; set; }
        }
        public DocumentMetadataGenerator()
        {
        }

        public void ExportMetadata()
        {
            using (SchemaModelContext db = new SchemaModelContext())
            {
                SqlConnection connection = (SqlConnection)db.Database.Connection;
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[DocumentMetadataExport]", connection))
                {
                    using (XmlReader reader = command.ExecuteXmlReader())
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(reader);
                        StringBuilder buffer = new StringBuilder();
                        XmlWriterSettings settings = new XmlWriterSettings { Indent = true, IndentChars = "  ", OmitXmlDeclaration = true };
                        using(XmlWriter writer = XmlWriter.Create(buffer,settings))
                        {
                            document.Save(writer);
                        }
                        string xml = buffer.ToString().Replace("'", "''");
                        using (FileStream stream = File.Create(@"..\..\..\CrmDb\UpdateMetadata.sql"))
                        {
                            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                            {
                                writer.Write(string.Format("exec [dbo].[DocumentMetadataImport] N'{0}';\ngo\n", xml));
                            }
                        }
                    }
                }
            }
        }

        public void Generate()
        {
            PublishMetadata();
        }

        public void PublishMetadata()
        {
            XmlDocument document = new XmlDocument();
            document.Load("DocumentMetadata.xml");
            using (SchemaModelContext db = new SchemaModelContext())
            {
                var documentTypes = db.DocumentTypes.Select(t => new DocumentTypeId { Id = t.Id, ClassName = t.ClassName }).ToDictionary(t => t.ClassName);

                XmlNodeList viewNodes = document.DocumentElement.SelectNodes("View");
                foreach (XmlNode node in viewNodes)
                {
                    string viewName = node.Attributes["Name"].Value;
                    string table = node.Attributes["Table"].Value;
                    string dataAdapterAssembly = "DykBits.Crm.DataAdapters";
                    string entityAssembly = "DykBits.Crm.Entities";

                    if (node.Attributes["EntityAssembly"] != null)
                        entityAssembly = node.Attributes["EntityAssembly"].Value;
                    if (node.Attributes["DataAdapterAssembly"] != null)
                        dataAdapterAssembly = node.Attributes["DataAdapterAssembly"].Value;

                    string schema = "dbo";
                    int index = table.IndexOf('.');
                    if (index >= 0)
                    {
                        schema = table.Substring(0, index);
                        table = table.Substring(index + 1);
                    }
                    DocumentView documentView = db.DocumentViews.Where(t => t.ViewName == viewName).SingleOrDefault();
                    if (documentView == null)
                    {
                        documentView = new DocumentView
                        {
                            ClassName = null,
                            ViewName = viewName,
                            TableName = table,
                            SchemaName = schema,
                            Caption = node.Attributes["Caption"].Value,
                            ClrTypeName = string.Format("DykBits.Crm.Data.{0},{1}", viewName, entityAssembly),
                            DataAdapterTypeName = string.Format("DykBits.Crm.Data.{0}DataAdapter,{1}", viewName, dataAdapterAssembly),
                            DataAdapterType = node.Attributes["DataAdapterMode"].Value,
                            Description = null,
                            Created = DateTime.Now,
                            CreatedBy = 1,
                            Modified = DateTime.Now,
                            ModifiedBy = 1
                        };
                        db.DocumentViews.Add(documentView);
                    }
                    else
                    {
                        documentView.ClassName = null;
                        documentView.TableName = table;
                        documentView.SchemaName = schema;
                        documentView.Caption = node.Attributes["Caption"].Value;
                        documentView.ClrTypeName = string.Format("DykBits.Crm.Data.{0},{1}", viewName, entityAssembly);
                        documentView.DataAdapterTypeName = string.Format("DykBits.Crm.Data.{0}DataAdapter,{1}", viewName, dataAdapterAssembly);
                        documentView.DataAdapterType = node.Attributes["DataAdapterMode"].Value;
                        documentView.Description = null;
                        documentView.Modified = DateTime.Now;
                        documentView.ModifiedBy = 1;
                    }
                    db.SaveChanges();
                }

                foreach (XmlNode node in document.DocumentElement.SelectNodes("Document"))
                {
                    string className = node.Attributes["Name"].Value;
                    string table = node.Attributes["Table"].Value;
                    
                    string dataAdapterAssembly = "DykBits.Crm.DataAdapters";
                    string entityAssembly = "DykBits.Crm.Entities";

                    if (node.Attributes["EntityAssembly"] != null)
                        entityAssembly = node.Attributes["EntityAssembly"].Value;
                    if (node.Attributes["DataAdapterAssembly"] != null)
                        dataAdapterAssembly = node.Attributes["DataAdapterAssembly"].Value;

                    string schema = "dbo";
                    string description = null;
                    XmlNode descriptionNode = node.SelectSingleNode("Description");
                    if (descriptionNode != null)
                        description = descriptionNode.FirstChild.Value;
                    byte[] smallImage = null;
                    XmlNode imageNode = node.SelectSingleNode("SmallImage");
                    if (imageNode != null)
                        smallImage = Convert.FromBase64String(imageNode.FirstChild.Value);

                    byte[] largeImage = null;
                    imageNode = node.SelectSingleNode("LargeImage");
                    if (imageNode != null)
                        largeImage = Convert.FromBase64String(imageNode.FirstChild.Value);

                    int index = table.IndexOf('.');
                    if (index >= 0)
                    {
                        schema = table.Substring(0, index);
                        table = table.Substring(index + 1);
                    }
                    DocumentType documentType = db.DocumentTypes.Where(t => t.ClassName == className).SingleOrDefault();
                    bool isNumbered = false;
                    if (node.Attributes["IsNumbered"] != null)
                        isNumbered = XmlConvert.ToBoolean(node.Attributes["IsNumbered"].Value.ToLower());
                    bool supportsTransitionTemplates = false;
                    if (node.Attributes["SupportsTransitionTemplates"] != null)
                        supportsTransitionTemplates = XmlConvert.ToBoolean(node.Attributes["SupportsTransitionTemplates"].Value.ToLower());

                    if (documentType == null)
                    {
                        documentType = new DocumentType
                        {
                            ClassName = className,
                            TableName = table,
                            SchemaName = schema,
                            Caption = node.Attributes["Caption"].Value,
                            ClrTypeName = string.Format("DykBits.Crm.Data.{0},{1}", className, entityAssembly),
                            DataAdapterTypeName = string.Format("DykBits.Crm.Data.{0}DataAdapter,{1}", className, dataAdapterAssembly),
                            DataAdapterType = node.Attributes["DataAdapterMode"].Value,
                            IsNumbered = isNumbered,
                            SupportsTransitionTemplates = supportsTransitionTemplates,
                            SmallImage = smallImage,
                            LargeImage = largeImage,
                            Description = description,
                            Created = DateTime.Now,
                            CreatedBy = 1,
                            Modified = DateTime.Now,
                            ModifiedBy = 1
                        };
                        db.DocumentTypes.Add(documentType);
                    }
                    else
                    {
                        documentType.TableName = table;
                        documentType.SchemaName = schema;
                        documentType.Caption = node.Attributes["Caption"].Value;
                        documentType.ClrTypeName = string.Format("DykBits.Crm.Data.{0},{1}", className, entityAssembly);
                        documentType.DataAdapterTypeName = string.Format("DykBits.Crm.Data.{0}DataAdapter,{1}", className, dataAdapterAssembly);
                        documentType.DataAdapterType = node.Attributes["DataAdapterMode"].Value;
                        documentType.IsNumbered = isNumbered;
                        documentType.SupportsTransitionTemplates = supportsTransitionTemplates;
                        documentType.SmallImage = smallImage;
                        documentType.LargeImage = largeImage;
                        documentType.Description = description;
                        documentType.Modified = DateTime.Now;
                        documentType.ModifiedBy = 1;
                        db.DocumentStates.RemoveRange(db.DocumentStates.Where(t => t.DocumentTypeId == documentType.Id));
                    }
                    db.SaveChanges();

                    documentTypes.Remove(documentType.ClassName);

                    foreach (XmlNode stateNode in node.SelectNodes("State"))
                    {
                        descriptionNode = stateNode.SelectSingleNode("Description");
                        if (descriptionNode != null)
                            description = descriptionNode.FirstChild.Value;
                        else
                            description = null;
                        int ordinalPosition = 0;
                        
                        if (stateNode.Attributes["Ordinal"] != null)
                            ordinalPosition = XmlConvert.ToInt32(stateNode.Attributes["Ordinal"].Value);
                        else
                            ordinalPosition = XmlConvert.ToInt32(stateNode.Attributes["Value"].Value);
                        byte[] overlayImage = null;
                        if (stateNode.Attributes["OverlayImage"] != null)
                            overlayImage = Convert.FromBase64String(stateNode.Attributes["OverlayImage"].Value);

                        DocumentState state = new DocumentState
                        {
                            DocumentTypeId = documentType.Id,
                            State = XmlConvert.ToByte(stateNode.Attributes["Value"].Value),
                            OrdinalPosition = ordinalPosition,
                            Name = stateNode.Attributes["Name"].Value,
                            Caption = stateNode.Attributes["Caption"].Value,
                            OverlayImage = overlayImage,
                            Description = description,
                            Created = DateTime.Now,
                            CreatedBy = 1,
                            Modified = DateTime.Now,
                            ModifiedBy = 1
                        };
                        db.DocumentStates.Add(state);
                    }
                    db.SaveChanges();
                    UpdateViews(db, node, documentType);
                }
                foreach (var item in documentTypes)
                {
                    db.DocumentStates.RemoveRange(db.DocumentStates.Where(t => t.DocumentTypeId == item.Value.Id));
                    db.DocumentTypes.RemoveRange(db.DocumentTypes.Where(t => t.Id == item.Value.Id));
                    db.SaveChanges();
                }
            }
        }
        private void UpdateViews(SchemaModelContext db, XmlNode documentTypeNode, DocumentType documentType)
        {
            foreach (XmlNode node in documentTypeNode.SelectNodes("View"))
            {
                string className = documentType.ClassName;
                string viewName = node.Attributes["Name"].Value;
                string table = node.Attributes["Table"].Value;

                string schema = "dbo";
                string description = null;
                XmlNode descriptionNode = node.SelectSingleNode("Description");
                if (descriptionNode != null)
                    description = descriptionNode.FirstChild.Value;

                int index = table.IndexOf('.');
                if (index >= 0)
                {
                    schema = table.Substring(0, index);
                    table = table.Substring(index + 1);
                }
                DocumentView documentView = db.DocumentViews.Where(t => t.ViewName == viewName).SingleOrDefault();
                if (documentView == null)
                {
                    documentView = new DocumentView
                    {
                        ClassName = className,
                        ViewName = viewName,
                        TableName = table,
                        SchemaName = schema,
                        Caption = node.Attributes["Caption"].Value,
                        ClrTypeName = string.Format("DykBits.Crm.Data.{0},DykBits.Crm.Entities", viewName),
                        DataAdapterTypeName = string.Format("DykBits.Crm.Data.{0}DataAdapter,DykBits.Crm.DataAdapters", viewName),
                        DataAdapterType = node.Attributes["DataAdapterMode"].Value,
                        Description = description,
                        Created = DateTime.Now,
                        CreatedBy = 1,
                        Modified = DateTime.Now,
                        ModifiedBy = 1
                    };
                    db.DocumentViews.Add(documentView);
                }
                else
                {
                    documentView.ClassName = className;
                    documentView.TableName = table;
                    documentView.SchemaName = schema;
                    documentView.Caption = node.Attributes["Caption"].Value;
                    documentView.ClrTypeName = string.Format("DykBits.Crm.Data.{0},DykBits.Crm.Entities", viewName);
                    documentView.DataAdapterTypeName = string.Format("DykBits.Crm.Data.{0}DataAdapter,DykBits.Crm.DataAdapters", viewName);
                    documentView.DataAdapterType = node.Attributes["DataAdapterMode"].Value;
                    documentView.Description = description;
                    documentView.Modified = DateTime.Now;
                    documentView.ModifiedBy = 1;
                }
                db.SaveChanges();
            }
        }
    }
}
