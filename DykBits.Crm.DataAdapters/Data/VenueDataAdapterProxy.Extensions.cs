using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class VenueDataAdapterProxy
    {
        protected override Venue CreateItemOverride(object dataContext)
        {
            Venue document = base.CreateItemOverride(dataContext);
            Employee employee = (Employee)SecurityManager.GetCurrentEmployee();
            document.AssignedToEmployeeId = employee.Id;
            document.ManagingOrganizationId = employee.AccountId;
            document.TradeMarkId = employee.TradeMarkId;
            document.AccountTypeId = 0x10;
            document.Summer = true;
            document.Winter = true;
            return document;
        }
    }
}
