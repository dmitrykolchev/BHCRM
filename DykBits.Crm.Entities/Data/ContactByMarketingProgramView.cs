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
    
    public partial class ContactByMarketingProgramView : DataItemView
    {
        public const string DataItemClassName = "Contact";
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
        private int _MarketingProgramTypeIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
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
        public System.Nullable<int> ContactGroupId
        {
            get
            {
                return this._ContactGroupIdField;
            }
            set
            {
                this._ContactGroupIdField = value;
            }
        }
        public System.Nullable<int> ContactRoleId
        {
            get
            {
                return this._ContactRoleIdField;
            }
            set
            {
                this._ContactRoleIdField = value;
            }
        }
        public System.Nullable<int> AssignedToEmployeeId
        {
            get
            {
                return this._AssignedToEmployeeIdField;
            }
            set
            {
                this._AssignedToEmployeeIdField = value;
            }
        }
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
        public System.Nullable<int> LeadSourceId
        {
            get
            {
                return this._LeadSourceIdField;
            }
            set
            {
                this._LeadSourceIdField = value;
            }
        }
        public string Title
        {
            get
            {
                return this._TitleField;
            }
            set
            {
                this._TitleField = value;
            }
        }
        public string Department
        {
            get
            {
                return this._DepartmentField;
            }
            set
            {
                this._DepartmentField = value;
            }
        }
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
        public int MarketingProgramTypeId
        {
            get
            {
                return this._MarketingProgramTypeIdField;
            }
            set
            {
                this._MarketingProgramTypeIdField = value;
            }
        }
    }
}
