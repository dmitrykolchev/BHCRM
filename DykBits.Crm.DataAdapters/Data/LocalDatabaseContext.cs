using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace DykBits.Crm.Data
{
    public class LocalDatabaseContext : IDatabaseContext
    {
        private static SqlCommand CreateCommand(string commandName, SqlConnection connection)
        {
            SqlProcedureManager commandManager = ServiceManager.GetService<SqlProcedureManager>();
            return commandManager.GetProcedure(commandName, connection);
        }

        private DocumentNumberInfo GetDocumentNumber(string className, int organizationId)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand("[dbo].[DocumentNumberGenerate]", connection))
                {
                    command.Parameters["@ClassName"].Value = className;
                    command.Parameters["@OrganizationId"].Value = organizationId;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException("Произошла ошибка при получении номера. Вероятно не определен нумератор для этого вида документа.");
                        DocumentNumberInfo info = new DocumentNumberInfo
                        {
                            Number = reader.GetInt32(reader.GetOrdinal("Number")),
                            FormattedNumber = reader.GetString(reader.GetOrdinal("FormatString")),
                            FileAs = reader.GetString(reader.GetOrdinal("FileAsFormatString"))
                        };
                        return info;
                    }
                }
            }
        }

        public DocumentNumberInfo GetDocumentNumberInfo(string className, int organizationId, DateTime documentDate)
        {
            DocumentNumberInfo info = GetDocumentNumber(className, organizationId);
            info.FormattedNumber = string.Format(info.FormattedNumber, info.Number, documentDate);
            info.FileAs = string.Format(info.FileAs, info.Number, documentDate);
            return info;
        }

        public Stream GetDocumentMetadata()
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand("[dbo].[DocumentMetadataBrowse]", connection))
                {
                    using (XmlReader reader = command.ExecuteXmlReader())
                    {
                        return ConvertToStream(reader);
                    }
                }
            }
        }
        public Stream ExecuteQuery(Stream stream)
        {
            XmlDocument document = new XmlDocument();
            document.Load(stream);
            IDataQueryManager manager = ServiceManager.GetService<IDataQueryManager>();
            IDataQuery dataQuery = manager.Find(document);
            if (dataQuery == null)
                throw new ArgumentException("Cannot find data query");
            LocalDatabaseContext db = new LocalDatabaseContext();
            return db.ExecuteQuery(string.Format("[{0}].[{1}]", dataQuery.SchemaName, dataQuery.ProcedureName), document);
        }

        public int ExecuteNonQuery(Stream stream)
        {
            XmlDocument document = new XmlDocument();
            document.Load(stream);
            IDataQueryManager manager = ServiceManager.GetService<IDataQueryManager>();
            IDataQuery dataQuery = manager.Find(document);
            if (dataQuery == null)
                throw new ArgumentException("Cannot find data query");
            LocalDatabaseContext db = new LocalDatabaseContext();
            return db.ExecuteNonQuery(string.Format("[{0}].[{1}]", dataQuery.SchemaName, dataQuery.ProcedureName), document);
        }

        private Stream ExecuteQuery(string procedureName, XmlDocument document)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(procedureName, connection))
                {
                    command.Parameters["@xml"].Value = document.DocumentElement.OuterXml;
                    using (XmlReader reader = command.ExecuteXmlReader())
                    {
                        if (reader.NodeType == XmlNodeType.None)
                        {
                            if (!reader.Read())
                            {
                                Stream stream = new MemoryStream();
                                using (XmlWriter writer = XmlWriter.Create(stream))
                                {
                                    writer.WriteStartElement("Empty");
                                    writer.WriteEndElement();
                                }
                                stream.Position = 0;
                                return stream;
                            }
                        }
                        return ConvertToStream(reader);
                    }
                }
            }
        }

        private int ExecuteNonQuery(string procedureName, XmlDocument document)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(procedureName, connection))
                {
                    command.Parameters["@xml"].Value = document.DocumentElement.OuterXml;
                    return command.ExecuteNonQuery();
                }
            }
        }

        private Stream ConvertToStream(DataItem dataItem)
        {
            MemoryStream stream = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                dataItem.WriteXml(writer);
            }
            stream.Position = 0;
            return stream;
        }

        private Stream ConvertToStream(XmlReader reader)
        {
            MemoryStream stream = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                writer.WriteNode(reader, false);
            }
            stream.Position = 0;
            return stream;
        }

        public IEmployeeInfo GetCurrentEmployee()
        {
            EmployeeDataAdapter adapter = new EmployeeDataAdapter();
            return adapter.GetCurrentEmployee();
        }

        public IList<DataQueryView> GetDataQueries()
        {
            DataQueryDataAdapter adapter = new DataQueryDataAdapter();
            return adapter.Browse(Filter.EmptyXml);
        }


        public bool IsRemote
        {
            get { return false; }
        }
    }
}
