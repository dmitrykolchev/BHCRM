using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class AccountEventFilter : Filter
    {
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<int> ServiceRequestId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)AccountEventState.Planned, (byte)AccountEventState.Completed };
            if (dataContext is Employee)
                this.EmployeeId = ((Employee)dataContext).Id;
            else if (dataContext is Account)
                this.AccountId = ((Account)dataContext).Id;
            else if (dataContext is AccountView)
                this.AccountId = ((AccountView)dataContext).Id;
            else if (dataContext is Contact)
                this.ContactId = ((Contact)dataContext).Id;
            else if (dataContext is Venue)
                this.AccountId = ((Venue)dataContext).Id;
            else if (dataContext is ServiceRequest)
                this.ServiceRequestId = ((ServiceRequest)dataContext).Id;
        }
    }
}
