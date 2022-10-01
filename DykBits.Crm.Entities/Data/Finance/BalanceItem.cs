using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class BalanceItemFactory: FinanceReportItemFactory<BalanceItem>
    {
        public BalanceItemFactory()
        {
        }
    }
    public class BalanceItem: FinanceReportItem
    {
        public BalanceItem()
        {
        }
        public BalanceItem Parent
        {
            get
            {
                return (BalanceItem)base.ParentInternal;
            }
        }

        public Nullable<decimal> AssetValue { get; set; }
        public Nullable<decimal> LiabilityValue { get; set; }
        public override bool IsEmpty
        {
            get
            {
                return !AssetValue.HasValue && !LiabilityValue.HasValue;
            }
        }
    }
}
