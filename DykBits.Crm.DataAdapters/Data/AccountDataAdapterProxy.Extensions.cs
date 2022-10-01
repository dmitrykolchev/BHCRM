using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class AccountDataAdapterProxy
    {
        protected override Account CreateItemOverride(object dataContext)
        {
            Account account = base.CreateItemOverride(dataContext);
            if (dataContext is Lead)
            {
                Lead lead = (Lead)dataContext;
                account.FileAs = lead.AccountName;
                account.BillingAddressCity = lead.PrimaryAddressCity;
                account.BillingAddressCountry = lead.PrimaryAddressCountry;
                account.BillingAddressPostalCode = lead.PrimaryAddressPostalCode;
                account.BillingAddressRegion = lead.PrimaryAddressRegion;
                account.BillingAddressStreet = lead.PrimaryAddressStreet;

                account.Phone = lead.BusinessPhone;
                account.AssignedToEmployeeId = lead.AssignedToEmployeeId;
                account.Comments = lead.Comments;
                account.WebSite = lead.WebSite;
            }
            else
            {
                IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
                account.AssignedToEmployeeId = employee.Id;
                account.ManagingOrganizationId = employee.OrganizationId;
                account.AccountTypeId = (int)AccountTypeFlag.Customer;
            }
            return account;
        }
        protected override void OnValidate(Account item)
        {
            base.OnValidate(item);
            if (item.AccountTypeId == 0)
                throw new ArgumentException("Необходимо указать тип отношений c контрагентом");
        }
        public override bool ValidateAccess(ItemKey key)
        {
            ICurrentUser currentUser = SecurityManager.CurrentUser;
            if (currentUser.HasRight(AccessRight.ViewAllAccountDetails))
                return true;
            IEmployeeInfo employeeInfo = SecurityManager.GetCurrentEmployee();
            AccountFilter accountFilter = new AccountFilter
            {
                AllStates = true,
                Id = key.Id
            };
            var account = this.Browse(accountFilter.ToXml()).FirstOrDefault();
            if (account.AssignedToEmployeeId == employeeInfo.Id || account.AssistantEmployeeId == employeeInfo.Id)
                return true;
            DocumentEmployeeAccessRightFilter accessRightFilter = new DocumentEmployeeAccessRightFilter()
            {
                AllStates = true,
                EmployeeId = employeeInfo.Id,
                DocumentId = key.Id,
                DocumentTypeId = DocumentManager.GetMetadata<Account>().Id
            };
            DocumentEmployeeAccessRightDataAdapterProxy accessRightDataAdapter = new DocumentEmployeeAccessRightDataAdapterProxy();
            var accessRights = accessRightDataAdapter.Browse(accessRightFilter.ToXml());
            foreach (var accessRight in accessRights)
            {
                if (accessRight.DocumentAccessTypeId == DocumentAccessType.DocumentAccessTypeTemporary)
                    return DateTime.Today >= accessRight.StartDate.Value && DateTime.Today <= accessRight.EndDate.Value;
                else
                    return DateTime.Today >= accessRight.StartDate.Value;
            }
            return false;
        }

        public void ChangeAccessRights(AccountChangeAccessData data)
        {
            IDatabaseContext db = ServiceManager.GetService<IDatabaseContext>();
            using (Stream stream = DocumentSerializer.Serialize(data, typeof(ItemId)))
            {
                db.ExecuteNonQuery(stream);
            }
        }
    }
}
