using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class SalesInvoiceDataAdapterProxy
    {
        protected override SalesInvoice CreateItemOverride(object dataContext)
        {
            SalesInvoice document = base.CreateItemOverride(dataContext);
            document.DueDate = DateTime.Today;
            IEmployeeInfo employeeInfo = SecurityManager.GetCurrentEmployee();
            if(employeeInfo != null)
                document.ResponsibleEmployeeId = employeeInfo.Id;
            if (dataContext is Budget)
            {
                document.BudgetId = ((Budget)dataContext).Id;
                document.OrganizationId = ((Budget)dataContext).OrganizationId;
                var serviceRequest = ListManager.GetItem<ServiceRequestView>(((Budget)dataContext).ServiceRequestId);
                document.AccountId = serviceRequest.AccountId;
                document.BudgetItemGroupId = BudgetItemGroup.Доходы_по_ОВД;
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
