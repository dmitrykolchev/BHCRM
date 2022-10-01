using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class InvoiceByBudgetItemItem: XmlSerializableDataItem
    {
        private BudgetItemGroupView _budgetItemGroup;
        private BudgetItemView _budgetItem;

        [XmlIgnore]
        public BudgetItemGroupView BudgetItemGroup
        {
            get
            {
                if (this.BudgetItemGroupId.HasValue)
                {
                    if (this._budgetItemGroup == null)
                        this._budgetItemGroup = ListManager.GetItem<BudgetItemGroupView>(this.BudgetItemGroupId.Value);
                    return this._budgetItemGroup;
                }
                return null;
            }
        }
        [XmlIgnore]
        public BudgetItemView BudgetItem
        {
            get
            {
                if (this.BudgetItemId.HasValue)
                {
                    if (this._budgetItem == null)
                        this._budgetItem = ListManager.GetItem<BudgetItemView>(this.BudgetItemId.Value);
                    return this._budgetItem;
                }
                return null;
            }
        }
        [XmlIgnore]
        public string BudgetItemGroupCode
        {
            get
            {
                return this.BudgetItemGroup != null ? this.BudgetItemGroup.Code : null;
            }
        }
        [XmlIgnore]
        public string BudgetItemCode
        {
            get
            {
                return this.BudgetItem != null ? this.BudgetItem.Code : null;
            }
        }
        [XmlAttribute]
        public Nullable<int> BudgetItemGroupId { get; set; }
        [XmlAttribute]
        public Nullable<int> BudgetItemId { get; set; }
        [XmlAttribute]
        public int Direction { get; set; }
        [XmlIgnore]
        public string DirectionName
        {
            get
            {
                if (Direction == -1)
                    return "Полученные  поставщиков";
                return "Выставленные счета";
            }
        }
        [XmlAttribute]
        public Nullable<decimal> InvoiceValue { get; set; }
        [XmlAttribute]
        public Nullable<decimal> InvoiceVATValue { get; set; }
    }

    public class InvoiceByBudgetItemFilter : Filter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            this.States = new byte[] { (byte)SalesInvoiceState.Draft, (byte)SalesInvoiceState.Approved, (byte)SalesInvoiceState.Payed };
            base.InitializeDefaults(dataContext, parameter);
        }
    }

}
