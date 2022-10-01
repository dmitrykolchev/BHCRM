using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class InvoiceByContragentItemDataAdapter: XmlViewDataAdapterBase<InvoiceByContragentItem, InvoiceByContragentFilter>
    {
        public InvoiceByContragentItemDataAdapter()
            : base("[reports].[InvoiceByContragentBrowse]")
        {
        }
    }
    public class InvoiceByContragentItemDataAdapterProxy : ViewDataAdapterProxy<InvoiceByContragentItem, InvoiceByContragentFilter>
    {
    }
}
