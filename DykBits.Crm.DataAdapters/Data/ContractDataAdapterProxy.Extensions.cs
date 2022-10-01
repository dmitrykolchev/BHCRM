using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ContractDataAdapterProxy
    {
        protected override Contract CreateItemOverride(object dataContext)
        {
            Contract item = base.CreateItemOverride(dataContext);
            if(dataContext is Organization)
                item.OrganizationId = ((Organization)dataContext).Id;
            else if(dataContext is Account)
                item.AccountId = ((Account)dataContext).Id;
            else if (dataContext is Contract)
            {
                Contract parent = (Contract)dataContext;
                item.OrganizationId = parent.OrganizationId;
                item.AccountId = parent.AccountId;
                item.ParentContractId = parent.Id;
            }
            item.ContractDate = DateTime.Today;

            return item;
        }
    }
}
