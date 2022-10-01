using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class BalanceSheetLineDataAdapter : XmlViewDataAdapterBase<BalanceSheetLine, BalanceSheetFilter>
    {
        public BalanceSheetLineDataAdapter()
            : base("[dbo].[BalanceSheetBrowse]")
        {
        }
    }

    public class BalanceSheetLineDataAdapterProxy : ViewDataAdapterProxy<BalanceSheetLine, BalanceSheetFilter>
    {
    }
}
