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
    
    public enum PresentationNodeState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
        [XmlEnum("2")]
        Inactive = 2,
    }
    public partial class PresentationNode : DataItem
    {
        public const string DataItemClassName = "PresentationNode";
        public const string KeyProperty = "Key";
        public const string DefaultViewIdProperty = "DefaultViewId";
        public const string OrdinalPositionProperty = "OrdinalPosition";
        public const string ViewControlTypeNameProperty = "ViewControlTypeName";
        public const string ParameterProperty = "Parameter";
        public const string ParentIdProperty = "ParentId";
        public const string DocumentTypeIdProperty = "DocumentTypeId";
        public const string SmallImageDataProperty = "SmallImageData";
        public const string LargeImageDataProperty = "LargeImageData";
        public const string NodeTypeProperty = "NodeType";
        private string _KeyField;
        private System.Nullable<int> _DefaultViewIdField;
        private int _OrdinalPositionField;
        private string _ViewControlTypeNameField;
        private string _ParameterField;
        private System.Nullable<int> _ParentIdField;
        private System.Nullable<int> _DocumentTypeIdField;
        private byte[] _SmallImageDataField;
        private byte[] _LargeImageDataField;
        private int _NodeTypeField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public PresentationNodeState State
        {
            get
            {
                return (PresentationNodeState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="Key", IsNullable=false, MaximumLength=256)]
        [XmlAttribute()]
        public string Key
        {
            get
            {
                return this._KeyField;
            }
            set
            {
                this._KeyField = value;
                InvokePropertyChanged("Key");
            }
        }
        [Column(Name="DefaultViewId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DefaultViewId
        {
            get
            {
                return this._DefaultViewIdField;
            }
            set
            {
                this._DefaultViewIdField = value;
                InvokePropertyChanged("DefaultViewId");
            }
        }
        [Column(Name="OrdinalPosition", IsNullable=false)]
        [XmlAttribute()]
        public int OrdinalPosition
        {
            get
            {
                return this._OrdinalPositionField;
            }
            set
            {
                this._OrdinalPositionField = value;
                InvokePropertyChanged("OrdinalPosition");
            }
        }
        [Column(Name="ViewControlTypeName", IsNullable=true, MaximumLength=1024)]
        [XmlAttribute()]
        public string ViewControlTypeName
        {
            get
            {
                return this._ViewControlTypeNameField;
            }
            set
            {
                this._ViewControlTypeNameField = value;
                InvokePropertyChanged("ViewControlTypeName");
            }
        }
        [Column(Name="Parameter", IsNullable=true, MaximumLength=256)]
        [XmlAttribute()]
        public string Parameter
        {
            get
            {
                return this._ParameterField;
            }
            set
            {
                this._ParameterField = value;
                InvokePropertyChanged("Parameter");
            }
        }
        [Column(Name="ParentId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ParentId
        {
            get
            {
                return this._ParentIdField;
            }
            set
            {
                this._ParentIdField = value;
                InvokePropertyChanged("ParentId");
            }
        }
        [Column(Name="DocumentTypeId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DocumentTypeId
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
        [Column(Name="SmallImageData", IsNullable=true, MaximumLength=-1)]
        [XmlAttribute()]
        public byte[] SmallImageData
        {
            get
            {
                return this._SmallImageDataField;
            }
            set
            {
                this._SmallImageDataField = value;
                InvokePropertyChanged("SmallImageData");
            }
        }
        [Column(Name="LargeImageData", IsNullable=true, MaximumLength=-1)]
        [XmlAttribute()]
        public byte[] LargeImageData
        {
            get
            {
                return this._LargeImageDataField;
            }
            set
            {
                this._LargeImageDataField = value;
                InvokePropertyChanged("LargeImageData");
            }
        }
        [Column(Name="NodeType", IsNullable=false)]
        [XmlAttribute()]
        public int NodeType
        {
            get
            {
                return this._NodeTypeField;
            }
            set
            {
                this._NodeTypeField = value;
                InvokePropertyChanged("NodeType");
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
