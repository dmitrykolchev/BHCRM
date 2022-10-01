using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public class PresentationManagerCollection : Collection<PresentationManager>
    {
        private Dictionary<string, PresentationManager> _fromKey = new Dictionary<string, PresentationManager>();

        internal PresentationManagerCollection()
        {
        }

        protected override void InsertItem(int index, PresentationManager item)
        {
            if (!string.IsNullOrEmpty(item.Key))
            {
                this._fromKey[item.Key] = item;
            }
            base.InsertItem(index, item);
        }

        protected override void ClearItems()
        {
            while (this.Count > 0)
                RemoveAt(0);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            this._fromKey.Remove(item.Key);
            base.RemoveItem(index);
        }

        public PresentationManager this[string key]
        {
            get { return this._fromKey[key]; }
        }

        public bool ContainsKey(string key)
        {
            return this._fromKey.ContainsKey(key);
        }
    }
}
