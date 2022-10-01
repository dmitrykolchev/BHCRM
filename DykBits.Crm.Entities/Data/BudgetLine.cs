using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class BudgetLineProxy : NotifyObject
    {
        private BudgetLineInternal _line;
        public Budget Parent { get; internal set; }
        internal BudgetLineInternal Line
        {
            get { return this._line; }
            set
            {
                this._line = value;
                InvokeDataChanged();
            }
        }
        private int _budgetItemGroupId;
        public int BudgetItemGroupId
        {
            get
            {
                if (this.Line != null)
                    return this.Line.BudgetItemGroupId;
                return this._budgetItemGroupId;
            }
            set
            {
                this._budgetItemGroupId = value;
            }
        }
        public int BudgetItemId { get; set; }
        public int Id { get; set; }
        public int Level { get; set; }
        public int ParentId { get; set; }
        public string FileAs { get; set; }

        private Nullable<decimal> CalculateInvoiceValue(BudgetLineInternal line)
        {
            if (line.BudgetItemGroupId == BudgetItemGroup.Доходы_по_ОВД || line.BudgetItemGroupId == BudgetItemGroup.Прочие_доходы)
            {
                var items = this.Parent.SalesInvoices.Where(t => t.BudgetItemId == line.BudgetItemId);
                if (items.Count() > 0)
                    return items.Sum(t => t.Value);
            }
            else
            {
                decimal? invoiceValue = null;
                decimal? orderValue = null;
                var items = this.Parent.PurchaseInvoices.Where(t => t.BudgetItemId == line.BudgetItemId);
                if (items.Count() > 0)
                    invoiceValue = items.Sum(t => t.Value);
                var orders = this.Parent.SalesOrders.Where(t => t.BudgetItemId == line.BudgetItemId);
                if (orders.Count() > 0)
                    orderValue = orders.Sum(t => t.TotalCost);
                if (invoiceValue.HasValue || orderValue.HasValue)
                    return invoiceValue.GetValueOrDefault() + orderValue.GetValueOrDefault();
            }
            return null;
        }
        private Nullable<decimal> CalculateInvoiceValue(int budgetItemGroupId)
        {
            if (budgetItemGroupId == BudgetItemGroup.Доходы_по_ОВД || budgetItemGroupId == BudgetItemGroup.Прочие_доходы)
            {
                var items = this.Parent.SalesInvoices.Where(t => t.BudgetItemGroupId == budgetItemGroupId);
                if (items.Count() > 0)
                    return items.Sum(t => t.Value);
            }
            else
            {
                decimal? invoiceValue = null;
                decimal? orderValue = null;
                var items = this.Parent.PurchaseInvoices.Where(t => t.BudgetItemGroupId == budgetItemGroupId);
                if (items.Count() > 0)
                    invoiceValue = items.Sum(t => t.Value);
                var orders = this.Parent.SalesOrders.Where(t => t.BudgetItemGroupId == budgetItemGroupId);
                if (orders.Count() > 0)
                    orderValue = orders.Sum(t => t.TotalCost);
                if (invoiceValue.HasValue || orderValue.HasValue)
                    return invoiceValue.GetValueOrDefault() + orderValue.GetValueOrDefault();
            }
            return null;
        }
        public Nullable<decimal> InvoiceValue
        {
            get
            {
                if (Line != null)
                    return CalculateInvoiceValue(Line);
                if (BudgetItemGroupId > 0)
                    return CalculateInvoiceValue(BudgetItemGroupId);
                return null;
            }
        }
        private Nullable<decimal> CalculatePaymentValue(BudgetLineInternal line)
        {
            if (line.BudgetItemGroupId == BudgetItemGroup.Доходы_по_ОВД || line.BudgetItemGroupId == BudgetItemGroup.Прочие_доходы)
            {
                var items = this.Parent.PaymentInList.Where(t => t.BudgetItemId == line.BudgetItemId);
                if (items.Count() > 0)
                    return items.Sum(t => t.Value);
            }
            else
            {
                decimal? paymentValue = null;
                decimal? orderValue = null;
                var items = this.Parent.PaymentOutList.Where(t => t.BudgetItemId == line.BudgetItemId);
                if (items.Count() > 0)
                    paymentValue = items.Sum(t => t.Value);
                var orders = this.Parent.SalesOrders.Where(t => t.BudgetItemId == line.BudgetItemId);
                if (orders.Count() > 0)
                    orderValue = orders.Sum(t => t.TotalCost);
                if (paymentValue.HasValue || orderValue.HasValue)
                    return paymentValue.GetValueOrDefault() + orderValue.GetValueOrDefault();
            }
            return null;
        }
        private Nullable<decimal> CalculatePaymentValue(int budgetItemGroupId)
        {
            if (budgetItemGroupId == BudgetItemGroup.Доходы_по_ОВД || budgetItemGroupId == BudgetItemGroup.Прочие_доходы)
            {
                var items = this.Parent.PaymentInList.Where(t => t.BudgetItemGroupId == budgetItemGroupId);
                if (items.Count() > 0)
                    return items.Sum(t => t.Value);
            }
            else
            {
                decimal? paymentValue = null;
                decimal? orderValue = null;
                var items = this.Parent.PaymentOutList.Where(t => t.BudgetItemGroupId == budgetItemGroupId);
                if (items.Count() > 0)
                    if (items.Count() > 0)
                        paymentValue = items.Sum(t => t.Value);
                var orders = this.Parent.SalesOrders.Where(t => t.BudgetItemGroupId == budgetItemGroupId);
                if (orders.Count() > 0)
                    orderValue = orders.Sum(t => t.TotalCost);
                if (paymentValue.HasValue || orderValue.HasValue)
                    return paymentValue.GetValueOrDefault() + orderValue.GetValueOrDefault();
            }
            return null;
        }
        public Nullable<decimal> PaymentValue
        {
            get
            {
                if (Line != null)
                    return CalculatePaymentValue(Line);
                if (BudgetItemGroupId > 0)
                    return CalculatePaymentValue(BudgetItemGroupId);
                return null;
            }
        }
        private Nullable<decimal> _standardValue;
        public Nullable<decimal> StandardValue
        {
            get
            {
                if (this.Line != null)
                    return this.Line.StandardValue;
                return this._standardValue;
            }
            set
            {
                this._standardValue = value;
            }
        }
        public Nullable<decimal> StandardPercentage { get; set; }

        private Nullable<decimal> _plannedValue;
        public Nullable<decimal> PlannedValue
        {
            get
            {
                if (this.Line != null)
                    return this.Line.PlannedValue;
                return this._plannedValue;
            }
            set
            {
                this._plannedValue = value;
            }
        }

        public Nullable<decimal> PlannedPercentage { get; set; }
        public Nullable<decimal> PlannedToStandard
        {
            get
            {
                if (PlannedValue.HasValue && StandardValue.HasValue && StandardValue.Value != 0)
                    return (PlannedValue.Value / StandardValue.Value - 1);
                return null;
            }
        }

        public Nullable<decimal> _actualValue;
        public Nullable<decimal> ActualValue
        {
            get
            {
                if (this.Line != null)
                    return this.Line.ActualValue;
                return this._actualValue;
            }
            set
            {
                this._actualValue = value;
            }
        }

        public Nullable<decimal> ActualPercentage { get; set; }
        public Nullable<decimal> ActualToPlanned
        {
            get
            {
                if (ActualValue.HasValue && PlannedValue.HasValue && PlannedValue.Value != 0)
                    return (ActualValue.Value / PlannedValue.Value - 1);
                return null;
            }
        }
        public Nullable<decimal> ActualToStandard
        {
            get
            {
                if (ActualValue.HasValue && StandardValue.HasValue && StandardValue.Value != 0)
                    return (ActualValue.Value / StandardValue.Value - 1);
                return null;
            }
        }
        public Nullable<byte> PlannedState
        {
            get
            {
                if (this.Line != null && this.Line.Planned != null)
                    return this.Line.Planned.CalculationState;
                return null;
            }
        }
        public Nullable<byte> ActualState
        {
            get
            {
                if (this.Line != null && this.Line.Actual != null)
                    return this.Line.Actual.CalculationState;
                return null;
            }
        }
        internal void InvokeDataChanged()
        {
            InvokePropertyChanged("StandardValue");
            InvokePropertyChanged("PlannedValue");
            InvokePropertyChanged("ActualValue");
            InvokePropertyChanged("StandardPercentage");
            InvokePropertyChanged("PlannedPercentage");
            InvokePropertyChanged("ActualPercentage");
            InvokePropertyChanged("PlannedToStandard");
            InvokePropertyChanged("ActualToPlanned");
            InvokePropertyChanged("ActualToStandard");
            InvokePropertyChanged("InvoiceValue");
            InvokePropertyChanged("PaymentValue");
            InvokePropertyChanged("PlannedState");
            InvokePropertyChanged("ActualState");
        }
    }
    public class BudgetLineInternal
    {
        private BudgetItemView _budgetItem;
        private BudgetLine[] _lines = new BudgetLine[3];
        public BudgetLineInternal(int id, int budgetId, BudgetItemView budgetItem)
        {
            if (budgetItem == null)
                throw new ArgumentNullException("budgetItem");
            this.Id = id;
            this.BudgetId = budgetId;
            this._budgetItem = budgetItem;
        }
        public int Id { get; private set; }
        public int BudgetId { get; private set; }
        public int BudgetItemId
        {
            get
            {
                return this._budgetItem.Id;
            }
        }
        public int BudgetItemGroupId
        {
            get
            {
                return this._budgetItem.BudgetItemGroupId;
            }
        }
        internal BudgetLine this[int calculationStage]
        {
            get { return this._lines[calculationStage - 1]; }
            set { this._lines[calculationStage - 1] = value; }
        }
        private Nullable<decimal> GetValue(int calculationStage)
        {
            if (this[calculationStage] != null)
                return this[calculationStage].Value;
            return null;
        }
        public BudgetLine Standard
        {
            get { return this[CalculationStage.Standard]; }
        }
        public BudgetLine Planned
        {
            get { return this[CalculationStage.Planned]; }
        }
        public BudgetLine Actual
        {
            get { return this[CalculationStage.Actual]; }
        }
        public Nullable<decimal> StandardValue
        {
            get
            {
                return GetValue(CalculationStage.Standard);
            }
        }
        public Nullable<decimal> PlannedValue
        {
            get
            {
                return GetValue(CalculationStage.Planned);
            }
        }
        public Nullable<decimal> ActualValue
        {
            get
            {
                return GetValue(CalculationStage.Actual);
            }
        }
        [XmlIgnore]
        public string BudgetLineName
        {
            get { return BudgetItem.FileAs; }
        }
        [XmlIgnore]
        public BudgetItemView BudgetItem
        {
            get
            {
                return this._budgetItem;
            }
        }
        public Budget Parent { get; internal set; }
    }
    public class BudgetLine
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public int BudgetId { get; set; }
        [XmlAttribute]
        public int BudgetItemGroupId { get; set; }
        [XmlAttribute]
        public int BudgetItemId { get; set; }
        [XmlAttribute]
        public Nullable<byte> CalculationState { get; set; }
        [XmlAttribute]
        public int CalculationStage { get; set; }
        [XmlAttribute]
        public decimal Value { get; set; }
        [XmlIgnore]
        public Budget Parent
        {
            get;
            internal set;
        }
    }
}
