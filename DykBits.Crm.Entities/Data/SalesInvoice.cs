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
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    public enum SalesInvoiceState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Draft = 1,
        [XmlEnum("2")]
        Approved = 2,
        [XmlEnum("3")]
        Payed = 3,
    }
    public partial class SalesInvoice : NumberedDataItem
    {
        public const string DataItemClassName = "SalesInvoice";
        public const string DueDateProperty = "DueDate";
        public const string AccountIdProperty = "AccountId";
        public const string BudgetIdProperty = "BudgetId";
        public const string OperatingBudgetIdProperty = "OperatingBudgetId";
        public const string BudgetItemGroupIdProperty = "BudgetItemGroupId";
        public const string BudgetItemIdProperty = "BudgetItemId";
        public const string ResponsibleEmployeeIdProperty = "ResponsibleEmployeeId";
        public const string SubjectProperty = "Subject";
        public const string IsCashProperty = "IsCash";
        public const string ValueProperty = "Value";
        public const string VATRateIdProperty = "VATRateId";
        public const string VATValueProperty = "VATValue";
        private System.DateTime _DueDateField;
        private int _AccountIdField;
        private System.Nullable<int> _BudgetIdField;
        private System.Nullable<int> _OperatingBudgetIdField;
        private int _BudgetItemGroupIdField;
        private System.Nullable<int> _BudgetItemIdField;
        private int _ResponsibleEmployeeIdField;
        private string _SubjectField;
        private bool _IsCashField;
        private decimal _ValueField;
        private System.Nullable<int> _VATRateIdField;
        private decimal _VATValueField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public SalesInvoiceState State
        {
            get
            {
                return (SalesInvoiceState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="DueDate", IsNullable=false)]
        [XmlAttribute()]
        public System.DateTime DueDate
        {
            get
            {
                return this._DueDateField;
            }
            set
            {
                this._DueDateField = value;
                InvokePropertyChanged("DueDate");
            }
        }
        [Column(Name="AccountId", IsNullable=false)]
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
                InvokePropertyChanged("AccountId");
            }
        }
        [Column(Name="BudgetId", IsNullable=true)]
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
                InvokePropertyChanged("BudgetId");
            }
        }
        [Column(Name="OperatingBudgetId", IsNullable=true)]
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
                InvokePropertyChanged("OperatingBudgetId");
            }
        }
        [Column(Name="BudgetItemGroupId", IsNullable=false)]
        [XmlAttribute()]
        public int BudgetItemGroupId
        {
            get
            {
                return this._BudgetItemGroupIdField;
            }
            set
            {
                this._BudgetItemGroupIdField = value;
                InvokePropertyChanged("BudgetItemGroupId");
            }
        }
        [Column(Name="BudgetItemId", IsNullable=true)]
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
                InvokePropertyChanged("BudgetItemId");
            }
        }
        [Column(Name="ResponsibleEmployeeId", IsNullable=false)]
        [XmlAttribute()]
        public int ResponsibleEmployeeId
        {
            get
            {
                return this._ResponsibleEmployeeIdField;
            }
            set
            {
                this._ResponsibleEmployeeIdField = value;
                InvokePropertyChanged("ResponsibleEmployeeId");
            }
        }
        [Column(Name="Subject", IsNullable=true, MaximumLength=1024)]
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
                InvokePropertyChanged("Subject");
            }
        }
        [Column(Name="IsCash", IsNullable=false)]
        [XmlAttribute()]
        public bool IsCash
        {
            get
            {
                return this._IsCashField;
            }
            set
            {
                this._IsCashField = value;
                InvokePropertyChanged("IsCash");
            }
        }
        [Column(Name="Value", IsNullable=false)]
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
                InvokePropertyChanged("Value");
            }
        }
        [Column(Name="VATRateId", IsNullable=true)]
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
                InvokePropertyChanged("VATRateId");
            }
        }
        [Column(Name="VATValue", IsNullable=false)]
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
                InvokePropertyChanged("VATValue");
            }
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            NotifyPropertyChangedInternal(e.PropertyName);
            base.OnPropertyChanged(e);
        }

		partial void NotifyPropertyChangedInternal(string propertyName);
    }
}
