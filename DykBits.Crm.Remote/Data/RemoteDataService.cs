using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using DykBits.Crm.DocumentServices;
using System.IO;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public class RemoteDataService : DykBits.Crm.DocumentServices.IDocumentService
    {
        public const string ServiceNamespace = "http://www.dykbits.net/2014/crm/documentservice";

        private DykBits.Crm.DocumentServices.DocumentServiceClient _client;
        public RemoteDataService()
        {
            this._client = RemoteDataServicePool.Instance.GetClient();
        }
        public static Uri EndPointUri
        {
            get
            {
                RemoteDataService service = new RemoteDataService();
                try
                {
                    Uri uri = service._client.Endpoint.ListenUri;
                    return uri;
                }
                finally
                {
                    service.Close();
                }
            }
        }
        public static string Server
        {
            get
            {
                try
                {
                    Uri uri = EndPointUri;
                    return uri.Host + ":" + uri.Port;
                }
                catch
                {
                    return "localhost";
                }
            }
        }
        private void ExceptionFromExceptionData(byte[] data)
        {
            if (data != null)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.MemoryStream stream = new System.IO.MemoryStream(data);
                Exception x = (Exception)formatter.Deserialize(stream);
                throw x;
            }
        }
        private Exception ExceptionFromFault(FaultException<DocumentServiceFault> fault)
        {
            if (fault.Detail != null && fault.Detail.ExceptionData != null)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.MemoryStream stream = new System.IO.MemoryStream(fault.Detail.ExceptionData);
                Exception x = (Exception)formatter.Deserialize(stream);
                return x;
            }
            return fault;
        }
        private void CreateOutgoingMessageHeaders()
        {
            if (OperationContext.Current != null)
            {
                MessageHeader header = MessageHeader.CreateHeader("ApplicationName", ServiceNamespace, this._client.ApplicationName);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
                header = MessageHeader.CreateHeader("WorkstatiionId", ServiceNamespace, this._client.WorkstationId);
                OperationContext.Current.OutgoingMessageHeaders.Add(header);
            }
        }
        public System.IO.Stream Browse(string documentType, System.Xml.Linq.XElement filter)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.Browse(documentType, filter);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<System.IO.Stream> BrowseAsync(string documentType, System.Xml.Linq.XElement filter)
        {
            return this._client.BrowseAsync(documentType, filter);
        }
        public System.IO.Stream GetList(string documentType, System.Xml.Linq.XElement filter)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders(); 
                    return this._client.GetList(documentType, filter);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<System.IO.Stream> GetListAsync(string documentType, System.Xml.Linq.XElement filter)
        {
            return this._client.GetListAsync(documentType, filter);
        }
        public System.IO.Stream GetDocument(ItemKey key)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.GetDocument(key);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<System.IO.Stream> GetDocumentAsync(ItemKey key)
        {
            return this._client.GetDocumentAsync(key);
        }
        public void DeleteDocument(ItemKey key)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    this._client.DeleteDocument(key);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task DeleteDocumentAsync(ItemKey key)
        {
            return this._client.DeleteDocumentAsync(key);
        }
        public void ChangeDocumentState(ItemKey key, byte newState, XElement applicationData)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    this._client.ChangeDocumentState(key, newState, applicationData);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task ChangeDocumentStateAsync(ItemKey key, byte newState, XElement applicationData)
        {
            return this._client.ChangeDocumentStateAsync(key, newState, applicationData);
        }
        public System.IO.Stream Save(System.IO.Stream documentData)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.Save(documentData);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<System.IO.Stream> SaveAsync(System.IO.Stream documentData)
        {
            return this._client.SaveAsync(documentData);
        }
        public DocumentNumberInfo GetDocumentNumberInfo(string className, int organizationId, DateTime documentDate)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.GetDocumentNumberInfo(className, organizationId, documentDate);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<DocumentNumberInfo> GetDocumentNumberInfoAsync(string className, int organizationId, DateTime documentDate)
        {
            return this._client.GetDocumentNumberInfoAsync(className, organizationId, documentDate);
        }
        public System.IO.Stream GetDocumentMetadata()
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.GetDocumentMetadata();
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<System.IO.Stream> GetDocumentMetadataAsync()
        {
            return this._client.GetDocumentMetadataAsync();
        }
        public System.IO.Stream GetCurrentEmployee()
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.GetCurrentEmployee();
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<System.IO.Stream> GetCurrentEmployeeAsync()
        {
            using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
            {
                CreateOutgoingMessageHeaders();
                return this._client.GetCurrentEmployeeAsync();
            }
        }
        public void Close()
        {
            RemoteDataServicePool.Instance.Reuse(this._client);
        }
        public Stream ExecuteQuery(Stream stream)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.ExecuteQuery(stream);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<Stream> ExecuteQueryAsync(Stream stream)
        {
            using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
            {
                CreateOutgoingMessageHeaders();
                return this._client.ExecuteQueryAsync(stream);
            }
        }
        public int ExecuteNonQuery(Stream stream)
        {
            try
            {
                using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
                {
                    CreateOutgoingMessageHeaders();
                    return this._client.ExecuteNonQuery(stream);
                }
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<int> ExecuteNonQueryAsync(Stream stream)
        {
            using (OperationContextScope scope = new OperationContextScope(this._client.InnerChannel))
            {
                CreateOutgoingMessageHeaders();
                return this._client.ExecuteNonQueryAsync(stream);
            }
        }
        public string Ping(string message)
        {
            try
            {
                return this._client.Ping(message);
            }
            catch (FaultException<DocumentServiceFault> ex)
            {
                throw ExceptionFromFault(ex);
            }
        }
        public Task<string> PingAsync(string message)
        {
            return this._client.PingAsync(message);
        }
    }
}
