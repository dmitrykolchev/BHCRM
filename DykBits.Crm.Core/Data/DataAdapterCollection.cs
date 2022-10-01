using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DataAdapterCollection
    {
        private Dictionary<Type, Type> _items = new Dictionary<Type, Type>();

        internal DataAdapterCollection()
        {
        }

        public void Add(Type itemType, Type dataAdapterType)
        {
            if (itemType == null)
                throw new ArgumentNullException("itemType");
            if (dataAdapterType == null)
                throw new ArgumentNullException("dataAdapter");
            this._items.Add(itemType, dataAdapterType);
        }

        public Type this[Type itemType]
        {
            get
            {
                if (itemType == null)
                    throw new ArgumentNullException("itemType");
                return this._items[itemType];
            }
        }
    }
}
