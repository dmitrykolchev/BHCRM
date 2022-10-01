using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    internal class CalculationStatementSubtotalSectionItem: CalculationStatementSectionItem
    {
        public CalculationStatementSubtotalSectionItem(CalculationStatement parent)
            : base(new CalculationStatementSection() { Parent = parent })
        {
        }
        public override bool ReadOnly
        {
            get
            {
                return true;
            }
        }
        protected override decimal CalculateIncome()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.Income);
        }
        protected override decimal CalculateTotalCost()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalCost);
        }
        protected override decimal CalculateTotalPrice()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalPrice);
        }
        protected override decimal CalculateTotalDuration()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalDuration.GetValueOrDefault(0));
        }
        public override int OrdinalPosition
        {
            get
            {
                return Int32.MaxValue - 100;
            }
        }
        public override string FileAs
        {
            get
            {
                return "Итого";
            }
            set
            {
            }
        }
        public override decimal? WeightPerGuest
        {
            get
            {
                var temp = Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly && t.WeightPerGuest.HasValue);
                if (temp.Count() > 0)
                    return temp.Sum(t => t.WeightPerGuest.Value);
                return null;
            }
        }
        public override decimal? PricePerGuest
        {
            get
            {
                var temp = Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly && t.PricePerGuest.HasValue);
                if (temp.Count() > 0)
                    return temp.Sum(t => t.PricePerGuest.Value);
                return null;
            }
        }
        public override decimal? CostPerGuest
        {
            get
            {
                var temp = Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly && t.CostPerGuest.HasValue);
                if (temp.Count() > 0)
                    return temp.Sum(t => t.CostPerGuest.Value);
                return null;
            }
        }
    }
}
