using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ConsolidatedAccrualLineDataAdapter : XmlViewDataAdapterBase<ConsolidatedAccrualLine, ConsolidatedBudgetItemFilter>
    {
        public ConsolidatedAccrualLineDataAdapter()
            : base("[dbo].[AccrualBrowse]")
        {
        }
    }

    public class ConsolidatedAccrualLineDataAdapterProxy : ViewDataAdapterProxy<ConsolidatedAccrualLine, ConsolidatedBudgetItemFilter>
    {
    }
}
