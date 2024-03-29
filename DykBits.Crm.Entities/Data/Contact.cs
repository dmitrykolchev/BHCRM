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
    
    public enum ContactState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
        [XmlEnum("2")]
        Inactive = 2,
    }
    public partial class Contact : DataItem
    {
        public const string DataItemClassName = "Contact";
        public const string ContactGroupIdProperty = "ContactGroupId";
        public const string ContactRoleIdProperty = "ContactRoleId";
        public const string AssignedToEmployeeIdProperty = "AssignedToEmployeeId";
        public const string FirstNameProperty = "FirstName";
        public const string MiddleNameProperty = "MiddleName";
        public const string LastNameProperty = "LastName";
        public const string AccountIdProperty = "AccountId";
        public const string ReportsToEmployeeIdProperty = "ReportsToEmployeeId";
        public const string LeadSourceIdProperty = "LeadSourceId";
        public const string TitleProperty = "Title";
        public const string DepartmentProperty = "Department";
        public const string BirthDateProperty = "BirthDate";
        public const string GenderProperty = "Gender";
        public const string BusinessPhoneProperty = "BusinessPhone";
        public const string MobilePhoneProperty = "MobilePhone";
        public const string HomePhoneProperty = "HomePhone";
        public const string OtherPhoneProperty = "OtherPhone";
        public const string FaxProperty = "Fax";
        public const string EmailProperty = "Email";
        public const string OtherEmailProperty = "OtherEmail";
        public const string AssistantProperty = "Assistant";
        public const string AssistantPhoneProperty = "AssistantPhone";
        public const string PrimaryAddressStreetProperty = "PrimaryAddressStreet";
        public const string PrimaryAddressCityProperty = "PrimaryAddressCity";
        public const string PrimaryAddressRegionProperty = "PrimaryAddressRegion";
        public const string PrimaryAddressPostalCodeProperty = "PrimaryAddressPostalCode";
        public const string PrimaryAddressCountryProperty = "PrimaryAddressCountry";
        public const string AlternateAddressStreetProperty = "AlternateAddressStreet";
        public const string AlternateAddressCityProperty = "AlternateAddressCity";
        public const string AlternateAddressRegionProperty = "AlternateAddressRegion";
        public const string AlternateAddressPostalCodeProperty = "AlternateAddressPostalCode";
        public const string AlternateAddressCountryProperty = "AlternateAddressCountry";
        private System.Nullable<int> _ContactGroupIdField;
        private System.Nullable<int> _ContactRoleIdField;
        private System.Nullable<int> _AssignedToEmployeeIdField;
        private string _FirstNameField;
        private string _MiddleNameField;
        private string _LastNameField;
        private int _AccountIdField;
        private System.Nullable<int> _ReportsToEmployeeIdField;
        private System.Nullable<int> _LeadSourceIdField;
        private string _TitleField;
        private string _DepartmentField;
        private System.Nullable<System.DateTime> _BirthDateField;
        private byte _GenderField;
        private string _BusinessPhoneField;
        private string _MobilePhoneField;
        private string _HomePhoneField;
        private string _OtherPhoneField;
        private string _FaxField;
        private string _EmailField;
        private string _OtherEmailField;
        private string _AssistantField;
        private string _AssistantPhoneField;
        private string _PrimaryAddressStreetField;
        private string _PrimaryAddressCityField;
        private string _PrimaryAddressRegionField;
        private string _PrimaryAddressPostalCodeField;
        private string _PrimaryAddressCountryField;
        private string _AlternateAddressStreetField;
        private string _AlternateAddressCityField;
        private string _AlternateAddressRegionField;
        private string _AlternateAddressPostalCodeField;
        private string _AlternateAddressCountryField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public ContactState State
        {
            get
            {
                return (ContactState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="ContactGroupId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ContactGroupId
        {
            get
            {
                return this._ContactGroupIdField;
            }
            set
            {
                this._ContactGroupIdField = value;
                InvokePropertyChanged("ContactGroupId");
            }
        }
        [Column(Name="ContactRoleId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ContactRoleId
        {
            get
            {
                return this._ContactRoleIdField;
            }
            set
            {
                this._ContactRoleIdField = value;
                InvokePropertyChanged("ContactRoleId");
            }
        }
        [Column(Name="AssignedToEmployeeId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> AssignedToEmployeeId
        {
            get
            {
                return this._AssignedToEmployeeIdField;
            }
            set
            {
                this._AssignedToEmployeeIdField = value;
                InvokePropertyChanged("AssignedToEmployeeId");
            }
        }
        [Column(Name="FirstName", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string FirstName
        {
            get
            {
                return this._FirstNameField;
            }
            set
            {
                this._FirstNameField = value;
                InvokePropertyChanged("FirstName");
            }
        }
        [Column(Name="MiddleName", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string MiddleName
        {
            get
            {
                return this._MiddleNameField;
            }
            set
            {
                this._MiddleNameField = value;
                InvokePropertyChanged("MiddleName");
            }
        }
        [Column(Name="LastName", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string LastName
        {
            get
            {
                return this._LastNameField;
            }
            set
            {
                this._LastNameField = value;
                InvokePropertyChanged("LastName");
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
        [Column(Name="ReportsToEmployeeId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ReportsToEmployeeId
        {
            get
            {
                return this._ReportsToEmployeeIdField;
            }
            set
            {
                this._ReportsToEmployeeIdField = value;
                InvokePropertyChanged("ReportsToEmployeeId");
            }
        }
        [Column(Name="LeadSourceId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> LeadSourceId
        {
            get
            {
                return this._LeadSourceIdField;
            }
            set
            {
                this._LeadSourceIdField = value;
                InvokePropertyChanged("LeadSourceId");
            }
        }
        [Column(Name="Title", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string Title
        {
            get
            {
                return this._TitleField;
            }
            set
            {
                this._TitleField = value;
                InvokePropertyChanged("Title");
            }
        }
        [Column(Name="Department", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string Department
        {
            get
            {
                return this._DepartmentField;
            }
            set
            {
                this._DepartmentField = value;
                InvokePropertyChanged("Department");
            }
        }
        [Column(Name="BirthDate", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<System.DateTime> BirthDate
        {
            get
            {
                return this._BirthDateField;
            }
            set
            {
                this._BirthDateField = value;
                InvokePropertyChanged("BirthDate");
            }
        }
        [Column(Name="Gender", IsNullable=false)]
        [XmlAttribute()]
        public byte Gender
        {
            get
            {
                return this._GenderField;
            }
            set
            {
                this._GenderField = value;
                InvokePropertyChanged("Gender");
            }
        }
        [Column(Name="BusinessPhone", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string BusinessPhone
        {
            get
            {
                return this._BusinessPhoneField;
            }
            set
            {
                this._BusinessPhoneField = value;
                InvokePropertyChanged("BusinessPhone");
            }
        }
        [Column(Name="MobilePhone", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string MobilePhone
        {
            get
            {
                return this._MobilePhoneField;
            }
            set
            {
                this._MobilePhoneField = value;
                InvokePropertyChanged("MobilePhone");
            }
        }
        [Column(Name="HomePhone", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string HomePhone
        {
            get
            {
                return this._HomePhoneField;
            }
            set
            {
                this._HomePhoneField = value;
                InvokePropertyChanged("HomePhone");
            }
        }
        [Column(Name="OtherPhone", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string OtherPhone
        {
            get
            {
                return this._OtherPhoneField;
            }
            set
            {
                this._OtherPhoneField = value;
                InvokePropertyChanged("OtherPhone");
            }
        }
        [Column(Name="Fax", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string Fax
        {
            get
            {
                return this._FaxField;
            }
            set
            {
                this._FaxField = value;
                InvokePropertyChanged("Fax");
            }
        }
        [Column(Name="Email", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string Email
        {
            get
            {
                return this._EmailField;
            }
            set
            {
                this._EmailField = value;
                InvokePropertyChanged("Email");
            }
        }
        [Column(Name="OtherEmail", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string OtherEmail
        {
            get
            {
                return this._OtherEmailField;
            }
            set
            {
                this._OtherEmailField = value;
                InvokePropertyChanged("OtherEmail");
            }
        }
        [Column(Name="Assistant", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string Assistant
        {
            get
            {
                return this._AssistantField;
            }
            set
            {
                this._AssistantField = value;
                InvokePropertyChanged("Assistant");
            }
        }
        [Column(Name="AssistantPhone", IsNullable=true, MaximumLength=128)]
        [XmlAttribute()]
        public string AssistantPhone
        {
            get
            {
                return this._AssistantPhoneField;
            }
            set
            {
                this._AssistantPhoneField = value;
                InvokePropertyChanged("AssistantPhone");
            }
        }
        [Column(Name="PrimaryAddressStreet", IsNullable=true, MaximumLength=256)]
        [XmlAttribute()]
        public string PrimaryAddressStreet
        {
            get
            {
                return this._PrimaryAddressStreetField;
            }
            set
            {
                this._PrimaryAddressStreetField = value;
                InvokePropertyChanged("PrimaryAddressStreet");
            }
        }
        [Column(Name="PrimaryAddressCity", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string PrimaryAddressCity
        {
            get
            {
                return this._PrimaryAddressCityField;
            }
            set
            {
                this._PrimaryAddressCityField = value;
                InvokePropertyChanged("PrimaryAddressCity");
            }
        }
        [Column(Name="PrimaryAddressRegion", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string PrimaryAddressRegion
        {
            get
            {
                return this._PrimaryAddressRegionField;
            }
            set
            {
                this._PrimaryAddressRegionField = value;
                InvokePropertyChanged("PrimaryAddressRegion");
            }
        }
        [Column(Name="PrimaryAddressPostalCode", IsNullable=true, MaximumLength=10)]
        [XmlAttribute()]
        public string PrimaryAddressPostalCode
        {
            get
            {
                return this._PrimaryAddressPostalCodeField;
            }
            set
            {
                this._PrimaryAddressPostalCodeField = value;
                InvokePropertyChanged("PrimaryAddressPostalCode");
            }
        }
        [Column(Name="PrimaryAddressCountry", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string PrimaryAddressCountry
        {
            get
            {
                return this._PrimaryAddressCountryField;
            }
            set
            {
                this._PrimaryAddressCountryField = value;
                InvokePropertyChanged("PrimaryAddressCountry");
            }
        }
        [Column(Name="AlternateAddressStreet", IsNullable=true, MaximumLength=256)]
        [XmlAttribute()]
        public string AlternateAddressStreet
        {
            get
            {
                return this._AlternateAddressStreetField;
            }
            set
            {
                this._AlternateAddressStreetField = value;
                InvokePropertyChanged("AlternateAddressStreet");
            }
        }
        [Column(Name="AlternateAddressCity", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string AlternateAddressCity
        {
            get
            {
                return this._AlternateAddressCityField;
            }
            set
            {
                this._AlternateAddressCityField = value;
                InvokePropertyChanged("AlternateAddressCity");
            }
        }
        [Column(Name="AlternateAddressRegion", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string AlternateAddressRegion
        {
            get
            {
                return this._AlternateAddressRegionField;
            }
            set
            {
                this._AlternateAddressRegionField = value;
                InvokePropertyChanged("AlternateAddressRegion");
            }
        }
        [Column(Name="AlternateAddressPostalCode", IsNullable=true, MaximumLength=10)]
        [XmlAttribute()]
        public string AlternateAddressPostalCode
        {
            get
            {
                return this._AlternateAddressPostalCodeField;
            }
            set
            {
                this._AlternateAddressPostalCodeField = value;
                InvokePropertyChanged("AlternateAddressPostalCode");
            }
        }
        [Column(Name="AlternateAddressCountry", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string AlternateAddressCountry
        {
            get
            {
                return this._AlternateAddressCountryField;
            }
            set
            {
                this._AlternateAddressCountryField = value;
                InvokePropertyChanged("AlternateAddressCountry");
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
