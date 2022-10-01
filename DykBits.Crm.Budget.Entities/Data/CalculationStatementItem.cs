using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public abstract class CalculationStatementItem : NotifyObject
    {
        public const string StartTimeProperty = "StartTime";
        public const string EndTimeProperty = "EndTime";
        public const string DurationProperty = "Duration";
        public const string TotalDurationProperty = "TotalDuration";
        public const string CostProperty = "Cost";
        public const string PriceProperty = "Price";
        public const string AmountProperty = "Amount";
        public const string AmountUomProperty = "AmountUom";
        public const string TotalCostProperty = "TotalCost";
        public const string TotalPriceProperty = "TotalPrice";
        public const string IncomeProperty = "Income";
        public const string AmountPerGuestProperty = "AmountPerGuest";
        public const string PricePerGuestProperty = "PricePerGuest";
        public const string WeightPerGuestProperty = "WeightPerGuest";
        public const string TotalWeightProperty = "TotalWeight";
        public const string CostPerGuestProperty = "CostPerGuest";

        private static int Identifier;
        protected CalculationStatementItem()
        {
            this.Id = ++Identifier;
        }
        public abstract CalculationStatement Parent { get; }
        public virtual bool ReadOnly
        {
            get { return false; }
        }
        public int Id
        {
            get;
            private set;
        }
        public abstract int ParentId { get; }
        public abstract bool CanMoveUp { get; }
        public abstract bool CanMoveDown { get; }
        public abstract int Level { get; }
        public abstract CalculationStatementSectionItem SectionItem { get; protected set; }
        public virtual Nullable<int> ProductCategoryId { get { return null; } }
        public abstract int OrdinalPosition { get; }
        public abstract Nullable<int> ProductId { get; set; }
        public abstract string FileAs { get; set; }
        public abstract string Comments { get; set; }
        public abstract Nullable<DateTime> StartTime { get; set; }
        public abstract Nullable<DateTime> EndTime { get; set; }
        public abstract Nullable<decimal> Duration { get; }
        public abstract Nullable<decimal> StandardAmount { get; }
        public abstract Nullable<decimal> StandardTotalCost { get; }
        public abstract Nullable<decimal> StandardTotalPrice { get; }
        public abstract Nullable<decimal> Amount { get; set; }
        public abstract Nullable<decimal> Price { get; set; }
        public abstract Nullable<decimal> Cost { get; set; }
        public abstract Nullable<decimal> TotalDuration { get; }
        public abstract decimal TotalCost { get; }
        public abstract decimal TotalPrice { get; }
        public abstract decimal Income { get; }
        public virtual Nullable<int> UnitOfMeasureId { get { return null; } }
        public virtual Nullable<decimal> MarginFactor { get { return null; } }
        public virtual Nullable<decimal> AmountPerGuest
        {
            get { return null; }
            set { }
        }
        public virtual Nullable<decimal> TotalWeight
        {
            get
            {
                return null;
            }
        }
        public virtual Nullable<decimal> WeightPerGuest
        {
            get
            {
                return null;
            }
        }
        public virtual Nullable<decimal> CostPerGuest
        {
            get
            {
                return null;
            }
        }
        public virtual Nullable<decimal> PricePerGuest
        {
            get
            {
                return null;
            }
        }
        public virtual Nullable<decimal> Profitability
        {
            get
            {
                return null;
            }
        }
    }
}
