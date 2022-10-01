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
    
    public enum ContractState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
        [XmlEnum("2")]
        Inactive = 2,
    }
    public partial class Contract : DataItem
    {
        public const string DataItemClassName = "Contract";
        public const string ParentContractIdProperty = "ParentContractId";
        public const string NumberProperty = "Number";
        public const string ContractDateProperty = "ContractDate";
        public const string OrganizationIdProperty = "OrganizationId";
        public const string AccountIdProperty = "AccountId";
        public const string StartDateProperty = "StartDate";
        public const string EndDateProperty = "EndDate";
        public const string AmountProperty = "Amount";
        public const string VATProperty = "VAT";
        private System.Nullable<int> _ParentContractIdField;
        private string _NumberField;
        private System.DateTime _ContractDateField;
        private int _OrganizationIdField;
        private int _AccountIdField;
        private System.Nullable<System.DateTime> _StartDateField;
        private System.Nullable<System.DateTime> _EndDateField;
        private decimal _AmountField;
        private decimal _VATField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public ContractState State
        {
            get
            {
                return (ContractState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="ParentContractId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ParentContractId
        {
            get
            {
                return this._ParentContractIdField;
            }
            set
            {
                this._ParentContractIdField = value;
                InvokePropertyChanged("ParentContractId");
            }
        }
        [Column(Name="Number", IsNullable=true, MaximumLength=32)]
        [XmlAttribute()]
        public string Number
        {
            get
            {
                return this._NumberField;
            }
            set
            {
                this._NumberField = value;
                InvokePropertyChanged("Number");
            }
        }
        [Column(Name="ContractDate", IsNullable=false)]
        [XmlAttribute()]
        public System.DateTime ContractDate
        {
            get
            {
                return this._ContractDateField;
            }
            set
            {
                this._ContractDateField = value;
                InvokePropertyChanged("ContractDate");
            }
        }
        [Column(Name="OrganizationId", IsNullable=false)]
        [XmlAttribute()]
        public int OrganizationId
        {
            get
            {
                return this._OrganizationIdField;
            }
            set
            {
                this._OrganizationIdField = value;
                InvokePropertyChanged("OrganizationId");
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
        [Column(Name="StartDate", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<System.DateTime> StartDate
        {
            get
            {
                return this._StartDateField;
            }
            set
            {
                this._StartDateField = value;
                InvokePropertyChanged("StartDate");
            }
        }
        [Column(Name="EndDate", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<System.DateTime> EndDate
        {
            get
            {
                return this._EndDateField;
            }
            set
            {
                this._EndDateField = value;
                InvokePropertyChanged("EndDate");
            }
        }
        [Column(Name="Amount", IsNullable=false)]
        [XmlAttribute()]
        public decimal Amount
        {
            get
            {
                return this._AmountField;
            }
            set
            {
                this._AmountField = value;
                InvokePropertyChanged("Amount");
            }
        }
        [Column(Name="VAT", IsNullable=false)]
        [XmlAttribute()]
        public decimal VAT
        {
            get
            {
                return this._VATField;
            }
            set
            {
                this._VATField = value;
                InvokePropertyChanged("VAT");
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
