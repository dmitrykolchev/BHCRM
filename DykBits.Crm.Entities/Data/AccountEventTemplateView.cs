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
    
    public partial class AccountEventTemplateView : DataItemView
    {
        public const string DataItemClassName = "AccountEventTemplate";
        private int _AccountEventTypeIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public AccountEventTemplateState State
        {
            get
            {
                return (AccountEventTemplateState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public int AccountEventTypeId
        {
            get
            {
                return this._AccountEventTypeIdField;
            }
            set
            {
                this._AccountEventTypeIdField = value;
            }
        }
    }
}