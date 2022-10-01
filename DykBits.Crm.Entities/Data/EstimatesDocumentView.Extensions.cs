using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class EstimatesDocumentView
    {
        public Nullable<decimal> Profitability
        {
            get
            {
                if (this.TotalPrice.HasValue && this.Income.HasValue && this.TotalPrice.Value != 0)
                {
                    return this.Income.GetValueOrDefault() / this.TotalPrice.GetValueOrDefault();
                }
                return null;
            }
        }
    }
}
