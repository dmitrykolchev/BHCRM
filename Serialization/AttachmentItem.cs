using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization
{
    public class AttachmentItem
    {
        public AttachmentItem()
        {
        }
        private AttachmentItem(int id, string blobId, string name, string localPath = null)
        {
            this.Id = id;
            this.BlobId = blobId;
            this.Name = name;
            this.LocalPath = localPath;
        }

        private static AttachmentItem CreateInstance(int id, string blobId, string name)
        {
            return new AttachmentItem(id, blobId, name);
        }

        public static AttachmentItem CreateInstance(string localPath)
        {
            string name = Path.GetFileName(localPath);
            return new AttachmentItem(0, null, name, localPath);
        }
        public string BlobId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public string LocalPath
        {
            get;
            set;
        }

        public bool IsNew
        {
            get { return this.Id == 0; }
        }

    }
}
