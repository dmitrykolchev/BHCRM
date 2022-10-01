using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public enum DocumentOperation
    {
        Save,
        Delete,
        ChangeState
    }

    public class DocumentOperationCompleteEventArgs: EventArgs
    {
        private DocumentOperation _operation;
        private IDataItem _data;
        private ItemKey _itemKey;

        public DocumentOperationCompleteEventArgs(DocumentOperation operation, IDataItem data)
        {
            if(data == null)
                throw new ArgumentNullException("data");
            this._operation = operation;
            this._data = data;
            this._itemKey = data.GetKey();
        }

        public DocumentOperationCompleteEventArgs(DocumentOperation operation, ItemKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            this._operation = operation;
            this._itemKey = key;
        }

        public DocumentOperation Operation
        {
            get { return this._operation; }
        }

        public ItemKey Key
        {
            get { return this._itemKey; }
        }

        public IDataItem Data
        {
            get { return this._data; }
        }
    }
}
