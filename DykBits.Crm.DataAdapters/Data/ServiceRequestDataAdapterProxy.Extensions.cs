using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Transactions;
using System.IO;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class ServiceRequestDataAdapterProxy
    {
        protected override void OnValidate(ServiceRequest item)
        {
            base.OnValidate(item);
            switch (item.CustomerSelector)
            {
                case 0:
                    item.AccountId = item.CustomerId.Value;
                    break;
                case 1:
                    item.AccountId = item.AgentId.Value;
                    break;
                case 2:
                    item.AccountId = item.VenueProviderId.Value;
                    break;
            }
            if (!item.AmountOfGuests.HasValue)
                throw new DataValidationException("Необходимо указать кол-во гостей");
            if (!item.Value.HasValue)
                throw new DataValidationException("Необходимо указать бюджет");
        }
        protected override ServiceRequest CreateItemOverride(object dataContext)
        {
            ServiceRequest document = base.CreateItemOverride(dataContext);
            document.EventMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            document.EventDate = null;
            Employee currentEmployee = (Employee)SecurityManager.GetCurrentEmployee();
            if(currentEmployee != null)
                document.TradeMarkId = currentEmployee.TradeMarkId;
            document.ServiceLevelId = ServiceLevel.Standard;
            document.AmountOfGuests = 0;
            document.ValuePerGuest = 0;
            document.Value = 0;
            if (dataContext is Account)
            {
                document.AccountId = ((Account)dataContext).Id;
                document.CustomerId = ((Account)dataContext).Id;
            }
            return document;
        }
        public void ProjectMemberChange(ProjectMemberChangeData data)
        {
            IDatabaseContext db = ServiceManager.GetService<IDatabaseContext>();
            using (Stream stream = DocumentSerializer.Serialize(data, typeof(ItemId)))
            {
                db.ExecuteNonQuery(stream);
            }
        }
    }
}
