using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.UI
{
    public class PresentationExtensionTypeCollection: Collection<PresentationExtensionType>
    {
        private PresentationNode _owner;
        internal PresentationExtensionTypeCollection(PresentationNode owner)
        {
            this._owner = owner;
        }

        protected override void InsertItem(int index, PresentationExtensionType item)
        {
            base.InsertItem(index, item);
            item.Node = this._owner;
        }
    }
}
