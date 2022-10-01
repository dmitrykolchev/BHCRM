using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class AccountType
    {
        public const int Organization = 1;
        public const int Supplier = 2;
        public const int Customer = 3;
        public const int Employee = 4;
        public const int VenueProvider = 5;

        public const int OrgranizationFlag = 1;
        public const int SupplierFlag = 2;
        public const int CustomerFlag = 4;
        public const int EmployeeFlag = 8;
        public const int VenueProviderFlag = 16;
    }
}
