using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ConsolidatedInventoryOperationLineFilter: Filter
    {
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> StoragePlaceId { get; set; }
    }
}
