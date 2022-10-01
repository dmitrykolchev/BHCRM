using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class CalculationStatementView
    {
        [XmlIgnore]
        public Nullable<decimal> TotalIncome
        {
            get
            {
                if (TotalPrice.HasValue || TotalCost.HasValue)
                    return TotalPrice.GetValueOrDefault() - TotalCost.GetValueOrDefault();
                return null;
            }
        }
    }
}
