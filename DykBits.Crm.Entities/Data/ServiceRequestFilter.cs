using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ServiceRequestFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> TradeMarkId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> VenueProviderId { get; set; }
        public Nullable<int> ProjectMemberId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public Nullable<int> ProjectId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { 
                (byte)ServiceRequestState.Canceled,
                (byte)ServiceRequestState.Closed, 
                (byte)ServiceRequestState.InProgress,
                (byte)ServiceRequestState.Completed, 
                (byte)ServiceRequestState.Lost,
                (byte)ServiceRequestState.Prospecting, 
                (byte)ServiceRequestState.Qualification, 
                (byte)ServiceRequestState.Won
            };
            this.PeriodStart = DateTime.MinValue;
            this.PeriodEnd = DateTime.MaxValue;
            if (dataContext is Account)
            {
                this.AccountId = ((Account)dataContext).Id;
            }
            else if (dataContext is Venue)
            {
                this.VenueProviderId = ((Venue)dataContext).Id;
            }
        }
    }
}
