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
    
    public enum DishSubtypeState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
    }
    public partial class DishSubtype : DataItem
    {
        public const string DataItemClassName = "DishSubtype";
        public const string DishTypeIdProperty = "DishTypeId";
        private int _DishTypeIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public DishSubtypeState State
        {
            get
            {
                return (DishSubtypeState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="DishTypeId", IsNullable=false)]
        [XmlAttribute()]
        public int DishTypeId
        {
            get
            {
                return this._DishTypeIdField;
            }
            set
            {
                this._DishTypeIdField = value;
                InvokePropertyChanged("DishTypeId");
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
