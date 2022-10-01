using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CashFlowItemFactory: FinanceReportItemFactory<CashFlowItem>
    {
        public CashFlowItemFactory()
        {
        }
    }
    public class CashFlowItem: FinanceReportItem
    {
        public CashFlowItem()
        {
        }
        public CashFlowItem Parent
        {
            get
            {
                return (CashFlowItem)base.ParentInternal;
            }
        }
        public Nullable<decimal> Value { get; set; }
        public override bool IsEmpty
        {
            get
            {
                return !Value.HasValue;
            }
        }
    }
}
