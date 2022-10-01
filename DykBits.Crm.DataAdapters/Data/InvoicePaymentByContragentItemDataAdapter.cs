using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class InvoicePaymentByContragentItemDataAdapter: XmlViewDataAdapterBase<InvoicePaymentByContragentItem, InvoicePaymentByContragentFilter>
    {
        public InvoicePaymentByContragentItemDataAdapter()
            : base("[reports].[InvoicePaymentByContragentBrowse]")
        {
        }
    }
    public class InvoicePaymentByContragentItemDataAdapterProxy : ViewDataAdapterProxy<InvoicePaymentByContragentItem, InvoicePaymentByContragentFilter>
    {
    }
}
