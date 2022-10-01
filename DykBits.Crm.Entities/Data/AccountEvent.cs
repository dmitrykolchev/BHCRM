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
    
    public enum AccountEventState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Planned = 1,
        [XmlEnum("2")]
        Canceled = 2,
        [XmlEnum("3")]
        Completed = 3,
    }
    public partial class AccountEvent : DataItem
    {
        public const string DataItemClassName = "AccountEvent";
        public const string AccountEventTypeIdProperty = "AccountEventTypeId";
        public const string AccountEventDirectionIdProperty = "AccountEventDirectionId";
        public const string ImportanceProperty = "Importance";
        public const string EventStartProperty = "EventStart";
        public const string EventEndProperty = "EventEnd";
        public const string AccountIdProperty = "AccountId";
        public const string ContactIdProperty = "ContactId";
        public const string ServiceRequestIdProperty = "ServiceRequestId";
        public const string EmployeeIdProperty = "EmployeeId";
        private int _AccountEventTypeIdField;
        private int _AccountEventDirectionIdField;
        private int _ImportanceField;
        private System.DateTime _EventStartField;
        private System.DateTime _EventEndField;
        private int _AccountIdField;
        private int _ContactIdField;
        private System.Nullable<int> _ServiceRequestIdField;
        private int _EmployeeIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public AccountEventState State
        {
            get
            {
                return (AccountEventState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="AccountEventTypeId", IsNullable=false)]
        [XmlAttribute()]
        public int AccountEventTypeId
        {
            get
            {
                return this._AccountEventTypeIdField;
            }
            set
            {
                this._AccountEventTypeIdField = value;
                InvokePropertyChanged("AccountEventTypeId");
            }
        }
        [Column(Name="AccountEventDirectionId", IsNullable=false)]
        [XmlAttribute()]
        public int AccountEventDirectionId
        {
            get
            {
                return this._AccountEventDirectionIdField;
            }
            set
            {
                this._AccountEventDirectionIdField = value;
                InvokePropertyChanged("AccountEventDirectionId");
            }
        }
        [Column(Name="Importance", IsNullable=false)]
        [XmlAttribute()]
        public int Importance
        {
            get
            {
                return this._ImportanceField;
            }
            set
            {
                this._ImportanceField = value;
                InvokePropertyChanged("Importance");
            }
        }
        [Column(Name="EventStart", IsNullable=false)]
        [XmlAttribute()]
        public System.DateTime EventStart
        {
            get
            {
                return this._EventStartField;
            }
            set
            {
                this._EventStartField = value;
                InvokePropertyChanged("EventStart");
            }
        }
        [Column(Name="EventEnd", IsNullable=false)]
        [XmlAttribute()]
        public System.DateTime EventEnd
        {
            get
            {
                return this._EventEndField;
            }
            set
            {
                this._EventEndField = value;
                InvokePropertyChanged("EventEnd");
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
        [Column(Name="ContactId", IsNullable=false)]
        [XmlAttribute()]
        public int ContactId
        {
            get
            {
                return this._ContactIdField;
            }
            set
            {
                this._ContactIdField = value;
                InvokePropertyChanged("ContactId");
            }
        }
        [Column(Name="ServiceRequestId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ServiceRequestId
        {
            get
            {
                return this._ServiceRequestIdField;
            }
            set
            {
                this._ServiceRequestIdField = value;
                InvokePropertyChanged("ServiceRequestId");
            }
        }
        [Column(Name="EmployeeId", IsNullable=false)]
        [XmlAttribute()]
        public int EmployeeId
        {
            get
            {
                return this._EmployeeIdField;
            }
            set
            {
                this._EmployeeIdField = value;
                InvokePropertyChanged("EmployeeId");
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
