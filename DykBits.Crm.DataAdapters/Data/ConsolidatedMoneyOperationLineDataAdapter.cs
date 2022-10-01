using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ConsolidatedMoneyOperationLineDataAdapter : XmlViewDataAdapterBase<ConsolidatedMoneyOperationLine, ConsolidatedBudgetItemFilter>
    {
        public ConsolidatedMoneyOperationLineDataAdapter()
            : base("[dbo].[ConsolidatedMoneyOperationBrowse]")
        {
        }
    }

    public class ConsolidatedMoneyOperationLineDataAdapterProxy : ViewDataAdapterProxy<ConsolidatedMoneyOperationLine, ConsolidatedBudgetItemFilter>
    {
    }
}
