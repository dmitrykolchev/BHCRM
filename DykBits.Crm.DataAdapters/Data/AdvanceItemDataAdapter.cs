using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class AdvanceItemDataAdapter: XmlViewDataAdapterBase<AdvanceItem, AdvanceItemFilter>
    {
        public AdvanceItemDataAdapter()
            : base("[dbo].[AdvanceBrowse]")
        {
        }
    }
    public class AdvanceItemDataAdapterProxy : ViewDataAdapterProxy<AdvanceItem, AdvanceItemFilter>
    {
    }
}
