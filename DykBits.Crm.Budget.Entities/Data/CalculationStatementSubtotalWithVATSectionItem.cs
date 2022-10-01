using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    internal class CalculationStatementSubtotalWithVATSectionItem : CalculationStatementSectionItem
    {
        public CalculationStatementSubtotalWithVATSectionItem(CalculationStatement parent)
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
            var vatRate = ListManager.GetItem<VATRateView>(Parent.VATRateId);
            decimal value = Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalPrice);
            return value * (1 - Parent.Discount) * (1 + vatRate.Value);
        }
        protected override decimal CalculateTotalDuration()
        {
            return Parent.Items.OfType<CalculationStatementLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalDuration.GetValueOrDefault(0));
        }
        public override decimal? PricePerGuest
        {
            get
            {
                var vatRate = ListManager.GetItem<VATRateView>(Parent.VATRateId);
                return Parent.SubtotalWithDiscountSectionItem.PricePerGuest.GetValueOrDefault() * (1 + vatRate.Value);
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
                return Int32.MaxValue - 98;
            }
        }
        public override string FileAs
        {
            get
            {
                return "Итого с НДС";
            }
            set
            {
            }
        }
    }
}
