using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BudgetView
    {
        public Nullable<decimal> ValuePerGuest
        {
            get
            {
                if (this.AmountOfGuests.HasValue && this.AmountOfGuests.Value > 0)
                    return this.Value / this.AmountOfGuests.Value;
                return null;
            }
        }

        public Nullable<decimal> StandardValueWithVAT
        {
            get
            {
                if(this.StandardValue.HasValue)
                    return this.StandardValue.Value;
                return null;
            }
        }
        public Nullable<decimal> PlannedValueWithVAT
        {
            get
            {
                if (this.PlannedValue.HasValue)
                    return this.PlannedValue.Value;
                return null;
            }
        }
        public Nullable<decimal> ActualValueWithVAT
        {
            get
            {
                if (this.ActualValue.HasValue)
                    return this.ActualValue.Value;
                return null;
            }
        }
    }
}
