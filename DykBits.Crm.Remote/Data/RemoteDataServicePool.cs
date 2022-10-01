using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Crm.DocumentServices;

namespace DykBits.Crm.Data
{
    sealed class RemoteDataServicePool
    {
        public static readonly RemoteDataServicePool Instance = new RemoteDataServicePool();
        private class ConnectionEntry
        {
            public DykBits.Crm.DocumentServices.DocumentServiceClient Client;
            public DateTime ReturnTime;
        }

        private Stack<ConnectionEntry> _entries = new Stack<ConnectionEntry>();
        private RemoteDataServicePool()
        {
        }

        public DykBits.Crm.DocumentServices.DocumentServiceClient GetClient()
        {
            if (_entries.Count > 0)
            {
                DocumentServices.DocumentServiceClient client = _entries.Pop().Client;
                return client;
            }
            return CreateNewInstance();
        }

        public void Reuse(DocumentServices.DocumentServiceClient client)
        {
            if (this._entries.Count > 10)
            {
                var entry = this._entries.Pop();
                CloseClient(entry.Client);
            }
            this._entries.Push(new ConnectionEntry { Client = client, ReturnTime = DateTime.Now });
        }

        private void CloseClient(DocumentServices.DocumentServiceClient client)
        {
            try
            {
                if (client != null)
                {
                    if (client.State == System.ServiceModel.CommunicationState.Faulted)
                        client.Abort();
                    else
                        client.Close();
                }
            }
            catch { }
        }
        private DocumentServiceClient CreateNewInstance()
        {
            RemoteConnectionManager connectionManager = (RemoteConnectionManager)ServiceManager.GetService<IConnectionManager>();
            return connectionManager.CreateConnection();
            //var client = new DocumentServices.DocumentServiceClient();
            //client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            //client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            //client.Open();
            //return client;
        }
    }
}
