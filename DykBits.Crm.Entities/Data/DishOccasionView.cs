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
    
    public partial class DishOccasionView : DataItemView
    {
        public const string DataItemClassName = "DishOccasion";
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public DishOccasionState State
        {
            get
            {
                return (DishOccasionState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
    }
}
