using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateLineItem: CalculationStatementTemplateItem
    {
        private CalculationStatementTemplateLine _line;
        private CalculationStatementTemplateSectionItem _sectionItem;
        public CalculationStatementTemplateLineItem(CalculationStatementTemplateSectionItem sectionItem, CalculationStatementTemplateLine line)
        {
            this._line = line;
            this._line.CalculationStatementTemplateSectionId = sectionItem.Section.CalculationStatementTemplateSectionId;
            this._sectionItem = sectionItem;
        }
        public override bool CanMoveDown
        {
            get
            {
                var item = SectionItem.GetChildren().LastOrDefault();
                if (item == null)
                    return false;
                return this.OrdinalPosition < item.OrdinalPosition;
            }
        }
        public override bool CanMoveUp
        {
            get
            {
                var item = SectionItem.GetChildren().FirstOrDefault();
                if (item == null)
                    return false;
                return this.OrdinalPosition > item.OrdinalPosition;
            }
        }
        public CalculationStatementTemplateLine Line
        {
            get { return this._line; }
        }
        public override int ParentId
        {
            get { return this._sectionItem.Id; }
        }
        public override int Level
        {
            get { return 1; }
        }
        public override CalculationStatementTemplateSectionItem SectionItem
        {
            get { return this._sectionItem; }
            protected set
            {
                this._sectionItem = value;
            }
        }
        public override CalculationStatementTemplate Parent
        {
            get { return this._line.Parent; }
        }
        public override int? ProductCategoryId
        {
            get
            {
                return this.SectionItem.ProductCategoryId;
            }
        }
        public override int OrdinalPosition
        {
            get { return this._line.OrdinalPosition; }
        }
        public override int? ProductId
        {
            get
            {
                return this._line.ProductId;
            }
            set
            {
                this._line.ProductId = value;
                InvokePropertyChanged();
            }
        }
        public override string FileAs
        {
            get
            {
                return this._line.FileAs;
            }
            set
            {
                this._line.FileAs = value;
                InvokePropertyChanged();
            }
        }
        public override string Comments
        {
            get
            {
                return this._line.Comments;
            }
            set
            {
                this._line.Comments = value;
                InvokePropertyChanged();
            }
        }
        public override decimal? Duration
        {
            get
            {
                return this._line.Duration;
            }
            set
            {
                this._line.Duration = value.GetValueOrDefault();
                InvokePropertyChanged();
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(IncomeProperty);
            }
        }
        public override decimal? Amount
        {
            get
            {
                return this._line.Amount;
            }
            set
            {
                this._line.Amount = value.GetValueOrDefault();
                InvokePropertyChanged();
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(IncomeProperty);
            }
        }
        public override Nullable<bool> DependsOnEventDuration
        {
            get
            {
                return this._line.DependsOnEventDuration;
            }
            set
            {
                this._line.DependsOnEventDuration = value.GetValueOrDefault();
                InvokePropertyChanged();
            }
        }
        public override Nullable<bool> DependsOnAmountOfPersons
        {
            get
            {
                return this._line.DependsOnAmountOfPersons;
            }
            set
            {
                this._line.DependsOnAmountOfPersons = value.GetValueOrDefault();
                InvokePropertyChanged();
            }
        }
        public override decimal? Price
        {
            get
            {
                return this._line.Price;
            }
            set
            {
                this._line.Price = value.GetValueOrDefault();
                InvokePropertyChanged();
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(IncomeProperty);
            }
        }
        public override decimal? Cost
        {
            get
            {
                return this._line.Cost;
            }
            set
            {
                this._line.Cost = value.GetValueOrDefault();
                InvokePropertyChanged();
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(IncomeProperty);
            }
        }
        public override decimal TotalCost
        {
            get { return this._line.Amount * this._line.Duration * this._line.Cost; }
        }
        public override decimal TotalPrice
        {
            get { return this._line.Amount * this._line.Duration * this._line.Price; }
        }
        public override decimal Income
        {
            get { return TotalPrice - TotalCost; }
        }

        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TotalCostProperty || e.PropertyName == TotalPriceProperty || e.PropertyName == IncomeProperty || e.PropertyName == AmountProperty ||
                e.PropertyName == CostProperty || e.PropertyName == PriceProperty || e.PropertyName == DependsOnAmountOfPersonsProperty || e.PropertyName == DependsOnEventDurationProperty)
                this.SectionItem.InvokeSectionChanged(e.PropertyName);
            base.OnPropertyChanged(e);
        }
    }
}
