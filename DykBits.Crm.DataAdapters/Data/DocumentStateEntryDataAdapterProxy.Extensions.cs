using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DocumentStateEntryDataAdapterProxy
    {
        protected override DocumentStateEntry CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is DocumentTypeEntry)
            {
                document.DocumentTypeId = ((DocumentTypeEntry)dataContext).Id;
            }
            return document;
        }
    }
}
