using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class PurchaseInvoice
    {
        private IList<MoneyOperationView> _payments;
        IList<MoneyOperationView> GetPayments()
        {
            var filter = new MoneyOperationFilter { AllStates = true, PurchaseInvoiceId = this.Id };
            return DocumentManager.Browse<MoneyOperationView>(filter);
        }
        [XmlIgnore]
        public IList<MoneyOperationView> Payments
        {
            get
            {
                if (this._payments == null)
                    this._payments = GetPayments();
                return this._payments;
            }
        }
        public bool IsVATRateReadOnly
        {
            get
            {
                return this.VATRateId.HasValue;
            }
        }
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == VATRateIdProperty)
            {
                InvokePropertyChanged("IsVATRateReadOnly");
            }
            else if (propertyName == "BudgetIdUI")
            {
                this.BudgetItemGroupIdUI = 0;
                this.BudgetItemIdUI = null;
                ValidateBudgetItemGroups();
                ValidateBudgetItems();
            }
            else if (propertyName == "OperatingBudgetIdUI")
            {
                this.BudgetItemGroupIdUI = 0;
                this.BudgetItemIdUI = null;
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
                this.BudgetIdUI = null;
                this.OperatingBudgetIdUI = null;
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
            IList<BudgetItemGroupView> groups = ListManager.GetList<BudgetItemGroupView>(t => t.BudgetItemGroupType == groupType && t.IsExpenseGroup);
            this._budgetItemGroups.Clear();
            foreach (var item in groups)
                this._budgetItemGroups.Add(item);
        }

        private void ValidateBudgetItems()
        {
            if (this._budgetItems == null)
                this._budgetItems = new ObservableCollection<BudgetItemView>();
            var budgetItemGroupId = this.BudgetItemGroupId;
             IList<BudgetItemView> items = ListManager.GetList<BudgetItemView>(t => t.BudgetItemGroupId == budgetItemGroupId && t.Id != BudgetItem.Прочие_расходы_НДС && t.Id != BudgetItem.Расходы_по_ОВД_НДС);
            this._budgetItems.Clear();
            foreach (var item in items)
            {
                if(item.State == BudgetItemState.Active || (this.BudgetItemId.HasValue && this.BudgetItemId.Value == item.Id))
                {
                    this._budgetItems.Add(item);
                }
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
        public int OrganizationIdUI
        {
            get { return this.OrganizationId; }
            set
            {
                this.OrganizationId = value;
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
        public int BudgetItemGroupIdUI
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

        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == AccountIdProperty)
            {
                if (this.AccountId == 0)
                    return "Необходимо указать поставщика";
            }
            else if (propertyInfo.Name == BudgetItemGroupIdProperty)
            {
                if (this.BudgetItemGroupId == 0)
                    return "Необходимо выбрать раздел";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }

    }
}
