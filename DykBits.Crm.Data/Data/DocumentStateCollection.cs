using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DocumentStateCollection: Collection<DocumentState>
    {
        private DocumentMetadata _owner;
        private Dictionary<string, DocumentState> _fromName = new Dictionary<string, DocumentState>();
        private Dictionary<byte, DocumentState> _fromId = new Dictionary<byte, DocumentState>();

        internal DocumentStateCollection(DocumentMetadata owner)
        {
            this._owner = owner;
        }

        protected override void ClearItems()
        {
            throw new NotSupportedException();
        }

        protected override void InsertItem(int index, DocumentState item)
        {
            base.InsertItem(index, item);
            this._fromName.Add(item.Name, item);
            this._fromId.Add(item.State, item);
            item.Document = this._owner;
        }

        protected override void RemoveItem(int index)
        {
            throw new NotSupportedException();
        }

        protected override void SetItem(int index, DocumentState item)
        {
            throw new NotSupportedException();
        }

        public DocumentState this[string name]
        {
            get { return this._fromName[name]; }
        }

        public DocumentState GetById(byte state)
        {
            return this._fromId[state];
        }
    }
}
