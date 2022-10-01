using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BudgetFilter
    {
        public Nullable<int> ServiceRequestId { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> TradeMarkId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)BudgetState.ActualApproved, (byte)BudgetState.PlannedApproved, (byte)BudgetState.StandardApproved };
            if (dataContext is ServiceRequest)
                this.ServiceRequestId = ((ServiceRequest)dataContext).Id;
        }
    }
}
