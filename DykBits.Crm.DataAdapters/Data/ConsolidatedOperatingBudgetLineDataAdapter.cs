using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ConsolidatedOperatingBudgetLineDataAdapter : XmlViewDataAdapterBase<ConsolidatedOperatingBudgetLine, ConsolidatedBudgetItemFilter>
    {
        public ConsolidatedOperatingBudgetLineDataAdapter()
            : base("[dbo].[ConsolidatedOperatingBudgetBrowse]")
        {
        }
    }

    public class ConsolidatedOperatingBudgetLineDataAdapterProxy : ViewDataAdapterProxy<ConsolidatedOperatingBudgetLine, ConsolidatedBudgetItemFilter>
    {
    }
}
