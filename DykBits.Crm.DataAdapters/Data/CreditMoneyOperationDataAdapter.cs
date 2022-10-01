using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CreditMoneyOperationDataAdapter : XmlViewDataAdapterBase<CreditMoneyOperation, CreditMoneyOperationFilter>
    {
        public CreditMoneyOperationDataAdapter()
            : base("[dbo].[CreditMoneyOperationBrowse]")
        {
        }
    }

    public class CreditMoneyOperationDataAdapterProxy : ViewDataAdapterProxy<CreditMoneyOperation, CreditMoneyOperationFilter>
    {
    }
}
