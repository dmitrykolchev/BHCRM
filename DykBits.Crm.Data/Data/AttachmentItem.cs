using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using DykBits.Crm.RemoteServices;

namespace DykBits.Crm.Data
{
    public class AttachmentItem : IAttachmentItem
    {
        private abstract class AttachmentDataSource
        {
            protected AttachmentDataSource()
            {
            }
            public abstract string Name { get; }
            public abstract Stream Data { get; }
        }

        private class LocalFileAttachment : AttachmentDataSource
        {

            private string _name;
            private string _filePath;
            private Stream _data;
            private DateTime _lastWriteTime;

            public LocalFileAttachment(string filePath)
            {
                this._name = Path.GetFileName(filePath);
                this._filePath = filePath;
                this._lastWriteTime = File.GetLastWriteTime(filePath);
            }
            public string FilePath
            {
                get { return this._filePath; }
            }
            public DateTime LastWriteTime
            {
                get { return this._lastWriteTime; }
            }

            public bool IsModified
            {
                get
                {
                    return File.GetLastWriteTime(this._filePath) > LastWriteTime;
                }
            }
            public override string Name
            {
                get
                {
                    return this._name;
                }
            }
            public override Stream Data
            {
                get
                {
                    if (this._data == null)
                    {
                        this._data = File.Open(this._filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    }
                    return this._data;
                }
            }
        }

        private class StreamAttachment : AttachmentDataSource
        {
            private string _name;
            private Stream _data;

            public StreamAttachment(string name, Stream data)
            {
                this._name = name;
                this._data = data;
            }

            public override Stream Data
            {
                get
                {
                    return this._data;
                }
            }
            public override string Name
            {
                get
                {
                    return this._name;
                }
            }
        }

        public AttachmentItem()
        {
        }

        private AttachmentDataSource _localDataSource;
        private AttachmentItem(int id, string blobId, string name)
        {
            this.Id = id;
            this.BlobId = blobId;
            this.Name = name;
        }
        private AttachmentItem(string localPath)
        {
            this.Name = Path.GetFileName(localPath);
            this._localDataSource = new LocalFileAttachment(localPath);
        }
        private AttachmentItem(string name, Stream data)
        {
            this.Name = name;
            this._localDataSource = new StreamAttachment(name, data);
        }
        private AttachmentDataSource DataSource
        {
            get { return this._localDataSource; }
        }
        private static AttachmentItem CreateInstance(int id, string blobId, string name)
        {
            return new AttachmentItem(id, blobId, name);
        }
        public static AttachmentItem CreateInstance(string localPath)
        {
            return new AttachmentItem(localPath);
        }
        public static AttachmentItem CreateInstance(string name, Stream stream)
        {
            return new AttachmentItem(name, stream);
        }
        [XmlAttribute]
        public string BlobId
        {
            get;
            set;
        }
        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }
        [XmlAttribute]
        public int Id
        {
            get;
            set;
        }
        public bool IsNew
        {
            get { return this.Id == 0; }
        }
        private static BlobServiceClient CreateBlobServiceConnection()
        {
            var service = ServiceManager.GetService<BlobServiceConnectionManager>();
            return service.CreateConnection();
        }
        public void CreateBlobEntry()
        {
            if (string.IsNullOrEmpty(this.BlobId))
            {
                BlobServiceClient client = CreateBlobServiceConnection();
                try
                {
                    string messageId = client.CreateMessageId();
                    using (Stream stream = this.DataSource.Data)
                    {
                        UploadBlobRequest request = new UploadBlobRequest(messageId, stream);
                        ((IBlobService)client).UploadBlob(request);
                    }
                    this.BlobId = messageId;
                }
                finally
                {
                    if (client.State == System.ServiceModel.CommunicationState.Faulted)
                        client.Abort();
                    else
                        client.Close();
                }
            }
        }
        public void UpdateBlobEntry()
        {
            if (string.IsNullOrEmpty(this.BlobId))
                throw new InvalidOperationException("Cannot update unexistent blob");
            BlobServiceClient client = CreateBlobServiceConnection();
            try
            {
                using (Stream stream = this.DataSource.Data)
                {
                    UploadBlobRequest request = new UploadBlobRequest(this.BlobId, stream);
                    ((IBlobService)client).UploadBlob(request);
                }
            }
            finally
            {
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                    client.Abort();
                else
                    client.Close();
            }
        }
        public void Download(string path)
        {
            BlobServiceClient client = CreateBlobServiceConnection();
            try
            {
                DownloadBlobResponse response = ((IBlobService)client).DownloadBlob(new DownloadBlobRequest { MessageId = this.BlobId, StartPosition = 0, Length = 0 });
                using (response.Data)
                {
                    using (FileStream output = File.Create(path))
                    {
                        response.Data.CopyTo(output);
                    }
                }
            }
            finally
            {
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                    client.Abort();
                else
                    client.Close();
            }
        }
        public void Open()
        {
            string filePath;
            if (this.IsNew)
            {
                LocalFileAttachment attachment = this._localDataSource as LocalFileAttachment;
                filePath = attachment.FilePath;
            }
            else
            {
                filePath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), this.Name);
                Download(filePath);
                this._localDataSource = new LocalFileAttachment(filePath);
            }
            System.Diagnostics.Process.Start(filePath);
        }
        public bool IsModified
        {
            get
            {
                if (!IsNew && this._localDataSource is LocalFileAttachment)
                {
                    LocalFileAttachment localFileAttachment = (LocalFileAttachment)this._localDataSource;
                    return localFileAttachment.IsModified;
                }
                return false;
            }
        }
        internal void Create(IDataItem dataItem)
        {
            if (this.Id != 0)
                throw new InvalidOperationException();
            if (string.IsNullOrEmpty(this.BlobId))
                this.CreateBlobEntry();
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = DataHelper.CreateProcedure("[dbo].[DocumentAttachmentCreate]", connection))
                {
                    command.Parameters["@ClassName"].Value = dataItem.DataItemClass;
                    command.Parameters["@DocumentId"].Value = dataItem.Id;
                    command.Parameters["@BlobId"].Value = this.BlobId;
                    command.Parameters["@BlobName"].Value = this.Name;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException();
                        this.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    }
                }
            }
        }
        internal void Delete()
        {
            if (this.Id == 0 || string.IsNullOrEmpty(this.BlobId))
                throw new InvalidOperationException();
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = DataHelper.CreateProcedure("[dbo].[DocumentAttachmentDelete]", connection))
                {
                    command.Parameters["@Id"].Value = this.Id;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
