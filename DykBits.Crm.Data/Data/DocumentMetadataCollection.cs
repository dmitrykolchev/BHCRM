using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DocumentMetadataCollection : Collection<DocumentMetadata>
    {
        private Dictionary<string, DocumentMetadata> _fromClassName = new Dictionary<string, DocumentMetadata>();
        private Dictionary<int, DocumentMetadata> _fromId = new Dictionary<int, DocumentMetadata>();
        private Dictionary<Type, DocumentMetadata> _fromType = new Dictionary<Type, DocumentMetadata>();

        internal DocumentMetadataCollection()
        {
        }
        protected override void ClearItems()
        {
            throw new NotSupportedException();
        }
        protected override void InsertItem(int index, DocumentMetadata item)
        {
            this._fromClassName.Add(item.ClassName, item);
            this._fromId.Add(item.Id, item);
            this._fromType.Add(item.ViewItemType, item);
            if (!this._fromType.ContainsKey(item.DocumentType))
                this._fromType.Add(item.DocumentType, item);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            DocumentMetadata metadata = this[index];
            this._fromClassName.Remove(metadata.ClassName);
            this._fromType.Remove(metadata.ViewItemType);
            this._fromType.Remove(metadata.DocumentType);
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, DocumentMetadata item)
        {
            throw new NotSupportedException();
        }
        public DocumentMetadata this[Type documentType]
        {
            get { return this._fromType[documentType]; }
        }
        public DocumentMetadata FromName(string className)
        {
            DocumentMetadata metadata;
            if (this._fromClassName.TryGetValue(className, out metadata))
                return metadata;
            return null;
        }
        public DocumentMetadata this[string className]
        {
            get { return this._fromClassName[className]; }
        }
        public DocumentMetadata GetById(int id)
        {
            DocumentMetadata metadata;
            if (this._fromId.TryGetValue(id, out metadata))
                return metadata;
            return null;
        }
    }
}
