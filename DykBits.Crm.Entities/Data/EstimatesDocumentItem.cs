using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DykBits.Crm.Data
{
    public abstract class EstimatesDocumentItem : NotifyObject
    {
        public const string FileAsProperty = "FileAs";
        public const string CashCostProperty = "CashCost";
        public const string NonCashCostProperty = "NonCashCost";
        public const string ExtraCostProperty = "ExtraCost";
        public const string TotalCostProperty = "TotalCost";
        public const string TotalPriceProperty = "TotalPrice";
        public const string IncomeProperty = "Income";
        private static int Identifier;
        private EstimatesDocumentSectionItem _sectionItem;

        protected EstimatesDocumentItem()
        {
            this.Id = ++Identifier;
        }
        public virtual EstimatesDocumentSectionItem SectionItem
        {
            get { return this._sectionItem; }
            protected set
            {
                this._sectionItem = value;
                this.ParentId = this._sectionItem.Id;
            }
        }
        public abstract EstimatesDocument Parent { get; }
        public abstract int OrdinalPosition { get; }
        public int Id
        {
            get;
            private set;
        }
        public int ParentId
        {
            get;
            private set;
        }
        public virtual int ProductCategoryId
        {
            get { return 0; }
        }
        public abstract bool ReadOnly { get; }
        public abstract int Level { get; }
        public abstract string FileAs { get; set; }
        public abstract string Comments { get; set; }
        public virtual Nullable<int> UnitOfMeasureId
        {
            get { return null; }
            set { }
        }
        public virtual Nullable<int> ProductId
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

        public abstract decimal CashCost { get; set; }
        public abstract decimal NonCashCost { get; set; }
        public abstract decimal ExtraCost { get; }
        public abstract decimal TotalCost { get; }
        public abstract decimal TotalPrice { get; }
        public abstract decimal Income { get; }
    }

    public class EstimatesDocumentSectionItem : EstimatesDocumentItem
    {
        private EstimatesDocumentSection _section;
        public EstimatesDocumentSectionItem(EstimatesDocumentSection section)
            : base()
        {
            this._section = section;
        }
        public IList<EstimatesDocumentLineItem> GetChildren()
        {
            return Parent.Items.Where(t => t.ParentId == this.Id).OrderBy(t => t.OrdinalPosition).OfType<EstimatesDocumentLineItem>().ToArray();
        }
        public override bool ReadOnly
        {
            get { return this._section.ReadOnly; }
        }
        public override int OrdinalPosition
        {
            get { return this._section.OrdinalPosition; }
        }
        public override EstimatesDocumentSectionItem SectionItem
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
        public override EstimatesDocument Parent
        {
            get { return this._section.Parent; }
        }

        internal EstimatesDocumentSection Section
        {
            get { return this._section; }
        }
        public override int ProductCategoryId
        {
            get
            {
                return this._section.ProductCategoryId;
            }
        }
        public override int Level
        {
            get { return 0; }
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
            }
        }
        public void InvokeSectionChanged()
        {
            InvokeSectionChangedInternal();
            this.Parent.SubtotalItem.InvokeSectionChangedInternal();
            this.Parent.CommissionItem.InvokeLineChanged();
            this.Parent.SubtotalWithCommissionItem.InvokeSectionChangedInternal();
            this.Parent.VATItem.InvokeLineChanged();
            this.Parent.SubtotalWithVATItem.InvokeSectionChangedInternal();
        }

        private void InvokeSectionChangedInternal()
        {
            InvokePropertyChanged(TotalPriceProperty);
            InvokePropertyChanged(CashCostProperty);
            InvokePropertyChanged(NonCashCostProperty);
            InvokePropertyChanged(ExtraCostProperty);
            InvokePropertyChanged(TotalCostProperty);
            InvokePropertyChanged(IncomeProperty);
        }

        private Nullable<decimal> _cashCost;
        private Nullable<decimal> _nonCashCost;
        private Nullable<decimal> _extraCost;
        private Nullable<decimal> _totalCost;
        private Nullable<decimal> _totalPrice;
        private Nullable<decimal> _income;

        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CashCostProperty)
            {
                this._cashCost = null;
                this._extraCost = null;
            }
            else if (e.PropertyName == NonCashCostProperty)
                this._nonCashCost = null;
            else if (e.PropertyName == TotalCostProperty)
                this._totalCost = null;
            else if (e.PropertyName == TotalPriceProperty)
                this._totalPrice = null;
            else if (e.PropertyName == IncomeProperty)
                this._income = null;
            base.OnPropertyChanged(e);
        }

        protected virtual decimal CalculateCashCost()
        {
            return GetChildren().Sum(t => t.CashCost);
        }

        public override decimal CashCost
        {
            get
            {
                if (this._cashCost == null)
                    this._cashCost = CalculateCashCost();
                return this._cashCost.Value;
            }
            set
            {
            }
        }

        protected virtual decimal CalculateNonCashCost()
        {
            return GetChildren().Sum(t => t.NonCashCost);
        }

        public override decimal NonCashCost
        {
            get
            {
                if (this._nonCashCost == null)
                    this._nonCashCost = CalculateNonCashCost();
                return this._nonCashCost.Value;
            }
            set
            {
            }
        }
        protected virtual decimal CalculateExtraCost()
        {
            return GetChildren().Sum(t => t.ExtraCost);
        }
        public override decimal ExtraCost
        {
            get
            {
                if (this._extraCost == null)
                    this._extraCost = CalculateExtraCost();
                return this._extraCost.Value;
            }
        }

        protected virtual decimal CalculateTotalCost()
        {
            return GetChildren().Sum(t => t.TotalCost);
        }
        public override decimal TotalCost
        {
            get
            {
                if (this._totalCost == null)
                    this._totalCost = CalculateTotalCost();
                return this._totalCost.Value;
            }
        }
        protected virtual decimal CalculateTotalPrice()
        {
            return GetChildren().Sum(t => t.TotalPrice);
        }
        public override decimal TotalPrice
        {
            get
            {
                if (this._totalPrice == null)
                    this._totalPrice = CalculateTotalPrice();
                return this._totalPrice.Value;
            }
        }
        protected virtual decimal CalculateIncome()
        {
            return GetChildren().Sum(t => t.Income);
        }
        public override decimal Income
        {
            get
            {
                if (this._income == null)
                    this._income = CalculateIncome();
                return this._income.Value;
            }
        }
    }

    public class EstimatesDocumentSubtotalSectionItem : EstimatesDocumentSectionItem
    {
        public EstimatesDocumentSubtotalSectionItem(EstimatesDocumentSection section)
            : base(section)
        {
        }
        protected override decimal CalculateCashCost()
        {
            return Parent.Items.OfType<EstimatesDocumentLineItem>().Where(t => !t.ReadOnly).Sum(t => t.CashCost);
        }

        protected override decimal CalculateNonCashCost()
        {
            return Parent.Items.OfType<EstimatesDocumentLineItem>().Where(t => !t.ReadOnly).Sum(t => t.NonCashCost);
        }
        protected override decimal CalculateExtraCost()
        {
            return Parent.Items.OfType<EstimatesDocumentLineItem>().Where(t => !t.ReadOnly).Sum(t => t.ExtraCost);
        }
        protected override decimal CalculateTotalCost()
        {
            return Parent.Items.OfType<EstimatesDocumentLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalCost);
        }
        protected override decimal CalculateTotalPrice()
        {
            return Parent.Items.OfType<EstimatesDocumentLineItem>().Where(t => !t.ReadOnly).Sum(t => t.TotalPrice);
        }
        protected override decimal CalculateIncome()
        {
            return Parent.Items.OfType<EstimatesDocumentLineItem>().Where(t => !t.ReadOnly).Sum(t => t.Income);
        }
    }
    public class EstimatesDocumentSubtotalWithCommissionSectionItem : EstimatesDocumentSectionItem
    {
        public EstimatesDocumentSubtotalWithCommissionSectionItem(EstimatesDocumentSection section)
            : base(section)
        {
        }

        protected override decimal CalculateCashCost()
        {
            return Parent.SubtotalItem.CashCost + Parent.CommissionItem.CashCost;
        }
        protected override decimal CalculateNonCashCost()
        {
            return Parent.SubtotalItem.NonCashCost + Parent.CommissionItem.NonCashCost;
        }
        protected override decimal CalculateExtraCost()
        {
            return Parent.SubtotalItem.ExtraCost + Parent.CommissionItem.ExtraCost;
        }
        protected override decimal CalculateTotalCost()
        {
            return Parent.SubtotalItem.TotalCost + Parent.CommissionItem.TotalCost;
        }
        protected override decimal CalculateTotalPrice()
        {
            return Parent.SubtotalItem.TotalPrice + Parent.CommissionItem.TotalPrice;
        }
        protected override decimal CalculateIncome()
        {
            return Parent.SubtotalItem.Income + Parent.CommissionItem.Income;
        }
    }
    public class EstimatesDocumentSubtotalWithVATSectionItem : EstimatesDocumentSectionItem
    {
        public EstimatesDocumentSubtotalWithVATSectionItem(EstimatesDocumentSection section)
            : base(section)
        {
        }
        protected override decimal CalculateCashCost()
        {
            return Parent.SubtotalItem.CashCost + Parent.CommissionItem.CashCost + Parent.VATItem.CashCost;
        }
        protected override decimal CalculateNonCashCost()
        {
            return Parent.SubtotalItem.NonCashCost + Parent.CommissionItem.NonCashCost + Parent.VATItem.NonCashCost;
        }
        protected override decimal CalculateExtraCost()
        {
            return Parent.SubtotalItem.ExtraCost + Parent.CommissionItem.ExtraCost + Parent.VATItem.ExtraCost;
        }
        protected override decimal CalculateTotalCost()
        {
            return Parent.SubtotalItem.TotalCost + Parent.CommissionItem.TotalCost + Parent.VATItem.TotalCost;
        }
        protected override decimal CalculateTotalPrice()
        {
            return Parent.SubtotalItem.TotalPrice + Parent.CommissionItem.TotalPrice + Parent.VATItem.TotalPrice;
        }
        protected override decimal CalculateIncome()
        {
            return Parent.SubtotalItem.Income + Parent.CommissionItem.Income + Parent.VATItem.Income;
        }
    }

    public class EstimatesDocumentLineItem : EstimatesDocumentItem
    {
        private EstimatesDocumentLine _line;
        public EstimatesDocumentLineItem(EstimatesDocumentSectionItem sectionItem, EstimatesDocumentLine line)
            : base()
        {
            this._line = line;
            this._line.EstimatesDocumentSectionId = sectionItem.Section.EstimatesDocumentSectionId;
            this.SectionItem = sectionItem;
        }
        public override int OrdinalPosition
        {
            get { return this._line.OrdinalPosition; }
        }
        public bool CanMoveUp
        {
            get
            {
                EstimatesDocumentLineItem item = SectionItem.GetChildren().FirstOrDefault();
                if (item == null)
                    return false;
                return this.OrdinalPosition > item.OrdinalPosition;
            }
        }
        public bool CanMoveDown
        {
            get
            {
                EstimatesDocumentLineItem item = SectionItem.GetChildren().LastOrDefault();
                if (item == null)
                    return false;
                return this.OrdinalPosition < item.OrdinalPosition;
            }
        }
        public override bool ReadOnly
        {
            get { return this._line.ReadOnly; }
        }
        public EstimatesDocumentLine Line
        {
            get { return this._line; }
        }
        public override EstimatesDocument Parent
        {
            get { return this._line.Parent; }
        }
        public override int Level
        {
            get { return 1; }
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
        public override int? UnitOfMeasureId
        {
            get
            {
                return this._line.UnitOfMeasureId;
            }
            set
            {
                this._line.UnitOfMeasureId = value.GetValueOrDefault();
                InvokePropertyChanged();
            }
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
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(IncomeProperty);
                SectionItem.InvokeSectionChanged();
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
                SectionItem.InvokeSectionChanged();
            }
        }
        public override decimal CashCost
        {
            get
            {
                return this._line.CashCost;
            }
            set
            {
                this._line.CashCost = value;
                InvokePropertyChanged();
                InvokePropertyChanged(ExtraCostProperty);
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(IncomeProperty);
                SectionItem.InvokeSectionChanged();
            }
        }
        public override decimal NonCashCost
        {
            get
            {
                return this._line.NonCashCost;
            }
            set
            {
                this._line.NonCashCost = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(IncomeProperty);
                SectionItem.InvokeSectionChanged();
            }
        }
        public override decimal ExtraCost
        {
            get
            {
                return this.CashCost * Parent.ExtraCostRate.Value / (1 - Parent.ExtraCostRate.Value);
            }
        }
        public override decimal TotalCost
        {
            get { return this.CashCost / (1 - Parent.ExtraCostRate.Value) + this.NonCashCost; }
        }
        public override decimal TotalPrice
        {
            get { return this._line.Amount * this._line.Price; }
        }
        public override decimal Income
        {
            get { return TotalPrice - TotalCost; }
        }
        public void InvokeLineChanged()
        {
            InvokePropertyChanged(FileAsProperty);
            InvokePropertyChanged(TotalPriceProperty);
            InvokePropertyChanged(TotalCostProperty);
            InvokePropertyChanged(IncomeProperty);
        }
    }

    public class EstimatesDocumentCommissionLineItem : EstimatesDocumentLineItem
    {
        public EstimatesDocumentCommissionLineItem(EstimatesDocumentSectionItem sectionItem, EstimatesDocumentLine line)
            : base(sectionItem, line)
        {
        }

        public override decimal TotalCost
        {
            get
            {
                return 0;
            }
        }

        public override decimal TotalPrice
        {
            get
            {
                return this.Parent.SubtotalItem.TotalPrice * this.Parent.Commission;
            }
        }
        public override decimal Income
        {
            get
            {
                return TotalPrice;
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
    }
    public class EstimatesDocumentVATLineItem : EstimatesDocumentLineItem
    {
        public EstimatesDocumentVATLineItem(EstimatesDocumentSectionItem sectionItem, EstimatesDocumentLine line)
            : base(sectionItem, line)
        {
        }
        public override decimal TotalCost
        {
            get
            {
                return NonCashCost;
            }
        }
        public override decimal TotalPrice
        {
            get
            {
                return this.Parent.SubtotalWithCommissionItem.TotalPrice * this.Parent.VATRate.Value;
            }
        }
        public override decimal NonCashCost
        {
            get
            {
                return TotalPrice / 3m;
            }
            set
            {
            }
        }
        public override decimal Income
        {
            get
            {
                return TotalPrice - TotalCost;
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
    }
}
