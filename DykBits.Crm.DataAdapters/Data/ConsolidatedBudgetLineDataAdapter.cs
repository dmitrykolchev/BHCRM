using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ConsolidatedBudgetLineDataAdapter : XmlViewDataAdapterBase<ConsolidatedBudgetLine, ConsolidatedBudgetItemFilter>
    {
        public ConsolidatedBudgetLineDataAdapter()
            : base("[dbo].[ConsolidatedBudgetBrowse]")
        {
        }
    }

    public class ConsolidatedBudgetLineDataAdapterProxy : ViewDataAdapterProxy<ConsolidatedBudgetLine, ConsolidatedBudgetItemFilter>
    {
    }
}
