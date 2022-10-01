using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public delegate IList<T> GetCollectionItems<T>();
    public class ObservableCollectionWithRefresh<T> : ObservableCollection<T>
    {
        private GetCollectionItems<T> _getCollectionItems;
        public ObservableCollectionWithRefresh(GetCollectionItems<T> getCollectionItems)
            : base(getCollectionItems())
        {
            this._getCollectionItems = getCollectionItems;
        }

        public void Refresh()
        {
            this.Clear();
            IList<T> items = this._getCollectionItems();
            foreach (var item in items)
                this.Add(item);
        }
    }
}
