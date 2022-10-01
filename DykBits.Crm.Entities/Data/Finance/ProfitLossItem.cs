using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ProfitLossItemFactory: FinanceReportItemFactory<ProfitLossItem>
    {
        public ProfitLossItemFactory()
        {
        }
    }
    public class ProfitLossItem: FinanceReportItem
    {
        public ProfitLossItem()
        {
        }
        public ProfitLossItem Parent
        {
            get
            {
                return (ProfitLossItem) base.ParentInternal;
            }
        }
        public Nullable<decimal> StandardValue { get; set; }
        public Nullable<decimal> PlannedValue { get; set; }
        public Nullable<decimal> ActualValue { get; set; }
        public Nullable<decimal> AccrualValue { get; set; }
        public override bool IsEmpty
        {
            get
            {
                return !StandardValue.HasValue && !PlannedValue.HasValue && !ActualValue.HasValue && !AccrualValue.HasValue;
            }
        }
    }
}
