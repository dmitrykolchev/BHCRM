using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DocumentTypeEntryDataAdapterProxy
    {
        protected override DocumentTypeEntry CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            document.SchemaName = "dbo";
            document.DataAdapterMode = "XmlReader";
            return document;
        }
    }
}
