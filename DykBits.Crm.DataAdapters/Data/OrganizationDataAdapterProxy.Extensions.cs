using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class OrganizationDataAdapterProxy
    {
        protected override Organization CreateItemOverride(object dataContext)
        {
            Organization document = base.CreateItemOverride(dataContext);
            document.AccountTypeId |= (int)(AccountTypeFlag.Organization | AccountTypeFlag.Customer | AccountTypeFlag.Supplier);
            return document;
        }
    }
}
