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
    
    public enum DocumentTransitionState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
    }
    public partial class DocumentTransition : DataItem
    {
        public const string DataItemClassName = "DocumentTransition";
        public const string DocumentTypeIdProperty = "DocumentTypeId";
        public const string FromStateProperty = "FromState";
        public const string ToStateProperty = "ToState";
        private int _DocumentTypeIdField;
        private byte _FromStateField;
        private byte _ToStateField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public DocumentTransitionState State
        {
            get
            {
                return (DocumentTransitionState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="DocumentTypeId", IsNullable=false)]
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
                InvokePropertyChanged("DocumentTypeId");
            }
        }
        [Column(Name="FromState", IsNullable=false)]
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
                InvokePropertyChanged("FromState");
            }
        }
        [Column(Name="ToState", IsNullable=false)]
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
                InvokePropertyChanged("ToState");
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
