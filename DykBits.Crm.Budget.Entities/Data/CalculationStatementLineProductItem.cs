using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementLineProductItem : CalculationStatementLineItem
    {
        public CalculationStatementLineProductItem(CalculationStatementSectionItem sectionItem, CalculationStatementLine line)
            : base(sectionItem, line)
        {
        }
    }
}
