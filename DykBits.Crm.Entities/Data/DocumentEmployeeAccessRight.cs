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
    
    public enum DocumentEmployeeAccessRightState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
    }
    public partial class DocumentEmployeeAccessRight : DataItem
    {
        public const string DataItemClassName = "DocumentEmployeeAccessRight";
        public const string DocumentTypeIdProperty = "DocumentTypeId";
        public const string DocumentIdProperty = "DocumentId";
        public const string DocumentAccessTypeIdProperty = "DocumentAccessTypeId";
        public const string EmployeeIdProperty = "EmployeeId";
        public const string StartDateProperty = "StartDate";
        public const string EndDateProperty = "EndDate";
        private int _DocumentTypeIdField;
        private int _DocumentIdField;
        private int _DocumentAccessTypeIdField;
        private int _EmployeeIdField;
        private System.Nullable<System.DateTime> _StartDateField;
        private System.Nullable<System.DateTime> _EndDateField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public DocumentEmployeeAccessRightState State
        {
            get
            {
                return (DocumentEmployeeAccessRightState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="DocumentTypeId", IsNullable=false)]
        [XmlAttribute()]
        public int DocumentTypeId
        {
            get
            {
                return this._DocumentTypeIdField;
            }
            set
            {
                this._DocumentTypeIdField = value;
                InvokePropertyChanged("DocumentTypeId");
            }
        }
        [Column(Name="DocumentId", IsNullable=false)]
        [XmlAttribute()]
        public int DocumentId
        {
            get
            {
                return this._DocumentIdField;
            }
            set
            {
                this._DocumentIdField = value;
                InvokePropertyChanged("DocumentId");
            }
        }
        [Column(Name="DocumentAccessTypeId", IsNullable=false)]
        [XmlAttribute()]
        public int DocumentAccessTypeId
        {
            get
            {
                return this._DocumentAccessTypeIdField;
            }
            set
            {
                this._DocumentAccessTypeIdField = value;
                InvokePropertyChanged("DocumentAccessTypeId");
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
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            NotifyPropertyChangedInternal(e.PropertyName);
            base.OnPropertyChanged(e);
        }

		partial void NotifyPropertyChangedInternal(string propertyName);
    }
}