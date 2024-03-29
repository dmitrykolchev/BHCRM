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
    
    public partial class ServiceRequestView : NumberedDataItemView
    {
        public const string DataItemClassName = "ServiceRequest";
        private System.Nullable<int> _TradeMarkIdField;
        private System.Nullable<int> _ResponsibleEmployeeIdField;
        private System.Nullable<int> _ProjectManagerIdField;
        private System.Nullable<int> _ProjectMember1IdField;
        private System.Nullable<int> _ProjectMember2IdField;
        private System.Nullable<int> _ProjectMember3IdField;
        private System.Nullable<int> _ProjectMember4IdField;
        private int _AttachmentCountField;
        private int _AccountIdField;
        private System.Nullable<int> _CustomerIdField;
        private System.Nullable<int> _VenueProviderIdField;
        private System.Nullable<int> _AgentIdField;
        private System.Nullable<int> _ResponsibleContactIdField;
        private int _ServiceRequestTypeIdField;
        private int _ServiceLevelIdField;
        private int _ReasonIdField;
        private System.Nullable<int> _LeadSourceIdField;
        private int _ProjectIdField;
        private System.Nullable<int> _AmountOfGuestsField;
        private System.Nullable<decimal> _ValueField;
        private System.Nullable<decimal> _BudgetValueField;
        private System.Nullable<int> _MileageField;
        private string _EventLocationField;
        private System.Nullable<System.DateTime> _EventMonthField;
        private System.Nullable<System.DateTime> _EventDateField;
        private int _EventDurationField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public ServiceRequestState State
        {
            get
            {
                return (ServiceRequestState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
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
        public System.Nullable<int> ResponsibleEmployeeId
        {
            get
            {
                return this._ResponsibleEmployeeIdField;
            }
            set
            {
                this._ResponsibleEmployeeIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ProjectManagerId
        {
            get
            {
                return this._ProjectManagerIdField;
            }
            set
            {
                this._ProjectManagerIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ProjectMember1Id
        {
            get
            {
                return this._ProjectMember1IdField;
            }
            set
            {
                this._ProjectMember1IdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ProjectMember2Id
        {
            get
            {
                return this._ProjectMember2IdField;
            }
            set
            {
                this._ProjectMember2IdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ProjectMember3Id
        {
            get
            {
                return this._ProjectMember3IdField;
            }
            set
            {
                this._ProjectMember3IdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ProjectMember4Id
        {
            get
            {
                return this._ProjectMember4IdField;
            }
            set
            {
                this._ProjectMember4IdField = value;
            }
        }
        [XmlAttribute()]
        public int AttachmentCount
        {
            get
            {
                return this._AttachmentCountField;
            }
            set
            {
                this._AttachmentCountField = value;
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
        public System.Nullable<int> CustomerId
        {
            get
            {
                return this._CustomerIdField;
            }
            set
            {
                this._CustomerIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> VenueProviderId
        {
            get
            {
                return this._VenueProviderIdField;
            }
            set
            {
                this._VenueProviderIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> AgentId
        {
            get
            {
                return this._AgentIdField;
            }
            set
            {
                this._AgentIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> ResponsibleContactId
        {
            get
            {
                return this._ResponsibleContactIdField;
            }
            set
            {
                this._ResponsibleContactIdField = value;
            }
        }
        [XmlAttribute()]
        public int ServiceRequestTypeId
        {
            get
            {
                return this._ServiceRequestTypeIdField;
            }
            set
            {
                this._ServiceRequestTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public int ServiceLevelId
        {
            get
            {
                return this._ServiceLevelIdField;
            }
            set
            {
                this._ServiceLevelIdField = value;
            }
        }
        [XmlAttribute()]
        public int ReasonId
        {
            get
            {
                return this._ReasonIdField;
            }
            set
            {
                this._ReasonIdField = value;
            }
        }
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
            }
        }
        [XmlAttribute()]
        public int ProjectId
        {
            get
            {
                return this._ProjectIdField;
            }
            set
            {
                this._ProjectIdField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> AmountOfGuests
        {
            get
            {
                return this._AmountOfGuestsField;
            }
            set
            {
                this._AmountOfGuestsField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<decimal> Value
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
        public System.Nullable<decimal> BudgetValue
        {
            get
            {
                return this._BudgetValueField;
            }
            set
            {
                this._BudgetValueField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> Mileage
        {
            get
            {
                return this._MileageField;
            }
            set
            {
                this._MileageField = value;
            }
        }
        [XmlAttribute()]
        public string EventLocation
        {
            get
            {
                return this._EventLocationField;
            }
            set
            {
                this._EventLocationField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<System.DateTime> EventMonth
        {
            get
            {
                return this._EventMonthField;
            }
            set
            {
                this._EventMonthField = value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<System.DateTime> EventDate
        {
            get
            {
                return this._EventDateField;
            }
            set
            {
                this._EventDateField = value;
            }
        }
        [XmlAttribute()]
        public int EventDuration
        {
            get
            {
                return this._EventDurationField;
            }
            set
            {
                this._EventDurationField = value;
            }
        }
    }
}
