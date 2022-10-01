using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(CalculationStatementLine))]
    [TypeMapping(typeof(CalculationStatementSection))]
    [ReportDataSource(typeof(CalculationStatementReport))]
    partial class CalculationStatement: ICloneable
    {
        private ServiceRequest _serviceRequest;
        public const string IsCostVisibleProperty = "IsCostVisible";
        public const string IsPriceVisibleProperty = "IsPriceVisible";
        public const string IsIncomeVisibleProperty = "IsIncomeVisible";
        public const string IsVATRateVisibleProperty = "IsVATRateVisible";
        private Budget _budget;
        [XmlIgnore]
        public ServiceRequest ServiceRequest
        {
            get
            {
                if (this.ServiceRequestId > 0)
                {
                    if (this._serviceRequest == null)
                    {
                        this._serviceRequest = DocumentManager.GetItem<ServiceRequest>(this.ServiceRequestId);
                    }
                    return this._serviceRequest;
                }
                return null;
            }
        }
        [XmlIgnore]
        public Budget Budget
        {
            get
            {
                if (this.BudgetId > 0)
                {
                    if (this._budget == null)
                        this._budget = DocumentManager.GetItem<Budget>(this.BudgetId);
                    return this._budget;
                }
                return null;
            }
        }
        [XmlIgnore]
        public Nullable<int> AmountOfGuests
        {
            get
            {
                if (this.Budget != null)
                    return this.Budget.AmountOfGuests;
                return null;
            }
        }
        [XmlIgnore]
        public Nullable<int> EventDuration
        {
            get
            {
                if (this.Budget != null)
                    return this.Budget.EventDuration;
                return null;
            }
        }
        private CalculationStatementLineCollection _lines;
        private CalculationStatementSectionCollection _sections;
        private CalculationStatementItemCollection _items;
        public CalculationStatementSectionCollection Sections
        {
            get
            {
                if (this._sections == null)
                    this._sections = new CalculationStatementSectionCollection(this);
                return this._sections;
            }
        }
        public CalculationStatementLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                    this._lines = new CalculationStatementLineCollection(this);
                return this._lines;
            }
        }
        [XmlIgnore]
        public CalculationStatementItemCollection Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = new CalculationStatementItemCollection(this);
                    this._items.Initialize();
                    this._items.CollectionChanged += ItemsCollectionChanged;
                }
                return this._items;
            }
        }
        public CalculationStatementLineItem CreateItem(CalculationStatementSectionItem sectionItem, CalculationStatementLine line)
        {
            switch (IncomeBudgetItemId)
            {
                case BudgetItem.Доходы_по_ОВД_Меню:
                    return new CalculationStatementLineMenuItem(sectionItem, line);
                case BudgetItem.Доходы_по_ОВД_Напитки_алкогольные:
                case BudgetItem.Доходы_по_ОВД_Напитки_безалкогольные:
                    return new CalculationStatementLineBeverageItem(sectionItem, line);
                default:
                    return new CalculationStatementLineProductItem(sectionItem, line);
            }
        }
        void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Items");
        }
        private CalculationStatementSectionItem _subtotalSectionItem;
        [XmlIgnore]
        public CalculationStatementSectionItem SubtotalSectionItem
        {
            get
            {
                if (this._subtotalSectionItem == null)
                {
                    this._subtotalSectionItem = new CalculationStatementSubtotalSectionItem(this);
                }
                return this._subtotalSectionItem;
            }
        }
        private CalculationStatementSectionItem _subtotalWithDiscountSectionItem;
        [XmlIgnore]
        public CalculationStatementSectionItem SubtotalWithDiscountSectionItem
        {
            get
            {
                if (this._subtotalWithDiscountSectionItem == null)
                    this._subtotalWithDiscountSectionItem = new CalculationStatementSubtotalWithDiscountSectionItem(this);
                return this._subtotalWithDiscountSectionItem;
            }
        }

        private CalculationStatementSectionItem _subtotalWithVATSectionItem;
        [XmlIgnore]
        public CalculationStatementSectionItem SubtotalWithVATSectionItem
        {
            get
            {
                if (this._subtotalWithVATSectionItem == null)
                    this._subtotalWithVATSectionItem = new CalculationStatementSubtotalWithVATSectionItem(this);
                return this._subtotalWithVATSectionItem;
            }
        }
        internal void InvokeItemPropertyChanged(CalculationStatementItem item, string propertyName)
        {
            InvokePropertyChanged("Items[]");
        }
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == ExpenseBudgetItemIdProperty)
            {
                InvokePropertyChanged(IsCostVisibleProperty);
                InvokePropertyChanged(IsIncomeVisibleProperty);
            }
            else if (propertyName == IncomeBudgetItemIdProperty)
            {
                InvokePropertyChanged(IsPriceVisibleProperty);
                InvokePropertyChanged(IsIncomeVisibleProperty);
            }
            else if (propertyName == DiscountProperty || propertyName == VATRateIdProperty)
            {
                SubtotalWithDiscountSectionItem.InvokeSectionChangedInternal();
                SubtotalWithVATSectionItem.InvokeSectionChangedInternal();
            }
            else if (propertyName == IncomeBudgetItemIdProperty)
            {
                InvokePropertyChanged(IsVATRateVisibleProperty);
            }
        }
        [XmlIgnore]
        public bool IsCostVisible
        {
            get { return this.ExpenseBudgetItemId.HasValue; }
        }

        [XmlIgnore]
        public bool IsPriceVisible
        {
            get { return this.IncomeBudgetItemId.HasValue; }
        }
        [XmlIgnore]
        public bool IsIncomeVisible
        {
            get { return this.IsCostVisible && this.IsPriceVisible; }
        }
        public bool IsVATRateVisible
        {
            get { return this.IncomeBudgetItemId.HasValue; }
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        public CalculationStatement Clone()
        {
            CalculationStatement source = this;
            CalculationStatement that = new CalculationStatement();

            that.DocumentDate = DateTime.Today;
            that.OrganizationId = source.OrganizationId;
            that.ServiceRequestId = source.ServiceRequestId;
            that.BudgetId = source.BudgetId;
            that.CalculationStage = source.CalculationStage;
            that.IncomeBudgetItemId = source.IncomeBudgetItemId;
            that.ExpenseBudgetItemId = source.ExpenseBudgetItemId;
            that.DependsOnAmountOfPersons = source.DependsOnAmountOfPersons;
            that.AmountOnly = source.AmountOnly;
            that.VATRateId = source.VATRateId;
            that.Margin = source.Margin;
            that.Discount = source.Discount;
            that.ResponsibleEmployeeId = source.ResponsibleEmployeeId;
            that.Comments = source.Comments;

            foreach (var item in source.Sections)
            {
                that.Sections.Add(new CalculationStatementSection
                {
                    CalculationStatementSectionId = item.CalculationStatementSectionId,
                    OrdinalPosition = item.OrdinalPosition,
                    FileAs = item.FileAs,
                    ProductCategoryId = item.ProductCategoryId,
                    Comments = item.Comments,
                    StandardAmount = item.StandardAmount,
                    StandardTotalCost = item.StandardTotalCost,
                    StandardTotalPrice = item.StandardTotalPrice
                });
            }
            
            foreach (var line in source.Lines)
            {
                that.Lines.Add(new CalculationStatementLine
                {
                    CalculationStatementSectionId = line.CalculationStatementSectionId,
                    OrdinalPosition = line.OrdinalPosition,
                    ProductId = line.ProductId,
                    FileAs = line.FileAs,
                    Comments = line.Comments,
                    StartTime = line.StartTime,
                    EndTime = line.EndTime,
                    Amount = line.Amount,
                    Factor = line.Factor,
                    Price = line.Price,
                    Cost = line.Cost
                });
            }
            return that;
        }
    }
}
