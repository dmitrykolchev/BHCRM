using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public abstract class CalculationStatementTemplateItem: NotifyObject
    {
        public const string CostProperty = "Cost";
        public const string PriceProperty = "Price";
        public const string AmountProperty = "Amount";
        public const string TotalCostProperty = "TotalCost";
        public const string TotalPriceProperty = "TotalPrice";
        public const string IncomeProperty = "Income";
        public const string DependsOnAmountOfPersonsProperty = "DependsOnAmountOfPersons";
        public const string DependsOnEventDurationProperty = "DependsOnEventDuration";

        private static int Identifier;
        protected CalculationStatementTemplateItem()
        {
            this.Id = ++Identifier;
        }
        public abstract CalculationStatementTemplate Parent { get; }
        public virtual bool ReadOnly
        {
            get { return false; }
        }
        public int Id
        {
            get;
            private set;
        }
        public abstract int ParentId
        {
            get;
        }
        public virtual bool CanMoveUp
        {
            get { return false; }
        }
        public virtual bool CanMoveDown
        {
            get { return false; }
        }
        public abstract int Level { get; }
        public abstract CalculationStatementTemplateSectionItem SectionItem { get; protected set; }
        public virtual Nullable<int> ProductCategoryId { get { return null; } }
        public abstract int OrdinalPosition { get; }
        public virtual Nullable<int> ProductId
        {
            get { return null; }
            set { }
        }
        public abstract string FileAs { get; set; }
        public abstract string Comments { get; set; }
        public virtual Nullable<decimal> Duration
        {
            get { return null; }
            set { }
        }
        public virtual Nullable<decimal> Amount
        {
            get { return null; }
            set { }
        }
        public virtual Nullable<decimal> Price
        {
            get { return null; }
            set { }
        }
        public virtual Nullable<decimal> Cost
        {
            get { return null; }
            set { }
        }
        public abstract Nullable<bool> DependsOnAmountOfPersons
        {
            get;
            set;
        }
        public abstract Nullable<bool> DependsOnEventDuration
        {
            get;
            set;
        }
        public abstract decimal TotalCost { get; }
        public abstract decimal TotalPrice { get; }
        public abstract decimal Income { get; }
    }
}
