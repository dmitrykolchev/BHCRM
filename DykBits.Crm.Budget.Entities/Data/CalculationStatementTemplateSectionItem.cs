using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateSectionItem : CalculationStatementTemplateItem
    {
        private CalculationStatementTemplateSection _section;
        public CalculationStatementTemplateSectionItem(CalculationStatementTemplateSection section)
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
        public CalculationStatementTemplateSection Section
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
        public override CalculationStatementTemplateSectionItem SectionItem
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
        public override CalculationStatementTemplate Parent
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
        public override decimal? Amount
        {
            get
            {
                return null;
            }
            set
            {
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
        public IList<CalculationStatementTemplateLineItem> GetChildren()
        {
            return Parent.Items.Where(t => t.ParentId == this.Id).OrderBy(t => t.OrdinalPosition).OfType<CalculationStatementTemplateLineItem>().ToArray();
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
            else if (e.PropertyName == IncomeProperty)
            {
                this._income = null;
            }
            base.OnPropertyChanged(e);
        }
        public override bool? DependsOnAmountOfPersons
        {
            get
            {
                var children = this.GetChildren();
                var trueCount = children.Where(t=>t.DependsOnAmountOfPersons == true).Count();
                if (children.Count == 0)
                    return null;
                if (children.Count == trueCount)
                    return true;
                else if (trueCount == 0)
                    return false;
                return null;
            }
            set
            {
                var children = this.GetChildren();
                if (value == true)
                    foreach (var child in children)
                        child.DependsOnAmountOfPersons = true;
                else if (value == false)
                    foreach (var child in children)
                        child.DependsOnAmountOfPersons = false;
            }
        }

        public override bool? DependsOnEventDuration
        {
            get
            {
                var children = this.GetChildren();
                var trueCount = children.Where(t => t.DependsOnEventDuration == true).Count();
                if (children.Count == 0)
                    return null;
                if (children.Count == trueCount)
                    return true;
                if (trueCount == 0)
                    return false;
                return null;
            }
            set
            {
                var children = this.GetChildren();
                if (value == true)
                    foreach (var child in children)
                        child.DependsOnEventDuration = true;
                else if (value == false)
                    foreach (var child in children)
                        child.DependsOnEventDuration = false;
            }
        }
        internal void InvokeSectionChanged()
        {
            InvokeSectionChangedInternal();
            this.Parent.SubtotalSectionItem.InvokeSectionChangedInternal();
        }
        internal void InvokeSectionChangedInternal()
        {
            InvokePropertyChanged(TotalPriceProperty);
            InvokePropertyChanged(TotalCostProperty);
            InvokePropertyChanged(IncomeProperty);
        }
        internal void InvokeSectionChanged(string propertyName)
        {
            InvokePropertyChanged(propertyName);
            this.Parent.SubtotalSectionItem.InvokeSectionChangedInternal();
        }
    }
}
