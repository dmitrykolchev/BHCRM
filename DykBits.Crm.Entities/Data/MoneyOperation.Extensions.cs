using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class MoneyOperationDirection
    {
        public const int Incoming = 1;
        public const int Outgoing = -1;
    }
    partial class MoneyOperation
    {
        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == BankAccountIdProperty)
            {
                if (this.BankAccountId == 0)
                    return "Выберите расчетный счет из выпадающего списка";
            }
            else if (propertyInfo.Name == MoneyOperationTypeIdUIProperty)
            {
                if (this.MoneyOperationTypeId == 0)
                    return "Выберите тип операции из выпадающего списка";
            }
            else if (propertyInfo.Name == OrganizationIdUIProperty)
            {
                if (this.OrganizationId == 0)
                    return "Выберите организацию";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }

        private const int DirectionIncoming = 1;
        private const int DirectionOutgoing = -1;

        public const string DestinationBankAccountIdProperty = "DestinationBankAccountId";
        public const string MoneyOperationTypeIdUIProperty = "MoneyOperationTypeIdUI";
        public const string OrganizationIdUIProperty = "OrganizationIdUI";

        private Nullable<int> _DestinationBankAccountIdField;
        public Nullable<int> DestinationBankAccountId
        {
            get { return this._DestinationBankAccountIdField; }
            set
            {
                this._DestinationBankAccountIdField = value;
                InvokePropertyChanged();
            }
        }
        public IList<MoneyOperationView> GetChildren()
        {
            MoneyOperationFilter filter = new MoneyOperationFilter { AllStates = true, ParentId = this.Id, IncludeChildren = true };
            return DocumentManager.Browse<MoneyOperationView>(filter);
        }
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == VATRateIdProperty)
            {
                InvokePropertyChanged("IsVATRateReadOnly");
            }
            else if (propertyName == "MoneyOperationTypeIdUI")
            {
                ValidateBudgetItemGroups();
                ValidateBudgetItems();
            }
            else if (propertyName == "BudgetIdUI")
            {
                this.BudgetItemGroupIdUI = null;
                ValidateBudgetItemGroups();
                ValidateBudgetItems();
            }
            else if (propertyName == "OperatingBudgetIdUI")
            {
                this.BudgetItemGroupIdUI = null;
                ValidateBudgetItemGroups();
                ValidateBudgetItems();
            }
            else if (propertyName == "BudgetItemGroupIdUI")
            {
                this.BudgetItemIdUI = null;
                ValidateBudgetItems();
            }
            else if (propertyName == "OrganizationIdUI")
            {
                this.BankAccountId = 0;
                this.DestinationBankAccountId = 0;
                this.EmployeeId = null;
                this.BudgetIdUI = null;
                this.OperatingBudgetIdUI = null;
                this.PurchaseInvoiceIdUI = null;
                this.SalesInvoiceIdUI = null;
                this.AccountIdUI = 0;
                ValidateBankAccounts();
            }
        }
        [XmlIgnore]
        public int OrganizationIdUI
        {
            get { return this.OrganizationId; }
            set
            {
                this.OrganizationId = value;
                InvokePropertyChanged();
            }
        }

        private void ValidateBankAccounts()
        {
            if (this._bankAccounts == null)
                this._bankAccounts = new ObservableCollection<BankAccountView>();
            IList<BankAccountView> list = ListManager.GetList<BankAccountView>(t => t.AccountId == this.OrganizationId);
            this._bankAccounts.Clear();
            foreach (var item in list)
                this._bankAccounts.Add(item);
        }

        ObservableCollection<BankAccountView> _bankAccounts;
        [XmlIgnore]
        public ObservableCollection<BankAccountView> BankAccounts
        {
            get
            {
                if (this._bankAccounts == null)
                    ValidateBankAccounts();
                return this._bankAccounts;
            }
        }
        private void ValidateBudgetItemGroups()
        {
            if (this._budgetItemGroups == null)
                this._budgetItemGroups = new ObservableCollection<BudgetItemGroupView>();
            int groupType;
            if (BudgetIdUI.HasValue)
                groupType = BudgetItemGroupType.ProjectsGroup;
            else if (OperatingBudgetIdUI.HasValue)
                groupType = BudgetItemGroupType.OperationsGroup;
            else
                groupType = BudgetItemGroupType.MiscGroup;
            bool isExpense = this.IsExpense == true;
            IList<BudgetItemGroupView> groups = ListManager.GetList<BudgetItemGroupView>(t => t.BudgetItemGroupType == groupType && t.IsExpenseGroup == isExpense);
            this._budgetItemGroups.Clear();
            if (groups != null)
            {
                foreach (var item in groups)
                    this._budgetItemGroups.Add(item);
            }
        }

        private void ValidateBudgetItems()
        {
            if (this._budgetItems == null)
                this._budgetItems = new ObservableCollection<BudgetItemView>();
            var budgetItemGroupId = this.BudgetItemGroupId;
            var isExpense = this.IsExpense;
            IList<BudgetItemView> items = null;
            if (isExpense == false)
            {
                items = ListManager.GetList<BudgetItemView>(t => t.BudgetItemGroupId == budgetItemGroupId && t.Id != BudgetItem.Прочие_доходы_НДС && t.Id != BudgetItem.Доходы_по_ОВД_НДС);
            }
            else if (isExpense == true)
            {
                items = ListManager.GetList<BudgetItemView>(t => t.BudgetItemGroupId == budgetItemGroupId && t.Id != BudgetItem.Прочие_расходы_НДС && t.Id != BudgetItem.Расходы_по_ОВД_НДС);
            }
            this._budgetItems.Clear();
            if (items != null)
            {
                foreach (var item in items)
                    this._budgetItems.Add(item);
            }
        }

        private ObservableCollection<BudgetItemGroupView> _budgetItemGroups;
        [XmlIgnore]
        public ObservableCollection<BudgetItemGroupView> BudgetItemsGroups
        {
            get
            {
                if (this._budgetItemGroups == null)
                    ValidateBudgetItemGroups();
                return this._budgetItemGroups;
            }
        }

        public ObservableCollection<BudgetItemView> _budgetItems;
        [XmlIgnore]
        public ObservableCollection<BudgetItemView> BudgetItems
        {
            get
            {
                if (this._budgetItems == null)
                    ValidateBudgetItems();
                return this._budgetItems;
            }
        }
        [XmlIgnore]
        public bool IsVATRateReadOnly
        {
            get
            {
                return this.VATRateId.HasValue && this.VATRateId.Value != 0;
            }
        }
        [XmlIgnore]
        public Nullable<bool> IsExpense
        {
            get
            {
                switch (this.MoneyOperationTypeId)
                {
                    case MoneyOperationType.Advance:
                    case MoneyOperationType.PaymentOut:
                    case MoneyOperationType.Transfer:
                    case MoneyOperationType.Salary:
                    case MoneyOperationType.CreditIssue:
                    case MoneyOperationType.CreditReturn:
                        return true;
                    case MoneyOperationType.Credit:
                    case MoneyOperationType.InitialValue:
                    case MoneyOperationType.PaymentIn:
                    case MoneyOperationType.CashReturn:
                    case MoneyOperationType.CreditIssueReturn:
                        return false;
                }
                return null;
            }
        }
        [XmlIgnore]
        public int MoneyOperationTypeIdUI
        {
            get { return this.MoneyOperationTypeId; }
            set
            {
                this.MoneyOperationTypeId = value;
                InvokePropertyChanged();
            }
        }

        [XmlIgnore]
        public Nullable<int> BudgetIdUI
        {
            get { return this.BudgetId; }
            set
            {
                this.BudgetId = value;
                if (value.HasValue)
                    this.OperatingBudgetIdUI = null;
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public Nullable<int> OperatingBudgetIdUI
        {
            get { return this.OperatingBudgetId; }
            set
            {
                this.OperatingBudgetId = value;
                if (value.HasValue)
                    this.BudgetIdUI = null;
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public Nullable<int> BudgetItemGroupIdUI
        {
            get { return this.BudgetItemGroupId; }
            set
            {
                this.BudgetItemGroupId = value;
                BudgetItemIdUI = null;
                InvokePropertyChanged();
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
        [XmlIgnore]
        public Nullable<int> VATRateIdUI
        {
            get { return this.VATRateId; }
            set
            {
                this.VATRateId = value;
                InvokePropertyChanged();
                RecalculateVATValue();
            }
        }
        [XmlIgnore]
        public decimal ValueUI
        {
            get { return this.Value; }
            set
            {
                this.Value = value;
                InvokePropertyChanged();
                RecalculateVATValue();
            }
        }
        private void RecalculateVATValue()
        {
            if (this.VATRateId.HasValue)
            {
                var vatRate = ListManager.GetItem<VATRateView>(this.VATRateId.Value).Value;
                this.VATValue = (vatRate * this.Value) / (1 + vatRate);
                InvokePropertyChanged("VATValueUI");
            }
        }
        [XmlIgnore]
        public decimal VATValueUI
        {
            get
            {
                return this.VATValue;
            }
            set
            {
                if (!this.VATRateId.HasValue)
                {
                    this.VATValue = value;
                    InvokePropertyChanged();
                }
            }
        }
        [XmlIgnore]
        public int AccountIdUI
        {
            get { return this.AccountId; }
            set
            {
                this.AccountId = value;
                InvokePropertyChanged();
            }
        }

        [XmlIgnore]
        public Nullable<int> SalesInvoiceIdUI
        {
            get { return this.SalesInvoiceId; }
            set
            {
                this.SalesInvoiceId = value;
                if (value.HasValue)
                {
                    var invoice = ListManager.GetItem<SalesInvoiceView>(value.Value);

                    this.BudgetIdUI = invoice.BudgetId;
                    this.OperatingBudgetIdUI = invoice.OperatingBudgetId;
                    this.BudgetItemGroupIdUI = invoice.BudgetItemGroupId;
                    this.BudgetItemIdUI = invoice.BudgetItemId;
                    this.AccountIdUI = invoice.AccountId;
                    this.ValueUI = invoice.Value;
                    this.VATRateIdUI = invoice.VATRateId;
                    this.VATValueUI = invoice.VATValue;
                }
                InvokePropertyChanged();
            }
        }

        [XmlIgnore]
        public Nullable<int> PurchaseInvoiceIdUI
        {
            get { return this.PurchaseInvoiceId; }
            set
            {
                this.PurchaseInvoiceId = value;
                if (value.HasValue)
                {
                    var invoice = ListManager.GetItem<PurchaseInvoiceView>(value.Value);

                    this.BudgetIdUI = invoice.BudgetId;
                    this.OperatingBudgetIdUI = invoice.OperatingBudgetId;
                    this.BudgetItemGroupIdUI = invoice.BudgetItemGroupId;
                    this.BudgetItemIdUI = invoice.BudgetItemId;
                    this.AccountIdUI = invoice.AccountId;
                    this.ValueUI = invoice.Value;
                    this.VATRateIdUI = invoice.VATRateId;
                    this.VATValueUI = invoice.VATValue;
                }
                InvokePropertyChanged();
            }
        }
    }
}
