using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateSubtotalSectionItem : CalculationStatementTemplateSectionItem
    {
        public CalculationStatementTemplateSubtotalSectionItem(CalculationStatementTemplate parent)
            : base(new CalculationStatementTemplateSection() { Parent = parent })
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
            return Parent.Items.OfType<CalculationStatementTemplateLineItem>().Where(t => !t.ReadOnly).Sum(t => t.Income);
        }
        protected override decimal CalculateTotalCost()
        {
            return Parent.Items.OfType<CalculationStatementTemplateLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalCost);
        }
        protected override decimal CalculateTotalPrice()
        {
            return Parent.Items.OfType<CalculationStatementTemplateLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalPrice);
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
    }
}
