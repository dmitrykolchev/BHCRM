using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ViewMetadataCollection: Collection<ViewMetadata>
    {
        private Dictionary<string, ViewMetadata> _fromName = new Dictionary<string, ViewMetadata>();
        private Dictionary<Type, ViewMetadata> _fromType = new Dictionary<Type, ViewMetadata>();
        private DocumentMetadata _owner;
        internal ViewMetadataCollection(DocumentMetadata owner = null)
        {
            this._owner = owner;
        }
        protected override void ClearItems()
        {
            throw new NotSupportedException();
        }
        public bool ContainsKey(string className)
        {
            return _fromName.ContainsKey(className);
        }
        public bool ContainsKey(Type itemType)
        {
            return _fromType.ContainsKey(itemType);
        }
        protected override void InsertItem(int index, ViewMetadata item)
        {
            this._fromName.Add(item.ViewName, item);
            this._fromType.Add(item.ViewItemType, item);
            if (this._owner != null)
            {
                item.Document = this._owner;
            }
            else
            {
                if (!string.IsNullOrEmpty(item.ClassName))
                {
                    if (!this._fromName.ContainsKey(item.ClassName))
                        this._fromName.Add(item.ClassName, item);
                }
                if (item.Document != null)
                {
                    if (!this._fromType.ContainsKey(item.Document.DocumentType))
                        this._fromType.Add(item.Document.DocumentType, item);
                }
            }
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            throw new NotSupportedException();
        }
        protected override void SetItem(int index, ViewMetadata item)
        {
            throw new NotSupportedException();
        }
        public ViewMetadata this[Type viewType]
        {
            get { return this._fromType[viewType]; }
        }
        public ViewMetadata this[string viewName]
        {
            get { return this._fromName[viewName]; }
        }
    }
}
