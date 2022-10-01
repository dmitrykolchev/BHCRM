using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(CalculationStatementTemplateLine))]
    [TypeMapping(typeof(CalculationStatementTemplateSection))]
    [ReportDataSource(typeof(CalculationStatementTemplateReport))]
    partial class CalculationStatementTemplate
    {
        private CalculationStatementTemplateLineCollection _lines;
        private CalculationStatementTemplateSectionCollection _sections;
        private CalculationStatementTemplateItemCollection _items;
        public CalculationStatementTemplateSectionCollection Sections
        {
            get
            {
                if (this._sections == null)
                    this._sections = new CalculationStatementTemplateSectionCollection(this);
                return this._sections;
            }
        }
        public CalculationStatementTemplateLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                    this._lines = new CalculationStatementTemplateLineCollection(this);
                return this._lines;
            }
        }
        [XmlIgnore]
        public CalculationStatementTemplateItemCollection Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = new CalculationStatementTemplateItemCollection(this);
                    this._items.Initialize();
                    this._items.CollectionChanged += ItemsCollectionChanged;
                }
                return this._items;
            }
        }
        void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Items");
        }
        private CalculationStatementTemplateSectionItem _subtotalSectionItem;
        [XmlIgnore]
        public CalculationStatementTemplateSectionItem SubtotalSectionItem
        {
            get
            {
                if (this._subtotalSectionItem == null)
                {
                    this._subtotalSectionItem = new CalculationStatementTemplateSubtotalSectionItem(this);
                }
                return this._subtotalSectionItem;
            }
        }
        internal void InvokeItemPropertyChanged(CalculationStatementTemplateItem item, string propertyName)
        {
            InvokePropertyChanged("Items[]");
        }
        [XmlIgnore]
        public bool IsCostVisible
        {
            get { return this.ExpenseBudgetItemId.HasValue && this.ExpenseBudgetItemId.Value > 0 && !AmountOnly; }
        }
        [XmlIgnore]
        public bool IsPriceVisible
        {
            get { return this.IncomeBudgetItemId.HasValue && this.IncomeBudgetItemId.Value > 0 && !AmountOnly; }
        }
        [XmlIgnore]
        public bool IsIncomeVisible
        {
            get { return IsCostVisible && IsPriceVisible; }
        }
        [XmlIgnore]
        public BudgetTemplate BudgetTemplate
        {
            get
            {
                if(this.BudgetTemplateId > 0)
                    return DocumentManager.GetItem<BudgetTemplate>(this.BudgetTemplateId);
                return null;
            }
        }
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == ExpenseBudgetItemIdProperty)
            {
                InvokePropertyChanged("IsCostVisible");
                InvokePropertyChanged("IsIncomeVisible");
            }
            else if (propertyName == IncomeBudgetItemIdProperty)
            {
                InvokePropertyChanged("IsPriceVisible");
                InvokePropertyChanged("IsIncomeVisible");
            }
            else if (propertyName == AmountOnlyProperty)
            {
                InvokePropertyChanged("IsPriceVisible");
                InvokePropertyChanged("IsCostVisible");
                InvokePropertyChanged("IsIncomeVisible");
            }
        }
    }
}
