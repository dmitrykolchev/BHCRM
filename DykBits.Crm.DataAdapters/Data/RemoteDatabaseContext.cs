using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using DykBits.Crm.DocumentServices;

namespace DykBits.Crm.Data
{
    public class RemoteDatabaseContext: IDatabaseContext
    {
        public DocumentNumberInfo GetDocumentNumberInfo(string className, int organizationId, DateTime documentDate)
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                return client.GetDocumentNumberInfo(className, organizationId, documentDate);
            }
            finally
            {
                client.Close();
            }
        }


        public System.IO.Stream GetDocumentMetadata()
        {
            RemoteDataService client = new RemoteDataService();
            return new RemoteStream(client.GetDocumentMetadata(), client);
        }


        public IEmployeeInfo GetCurrentEmployee()
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                using (Stream stream = client.GetCurrentEmployee())
                {
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        Employee employee = new Employee();
                        employee.ReadXml(reader);
                        return employee;
                    }
                }
            }
            finally
            {
                client.Close();
            }
        }


        public Stream ExecuteQuery(Stream stream)
        {
            RemoteDataService client = new RemoteDataService();
            return new RemoteStream(client.ExecuteQuery(stream), client);
        }

        public int ExecuteNonQuery(Stream stream)
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                return client.ExecuteNonQuery(stream);
            }
            finally
            {
                client.Close();
            }
        }
        public bool IsRemote
        {
            get { return true; }
        }
    }
}
