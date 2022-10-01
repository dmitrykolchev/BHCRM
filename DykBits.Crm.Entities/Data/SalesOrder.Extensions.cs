using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(SalesOrderLine))]
    [ReportDataSource(typeof(Reports.SalesOrderReport))]
    partial class SalesOrder
    {
        private SalesOrderLineCollection _lines;
        public const string BudgetItemsProperty = "BudgetItems";
        public const string BudgetItemGroupsProperty = "BudgetItemGroups";

        public ObservableCollection<SalesOrderLine> Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new SalesOrderLineCollection(this);
                    this._lines.CollectionChanged += _lines_CollectionChanged;
                }
                return this._lines;
            }
        }

        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Lines");
        }
        [XmlIgnore]
        public Nullable<int> BudgetIdUI
        {
            get { return this.BudgetId; }
            set
            {
                this.BudgetId = value;
                InvokePropertyChanged();
                this._budgetItemGroups = null;
                this._budgetItems = null;
                InvokePropertyChanged(BudgetItemGroupsProperty);
                InvokePropertyChanged(BudgetItemsProperty);
            }
        }
        [XmlIgnore]
        public Nullable<int> BudgetItemGroupIdUI
        {
            get { return this.BudgetItemGroupId; }
            set
            {
                this.BudgetItemGroupId = value;
                InvokePropertyChanged();
                this._budgetItems = null;
                InvokePropertyChanged(BudgetItemsProperty);
            }
        }
        [XmlIgnore]
        public Nullable<int> BudgetItemIdUI
        {
            get { return this.BudgetItemId; }
            set
            {
                this.BudgetItemId = value;
                InvokePropertyChanged();
            }
        }
        private IList<BudgetItemGroupView> _budgetItemGroups;
        [XmlIgnore]
        public IList<BudgetItemGroupView> BudgetItemGroups
        {
            get
            {
                if(!this.BudgetId.HasValue)
                    return null;
                if (this._budgetItemGroups == null)
                {
                    this._budgetItemGroups = ListManager.GetList<BudgetItemGroupView>((t) =>
                    {
                        return t.BudgetItemGroupType == BudgetItemGroupType.ProjectsGroup && t.IsExpenseGroup;
                    });
                }
                return this._budgetItemGroups;
            }
        }
        private IList<BudgetItemView> _budgetItems;
        [XmlIgnore]
        public IList<BudgetItemView> BudgetItems
        {
            get
            {
                if (!this.BudgetId.HasValue)
                    return null;
                if (this._budgetItems == null)
                {
                    Nullable<int> budgetItemGroupId = this.BudgetItemGroupId;
                    this._budgetItems = ListManager.GetList<BudgetItemView>((t) =>
                    {
                        return t.BudgetItemGroupId == budgetItemGroupId && t.Id != BudgetItem.Расходы_по_ОВД_НДС && t.Id != BudgetItem.Прочие_расходы_НДС;
                    });
                }
                return this._budgetItems;
            }
        }
    }
}
