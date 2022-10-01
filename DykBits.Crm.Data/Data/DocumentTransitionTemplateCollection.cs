using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DocumentTransitionTemplateCollection: Collection<DocumentTransitionTemplate>
    {
        private DocumentMetadata _owner;
        internal DocumentTransitionTemplateCollection(DocumentMetadata owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, DocumentTransitionTemplate item)
        {
            base.InsertItem(index, item);
            item.Document = this._owner;
        }
    }
}
