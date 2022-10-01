using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DocumentRecordCollection: KeyedCollection<int, IDataItem>
    {
        public DocumentRecordCollection()
        {
        }

        public DocumentRecordCollection(IEnumerable<IDataItem> items)
        {
            AddRange(items);
        }

        internal DocumentRecordCollection(IEnumerable items)
        {
            foreach (IDataItem item in items)
                Add(item);
        }

        protected override int GetKeyForItem(IDataItem item)
        {
            return item.Id;
        }

        public void AddRange(IEnumerable<IDataItem> items)
        {
            foreach (var item in items)
                Add(item);
        }
    }
}
