using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(BudgetLine))]
    [ReportDataSource(typeof(Reports.BudgetReport))]
    partial class Budget
    {

        private BudgetLineCollection _lines;
        private BudgetLineInternalCollection _linesInternal;
        private IList<BudgetItemView> _budgetItems;
        private IList<BudgetItemGroupView> _budgetItemsGroups;
        private ServiceRequest _serviceRequest;
        private Nullable<int> _newAmountOfGuests;
        public Nullable<int> NewAmountOfGuests
        {
            get
            {
                if (this._newAmountOfGuests == null)
                    return this.AmountOfGuests;
                return this._newAmountOfGuests;
            }
            set
            {
                this._newAmountOfGuests = value;
            }
        }
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == ServiceRequestIdProperty)
                this._serviceRequest = null;
        }

        [XmlIgnore]
        public ServiceRequest ServiceRequest
        {
            get
            {
                if (this.ServiceRequestId == 0)
                    return null;
                if (this._serviceRequest == null)
                {
                    this._serviceRequest = DocumentManager.GetItem<ServiceRequest>(this.ServiceRequestId);
                }
                return this._serviceRequest;
            }
        }
        private IList<PurchaseInvoiceView> _purchaseInvoices;
        [XmlIgnore]
        public IList<PurchaseInvoiceView> PurchaseInvoices
        {
            get
            {
                if (this._purchaseInvoices == null)
                {
                    PurchaseInvoiceFilter filter = new PurchaseInvoiceFilter { AllStates = true, BudgetId = this.Id };
                    this._purchaseInvoices = DocumentManager.Browse<PurchaseInvoiceView>(filter);
                }
                return this._purchaseInvoices;
            }
        }
        private IList<SalesInvoiceView> _salesInvoices;
        [XmlIgnore]
        public IList<SalesInvoiceView> SalesInvoices
        {
            get
            {
                if (this._salesInvoices == null)
                {
                    SalesInvoiceFilter filter = new SalesInvoiceFilter { AllStates = true, BudgetId = this.Id };
                    this._salesInvoices = DocumentManager.Browse<SalesInvoiceView>(filter);
                }
                return this._salesInvoices;
            }
        }

        private IList<SalesOrderView> _salesOrders;
        [XmlIgnore]
        public IList<SalesOrderView> SalesOrders
        {
            get
            {
                if (this._salesOrders == null)
                {
                    SalesOrderFilter filter = new SalesOrderFilter { AllStates = true, BudgetId = this.Id };
                    this._salesOrders = DocumentManager.Browse<SalesOrderView>(filter);
                }
                return this._salesOrders;
            }
        }

        private IList<MoneyOperationView> _paymentInList;
        [XmlIgnore]
        public IList<MoneyOperationView> PaymentInList
        {
            get
            {
                if (this._paymentInList == null)
                {
                    var filter = new MoneyOperationFilter { AllStates = true, BudgetId = this.Id, MoneyOperationDirection = MoneyOperationDirection.Incoming, IncludeChildren = false };
                    this._paymentInList = DocumentManager.Browse<MoneyOperationView>(filter);
                }
                return this._paymentInList;
            }
        }

        private IList<MoneyOperationView> _paymentOutList;
        [XmlIgnore]
        public IList<MoneyOperationView> PaymentOutList
        {
            get
            {
                if (this._paymentOutList == null)
                {
                    var filter = new MoneyOperationFilter { AllStates = true, BudgetId = this.Id, MoneyOperationDirection = MoneyOperationDirection.Outgoing, IncludeChildren = true };
                    this._paymentOutList = DocumentManager.Browse<MoneyOperationView>(filter);
                }
                return this._paymentOutList;
            }
        }
        public BudgetLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                    this._lines = new BudgetLineCollection(this);
                return this._lines;
            }
        }
        [XmlIgnore]
        public BudgetLineInternalCollection LinesInternal
        {
            get
            {
                if (this._linesInternal == null)
                {
                    this._linesInternal = new BudgetLineInternalCollection(this);
                    this._linesInternal.Initialize();
                }
                return this._linesInternal;
            }
        }

        [XmlIgnore]
        internal IList<BudgetItemView> BudgetItems
        {
            get
            {
                if (this._budgetItems == null)
                {
                    this._budgetItems = ListManager.GetList<BudgetItemView, string>(
                        t => { return t.BudgetItemGroupType == BudgetItemGroupType.ProjectsGroup; }, 
                        t => { return t.Code; }
                        );
                }
                return this._budgetItems;
            }
        }

        [XmlIgnore]
        internal IList<BudgetItemGroupView> BudgetItemGroups
        {
            get
            {
                if (this._budgetItemsGroups == null)
                {
                    this._budgetItemsGroups = ListManager.GetList<BudgetItemGroupView, string>(
                        t => { return t.BudgetItemGroupType == BudgetItemGroupType.ProjectsGroup; },
                        t => { return t.Code; } );
                }
                return this._budgetItemsGroups;
            }
        }

        private BudgetLineProxyCollection _items;
        [XmlIgnore]
        public BudgetLineProxyCollection Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = new BudgetLineProxyCollection(this);
                    foreach (var line in LinesInternal.OrderBy(t => t.BudgetItem.Code))
                    {
                        this._items.Add(line);
                    }
                    this._items.RecalculateFixedLines();
                }
                return this._items;
            }
        }

        public void RefreshItems()
        {
            this._paymentInList = null;
            this._paymentOutList = null;
            this._purchaseInvoices = null;
            this._salesInvoices = null;
            Budget budget = DocumentManager.GetItem<Budget>(this.Id);
            foreach (var line in budget.LinesInternal.OrderBy(t => t.BudgetItem.Code))
            {
                BudgetLineProxy itemProxy = FindItemForLine(line);
                itemProxy.Line = line;
            }
            this._items.RecalculateFixedLines();
        }

        private BudgetLineProxy FindItemForLine(BudgetLineInternal line)
        {
            foreach (var item in Items)
                if (item.BudgetItemId == line.BudgetItemId)
                    return item;
            return null;
        }
    }

    public class BudgetLineProxyCollection : Collection<BudgetLineProxy>
    {
        private BudgetLineProxy GeneralActivityLine = new BudgetLineProxy { Id = 1, ParentId = 0, Level = 0, FileAs = "Основной" };
        private BudgetLineProxy AdditionalActivityLine = new BudgetLineProxy { Id = 2, ParentId = 0, Level = 0, FileAs = "Дополнительный" };
        private BudgetLineProxy TotalProfitabilityLine = new BudgetLineProxy { Id = 3, ParentId = 0, Level = 0, FileAs = "Рентабельность" };
        private BudgetLineProxy GeneralIncomeLine = new BudgetLineProxy { Id = 4, ParentId = 1, BudgetItemGroupId = BudgetItemGroup.Доходы_по_ОВД, Level = 1, FileAs = "Доходы" };
        private BudgetLineProxy GeneralExpenseLine = new BudgetLineProxy { Id = 5, ParentId = 1, BudgetItemGroupId = BudgetItemGroup.Расходы_по_ОВД, Level = 1, FileAs = "Расходы" };
        private BudgetLineProxy GeneralProfitabilityLine = new BudgetLineProxy { Id = 6, ParentId = 1, Level = 1, FileAs = "Рентабельность" };
        private BudgetLineProxy AdditionalIncomeLine = new BudgetLineProxy { Id = 7, ParentId = 2, BudgetItemGroupId = BudgetItemGroup.Прочие_доходы, Level = 1, FileAs = "Доходы" };
        private BudgetLineProxy AdditionalExpenseLine = new BudgetLineProxy { Id = 8, ParentId = 2, BudgetItemGroupId = BudgetItemGroup.Прочие_расходы, Level = 1, FileAs = "Расходы" };
        private BudgetLineProxy AdditionalProfitabilityLine = new BudgetLineProxy { Id = 9, ParentId = 2, Level = 1, FileAs = "Рентабельность" };
        private Budget _owner;
        public BudgetLineProxyCollection(Budget owner)
        {
            this._owner = owner;
            Add(GeneralActivityLine);           // 0
            Add(AdditionalActivityLine);        // 1
            Add(TotalProfitabilityLine);        // 2
            Add(GeneralIncomeLine);             // 3
            Add(GeneralExpenseLine);            // 4
            Add(GeneralProfitabilityLine);      // 5
            Add(AdditionalIncomeLine);          // 6
            Add(AdditionalExpenseLine);         // 7
            Add(AdditionalProfitabilityLine);   // 8
        }

        protected override void InsertItem(int index, BudgetLineProxy item)
        {
            item.Parent = this._owner;
            base.InsertItem(index, item);
        }

        internal void RecalculateFixedLines()
        {
            RecalculateLine(GeneralIncomeLine);
            RecalculateLine(GeneralExpenseLine);
            RecalculateLine(AdditionalIncomeLine);
            RecalculateLine(AdditionalExpenseLine);

            RecalculateFixedLine(GeneralProfitabilityLine, GeneralIncomeLine, GeneralExpenseLine);
            RecalculateFixedLine(AdditionalProfitabilityLine, AdditionalIncomeLine, AdditionalExpenseLine);

            if (GeneralProfitabilityLine.StandardValue.HasValue || AdditionalProfitabilityLine.StandardValue.HasValue)
                TotalProfitabilityLine.StandardValue = GeneralProfitabilityLine.StandardValue.GetValueOrDefault() + AdditionalProfitabilityLine.StandardValue.GetValueOrDefault();
            else
                TotalProfitabilityLine.StandardValue = null;
            if (GeneralProfitabilityLine.PlannedValue.HasValue || AdditionalProfitabilityLine.PlannedValue.HasValue)
                TotalProfitabilityLine.PlannedValue = GeneralProfitabilityLine.PlannedValue.GetValueOrDefault() + AdditionalProfitabilityLine.PlannedValue.GetValueOrDefault();
            else
                TotalProfitabilityLine.PlannedValue = null;
            if (GeneralProfitabilityLine.ActualValue.HasValue || AdditionalProfitabilityLine.ActualValue.HasValue)
                TotalProfitabilityLine.ActualValue = GeneralProfitabilityLine.ActualValue.GetValueOrDefault() + AdditionalProfitabilityLine.ActualValue.GetValueOrDefault();
            else
                TotalProfitabilityLine.ActualValue = null;

            if (GeneralIncomeLine.StandardValue.GetValueOrDefault() + AdditionalIncomeLine.StandardValue.GetValueOrDefault() != 0)
                TotalProfitabilityLine.StandardPercentage = TotalProfitabilityLine.StandardValue.GetValueOrDefault() / (GeneralIncomeLine.StandardValue.GetValueOrDefault() + AdditionalIncomeLine.StandardValue.GetValueOrDefault());
            else
                TotalProfitabilityLine.StandardPercentage = null;
            if (GeneralIncomeLine.PlannedValue.GetValueOrDefault() + AdditionalIncomeLine.PlannedValue.GetValueOrDefault() != 0)
                TotalProfitabilityLine.PlannedPercentage = TotalProfitabilityLine.PlannedValue.GetValueOrDefault() / (GeneralIncomeLine.PlannedValue.GetValueOrDefault() + AdditionalIncomeLine.PlannedValue.GetValueOrDefault());
            else
                TotalProfitabilityLine.PlannedPercentage = null;

            if (GeneralIncomeLine.ActualValue.GetValueOrDefault() + AdditionalIncomeLine.ActualValue.GetValueOrDefault() != 0)
                TotalProfitabilityLine.ActualPercentage = TotalProfitabilityLine.ActualValue.GetValueOrDefault() / (GeneralIncomeLine.ActualValue.GetValueOrDefault() + AdditionalIncomeLine.ActualValue.GetValueOrDefault());
            else
                TotalProfitabilityLine.ActualPercentage = null;
            TotalProfitabilityLine.InvokeDataChanged();
        }
        private void RecalculateFixedLine(BudgetLineProxy profitability, BudgetLineProxy income, BudgetLineProxy expense)
        {
            if (income.StandardValue.HasValue || expense.StandardValue.HasValue)
                profitability.StandardValue = income.StandardValue.GetValueOrDefault() - expense.StandardValue.GetValueOrDefault();
            else
                profitability.StandardValue = null;
            if (income.PlannedValue.HasValue || expense.PlannedValue.HasValue)
                profitability.PlannedValue = income.PlannedValue.GetValueOrDefault() - expense.PlannedValue.GetValueOrDefault();
            else
                profitability.PlannedValue = null;
            if (income.ActualValue.HasValue || expense.ActualValue.HasValue)
                profitability.ActualValue = income.ActualValue.GetValueOrDefault() - expense.ActualValue.GetValueOrDefault();
            else
                profitability.ActualValue = null;

            if (income.StandardValue.GetValueOrDefault() != 0)
                profitability.StandardPercentage = profitability.StandardValue.GetValueOrDefault() / income.StandardValue.GetValueOrDefault();
            else
                profitability.StandardPercentage = null;
            if (income.PlannedValue.GetValueOrDefault() != 0)
                profitability.PlannedPercentage = profitability.PlannedValue.GetValueOrDefault() / income.PlannedValue.GetValueOrDefault();
            else
                profitability.PlannedPercentage = null;
            if (income.ActualValue.GetValueOrDefault() != 0)
                profitability.ActualPercentage = profitability.ActualValue.GetValueOrDefault() / income.ActualValue.GetValueOrDefault();
            else
                profitability.ActualPercentage = null;
            profitability.InvokeDataChanged();
        }
        private void RecalculateLine(BudgetLineProxy line)
        {
            Nullable<decimal> standard = null;
            Nullable<decimal> planned = null;
            Nullable<decimal> actual = null;
            foreach (var item in this.Where(t => t.ParentId == line.Id))
            {
                if (item.StandardValue.HasValue)
                {
                    if (!standard.HasValue)
                        standard = 0;
                    standard += item.StandardValue.Value;
                }
                if (item.PlannedValue.HasValue)
                {
                    if (!planned.HasValue)
                        planned = 0;
                    planned += item.PlannedValue.Value;
                }
                if (item.ActualValue.HasValue)
                {
                    if (!actual.HasValue)
                        actual = 0;
                    actual += item.ActualValue.Value;
                }
            }
            line.StandardValue = standard;
            line.PlannedValue = planned;
            line.ActualValue = actual;
            line.InvokeDataChanged();
        }

        private static int[] parentIds = new int[] { 0, 4, 5, 7, 8 };
        public void Add(BudgetLineInternal line)
        {
            this.Add(new BudgetLineProxy
            {
                Id = line.Id + 100,
                BudgetItemId = line.BudgetItemId,
                ParentId = parentIds[line.BudgetItemGroupId],
                Level = 2,
                FileAs = line.BudgetLineName,
                Line = line
            });
        }
    }

    public class BudgetLineCollection : Collection<BudgetLine>
    {
        private Budget _owner;
        public BudgetLineCollection(Budget owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, BudgetLine item)
        {
            item.Parent = this._owner;
            base.InsertItem(index, item);
        }
    }

    public class BudgetLineInternalCollection : Collection<BudgetLineInternal>
    {
        private Budget _owner;
        private Dictionary<int, BudgetLineInternal> _linesByItemId = new Dictionary<int, BudgetLineInternal>();
        public BudgetLineInternalCollection(Budget owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, BudgetLineInternal item)
        {
            item.Parent = this._owner;
            base.InsertItem(index, item);
        }
        internal void Initialize()
        {
            int count = 0;
            var usedBudgetItems = this._owner.Lines.Select(t => t.BudgetItemId).Distinct().ToArray();
            foreach (var item in this._owner.BudgetItems.Where(t => t.State == BudgetItemState.Active || usedBudgetItems.Contains(t.Id)))
            {
                
                var line = new BudgetLineInternal(++count, this._owner.Id, (BudgetItemView)item);
                this._linesByItemId.Add(item.Id, line);
                this.Add(line);
            }
            foreach (var line in this._owner.Lines)
            {
                this._linesByItemId[line.BudgetItemId][line.CalculationStage] = line;
            }
        }
    }
}
