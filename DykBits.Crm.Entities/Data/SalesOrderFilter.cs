using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class SalesOrderFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> StoragePlaceId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> BudgetId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { 
                (byte)SalesOrderState.Draft, 
                (byte)SalesOrderState.Approved
            };
            if (dataContext is Budget)
            {
                this.BudgetId = ((Budget)dataContext).Id;
            }
        }
    }
}
