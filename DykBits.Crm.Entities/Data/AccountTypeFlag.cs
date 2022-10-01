using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    [Flags]
    public enum AccountTypeFlag: int
    {
        Organization = AccountType.OrgranizationFlag,
        Supplier = AccountType.SupplierFlag,
        Customer = AccountType.CustomerFlag,
        Employee = AccountType.EmployeeFlag,
        Venue = AccountType.VenueProviderFlag
    }
}
