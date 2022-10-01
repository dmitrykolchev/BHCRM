using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementSectionItem: CalculationStatementItem
    {
        private CalculationStatementSection _section;
        public CalculationStatementSectionItem(CalculationStatementSection section)
        {
            this._section = section;
        }
        public override bool CanMoveDown
        {
            get
            {
                return this.Section != Parent.Sections[Parent.Sections.Count - 1];
            }
        }
        public override bool CanMoveUp
        {
            get
            {
                return this.Section != Parent.Sections[0];
            }
        }
        public CalculationStatementSection Section
        {
            get { return this._section; }
        }
        public override int ParentId
        {
            get { return 0; }
        }
        public override int Level
        {
            get { return 0; }
        }
        public override CalculationStatementSectionItem SectionItem
        {
            get
            {
                return this;
            }
            protected set
            {
                throw new NotSupportedException();
            }
        }
        public override CalculationStatement Parent
        {
            get { return this._section.Parent; }
        }
        public override Nullable<int> ProductCategoryId
        {
            get
            {
                return this._section.ProductCategoryId;
            }
        }
        public override int? ProductId
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override int OrdinalPosition
        {
            get { return this._section.OrdinalPosition; }
        }
        public override string FileAs
        {
            get
            {
                return this._section.FileAs;
            }
            set
            {
                this._section.FileAs = value;
                InvokePropertyChanged();
            }
        }
        public override string Comments
        {
            get
            {
                return this._section.Comments;
            }
            set
            {
                this._section.Comments = value;
                InvokePropertyChanged();
            }
        }
        public override decimal? StandardAmount
        {
            get { return this._section.StandardAmount; }
        }
        public override decimal? StandardTotalCost
        {
            get { return this._section.StandardTotalCost; }
        }
        public override decimal? StandardTotalPrice
        {
            get { return this._section.StandardTotalPrice; }
        }
        public override DateTime? StartTime
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override DateTime? EndTime
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override decimal? Duration
        {
            get { return null; }
        }
        public override decimal? Amount
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override decimal? Price
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        public override decimal? Cost
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        public Nullable<decimal> _totalDuration;
        protected virtual decimal CalculateTotalDuration()
        {
            return GetChildren().Sum(t => t.TotalDuration.GetValueOrDefault(0));
        }
        public override decimal? TotalDuration
        {
            get {
                if (this._totalDuration == null)
                    this._totalDuration = CalculateTotalDuration();
                return this._totalDuration.Value;
            }
        }
        protected virtual decimal CalculateTotalPrice()
        {
            return GetChildren().Sum(t => t.TotalPrice);
        }
        private Nullable<decimal> _totalPrice;
        public override decimal TotalPrice
        {
            get
            {
                if (this._totalPrice == null)
                    this._totalPrice = CalculateTotalPrice();
                return this._totalPrice.GetValueOrDefault();
            }
        }
        protected virtual decimal CalculateTotalCost()
        {
            return GetChildren().Sum(t => t.TotalCost);
        }
        private Nullable<decimal> _totalCost;
        public override decimal TotalCost
        {
            get
            {
                if (this._totalCost == null)
                    this._totalCost = CalculateTotalCost();
                return this._totalCost.GetValueOrDefault();
            }
        }
        protected virtual decimal CalculateIncome()
        {
            return GetChildren().Sum(t => t.Income);
        }
        private Nullable<decimal> _income;
        public override decimal Income
        {
            get
            {
                if (this._income == null)
                    this._income = CalculateIncome();
                return this._income.GetValueOrDefault();
            }
        }
        public IList<CalculationStatementLineItem> GetChildren()
        {
            return Parent.Items.Where(t => t.ParentId == this.Id).OrderBy(t => t.OrdinalPosition).OfType<CalculationStatementLineItem>().ToArray();
        }
        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TotalPriceProperty)
            {
                this._totalPrice = null;
                this._income = null;
            }
            else if (e.PropertyName == TotalCostProperty)
            {
                this._totalCost = null;
                this._income = null;
            }
            else if (e.PropertyName == TotalDurationProperty)
            {
                this._totalDuration = null;
            }
            else if (e.PropertyName == IncomeProperty)
            {
                this._income = null;
            }
            base.OnPropertyChanged(e);
        }
        public override decimal? WeightPerGuest
        {
            get
            {
                var result = this.GetChildren().Where(t => t.WeightPerGuest.HasValue);
                if (result.Count() > 0)
                    return result.Sum(t => t.WeightPerGuest.Value);
                return null;
            }
        }
        public override decimal? PricePerGuest
        {
            get
            {
                var result = this.GetChildren().Where(t => t.PricePerGuest.HasValue);
                if (result.Count() > 0)
                    return result.Sum(t => t.PricePerGuest.Value);
                return null;
            }
        }

        public override decimal? CostPerGuest
        {
            get
            {
                var result = this.GetChildren().Where(t => t.CostPerGuest.HasValue);
                if (result.Count() > 0)
                    return result.Sum(t => t.CostPerGuest.Value);
                return null;
            }
        }
        public override decimal? Profitability
        {
            get
            {
                if (this.TotalCost != 0)
                {
                    return (this.TotalPrice - this.TotalCost) / this.TotalCost;
                }
                return null;
            }
        }
        internal void InvokeSectionChanged()
        {
            InvokeSectionChangedInternal();
            this.Parent.SubtotalSectionItem.InvokeSectionChangedInternal();
            this.Parent.SubtotalWithDiscountSectionItem.InvokeSectionChangedInternal();
            this.Parent.SubtotalWithVATSectionItem.InvokeSectionChangedInternal();
        }
        internal void InvokeSectionChangedInternal()
        {
            InvokePropertyChanged(WeightPerGuestProperty);
            InvokePropertyChanged(PricePerGuestProperty);
            InvokePropertyChanged(CostPerGuestProperty);
            InvokePropertyChanged(TotalPriceProperty);
            InvokePropertyChanged(TotalCostProperty);
            InvokePropertyChanged(TotalDurationProperty);
            InvokePropertyChanged(IncomeProperty);
        }
        internal void InvokeSectionChanged(string propertyName)
        {
            InvokePropertyChanged(propertyName);
            this.Parent.SubtotalSectionItem.InvokeSectionChangedInternal();
            this.Parent.SubtotalWithDiscountSectionItem.InvokeSectionChangedInternal();
            this.Parent.SubtotalWithVATSectionItem.InvokeSectionChangedInternal();
        }
    }
}
