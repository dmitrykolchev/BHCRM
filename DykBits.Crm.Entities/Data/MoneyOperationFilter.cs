using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class MoneyOperationFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> BudgetId { get; set; }
        public Nullable<int> OperatingBudgetId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> MoneyOperationTypeId { get; set; }
        public Nullable<int> MoneyOperationDirection { get; set; }
        public bool IncludeChildren { get; set; }
        public Nullable<int> PurchaseInvoiceId { get; set; }
        public Nullable<int> SalesInvoiceId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)MoneyOperationState.Draft, (byte)MoneyOperationState.Approved };
            this.IncludeChildren = true;
            if (dataContext is OperatingBudget)
                this.OperatingBudgetId = ((OperatingBudget)dataContext).Id;
            else if (dataContext is Budget)
                this.BudgetId = ((Budget)dataContext).Id;
            else if (dataContext is Organization)
                this.OrganizationId = ((Organization)dataContext).Id;
            else if (dataContext is Account)
                this.AccountId = ((Account)dataContext).Id;
            else if (dataContext is SalesInvoice)
                this.SalesInvoiceId = ((SalesInvoice)dataContext).Id;
            else if (dataContext is PurchaseInvoice)
                this.PurchaseInvoiceId = ((PurchaseInvoice)dataContext).Id;
        }
    }
}
