using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(PayrollLine))]
    partial class Payroll : IOperatingBudgetDocument, ICloneable
    {
        private PayrollLineCollection _lines;
        private PayrollItemCollection _items;
        public PayrollLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new PayrollLineCollection(this);
                    this._lines.CollectionChanged += _lines_CollectionChanged;
                }
                return this._lines;
            }
        }

        [XmlIgnore]
        public PayrollItemCollection Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = new PayrollItemCollection(this);
                    this._items.Initialize();
                    this._items.CollectionChanged += _items_CollectionChanged;
                }
                return this._items;
            }
        }

        void _items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Items");
        }

        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Lines");
        }

        public Payroll Clone()
        {
            var source = this;
            var that = new Payroll
            {
                DocumentDate = source.DocumentDate,
                OrganizationId = source.OrganizationId,
                OperatingBudgetId = source.OperatingBudgetId,
                SalaryBudgetItemId = source.SalaryBudgetItemId,
                TaxBudgetItemId = source.TaxBudgetItemId,
                CashingBudgetItemId = source.CashingBudgetItemId,
                ExtraCostRateId = source.ExtraCostRateId,
                CalculationStage = source.CalculationStage,
                Comments = source.Comments
            };
            foreach (var line in source.Lines)
            {
                that.Lines.Add(new PayrollLine
                {
                    OrdinalPosition = line.OrdinalPosition,
                    AccountId = line.AccountId,
                    FileAs = line.FileAs,
                    Comments = line.Comments,
                    Cashing = line.Cashing,
                    DivisionId = line.DivisionId,
                    EmployeeId = line.EmployeeId,
                    IncomeTax = line.IncomeTax,
                    PositionId = line.PositionId,
                    SalaryBase = line.SalaryBase,
                    SalaryTotal = line.SalaryTotal,
                    SocialTax = line.SocialTax
                });
            }
            return that;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

        int IOperatingBudgetDocument.BudgetItemId
        {
            get
            {
                return this.SalaryBudgetItemId;
            }
            set
            {
                this.SalaryBudgetItemId = value;
            }
        }
    }
}
