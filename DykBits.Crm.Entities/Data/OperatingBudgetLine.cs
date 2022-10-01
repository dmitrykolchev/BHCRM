using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    internal static class IEnumberableExtensions
    {
        public static Nullable<decimal> SumOrNull<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source.Count() > 0)
                return source.Sum(selector);
            return null;
        }
    }
    public class OperatingBudgetLineCollection : DetailDataItemCollection<OperatingBudget, OperatingBudgetLine>
    {
        internal OperatingBudgetLineCollection(OperatingBudget owner)
            : base(owner)
        {
        }
    }
    public class OperatingBudgetLine : DetailDataItem<OperatingBudget>, ICloneable
    {
        private Nullable<decimal> _plannedValue;
        private bool _plannedCalculated;

        private Nullable<decimal> _actualValue;
        private bool _actualCalculated;
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public int ParentId { get; set; }
        [XmlAttribute]
        public int Level { get; set; }
        [XmlAttribute]
        public Nullable<int> BudgetItemGroupId { get; set; }
        [XmlAttribute]
        public Nullable<int> BudgetItemId { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string FileAs { get; set; }
        [XmlAttribute]
        public Nullable<byte> PlannedState { get; set; }
        private Nullable<decimal> CalculatePlannedValue()
        {
            Nullable<decimal> value = null;
            int id = this.Id;
            var lines = this.Parent.Lines.Where(t => t.ParentId == id);
            foreach (var line in lines)
            {
                if (line.PlannedValue.HasValue)
                {
                    if (!value.HasValue)
                        value = 0;
                    value += line.PlannedValue.Value;
                }
            }
            return value;
        }
        [XmlAttribute]
        public Nullable<decimal> PlannedValue
        {
            get
            {
                if (this.Level == 2 || this._plannedCalculated)
                    return this._plannedValue;
                this._plannedValue = CalculatePlannedValue();
                this._plannedCalculated = true;
                return this._plannedValue;
            }
            set
            {
                this._plannedValue = value;
                this._plannedCalculated = false;
            }
        }
        [XmlAttribute]
        public Nullable<byte> ActualState { get; set; }
        private Nullable<decimal> CalculateActualValue()
        {
            Nullable<decimal> value = null;
            int id = this.Id;
            var lines = this.Parent.Lines.Where(t => t.ParentId == id);
            foreach (var line in lines)
            {
                if (line.ActualValue.HasValue)
                {
                    if (!value.HasValue)
                        value = 0;
                    value += line.ActualValue.Value;
                }
            }
            return value;
        }
        [XmlAttribute]
        public Nullable<decimal> ActualValue
        {
            get
            {
                if (this.Level == 2 || this._actualCalculated)
                    return this._actualValue;
                this._actualValue = CalculateActualValue();
                this._actualCalculated = true;
                return _actualValue;
            }
            set
            {
                this._actualValue = value;
                this._actualCalculated = false;
            }
        }

        [XmlIgnore]
        public Nullable<decimal> Deviation
        {
            get
            {
                if (!ActualValue.HasValue && !PlannedValue.HasValue)
                    return null;
                if (!PlannedValue.HasValue)
                    return ActualValue.Value;
                if (!ActualValue.HasValue)
                    return null;
                return ActualValue.Value - PlannedValue.Value;
            }
        }
        [XmlIgnore]
        public int DeviationState
        {
            get
            {
                decimal value = Deviation.GetValueOrDefault();
                return Math.Sign(value);
            }
        }
        [XmlIgnore]
        public Nullable<decimal> ActualToPlanned
        {
            get
            {
                if (PlannedValue.HasValue && PlannedValue.Value != 0)
                    return ActualValue.GetValueOrDefault() / PlannedValue.Value;
                return null;
            }
        }
        public OperatingBudgetLine Clone()
        {
            return new OperatingBudgetLine
            {
                Id = this.Id,
                ParentId = this.ParentId,
                Level = this.Level,
                BudgetItemGroupId = this.BudgetItemGroupId,
                BudgetItemId = this.BudgetItemId,
                Code = this.Code,
                FileAs = this.FileAs,
                PlannedState = this.PlannedState,
                PlannedValue = this.PlannedValue,
                ActualState = this.ActualState,
                ActualValue = this.ActualValue
            };
        }
        [XmlIgnore]
        public bool IsExpense
        {
            get
            {

                OperatingBudgetLine temp = this;
                while(temp.Level > 0)
                    temp = temp.ParentLine;
                return temp.Id == 2;
            }
        }

        private OperatingBudgetLine _parentLine;
        private OperatingBudgetLine ParentLine
        {
            get
            {
                if(this._parentLine == null && this.Level != 0)
                    this._parentLine = this.Parent.Lines.Where(t => t.Id == this.ParentId).SingleOrDefault();
                return this._parentLine;
            }
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        private static Nullable<decimal> CalculateInvoiceValue(OperatingBudgetLine line)
        {
            if (line.Level == 0)
            {
                if (line.Id == 1)
                    return line.Parent.SalesInvoices.SumOrNull(t => t.Value);
                return line.Parent.PurchaseInvoices.SumOrNull(t => t.Value);
            }
            else if (line.Level == 1)
            {
                if(line.ParentId == 1)
                    return line.Parent.SalesInvoices.Where(t=>t.BudgetItemGroupId == line.BudgetItemGroupId).SumOrNull(t => t.Value);
                return line.Parent.PurchaseInvoices.Where(t => t.BudgetItemGroupId == line.BudgetItemGroupId).SumOrNull(t => t.Value);
            }
            else if (line.Level == 2)
            {
                var parentLine = line.Parent.Lines.Where(t => t.Id == line.ParentId).Single();
                if(parentLine.ParentId == 1)
                    return line.Parent.SalesInvoices.Where(t => t.BudgetItemId == line.BudgetItemId).SumOrNull(t => t.Value);
                return line.Parent.PurchaseInvoices.Where(t => t.BudgetItemId == line.BudgetItemId).SumOrNull(t => t.Value);
            }
            return null;
        }
        [XmlIgnore]
        public Nullable<decimal> InvoiceValue
        {
            get
            {
                return CalculateInvoiceValue(this);
            }
        }
        private static Nullable<decimal> CalculatePaymentVale(OperatingBudgetLine line)
        {
            if (line.Level == 0)
            {
                if (line.Id == 1)
                    return line.Parent.PaymentInList.SumOrNull(t => t.Value);
                return line.Parent.PaymentOutList.SumOrNull(t => t.Value);
            }
            else if (line.Level == 1)
            {
                if (line.ParentId == 1)
                    return line.Parent.PaymentInList.Where(t => t.BudgetItemGroupId == line.BudgetItemGroupId).SumOrNull(t => t.Value);
                return line.Parent.PaymentOutList.Where(t => t.BudgetItemGroupId == line.BudgetItemGroupId).SumOrNull(t => t.Value);
            }
            else if (line.Level == 2)
            {
                var parentLine = line.Parent.Lines.Where(t => t.Id == line.ParentId).Single();
                if (parentLine.ParentId == 1)
                    return line.Parent.PaymentInList.Where(t => t.BudgetItemId == line.BudgetItemId).SumOrNull(t => t.Value);
                return line.Parent.PaymentOutList.Where(t => t.BudgetItemId == line.BudgetItemId).SumOrNull(t => t.Value);
            }
            return null;
        }
        [XmlIgnore]
        public Nullable<decimal> PaymentValue
        {
            get
            {
                return CalculatePaymentVale(this);
            }
        }

    }
}
