using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ContactDataAdapterProxy
    {
        protected override Contact CreateItemOverride(object dataContext)
        {
            Contact contact = base.CreateItemOverride(dataContext);
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            contact.AssignedToEmployeeId = employee.Id;
            if (dataContext is Account)
            {
                Account account = (Account)dataContext;
                contact.AccountId = account.Id;
                contact.AssignedToEmployeeId = account.AssignedToEmployeeId;
            }
            else if (dataContext is Venue)
            {
                Venue venue = (Venue)dataContext;
                contact.AccountId = venue.Id;
                contact.AssignedToEmployeeId = venue.AssignedToEmployeeId;
            }
            else if (dataContext is Lead)
            {
                Lead lead = (Lead)dataContext;
                contact.FirstName = lead.FirstName;
                contact.MiddleName = lead.MiddleName;
                contact.LastName = lead.LastName;
                contact.BusinessPhone = lead.BusinessPhone;
                contact.OtherPhone = lead.OtherPhone;
                contact.Email = lead.Email;
                contact.OtherEmail = lead.OtherEmail;
                contact.HomePhone = lead.HomePhone;
                contact.PrimaryAddressCity = lead.PrimaryAddressCity;
                contact.PrimaryAddressCountry = lead.PrimaryAddressCountry;
                contact.PrimaryAddressPostalCode = lead.PrimaryAddressPostalCode;
                contact.PrimaryAddressRegion = lead.PrimaryAddressRegion;
                contact.PrimaryAddressStreet = lead.PrimaryAddressStreet;
                contact.AlternateAddressCity = lead.AlternateAddressCity;
                contact.AlternateAddressCountry = lead.AlternateAddressCountry;
                contact.AlternateAddressPostalCode = lead.AlternateAddressPostalCode;
                contact.AlternateAddressRegion = lead.AlternateAddressRegion;
                contact.AlternateAddressStreet = lead.AlternateAddressStreet;
                contact.LeadSourceId = lead.LeadSourceId;
                contact.AssignedToEmployeeId = lead.AssignedToEmployeeId;
                contact.FileAs = string.Join(" ", contact.LastName, contact.FirstName, contact.MiddleName);
                contact.Comments = lead.Comments;
            }
            return contact;
        }

        protected override void OnValidate(Contact item)
        {
            base.OnValidate(item);
            string fileAs = GetSuggestedName(item.LastName, item.FirstName, item.MiddleName);
            var documentManager = ServiceManager.GetService<DocumentManager>();
            var dataAdapter = DocumentManager.CreateDataAdapterProxy<Account>();
            var filter = dataAdapter.CreateFilter(null, null);
            filter.Id = item.AccountId;
            var account = dataAdapter.Browse(filter.ToXml()).OfType<AccountView>().SingleOrDefault();
            if (account != null)
                fileAs += " (" + account.FileAs + ")";
            item.FileAs = fileAs;
        }

        private static string GetSuggestedName(string lastName, string firstName, string middleName)
        {
            List<string> names = new List<string>();
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    names.Add(string.Format("{0}, {1}", lastName, firstName));
                    if (!string.IsNullOrWhiteSpace(middleName))
                        names.Add(string.Format("{0}, {1} {2}", lastName, firstName, middleName));
                }
                else
                    names.Add(lastName);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(middleName))
                    names.Add(string.Format("{0} {1}", firstName, middleName));
                else if (!string.IsNullOrWhiteSpace(firstName))
                    names.Add(string.Format("{0}", firstName));
            }
            if (names.Count > 0)
                return names[0];
            return string.Empty;
        }

    }
}
