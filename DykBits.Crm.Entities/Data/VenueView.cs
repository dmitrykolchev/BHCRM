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
    
    public partial class VenueView : DataItemView
    {
        public const string DataItemClassName = "Venue";
        private string _FullNameField;
        private System.Nullable<int> _MemberOfAccountIdField;
        private System.Nullable<int> _TradeMarkIdField;
        private int _AccountTypeIdField;
        private System.Nullable<int> _AccountGroupIdField;
        private System.Nullable<int> _IndustryIdField;
        private System.Nullable<int> _RegionIdField;
        private System.Nullable<int> _EmployeesField;
        private System.Nullable<decimal> _AnnualRevenueField;
        private System.Nullable<int> _ManagingOrganizationIdField;
        private System.Nullable<int> _AssignedToEmployeeIdField;
        private System.Nullable<int> _AssistantEmployeeIdField;
        private System.Nullable<int> _ExecutiveIdField;
        private System.Nullable<int> _AccountantIdField;
        private string _PhoneField;
        private string _OtherPhoneField;
        private string _FaxField;
        private string _EmailField;
        private string _OtherEmailField;
        private string _WebSiteField;
        private string _BillingAddressStreetField;
        private string _BillingAddressCityField;
        private string _BillingAddressRegionField;
        private string _BillingAddressPostalCodeField;
        private string _BillingAddressCountryField;
        private string _ShippingAddressStreetField;
        private string _ShippingAddressCityField;
        private string _ShippingAddressRegionField;
        private string _ShippingAddressPostalCodeField;
        private string _ShippingAddressCountryField;
        private System.Nullable<int> _VenuePlaceIdField;
        private System.Nullable<int> _PrimaryVenueTypeIdField;
        private System.Nullable<int> _SecondaryVenueTypeIdField;
        private System.Nullable<bool> _SummerField;
        private System.Nullable<bool> _WinterField;
        private System.Nullable<int> _MaximumNumberOfGuestsForBanquetField;
        private System.Nullable<int> _MaximumNumberOfGuestsForReceptionField;
        private System.Nullable<int> _CateringTypeIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public VenueState State
        {
            get
            {
                return (VenueState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public string FullName
        {
            get
            {
                return this._FullNameField;
            }
            set
            {
                this._FullNameField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> MemberOfAccountId
        {
            get
            {
                return this._MemberOfAccountIdField;
            }
            set
            {
                this._MemberOfAccountIdField = value;
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
        public int AccountTypeId
        {
            get
            {
                return this._AccountTypeIdField;
            }
            set
            {
                this._AccountTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> AccountGroupId
        {
            get
            {
                return this._AccountGroupIdField;
            }
            set
            {
                this._AccountGroupIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> IndustryId
        {
            get
            {
                return this._IndustryIdField;
            }
            set
            {
                this._IndustryIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> RegionId
        {
            get
            {
                return this._RegionIdField;
            }
            set
            {
                this._RegionIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> Employees
        {
            get
            {
                return this._EmployeesField;
            }
            set
            {
                this._EmployeesField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<decimal> AnnualRevenue
        {
            get
            {
                return this._AnnualRevenueField;
            }
            set
            {
                this._AnnualRevenueField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ManagingOrganizationId
        {
            get
            {
                return this._ManagingOrganizationIdField;
            }
            set
            {
                this._ManagingOrganizationIdField = value;
            }
        }
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
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> AssistantEmployeeId
        {
            get
            {
                return this._AssistantEmployeeIdField;
            }
            set
            {
                this._AssistantEmployeeIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ExecutiveId
        {
            get
            {
                return this._ExecutiveIdField;
            }
            set
            {
                this._ExecutiveIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> AccountantId
        {
            get
            {
                return this._AccountantIdField;
            }
            set
            {
                this._AccountantIdField = value;
            }
        }
        [XmlAttribute()]
        public string Phone
        {
            get
            {
                return this._PhoneField;
            }
            set
            {
                this._PhoneField = value;
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
        public string WebSite
        {
            get
            {
                return this._WebSiteField;
            }
            set
            {
                this._WebSiteField = value;
            }
        }
        [XmlAttribute()]
        public string BillingAddressStreet
        {
            get
            {
                return this._BillingAddressStreetField;
            }
            set
            {
                this._BillingAddressStreetField = value;
            }
        }
        [XmlAttribute()]
        public string BillingAddressCity
        {
            get
            {
                return this._BillingAddressCityField;
            }
            set
            {
                this._BillingAddressCityField = value;
            }
        }
        [XmlAttribute()]
        public string BillingAddressRegion
        {
            get
            {
                return this._BillingAddressRegionField;
            }
            set
            {
                this._BillingAddressRegionField = value;
            }
        }
        [XmlAttribute()]
        public string BillingAddressPostalCode
        {
            get
            {
                return this._BillingAddressPostalCodeField;
            }
            set
            {
                this._BillingAddressPostalCodeField = value;
            }
        }
        [XmlAttribute()]
        public string BillingAddressCountry
        {
            get
            {
                return this._BillingAddressCountryField;
            }
            set
            {
                this._BillingAddressCountryField = value;
            }
        }
        [XmlAttribute()]
        public string ShippingAddressStreet
        {
            get
            {
                return this._ShippingAddressStreetField;
            }
            set
            {
                this._ShippingAddressStreetField = value;
            }
        }
        [XmlAttribute()]
        public string ShippingAddressCity
        {
            get
            {
                return this._ShippingAddressCityField;
            }
            set
            {
                this._ShippingAddressCityField = value;
            }
        }
        [XmlAttribute()]
        public string ShippingAddressRegion
        {
            get
            {
                return this._ShippingAddressRegionField;
            }
            set
            {
                this._ShippingAddressRegionField = value;
            }
        }
        [XmlAttribute()]
        public string ShippingAddressPostalCode
        {
            get
            {
                return this._ShippingAddressPostalCodeField;
            }
            set
            {
                this._ShippingAddressPostalCodeField = value;
            }
        }
        [XmlAttribute()]
        public string ShippingAddressCountry
        {
            get
            {
                return this._ShippingAddressCountryField;
            }
            set
            {
                this._ShippingAddressCountryField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> VenuePlaceId
        {
            get
            {
                return this._VenuePlaceIdField;
            }
            set
            {
                this._VenuePlaceIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> PrimaryVenueTypeId
        {
            get
            {
                return this._PrimaryVenueTypeIdField;
            }
            set
            {
                this._PrimaryVenueTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> SecondaryVenueTypeId
        {
            get
            {
                return this._SecondaryVenueTypeIdField;
            }
            set
            {
                this._SecondaryVenueTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<bool> Summer
        {
            get
            {
                return this._SummerField;
            }
            set
            {
                this._SummerField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<bool> Winter
        {
            get
            {
                return this._WinterField;
            }
            set
            {
                this._WinterField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> MaximumNumberOfGuestsForBanquet
        {
            get
            {
                return this._MaximumNumberOfGuestsForBanquetField;
            }
            set
            {
                this._MaximumNumberOfGuestsForBanquetField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> MaximumNumberOfGuestsForReception
        {
            get
            {
                return this._MaximumNumberOfGuestsForReceptionField;
            }
            set
            {
                this._MaximumNumberOfGuestsForReceptionField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> CateringTypeId
        {
            get
            {
                return this._CateringTypeIdField;
            }
            set
            {
                this._CateringTypeIdField = value;
            }
        }
    }
}
