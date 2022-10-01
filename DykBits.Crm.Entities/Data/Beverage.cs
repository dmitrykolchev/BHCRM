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
    
    public enum BeverageState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
        [XmlEnum("2")]
        Inactive = 2,
    }
    public partial class Beverage : DataItem
    {
        public const string DataItemClassName = "Beverage";
        public const string OrganizationIdProperty = "OrganizationId";
        public const string CodeProperty = "Code";
        public const string FullNameProperty = "FullName";
        public const string AbstractProductIdProperty = "AbstractProductId";
        public const string ProductTypeIdProperty = "ProductTypeId";
        public const string ProductCategoryIdProperty = "ProductCategoryId";
        public const string ProductSubcategoryIdProperty = "ProductSubcategoryId";
        public const string ServiceLevelIdProperty = "ServiceLevelId";
        public const string AllowNegativeBalanceProperty = "AllowNegativeBalance";
        public const string CountryIdProperty = "CountryId";
        public const string ManufacturerProperty = "Manufacturer";
        public const string SupplierIdProperty = "SupplierId";
        public const string ItemColorIdProperty = "ItemColorId";
        public const string ListPriceProperty = "ListPrice";
        public const string StandardCostProperty = "StandardCost";
        public const string UnitOfMeasureIdProperty = "UnitOfMeasureId";
        public const string SizeProperty = "Size";
        public const string SizeUnitOfMeasureIdProperty = "SizeUnitOfMeasureId";
        public const string WeightProperty = "Weight";
        public const string WeightUnitOfMeasureIdProperty = "WeightUnitOfMeasureId";
        public const string DiscontinuedDateProperty = "DiscontinuedDate";
        public const string PictureProperty = "Picture";
        public const string BeverageTypeIdProperty = "BeverageTypeId";
        public const string BeverageSubtypeIdProperty = "BeverageSubtypeId";
        public const string BeveragePackIdProperty = "BeveragePackId";
        public const string BeverageMiscIdProperty = "BeverageMiscId";
        public const string VolumeProperty = "Volume";
        private int _OrganizationIdField;
        private string _CodeField;
        private string _FullNameField;
        private System.Nullable<int> _AbstractProductIdField;
        private int _ProductTypeIdField;
        private int _ProductCategoryIdField;
        private System.Nullable<int> _ProductSubcategoryIdField;
        private int _ServiceLevelIdField;
        private bool _AllowNegativeBalanceField;
        private System.Nullable<int> _CountryIdField;
        private string _ManufacturerField;
        private System.Nullable<int> _SupplierIdField;
        private System.Nullable<int> _ItemColorIdField;
        private decimal _ListPriceField;
        private decimal _StandardCostField;
        private int _UnitOfMeasureIdField;
        private System.Nullable<decimal> _SizeField;
        private System.Nullable<int> _SizeUnitOfMeasureIdField;
        private System.Nullable<decimal> _WeightField;
        private System.Nullable<int> _WeightUnitOfMeasureIdField;
        private System.Nullable<System.DateTime> _DiscontinuedDateField;
        private byte[] _PictureField;
        private System.Nullable<int> _BeverageTypeIdField;
        private System.Nullable<int> _BeverageSubtypeIdField;
        private System.Nullable<int> _BeveragePackIdField;
        private System.Nullable<int> _BeverageMiscIdField;
        private System.Nullable<decimal> _VolumeField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public BeverageState State
        {
            get
            {
                return (BeverageState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="OrganizationId", IsNullable=false)]
        [XmlAttribute()]
        public int OrganizationId
        {
            get
            {
                return this._OrganizationIdField;
            }
            set
            {
                this._OrganizationIdField = value;
                InvokePropertyChanged("OrganizationId");
            }
        }
        [Column(Name="Code", IsNullable=true, MaximumLength=32)]
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
                InvokePropertyChanged("Code");
            }
        }
        [Column(Name="FullName", IsNullable=true, MaximumLength=1024)]
        [XmlAttribute()]
        public string FullName
        {
            get
            {
                return this._FullNameField;
            }
            set
            {
                this._FullNameField = value;
                InvokePropertyChanged("FullName");
            }
        }
        [Column(Name="AbstractProductId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> AbstractProductId
        {
            get
            {
                return this._AbstractProductIdField;
            }
            set
            {
                this._AbstractProductIdField = value;
                InvokePropertyChanged("AbstractProductId");
            }
        }
        [Column(Name="ProductTypeId", IsNullable=false)]
        [XmlAttribute()]
        public int ProductTypeId
        {
            get
            {
                return this._ProductTypeIdField;
            }
            set
            {
                this._ProductTypeIdField = value;
                InvokePropertyChanged("ProductTypeId");
            }
        }
        [Column(Name="ProductCategoryId", IsNullable=false)]
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
                InvokePropertyChanged("ProductCategoryId");
            }
        }
        [Column(Name="ProductSubcategoryId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ProductSubcategoryId
        {
            get
            {
                return this._ProductSubcategoryIdField;
            }
            set
            {
                this._ProductSubcategoryIdField = value;
                InvokePropertyChanged("ProductSubcategoryId");
            }
        }
        [Column(Name="ServiceLevelId", IsNullable=false)]
        [XmlAttribute()]
        public int ServiceLevelId
        {
            get
            {
                return this._ServiceLevelIdField;
            }
            set
            {
                this._ServiceLevelIdField = value;
                InvokePropertyChanged("ServiceLevelId");
            }
        }
        [Column(Name="AllowNegativeBalance", IsNullable=false)]
        [XmlAttribute()]
        public bool AllowNegativeBalance
        {
            get
            {
                return this._AllowNegativeBalanceField;
            }
            set
            {
                this._AllowNegativeBalanceField = value;
                InvokePropertyChanged("AllowNegativeBalance");
            }
        }
        [Column(Name="CountryId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> CountryId
        {
            get
            {
                return this._CountryIdField;
            }
            set
            {
                this._CountryIdField = value;
                InvokePropertyChanged("CountryId");
            }
        }
        [Column(Name="Manufacturer", IsNullable=true, MaximumLength=64)]
        [XmlAttribute()]
        public string Manufacturer
        {
            get
            {
                return this._ManufacturerField;
            }
            set
            {
                this._ManufacturerField = value;
                InvokePropertyChanged("Manufacturer");
            }
        }
        [Column(Name="SupplierId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> SupplierId
        {
            get
            {
                return this._SupplierIdField;
            }
            set
            {
                this._SupplierIdField = value;
                InvokePropertyChanged("SupplierId");
            }
        }
        [Column(Name="ItemColorId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ItemColorId
        {
            get
            {
                return this._ItemColorIdField;
            }
            set
            {
                this._ItemColorIdField = value;
                InvokePropertyChanged("ItemColorId");
            }
        }
        [Column(Name="ListPrice", IsNullable=false)]
        [XmlAttribute()]
        public decimal ListPrice
        {
            get
            {
                return this._ListPriceField;
            }
            set
            {
                this._ListPriceField = value;
                InvokePropertyChanged("ListPrice");
            }
        }
        [Column(Name="StandardCost", IsNullable=false)]
        [XmlAttribute()]
        public decimal StandardCost
        {
            get
            {
                return this._StandardCostField;
            }
            set
            {
                this._StandardCostField = value;
                InvokePropertyChanged("StandardCost");
            }
        }
        [Column(Name="UnitOfMeasureId", IsNullable=false)]
        [XmlAttribute()]
        public int UnitOfMeasureId
        {
            get
            {
                return this._UnitOfMeasureIdField;
            }
            set
            {
                this._UnitOfMeasureIdField = value;
                InvokePropertyChanged("UnitOfMeasureId");
            }
        }
        [Column(Name="Size", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<decimal> Size
        {
            get
            {
                return this._SizeField;
            }
            set
            {
                this._SizeField = value;
                InvokePropertyChanged("Size");
            }
        }
        [Column(Name="SizeUnitOfMeasureId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> SizeUnitOfMeasureId
        {
            get
            {
                return this._SizeUnitOfMeasureIdField;
            }
            set
            {
                this._SizeUnitOfMeasureIdField = value;
                InvokePropertyChanged("SizeUnitOfMeasureId");
            }
        }
        [Column(Name="Weight", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<decimal> Weight
        {
            get
            {
                return this._WeightField;
            }
            set
            {
                this._WeightField = value;
                InvokePropertyChanged("Weight");
            }
        }
        [Column(Name="WeightUnitOfMeasureId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> WeightUnitOfMeasureId
        {
            get
            {
                return this._WeightUnitOfMeasureIdField;
            }
            set
            {
                this._WeightUnitOfMeasureIdField = value;
                InvokePropertyChanged("WeightUnitOfMeasureId");
            }
        }
        [Column(Name="DiscontinuedDate", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<System.DateTime> DiscontinuedDate
        {
            get
            {
                return this._DiscontinuedDateField;
            }
            set
            {
                this._DiscontinuedDateField = value;
                InvokePropertyChanged("DiscontinuedDate");
            }
        }
        [Column(Name="Picture", IsNullable=true, MaximumLength=-1)]
        [XmlAttribute()]
        public byte[] Picture
        {
            get
            {
                return this._PictureField;
            }
            set
            {
                this._PictureField = value;
                InvokePropertyChanged("Picture");
            }
        }
        [Column(Name="BeverageTypeId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> BeverageTypeId
        {
            get
            {
                return this._BeverageTypeIdField;
            }
            set
            {
                this._BeverageTypeIdField = value;
                InvokePropertyChanged("BeverageTypeId");
            }
        }
        [Column(Name="BeverageSubtypeId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> BeverageSubtypeId
        {
            get
            {
                return this._BeverageSubtypeIdField;
            }
            set
            {
                this._BeverageSubtypeIdField = value;
                InvokePropertyChanged("BeverageSubtypeId");
            }
        }
        [Column(Name="BeveragePackId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> BeveragePackId
        {
            get
            {
                return this._BeveragePackIdField;
            }
            set
            {
                this._BeveragePackIdField = value;
                InvokePropertyChanged("BeveragePackId");
            }
        }
        [Column(Name="BeverageMiscId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> BeverageMiscId
        {
            get
            {
                return this._BeverageMiscIdField;
            }
            set
            {
                this._BeverageMiscIdField = value;
                InvokePropertyChanged("BeverageMiscId");
            }
        }
        [Column(Name="Volume", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<decimal> Volume
        {
            get
            {
                return this._VolumeField;
            }
            set
            {
                this._VolumeField = value;
                InvokePropertyChanged("Volume");
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