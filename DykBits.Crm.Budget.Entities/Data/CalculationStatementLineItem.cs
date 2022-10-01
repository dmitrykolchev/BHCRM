using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public abstract class CalculationStatementLineItem : CalculationStatementItem
    {
        private CalculationStatementLine _line;
        private CalculationStatementSectionItem _sectionItem;
        protected CalculationStatementLineItem(CalculationStatementSectionItem sectionItem, CalculationStatementLine line)
        {
            this._line = line;
            this._line.CalculationStatementSectionId = sectionItem.Section.CalculationStatementSectionId;
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
        public CalculationStatementLine Line
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
        public override CalculationStatementSectionItem SectionItem
        {
            get { return this._sectionItem; }
            protected set
            {
                this._sectionItem = value;
            }
        }
        public override CalculationStatement Parent
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
        public override DateTime? StartTime
        {
            get
            {
                return this._line.StartTime;
            }
            set
            {
                this._line.StartTime = value.GetValueOrDefault();
                InvokePropertyChanged();
                InvokePropertyChanged(EndTimeProperty);
                InvokePropertyChanged(DurationProperty);
                InvokePropertyChanged(TotalDurationProperty);
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(IncomeProperty);
            }
        }
        public override DateTime? EndTime
        {
            get
            {
                return this._line.EndTime;
            }
            set
            {
                this._line.EndTime = value.GetValueOrDefault();
                InvokePropertyChanged();
                InvokePropertyChanged(StartTimeProperty);
                InvokePropertyChanged(DurationProperty);
                InvokePropertyChanged(TotalDurationProperty);
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(IncomeProperty);
            }
        }

        public override decimal? Duration
        {
            get
            {
                return this._line.Duration;
            }
        }
        private decimal DurationInternal
        {
            get
            {
                if (Duration.HasValue)
                    return Duration.Value;
                return 1;
            }
        }
        public override decimal? TotalDuration
        {
            get
            {
                if (Duration.HasValue && Amount.HasValue)
                    return Duration.Value * Amount.Value;
                return null;
            }
        }
        public override Nullable<decimal> AmountPerGuest
        {
            get
            {
                if (!Line.AmountPerGuest.HasValue)
                    return CalculateAmountPerGuest();
                return Line.AmountPerGuest;
            }
            set
            {
                Line.AmountPerGuest = value.GetValueOrDefault();
                OnAmountPerGuestChanged();
                InvokePropertyChanged();
                InvokePropertyChanged(PricePerGuestProperty);
                InvokePropertyChanged(CostPerGuestProperty);
                SectionItem.InvokeSectionChanged();
            }
        }
        protected virtual decimal CalculateAmount()
        {
            return this.Parent.AmountOfGuests.GetValueOrDefault() * this.AmountPerGuest.GetValueOrDefault();
        }
        protected virtual void OnAmountPerGuestChanged()
        {
            this.Line.Amount = CalculateAmount();
            InvokePropertyChanged(AmountProperty);
            InvokePropertyChanged(TotalDurationProperty);
            InvokePropertyChanged(TotalCostProperty);
            InvokePropertyChanged(TotalPriceProperty);
            InvokePropertyChanged(IncomeProperty);
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
                OnAmountChanged();
                InvokePropertyChanged();
                InvokePropertyChanged(TotalDurationProperty);
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(IncomeProperty);
                SectionItem.InvokeSectionChanged();
            }
        }
        protected virtual decimal CalculateAmountPerGuest()
        {
            return this.Amount.GetValueOrDefault() / this.Parent.AmountOfGuests.GetValueOrDefault();
        }
        protected virtual void OnAmountChanged()
        {
            this.Line.AmountPerGuest = CalculateAmountPerGuest();
            InvokePropertyChanged(AmountPerGuestProperty);
            InvokePropertyChanged(PricePerGuestProperty);
            InvokePropertyChanged(CostPerGuestProperty);
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
        public override decimal? StandardAmount
        {
            get { return null; }
        }
        public override decimal? StandardTotalCost
        {
            get { return null; }
        }
        public override decimal? StandardTotalPrice
        {
            get { return null; }
        }
        public override decimal TotalCost
        {
            get { return this._line.Amount * this.DurationInternal * this._line.Cost; }
        }
        public override decimal TotalPrice
        {
            get { return this._line.Amount * this.DurationInternal * this._line.Price; }
        }
        public override decimal Income
        {
            get { return TotalPrice - TotalCost; }
        }
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TotalCostProperty || e.PropertyName == TotalPriceProperty || e.PropertyName == IncomeProperty || e.PropertyName == AmountProperty ||
                e.PropertyName == CostProperty || e.PropertyName == PriceProperty)
                this.SectionItem.InvokeSectionChanged(e.PropertyName);
            base.OnPropertyChanged(e);
        }
        private ProductView _product;
        internal ProductView Product
        {
            get
            {
                if (!Line.ProductId.HasValue)
                    return null;
                if (this._product == null)
                {
                    this._product = ListManager.GetItem<ProductView>(Line.ProductId.Value);
                }
                return this._product;
            }
        }
        public override Nullable<int> UnitOfMeasureId
        {
            get
            {
                if (this.Product != null)
                    return this.Product.UnitOfMeasureId;
                return null;
            }
        }
        public override Nullable<decimal> MarginFactor
        {
            get
            {
                if (this.Price.HasValue && this.Cost.HasValue)
                {
                    if (this.Cost.Value != 0)
                        return this.Price.Value / this.Cost.Value;
                }
                return null;
            }
        }
        public override Nullable<decimal> CostPerGuest
        {
            get
            {
                if (Parent.AmountOfGuests.HasValue && Parent.AmountOfGuests.Value != 0)
                    return this.TotalCost / Parent.AmountOfGuests.Value;
                return null;
            }
        }
        public override Nullable<decimal> PricePerGuest
        {
            get
            {
                if (Parent.AmountOfGuests.HasValue && Parent.AmountOfGuests.Value != 0)
                    return this.TotalPrice / Parent.AmountOfGuests.Value;
                return null;
            }
        }
        public override Nullable<decimal> Profitability
        {
            get
            {
                if (this.Price.HasValue && this.Cost.HasValue && this.Cost.Value != 0)
                {
                    return (this.Price.Value - this.Cost.Value) / this.Cost.Value;
                }
                return null;
            }
        }
    }
}
