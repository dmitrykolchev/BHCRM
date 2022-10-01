using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DykBits.Crm.Data
{
    [DataContract]
    public class ItemKey: IEquatable<ItemKey>
    {
        public ItemKey()
        {
        }

        public ItemKey(string documentType, int id)
        {
            DocumentType = documentType;
            Id = id;
        }

        [DataMember]
        public string DocumentType { get; set; }
        [DataMember]
        public int Id { get; set; }

        public static ItemKey CreateKey(string documentType, int id)
        {
            return new ItemKey(documentType, id);
        }
        public static ItemKey CreateKey(int documentTypeId, int id)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            DocumentMetadata metadata = documentManager.Documents.GetById(documentTypeId);
            return CreateKey(metadata.ClassName, id);
        }
        public static ItemKey CreateKey(Type documentType, int id)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            DocumentMetadata metadata = documentManager.Documents[documentType];
            return CreateKey(metadata.ClassName, id);
        }

        public static ItemKey CreateKey<T>(int id)
        {
            return CreateKey(typeof(T), id);
        }

        public override int GetHashCode()
        {
            return DocumentType.GetHashCode() ^ Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is ItemKey)
                return Equals((ItemKey)obj);
            return false;
        }

        public bool Equals(ItemKey other)
        {
            if (other != null)
                return this.DocumentType == other.DocumentType && this.Id == other.Id;
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", DocumentType, Id);
        }

    }
}
