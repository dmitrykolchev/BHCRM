using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProductCostStatementDataAdapterProxy
    {
        protected override ProductCostStatement CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            document.OrganizationId = employee.OrganizationId;
            document.DocumentDate = DateTime.Today;
            return document;
        }
    }
}
