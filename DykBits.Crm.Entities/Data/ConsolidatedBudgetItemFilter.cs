using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ConsolidatedBudgetItemFilter: Filter
    {
        [XmlArrayItem("BudgetState")]
        public BudgetState[] BudgetStates { get; set; }
        [XmlArrayItem("ServiceRequestState")]
        public ServiceRequestState[] ServiceRequestStates { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.BudgetStates = new BudgetState[] { BudgetState.PlannedApproved, BudgetState.StandardApproved, BudgetState.ActualApproved };
            this.ServiceRequestStates = new ServiceRequestState[] { ServiceRequestState.Prospecting,
                ServiceRequestState.Qualification,
                ServiceRequestState.Won,
                ServiceRequestState.Lost,
                ServiceRequestState.Canceled,
                ServiceRequestState.Completed,
                ServiceRequestState.Closed,
                ServiceRequestState.InProgress
            };
            this.States = new byte[] { (byte)MoneyOperationState.Draft, (byte)MoneyOperationState.Approved };
        }
    }
}
