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
    
    public partial class EmployeeView : DataItemView
    {
        public const string DataItemClassName = "Employee";
        private System.Nullable<int> _EmployeeAccountIdField;
        private int _AccountIdField;
        private System.Nullable<int> _TradeMarkIdField;
        private System.Nullable<int> _PositionIdField;
        private System.Nullable<int> _ReportsToEmployeeIdField;
        private System.Nullable<int> _DivisionIdField;
        private string _FirstNameField;
        private string _MiddleNameField;
        private string _LastNameField;
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
        private System.Nullable<int> _UserIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public EmployeeState State
        {
            get
            {
                return (EmployeeState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> EmployeeAccountId
        {
            get
            {
                return this._EmployeeAccountIdField;
            }
            set
            {
                this._EmployeeAccountIdField = value;
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
        public System.Nullable<int> TradeMarkId
        {
            get
            {
                return this._TradeMarkIdField;
            }
            set
            {
                this._TradeMarkIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> PositionId
        {
            get
            {
                return this._PositionIdField;
            }
            set
            {
                this._PositionIdField = value;
            }
        }
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
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> DivisionId
        {
            get
            {
                return this._DivisionIdField;
            }
            set
            {
                this._DivisionIdField = value;
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> UserId
        {
            get
            {
                return this._UserIdField;
            }
            set
            {
                this._UserIdField = value;
            }
        }
    }
}
