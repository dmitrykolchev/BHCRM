using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public class PresentationNodeCollection: Collection<PresentationNode>
    {
        private PresentationNode _owner;

        internal PresentationNodeCollection(PresentationNode owner)
        {
            this._owner = owner;
        }

        protected override void InsertItem(int index, PresentationNode item)
        {
            if(item == null)
                throw new ArgumentNullException("item");
            if (item.Parent != null)
                throw new ArgumentException("item already owned");

            base.InsertItem(index, item);
            item.Parent = this._owner;
        }

        protected override void RemoveItem(int index)
        {
            PresentationNode item = this[index];
            base.RemoveItem(index);
            item.Parent = null;
        }

        protected override void ClearItems()
        {
            while (this.Count > 0)
                RemoveAt(0);
        }

        public PresentationNode this[string key]
        {
            get
            {
                foreach(var item in this)
                {
                    if (item.Key == key)
                        return item;
                }
                return null;
            }
        }

        protected override void SetItem(int index, PresentationNode item)
        {
            throw new NotSupportedException();
        }
    }
}
