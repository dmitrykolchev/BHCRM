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
    
    public partial class ProductSubcategoryView : DataItemView
    {
        public const string DataItemClassName = "ProductSubcategory";
        private int _ProductCategoryIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public ProductSubcategoryState State
        {
            get
            {
                return (ProductSubcategoryState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public int ProductCategoryId
        {
            get
            {
                return this._ProductCategoryIdField;
            }
            set
            {
                this._ProductCategoryIdField = value;
            }
        }
    }
}
