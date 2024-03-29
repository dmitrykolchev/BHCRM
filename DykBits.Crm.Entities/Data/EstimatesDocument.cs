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
    
    public enum EstimatesDocumentState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Draft = 1,
        [XmlEnum("2")]
        Approved = 2,
    }
    public partial class EstimatesDocument : NumberedDataItem
    {
        public const string DataItemClassName = "EstimatesDocument";
        public const string ServiceRequestIdProperty = "ServiceRequestId";
        public const string VATRateIdProperty = "VATRateId";
        public const string ExtraCostRateIdProperty = "ExtraCostRateId";
        public const string CommissionProperty = "Commission";
        public const string MarginProperty = "Margin";
        public const string DiscountProperty = "Discount";
        private int _ServiceRequestIdField;
        private int _VATRateIdField;
        private int _ExtraCostRateIdField;
        private decimal _CommissionField;
        private decimal _MarginField;
        private decimal _DiscountField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public EstimatesDocumentState State
        {
            get
            {
                return (EstimatesDocumentState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="ServiceRequestId", IsNullable=false)]
        [XmlAttribute()]
        public int ServiceRequestId
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
        [Column(Name="VATRateId", IsNullable=false)]
        [XmlAttribute()]
        public int VATRateId
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
        [Column(Name="ExtraCostRateId", IsNullable=false)]
        [XmlAttribute()]
        public int ExtraCostRateId
        {
            get
            {
                return this._ExtraCostRateIdField;
            }
            set
            {
                this._ExtraCostRateIdField = value;
                InvokePropertyChanged("ExtraCostRateId");
            }
        }
        [Column(Name="Commission", IsNullable=false)]
        [XmlAttribute()]
        public decimal Commission
        {
            get
            {
                return this._CommissionField;
            }
            set
            {
                this._CommissionField = value;
                InvokePropertyChanged("Commission");
            }
        }
        [Column(Name="Margin", IsNullable=false)]
        [XmlAttribute()]
        public decimal Margin
        {
            get
            {
                return this._MarginField;
            }
            set
            {
                this._MarginField = value;
                InvokePropertyChanged("Margin");
            }
        }
        [Column(Name="Discount", IsNullable=false)]
        [XmlAttribute()]
        public decimal Discount
        {
            get
            {
                return this._DiscountField;
            }
            set
            {
                this._DiscountField = value;
                InvokePropertyChanged("Discount");
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
