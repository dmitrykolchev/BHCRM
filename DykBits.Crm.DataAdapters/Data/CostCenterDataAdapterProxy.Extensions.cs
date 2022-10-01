using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class CostCenterDataAdapterProxy
    {
        protected override CostCenter CreateItemOverride(object dataContext)
        {
            CostCenter document = base.CreateItemOverride(dataContext);
            if (dataContext is Account)
            {
                document.AccountId = ((Account)dataContext).Id;
            }
            else if (dataContext is Organization)
            {
                document.AccountId = ((Organization)dataContext).Id;
            }
            return document;
        }
    }
}
