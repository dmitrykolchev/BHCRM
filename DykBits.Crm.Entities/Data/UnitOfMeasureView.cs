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
    
    public partial class UnitOfMeasureView : DataItemView
    {
        public const string DataItemClassName = "UnitOfMeasure";
        private System.Nullable<int> _UnitOfMeasureClassIdField;
        private string _CodeField;
        private decimal _MultiplierField;
        private decimal _DividerField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public UnitOfMeasureState State
        {
            get
            {
                return (UnitOfMeasureState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public System.Nullable<int> UnitOfMeasureClassId
        {
            get
            {
                return this._UnitOfMeasureClassIdField;
            }
            set
            {
                this._UnitOfMeasureClassIdField = value;
            }
        }
        [XmlAttribute()]
        public string Code
        {
            get
            {
                return this._CodeField;
            }
            set
            {
                this._CodeField = value;
            }
        }
        [XmlAttribute()]
        public decimal Multiplier
        {
            get
            {
                return this._MultiplierField;
            }
            set
            {
                this._MultiplierField = value;
            }
        }
        [XmlAttribute()]
        public decimal Divider
        {
            get
            {
                return this._DividerField;
            }
            set
            {
                this._DividerField = value;
            }
        }
    }
}
