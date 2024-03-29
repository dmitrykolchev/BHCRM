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
    
    public partial class OpportunityView : DataItemView
    {
        public const string DataItemClassName = "Opportunity";
        private int _OrganizationIdField;
        private int _AssignedToEmployeeIdField;
        private int _AccountIdField;
        private int _OpportunityTypeIdField;
        private int _LeadSourceIdField;
        private int _ProjectTypeIdField;
        private int _ReasonIdField;
        private System.Nullable<int> _AmountOfGuestsField;
        private decimal _ValueField;
        private System.DateTime _DateClosedField;
        private System.DateTime _EventDateField;
        private decimal _ProbabilityField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public OpportunityState State
        {
            get
            {
                return (OpportunityState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
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
            }
        }
        [XmlAttribute()]
        public int AssignedToEmployeeId
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
        public int OpportunityTypeId
        {
            get
            {
                return this._OpportunityTypeIdField;
            }
            set
            {
                this._OpportunityTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public int LeadSourceId
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
        public int ProjectTypeId
        {
            get
            {
                return this._ProjectTypeIdField;
            }
            set
            {
                this._ProjectTypeIdField = value;
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
        public System.DateTime DateClosed
        {
            get
            {
                return this._DateClosedField;
            }
            set
            {
                this._DateClosedField = value;
            }
        }
        [XmlAttribute()]
        public System.DateTime EventDate
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
        public decimal Probability
        {
            get
            {
                return this._ProbabilityField;
            }
            set
            {
                this._ProbabilityField = value;
            }
        }
    }
}
