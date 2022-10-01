using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class PurchaseInvoiceFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> BudgetId { get; set; }
        public Nullable<int> OperatingBudgetId { get; set; }
        public Nullable<bool> IsCash { get; set; }
        public Nullable<int> ServiceRequestId { get; set; }
        public Nullable<int> ResponsibleEmployeeId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public bool BudgetItemGroupIdIsSet { get; set; }
        public Nullable<int> BudgetItemGroupId { get; set; }
        public bool BudgetItemIdIsSet { get; set; }
        public Nullable<int> BudgetItemId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)PurchaseInvoiceState.Draft, (byte)PurchaseInvoiceState.Payed, (byte)PurchaseInvoiceState.Approved };
            if (dataContext is Budget)
            {
                BudgetId = ((Budget)dataContext).Id;
            }
            else if (dataContext is OperatingBudget)
            {
                OperatingBudgetId = ((OperatingBudget)dataContext).Id;
            }
            else if (dataContext is ServiceRequest)
            {
                ServiceRequestId = ((ServiceRequest)dataContext).Id;
            }
            else if (dataContext is Organization)
            {
                OrganizationId = ((Organization)dataContext).Id;
            }
            else if (dataContext is Account)
            {
                AccountId = ((Account)dataContext).Id;
            }
        }
    }
}
