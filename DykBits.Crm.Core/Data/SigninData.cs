using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class SigninData: NotifyObject
    {
        private RemoteConnectionStringBuilder _connectionStringBuilder;
        private RemoteConnectionStringBuilder _blobConnectionStringBuilder;
        private string _endpointIdentity;
        public SigninData(RemoteConnectionStringBuilder connectionStringBuilder, RemoteConnectionStringBuilder blobConnectionStringBuilder, string endpointIdentity)
        {
            this._connectionStringBuilder = connectionStringBuilder;
            this._blobConnectionStringBuilder = blobConnectionStringBuilder;
            this._endpointIdentity = endpointIdentity;
        }
        public RemoteConnectionStringBuilder ConnectionStringBuilder
        {
            get { return this._connectionStringBuilder; }
        }

        public RemoteConnectionStringBuilder BlobConnectionStringBuilder
        {
            get { return this._blobConnectionStringBuilder; }
        }
        public string EndpointIdentity
        {
            get { return this._endpointIdentity; }
        }
        public string DataSource
        {
            get { return this._connectionStringBuilder.DataSource; }
            set
            {
                this._connectionStringBuilder.DataSource = value;
                InvokePropertyChanged();
            }
        }
        public string BlobDataSource
        {
            get { return this._blobConnectionStringBuilder.DataSource; }
            set
            {
                this._blobConnectionStringBuilder.DataSource = value;
                InvokePropertyChanged();
            }
        }
        public string UserID
        {
            get {
                if (this.IntegratedSecurity)
                    return Environment.UserDomainName + "\\" + Environment.UserName;
                return this._connectionStringBuilder.UserID; 
            }
            set
            {
                this._connectionStringBuilder.UserID = value;
                this._blobConnectionStringBuilder.UserID = value;
                InvokePropertyChanged();
            }
        }
        public string Password
        {
            get { return this._connectionStringBuilder.Password; }
            set
            {
                this._connectionStringBuilder.Password = value;
                this._blobConnectionStringBuilder.Password = value;
                InvokePropertyChanged();
            }
        }
        public bool IntegratedSecurity
        {
            get { return this._connectionStringBuilder.IntegratedSecurity; }
            set
            {
                this._connectionStringBuilder.IntegratedSecurity = value;
                this._blobConnectionStringBuilder.IntegratedSecurity = value;
                InvokePropertyChanged();
                InvokePropertyChanged("UserNamePasswordAuthentication");
                InvokePropertyChanged("AuthorizationMode");
                InvokePropertyChanged("UserID");
            }
        }
        public bool UserNamePasswordAuthentication
        {
            get { return !IntegratedSecurity; }
            set { IntegratedSecurity = !value; }
        }
        public int AuthorizationMode
        {
            get { return this.IntegratedSecurity ? 1 : 0; }
            set { this.IntegratedSecurity = value != 0; }
        }
    }
}
