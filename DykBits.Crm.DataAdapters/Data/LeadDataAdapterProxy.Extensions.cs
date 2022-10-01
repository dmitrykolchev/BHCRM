using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class LeadDataAdapterProxy
    {
        protected override Lead CreateItemOverride(object dataContext)
        {
            Lead lead = base.CreateItemOverride(dataContext);

            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            lead.AssignedToEmployeeId = employee.Id;
            return lead;
        }
    }
}
