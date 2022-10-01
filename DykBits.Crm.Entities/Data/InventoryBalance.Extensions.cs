using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class InventoryBalance : ISelectableDataItem
    {
        public bool Selected { get; set; }

        public decimal AmountInStock
        {
            get
            {
                return this.IncomingAmount.GetValueOrDefault() - this.OutgoingAmount.GetValueOrDefault();
            }
        }

        public Nullable<decimal> Cost
        {
            get
            {
                decimal amount = AmountInStock;
                if (amount != 0)
                    return (this.IncomingTotalCost.GetValueOrDefault() - this.OutgoingTotalCost.GetValueOrDefault()) / AmountInStock;
                return null;
            }
        }

    }
}
