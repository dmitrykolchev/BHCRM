using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class ServiceRequest
    {
        public const string ValuePerGuestProperty = "ValuePerGuest";
        public const string EventDateUIProperty = "EventDateUI";
        private IList<ProjectMemberView> _projectMembers;

        [XmlIgnore]
        public Nullable<DateTime> EventDateUI
        {
            get { return this.EventDate; }
            set
            {
                this.EventDate = value;
                if(value.HasValue)
                    this.EventMonthUI = new DateTime(value.Value.Year, value.Value.Month, 1);
                InvokePropertyChanged();
            }
        }

        [XmlIgnore]
        public Nullable<DateTime> EventMonthUI
        {
            get { return this.EventMonth; }
            set
            {
                if (value.HasValue)
                {
                    this.EventMonth = new DateTime(value.Value.Year, value.Value.Month, 1);
                    if (this.EventDate.HasValue && this.EventMonth.Value != new DateTime(this.EventDate.Value.Year, this.EventDate.Value.Month, 1))
                    {
                        this.EventDate = this.EventMonth;
                        InvokePropertyChanged(EventDateUIProperty);
                    }
                }
                else
                    this.EventMonth = null;
                InvokePropertyChanged();
            }
        }

        public Nullable<int> EstimatesDocumentId
        {
            get;
            set;
        }

        [XmlIgnore]
        public IList<ProjectMemberView> ProjectMembers
        {
            get
            {
                if (this._projectMembers == null)
                {
                    ProjectMemberFilter filter = new ProjectMemberFilter { ProjectId = this.ProjectId };
                    this._projectMembers = DocumentManager.Browse<ProjectMemberView>(filter).OrderBy(t => t.ProjectMemberRoleId).ToList();
                }
                return this._projectMembers;
            }
        }

        [XmlIgnore]
        public bool IsCustomer
        {
            get { return this.CustomerSelector == 0; }
            set
            {
                if (value)
                {
                    this.CustomerSelector = 0;
                }
            }
        }

        [XmlIgnore]
        public bool IsCustomerSet
        {
            get
            {
                return this.CustomerId.HasValue;
            }
        }

        [XmlIgnore]
        public bool IsAgent
        {
            get { return this.CustomerSelector == 1; }
            set
            {
                if (value)
                {
                    this.CustomerSelector = 1;
                }
            }
        }

        [XmlIgnore]
        public bool IsAgentSet
        {
            get { return this.AgentId.HasValue; }
        }

        [XmlIgnore]
        public bool IsVenueProvider
        {
            get { return this.CustomerSelector == 2; }
            set
            {
                if (value)
                {
                    this.CustomerSelector = 2;
                }
            }
        }
        [XmlIgnore]
        public bool IsVenueProviderSet
        {
            get
            {
                return this.VenueProviderId.HasValue;
            }
        }

        private int _customerSelector = -1;
        [XmlIgnore]
        public int CustomerSelector
        {
            get
            {
                if (this._customerSelector == -1)
                {
                    if (IsCustomerSet)
                        return 0;
                    else if (IsAgentSet)
                        return 1;
                    else if (IsVenueProviderSet)
                        return 2;
                }
                return this._customerSelector;
            }
            set
            {
                this._customerSelector = value;
                InvokePropertyChanged("IsCustomer");
                InvokePropertyChanged("IsAgent");
                InvokePropertyChanged("IsVenueProvider");
            }
        }

        private bool _recursive;

        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (!this._recursive)
            {
                this._recursive = true;
                try
                {
                    switch (propertyName)
                    {
                        case AgentIdProperty:
                            InvokePropertyChanged("IsAgentSet");
                            break;
                        case CustomerIdProperty:
                            InvokePropertyChanged("IsCustomerSet");
                            break;
                        case VenueProviderIdProperty:
                            InvokePropertyChanged("IsVenueProviderSet");
                            break;
                    }
                }
                finally
                {
                    this._recursive = false;
                }
            }
        }

        private decimal _valuePerGuest;

        [XmlIgnore]
        public decimal ValuePerGuest
        {
            get
            {
                return this._valuePerGuest;
            }
            set
            {
                this._valuePerGuest = value;
                InvokePropertyChanged(ValuePerGuestProperty);
            }
        }

        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            if (this.Value.HasValue && this.AmountOfGuests.HasValue && this.AmountOfGuests.Value != 0)
            {
                this.ValuePerGuest = Math.Round(this.Value.Value / this.AmountOfGuests.Value, 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                this.ValuePerGuest = 0;
            }
        }

        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == OrganizationIdProperty || propertyInfo.Name == ServiceRequestTypeIdProperty ||
                propertyInfo.Name == ReasonIdProperty || propertyInfo.Name == ServiceLevelIdProperty)
            {
                object value = propertyInfo.GetValue(this);
                if (0.Equals(value))
                    return "Выберите значение из списка";
            }
            else if (propertyInfo.Name == ValueProperty)
            {
                if (!Value.HasValue)
                    return "Введите бюджет";
            }
            else if (propertyInfo.Name == ValuePerGuestProperty)
            {
                if (ValuePerGuest < 0)
                    return "Бюджет на одного гостя должен быть больше или равен нулю";
            }
            else if (propertyInfo.Name == AmountOfGuestsProperty)
            {
                if (!AmountOfGuests.HasValue)
                    return "Введите кол-во гостей";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }

        private IList<BudgetView> _budgets;
        [XmlIgnore]
        public IList<BudgetView> Budgets
        {
            get
            {
                if (!this.IsNew)
                {
                    if (this._budgets == null)
                    {
                        this._budgets = DocumentManager.Browse<BudgetView>(new BudgetFilter { AllStates = true, ServiceRequestId = this.Id, Presentation="AllBudgets" });
                    }
                }
                return this._budgets;
            }
        }

    }
}
