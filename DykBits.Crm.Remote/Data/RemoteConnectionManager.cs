using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Security.Principal;
using System.IdentityModel.Claims;
using System.Security.Cryptography.X509Certificates;
using DykBits.DataService;
using DykBits.Crm.DocumentServices;

namespace DykBits.Crm.Data
{
    public class RemoteConnectionManager : IConnectionManager
    {
        private RemoteConnectionStringBuilder _connectionStringBuilder = new RemoteConnectionStringBuilder();
        private string _connectionString;
        private string _identity;

        public RemoteConnectionManager()
        {
        }
        public RemoteConnectionManager(string connectionString, string identity)
        {
            this.ConnectionString = connectionString;
            this._identity = identity;
        }

        public bool IntegratedSecurity
        {
            get { return this._connectionStringBuilder.IntegratedSecurity; }
        }

        public string ConnectionString
        {
            get { return this._connectionString ?? string.Empty; }
            set
            {
                this._connectionString = value;
                this._connectionStringBuilder.ConnectionString = value;
            }
        }

        public bool IsRemote
        {
            get
            {
                return true;
            }
        }

        private Binding _binding;
        private EndpointAddress _endpointAddress;

        private EndpointAddress ServiceEndpointAddress
        {
            get
            {
                if (this._endpointAddress == null)
                    InitializedEndpointAddressAndBinding();
                return this._endpointAddress;
            }
        }

        private Binding ServiceBinding
        {
            get
            {
                if (this._binding == null)
                    InitializedEndpointAddressAndBinding();
                return this._binding;
            }
        }

        private void InitializedEndpointAddressAndBinding()
        {
            NetTcpBinding netTcpBinding = new NetTcpBinding(SecurityMode.TransportWithMessageCredential, false);
            netTcpBinding.MaxReceivedMessageSize = 67108864;
            netTcpBinding.TransferMode = TransferMode.Streamed;
            EndpointIdentity identity = EndpointIdentity.CreateUpnIdentity(this._identity);
            if (this.IntegratedSecurity)
            {
                netTcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
                this._endpointAddress = new EndpointAddress(new Uri(new Uri(_connectionStringBuilder.DataSource), "Windows"), identity);
            }
            else
            {
                netTcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                this._endpointAddress = new EndpointAddress(new Uri(new Uri(_connectionStringBuilder.DataSource), "Basic"), identity);
            }
            BindingElementCollection bec = netTcpBinding.CreateBindingElements();
            SslStreamSecurityBindingElement sbe = bec.Find<SslStreamSecurityBindingElement>();
            sbe.IdentityVerifier = new CustomIdentityVerifier();
            CustomBinding customBinding = new CustomBinding();
            foreach (BindingElement e in bec)
            {
                if (e is MessageEncodingBindingElement)
                    customBinding.Elements.Add(new GZipMessageEncodingBindingElement(new BinaryMessageEncodingBindingElement()));
                else
                    customBinding.Elements.Add(e);
            }
            this._binding = customBinding;
        }

        public DocumentServiceClient CreateConnection()
        {
            DocumentServiceClient client = new DocumentServiceClient(ServiceBinding, ServiceEndpointAddress);
            if (!this.IntegratedSecurity)
            {
                client.ClientCredentials.UserName.UserName = this._connectionStringBuilder.UserID;
                client.ClientCredentials.UserName.Password = this._connectionStringBuilder.Password;
            }
            client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            
            client.WorkstationId = this._connectionStringBuilder.WorkstationID;
            client.ApplicationName = this._connectionStringBuilder.ApplicationName;
            client.CurrentLanguage = this._connectionStringBuilder.CurrentLanguage;
            client.Open();
            return client;
        }
    }
}
