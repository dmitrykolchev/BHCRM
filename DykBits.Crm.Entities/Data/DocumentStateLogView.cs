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
    
    public partial class DocumentStateLogView : DataItemView
    {
        public const string DataItemClassName = "DocumentStateLog";
        private int _DocumentTypeIdField;
        private int _DocumentIdField;
        private byte _FromStateField;
        private byte _ToStateField;
        private string _DataField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public DocumentStateLogState State
        {
            get
            {
                return (DocumentStateLogState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public int DocumentTypeId
        {
            get
            {
                return this._DocumentTypeIdField;
            }
            set
            {
                this._DocumentTypeIdField = value;
            }
        }
        [XmlAttribute()]
        public int DocumentId
        {
            get
            {
                return this._DocumentIdField;
            }
            set
            {
                this._DocumentIdField = value;
            }
        }
        [XmlAttribute()]
        public byte FromState
        {
            get
            {
                return this._FromStateField;
            }
            set
            {
                this._FromStateField = value;
            }
        }
        [XmlAttribute()]
        public byte ToState
        {
            get
            {
                return this._ToStateField;
            }
            set
            {
                this._ToStateField = value;
            }
        }
        [XmlAttribute()]
        public string Data
        {
            get
            {
                return this._DataField;
            }
            set
            {
                this._DataField = value;
            }
        }
    }
}
