using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class AccountEventDataAdapterProxy
    {
        protected override AccountEvent CreateItemOverride(object dataContext)
        {
            AccountEvent document = base.CreateItemOverride(dataContext);
            Employee currentEmployee = (Employee)SecurityManager.GetCurrentEmployee();
            document.EmployeeId = currentEmployee.Id;
            document.EventStart = DateTime.Now;
            document.EventEnd = DateTime.Now;
            document.AccountEventTypeId = AccountEventType.PhoneCall;
            document.AccountEventDirectionId = AccountEventDirection.Outgoing;
            document.Importance = Importance.Normal;
            if (dataContext is Account)
            {
                document.AccountId = ((Account)dataContext).Id;
            }
            else if (dataContext is Contact)
            {
                document.AccountId = ((Contact)dataContext).AccountId;
                document.ContactId = ((Contact)dataContext).Id;
            }
            else if (dataContext is ServiceRequest)
            {
                ServiceRequest serviceRequest = (ServiceRequest)dataContext;
                document.AccountId = serviceRequest.AccountId;
                if(serviceRequest.ResponsibleContactId.HasValue)
                    document.ContactId = serviceRequest.ResponsibleContactId.Value;
                document.ServiceRequestId = ((ServiceRequest)dataContext).Id;
            }
            else if (dataContext is AccountEvent)
            {
                AccountEvent source = (AccountEvent)dataContext;
                document.AccountId = source.AccountId;
                document.ContactId = source.ContactId;
                document.ServiceRequestId = source.ServiceRequestId;
                document.EventStart = source.EventStart.AddDays(14);
                document.EventEnd = source.EventEnd.AddDays(14);
                document.AccountEventTypeId = source.AccountEventTypeId;
            }
            return document;
        }
    }
}
