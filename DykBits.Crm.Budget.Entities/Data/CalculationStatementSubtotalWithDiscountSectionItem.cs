using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    internal class CalculationStatementSubtotalWithDiscountSectionItem: CalculationStatementSectionItem
    {
        public CalculationStatementSubtotalWithDiscountSectionItem(CalculationStatement parent)
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
            return CalculateTotalPrice() - CalculateTotalCost();
        }
        protected override decimal CalculateTotalCost()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalCost);
        }
        protected override decimal CalculateTotalPrice()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalPrice) * (1 - Parent.Discount);
        }
        protected override decimal CalculateTotalDuration()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalDuration.GetValueOrDefault(0));
        }
        public override decimal? PricePerGuest
        {
            get
            {
                return Parent.SubtotalSectionItem.PricePerGuest.GetValueOrDefault() * (1 - Parent.Discount);
            }
        }
        public override decimal? CostPerGuest
        {
            get
            {
                return Parent.SubtotalSectionItem.CostPerGuest.GetValueOrDefault();
            }
        }
        public override int OrdinalPosition
        {
            get
            {
                return Int32.MaxValue - 99;
            }
        }
        public override string FileAs
        {
            get
            {
                return "Итого со скидкой";
            }
            set
            {
            }
        }
    }
}
