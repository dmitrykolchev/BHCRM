using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BankAccountDataAdapterProxy
    {
        protected override BankAccount CreateItemOverride(object dataContext)
        {
            BankAccount item = base.CreateItemOverride(dataContext);
            if (dataContext is Account)
            {
                item.AccountId = ((Account)dataContext).Id;
            }
            else if (dataContext is Venue)
            {
                item.AccountId = ((Venue)dataContext).Id;
            }
            else if (dataContext is Organization)
            {
                item.AccountId = ((Organization)dataContext).Id;
            }
            return item;
        }
    }
}
