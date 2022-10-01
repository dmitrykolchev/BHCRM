using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class AccountFilter
    {
        public const string AllAccountsPresentation = "AllAccounts";
        public const string MyAccountsPresentation = "MyAccounts";
        public Nullable<int> AccountTypeId { get; set; }
        public Nullable<int> ExcludedAccountTypeId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)AccountState.Active };
            this.AccountTypeId = (int)(AccountTypeFlag.Customer | AccountTypeFlag.Supplier | AccountTypeFlag.Venue);
            this.ExcludedAccountTypeId = (int)AccountTypeFlag.Organization;
            if (parameter is string)
                this.Presentation = (string)parameter;
            if ("Customers".Equals(parameter))
                this.AccountTypeId = (int)(AccountTypeFlag.Customer);
            else if ("Suppliers".Equals(parameter))
                this.AccountTypeId = (int)(AccountTypeFlag.Supplier);
        }
    }
}
