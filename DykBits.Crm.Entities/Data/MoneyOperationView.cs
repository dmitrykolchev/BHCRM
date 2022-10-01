//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DykBits.Crm.Data
{
    using System;
    using System.Xml.Serialization;
    
    public partial class MoneyOperationView : NumberedDataItemView
    {
        public const string DataItemClassName = "MoneyOperation";
        private System.Nullable<int> _ParentIdField;
        private int _BankAccountIdField;
        private int _MoneyOperationTypeIdField;
        private int _MoneyOperationDirectionField;
        private System.Nullable<int> _BudgetIdField;
        private string _BudgetNumberField;
        private System.Nullable<int> _OperatingBudgetIdField;
        private System.Nullable<System.DateTime> _OperatingBudgetDateField;
        private string _OperatingBudgetNumberField;
        private System.Nullable<int> _BudgetItemGroupIdField;
        private System.Nullable<int> _BudgetItemIdField;
        private System.Nullable<int> _SalesInvoiceIdField;
        private System.Nullable<int> _PurchaseInvoiceIdField;
        private int _AccountIdField;
        private System.Nullable<int> _EmployeeIdField;
        private string _SubjectField;
        private decimal _ValueField;
        private System.Nullable<int> _VATRateIdField;
        private decimal _VATValueField;
        private System.Nullable<decimal> _InValueField;
        private System.Nullable<decimal> _OutValueField;
        private System.Nullable<decimal> _InVATValueField;
        private System.Nullable<decimal> _OutVATValueField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public MoneyOperationState State
        {
            get
            {
                return (MoneyOperationState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ParentId
        {
            get
            {
                return this._ParentIdField;
            }
            set
            {
                this._ParentIdField = value;
            }
        }
        [XmlAttribute()]
        public int BankAccountId
        {
            get
            {
                return this._BankAccountIdField;
            }
            set
            {
                this._BankAccountIdField = value;
            }
        }
        [XmlAttribute()]
        public int MoneyOperationTypeId
        {
            get
            {
                return this._MoneyOperationTypeIdField;
            }
            set
            {
                this._MoneyOperationTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public int MoneyOperationDirection
        {
            get
            {
                return this._MoneyOperationDirectionField;
            }
            set
            {
                this._MoneyOperationDirectionField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> BudgetId
        {
            get
            {
                return this._BudgetIdField;
            }
            set
            {
                this._BudgetIdField = value;
            }
        }
        [XmlAttribute()]
        public string BudgetNumber
        {
            get
            {
                return this._BudgetNumberField;
            }
            set
            {
                this._BudgetNumberField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> OperatingBudgetId
        {
            get
            {
                return this._OperatingBudgetIdField;
            }
            set
            {
                this._OperatingBudgetIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<System.DateTime> OperatingBudgetDate
        {
            get
            {
                return this._OperatingBudgetDateField;
            }
            set
            {
                this._OperatingBudgetDateField = value;
            }
        }
        [XmlAttribute()]
        public string OperatingBudgetNumber
        {
            get
            {
                return this._OperatingBudgetNumberField;
            }
            set
            {
                this._OperatingBudgetNumberField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> BudgetItemGroupId
        {
            get
            {
                return this._BudgetItemGroupIdField;
            }
            set
            {
                this._BudgetItemGroupIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> BudgetItemId
        {
            get
            {
                return this._BudgetItemIdField;
            }
            set
            {
                this._BudgetItemIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> SalesInvoiceId
        {
            get
            {
                return this._SalesInvoiceIdField;
            }
            set
            {
                this._SalesInvoiceIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> PurchaseInvoiceId
        {
            get
            {
                return this._PurchaseInvoiceIdField;
            }
            set
            {
                this._PurchaseInvoiceIdField = value;
            }
        }
        [XmlAttribute()]
        public int AccountId
        {
            get
            {
                return this._AccountIdField;
            }
            set
            {
                this._AccountIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> EmployeeId
        {
            get
            {
                return this._EmployeeIdField;
            }
            set
            {
                this._EmployeeIdField = value;
            }
        }
        [XmlAttribute()]
        public string Subject
        {
            get
            {
                return this._SubjectField;
            }
            set
            {
                this._SubjectField = value;
            }
        }
        [XmlAttribute()]
        public decimal Value
        {
            get
            {
                return this._ValueField;
            }
            set
            {
                this._ValueField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> VATRateId
        {
            get
            {
                return this._VATRateIdField;
            }
            set
            {
                this._VATRateIdField = value;
            }
        }
        [XmlAttribute()]
        public decimal VATValue
        {
            get
            {
                return this._VATValueField;
            }
            set
            {
                this._VATValueField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<decimal> InValue
        {
            get
            {
                return this._InValueField;
            }
            set
            {
                this._InValueField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<decimal> OutValue
        {
            get
            {
                return this._OutValueField;
            }
            set
            {
                this._OutValueField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<decimal> InVATValue
        {
            get
            {
                return this._InVATValueField;
            }
            set
            {
                this._InVATValueField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<decimal> OutVATValue
        {
            get
            {
                return this._OutVATValueField;
            }
            set
            {
                this._OutVATValueField = value;
            }
        }
    }
}
