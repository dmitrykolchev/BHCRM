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
    
    public partial class ExtraCostRateView : DataItemView
    {
        public const string DataItemClassName = "ExtraCostRate";
        private decimal _ValueField;
        private bool _IsDefaultField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public ExtraCostRateState State
        {
            get
            {
                return (ExtraCostRateState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
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
        public bool IsDefault
        {
            get
            {
                return this._IsDefaultField;
            }
            set
            {
                this._IsDefaultField = value;
            }
        }
    }
}
