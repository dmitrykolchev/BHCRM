using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ConsolidatedInventoryOperationLineDataAdapter : XmlViewDataAdapterBase<ConsolidatedInventoryOperationLine, ConsolidatedInventoryOperationLineFilter>
    {
        public ConsolidatedInventoryOperationLineDataAdapter()
            : base("[dbo].[ConsolidatedInventoryOperationBrowse]")
        {
        }
    }

    public class ConsolidatedInventoryOperationLineDataAdapterProxy : ViewDataAdapterProxy<ConsolidatedInventoryOperationLine, ConsolidatedInventoryOperationLineFilter>
    {
    }
}
