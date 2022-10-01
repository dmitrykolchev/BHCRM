using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class BudgetDataAdapterProxy
    {
        protected override Budget CreateItemOverride(object dataContext)
        {
            Budget document = base.CreateItemOverride(dataContext);
            if (dataContext is ServiceRequest)
            {
                document.ServiceRequestId = ((ServiceRequest)dataContext).Id;
                document.OrganizationId = ((ServiceRequest)dataContext).OrganizationId;
                document.AmountOfGuests = ((ServiceRequest)dataContext).AmountOfGuests;
                document.EventDuration = ((ServiceRequest)dataContext).EventDuration;
            }
            return document;
        }

        public void ChangeAmountOfGuests(int budgetId, int newAmountOfGuests)
        {
            DocumentManager.ExecuteNonQuery(new BudgetAmountOfGuests { BudgetId = budgetId, AmountOfGuests = newAmountOfGuests });
        }
    }
}
