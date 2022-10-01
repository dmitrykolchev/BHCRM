using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class InvoiceByBudgetItemItemDataAdapter: XmlViewDataAdapterBase<InvoiceByBudgetItemItem, InvoiceByBudgetItemFilter>
    {
        public InvoiceByBudgetItemItemDataAdapter()
            : base("[reports].[InvoiceByBudgetItemBrowse]")
        {
        }
    }
    public class InvoiceByBudgetItemItemDataAdapterProxy : ViewDataAdapterProxy<InvoiceByBudgetItemItem, InvoiceByBudgetItemFilter>
    {
    }
}
