using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class PurchaseOrderFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> StoragePlaceId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { 
                (byte)PurchaseOrderState.Draft, 
                (byte)PurchaseOrderState.Approved
            };
        }
    }
}
