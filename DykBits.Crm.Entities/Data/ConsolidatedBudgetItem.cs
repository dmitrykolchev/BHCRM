using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ConsolidatedBudgetItem
    {
        private static int ItemId = 0;
        private Nullable<int> _level;
        public ConsolidatedBudgetItem()
        {
            Id = System.Threading.Interlocked.Increment(ref ItemId);
        }
        public int Id { get; private set; }
        public ConsolidatedBudgetItem Parent
        {
            get; set;
        }
        public int ParentId { get { return Parent == null ? 0 : Parent.Id; } }
        public int Level
        {
            get
            {
                if (_level.HasValue)
                    return _level.Value;
                if (Parent != null)
                    return Parent.Level + 1;
                return 0;
            }
            set
            {
                _level = value;
            }
        }
        public string FileAs { get; set; }
        public object Tag { get; set; }
        public Nullable<decimal> StandardValue { get; set; }
        public Nullable<decimal> PlannedValue { get; set; }
        public Nullable<decimal> ActualValue { get; set; }
        public Nullable<decimal> AccrualValue { get; set; }
        public Nullable<decimal> PaymentValue { get; set; }
        public Nullable<decimal> BalanceValue
        {
            get; set;
        }
    }
}
