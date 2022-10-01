using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public abstract class PayrollItemBase : DetailDataItem<Payroll>
    {
        public const string TotalProperty = "Total";

        private static int PayrollItemId = 0;
        protected PayrollItemBase()
        {
            this.Id = System.Threading.Interlocked.Increment(ref PayrollItemId);
        }
        public int OrdinalPosition { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public abstract int Level { get; }
        public abstract PayrollItemBase ParentItem { get; }
        public abstract Nullable<int> AccountId { get; set; }
        public abstract Nullable<int> EmployeeId { get; set; }
        public abstract Nullable<int> PositionId { get; set; }
        public abstract int DivisionId { get; set; }
        public abstract string FileAs { get; set; }
        public abstract string Comments { get; set; }
        public abstract decimal SalaryTotal { get; set; }
        public abstract decimal SalaryBase { get; set; }
        public abstract decimal SalaryTotalUI { get; set; }
        public abstract decimal SalaryBaseUI { get; set; }
        public abstract decimal IncomeTax { get; set; }
        public abstract decimal SocialTax { get; set; }
        public abstract decimal Cashing { get; set; }
        public virtual decimal Total
        {
            get
            {
                return this.SalaryTotal + this.IncomeTax + this.SocialTax + this.Cashing;
            }
        }
        internal void RaisePropertyChanged(string propertyName)
        {
            InvokePropertyChanged(propertyName);
        }
    }

    public class PayrollEmployeeItem : PayrollItemBase
    {
        private PayrollLine _line;
        public PayrollEmployeeItem(PayrollLine line)
        {
            this._line = line;
        }
        private PayrollLine Line
        {
            get { return this._line; }
        }
        public override int Level
        {
            get { return 1; }
        }
        public override PayrollItemBase ParentItem
        {
            get
            {
                return this.Parent.Items.Where(t => t.Id == this.ParentId).SingleOrDefault();
            }
        }
        public override int? AccountId
        {
            get
            {
                return this._line.AccountId;
            }
            set
            {
                this._line.AccountId = value;
                InvokePropertyChanged();
            }
        }
        public override int? EmployeeId
        {
            get
            {
                return this._line.EmployeeId;
            }
            set
            {
                this._line.EmployeeId = value;
                InvokePropertyChanged();
            }
        }
        public override int? PositionId
        {
            get
            {
                return this._line.PositionId;
            }
            set
            {
                this._line.PositionId = value;
                InvokePropertyChanged();
            }
        }
        public override int DivisionId
        {
            get
            {
                return this._line.DivisionId.GetValueOrDefault();
            }
            set
            {
                this._line.DivisionId = value;
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
        [XmlIgnore]
        private TaxRateView IncomeTaxRate
        {
            get
            {
                return ListManager.GetItem<TaxRateView>(TaxRate.IncomeTaxRate);
            }
        }
        [XmlIgnore]
        private TaxRateView SocialTaxRate
        {
            get
            {
                return ListManager.GetItem<TaxRateView>(TaxRate.SocialTaxRate);
            }
        }
        [XmlIgnore]
        private decimal ExtraCostRate
        {
            get
            {
                if (this.Parent.ExtraCostRateId == 0)
                    return 0;
                return ListManager.GetItem<ExtraCostRateView>(this.Parent.ExtraCostRateId).Value;
            }
        }
        public override decimal SalaryTotalUI
        {
            get { return this.SalaryTotal; }
            set
            {
                this.SalaryTotal = value;
                InvokePropertyChanged();
                RecalculateTaxes();
            }
        }
        public override decimal SalaryBaseUI
        {
            get { return this.SalaryBase; }
            set
            {
                this.SalaryBase = value;
                InvokePropertyChanged();
                RecalculateTaxes();
            }
        }
        private void RecalculateTaxes()
        {
            this.IncomeTax = this._line.SalaryBase * IncomeTaxRate.Value;
            this.SocialTax = this._line.SalaryBase * SocialTaxRate.Value;
            this.Cashing = (this._line.SalaryTotal - this._line.SalaryBase * (1m - IncomeTaxRate.Value)) * this.ExtraCostRate;
            InvokePropertyChanged(TotalProperty);
        }
        public override decimal SalaryTotal
        {
            get
            {
                return this._line.SalaryTotal;
            }
            set
            {
                this._line.SalaryTotal = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalProperty);
            }
        }
        public override decimal SalaryBase
        {
            get
            {
                return this._line.SalaryBase;
            }
            set
            {
                this._line.SalaryBase = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalProperty);
            }
        }

        public override decimal IncomeTax
        {
            get
            {
                return this._line.IncomeTax;
            }
            set
            {
                this._line.IncomeTax = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalProperty);
            }
        }

        public override decimal SocialTax
        {
            get
            {
                return this._line.SocialTax;
            }
            set
            {
                this._line.SocialTax = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalProperty);
            }
        }

        public override decimal Cashing
        {
            get
            {
                return this._line.Cashing;
            }
            set
            {
                if (value < 0)
                    value = 0;
                this._line.Cashing = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalProperty);
            }
        }
    }

    public class PayrollTotalItem : PayrollItemBase
    {
        public PayrollTotalItem()
        {
        }
        public override int Level
        {
            get { return 0; }
        }
        public override PayrollItemBase ParentItem
        {
            get { return null; }
        }
        public override int? AccountId
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override int? EmployeeId
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override int? PositionId
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override int DivisionId
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }
        public override string Comments
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        private IEnumerable<PayrollItemBase> GetChildren()
        {
            return this.Parent.Items.Where(t => t.Level == 1);
        }
        public override decimal SalaryTotalUI
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryTotal);
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override decimal SalaryBaseUI
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryBase);
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override decimal SalaryTotal
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryTotal);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal SalaryBase
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryBase);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal IncomeTax
        {
            get
            {
                return GetChildren().Sum(t => t.IncomeTax);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal SocialTax
        {
            get
            {
                return GetChildren().Sum(t => t.SocialTax);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal Cashing
        {
            get
            {
                return GetChildren().Sum(t => t.Cashing);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal Total
        {
            get
            {
                return GetChildren().Sum(t => t.Total);
            }
        }
    }
    public class PayrollDivisionItem : PayrollItemBase
    {
        private DivisionView _division;
        public PayrollDivisionItem()
        {
        }
        public PayrollDivisionItem(DivisionView division)
        {
            this._division = division;
        }
        public override int Level
        {
            get { return 0; }
        }
        public override PayrollItemBase ParentItem
        {
            get { return null; }
        }
        public override int? AccountId
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override int? EmployeeId
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override int? PositionId
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override int DivisionId
        {
            get
            {
                return this._division == null ? 0 : this._division.Id;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override string FileAs
        {
            get
            {
                return this._division == null ? "(не указано)" : this._division.FileAs;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override string Comments
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        private IEnumerable<PayrollItemBase> GetChildren()
        {
            return this.Parent.Items.Where(t => t.ParentId == this.Id);
        }
        public override decimal SalaryTotalUI
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryTotal);
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override decimal SalaryBaseUI
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryBase);
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override decimal SalaryTotal
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryTotal);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal SalaryBase
        {
            get
            {
                return GetChildren().Sum(t => t.SalaryBase);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal IncomeTax
        {
            get
            {
                return GetChildren().Sum(t => t.IncomeTax);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal SocialTax
        {
            get
            {
                return GetChildren().Sum(t => t.SocialTax);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal Cashing
        {
            get
            {
                return GetChildren().Sum(t => t.Cashing);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override decimal Total
        {
            get
            {
                return GetChildren().Sum(t => t.Total);
            }
        }
    }
    public class PayrollItemCollection : DetailDataItemCollection<Payroll, PayrollItemBase>
    {
        internal PayrollItemCollection(Payroll owner)
            : base(owner)
        {
        }

        protected override void InsertItem(int index, PayrollItemBase item)
        {
            if (item.Level == 1)
            {
                var divisionItem = this.Where(t => t.Level == 0 && t.DivisionId == item.DivisionId).SingleOrDefault();
                if (divisionItem == null)
                {
                    if (item.DivisionId > 0)
                    {
                        var division = ListManager.GetItem<DivisionView>(item.DivisionId);
                        divisionItem = new PayrollDivisionItem(division);
                    }
                    else
                    {
                        divisionItem = new PayrollDivisionItem();
                    }
                    base.InsertItem(index++, divisionItem);
                }
                item.ParentId = divisionItem.Id;
                base.InsertItem(index, item);
            }
            else
            {
                base.InsertItem(index, item);
            }
        }

        protected override void OnItemPropertyChanged(ItemPropertyChangedEventArgs<PayrollItemBase> e)
        {
            base.OnItemPropertyChanged(e);
            if (e.Item.Level == 1)
            {
                e.Item.ParentItem.RaisePropertyChanged(e.PropertyName);
                this._totalItem.RaisePropertyChanged(e.PropertyName);
            }
        }

        private PayrollTotalItem _totalItem;

        internal void Initialize()
        {
            foreach (var line in this.Owner.Lines)
            {
                Add(new PayrollEmployeeItem(line));
            }
            this._totalItem = new PayrollTotalItem();
            Add(this._totalItem);
        }
    }
}
