using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class PurchaseInvoiceDataAdapterProxy
    {
        protected override PurchaseInvoice CreateItemOverride(object dataContext)
        {
            PurchaseInvoice document = base.CreateItemOverride(dataContext);
            document.DueDate = DateTime.Today;
            IEmployeeInfo employeeInfo = SecurityManager.GetCurrentEmployee();
            if(employeeInfo != null)
                document.ResponsibleEmployeeId = employeeInfo.Id;
            if (dataContext is Budget)
            {
                document.BudgetId = ((Budget)dataContext).Id;
                document.OrganizationId = ((Budget)dataContext).OrganizationId;
                document.BudgetItemGroupId = BudgetItemGroup.Расходы_по_ОВД;
            }
            else if (dataContext is OperatingBudget)
            {
                document.OperatingBudgetId = ((OperatingBudget)dataContext).Id;
                document.OrganizationId = ((OperatingBudget)dataContext).OrganizationId;
            }
            return document;
        }
    }
}
