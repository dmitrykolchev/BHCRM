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
    
    public enum MasterMenuState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
        [XmlEnum("2")]
        Inactive = 2,
    }
    public partial class MasterMenu : DataItem
    {
        public const string DataItemClassName = "MasterMenu";
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
        public const string ItemColorIdProperty = "ItemColorId";
        public const string ListPriceProperty = "ListPrice";
        public const string StandardCostProperty = "StandardCost";
        public const string PriceMarginIdProperty = "PriceMarginId";
        public const string UnitOfMeasureIdProperty = "UnitOfMeasureId";
        public const string SizeProperty = "Size";
        public const string SizeUnitOfMeasureIdProperty = "SizeUnitOfMeasureId";
        public const string WeightProperty = "Weight";
        public const string WeightUnitOfMeasureIdProperty = "WeightUnitOfMeasureId";
        public const string DiscontinuedDateProperty = "DiscontinuedDate";
        public const string PictureProperty = "Picture";
        public const string DishIngredientIdProperty = "DishIngredientId";
        public const string DishTypeIdProperty = "DishTypeId";
        public const string DishSubtypeIdProperty = "DishSubtypeId";
        public const string DishCourseIdProperty = "DishCourseId";
        public const string DishOccasionIdProperty = "DishOccasionId";
        public const string DishWorldIdProperty = "DishWorldId";
        public const string DishServingMaskProperty = "DishServingMask";
        public const string DishCookingMethodIdProperty = "DishCookingMethodId";
        public const string SeasonMaskProperty = "SeasonMask";
        public const string ServiceRequestTypeMaskProperty = "ServiceRequestTypeMask";
        public const string ServingAmountProperty = "ServingAmount";
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
        private System.Nullable<int> _ItemColorIdField;
        private decimal _ListPriceField;
        private decimal _StandardCostField;
        private int _PriceMarginIdField;
        private int _UnitOfMeasureIdField;
        private System.Nullable<decimal> _SizeField;
        private System.Nullable<int> _SizeUnitOfMeasureIdField;
        private System.Nullable<decimal> _WeightField;
        private System.Nullable<int> _WeightUnitOfMeasureIdField;
        private System.Nullable<System.DateTime> _DiscontinuedDateField;
        private byte[] _PictureField;
        private System.Nullable<int> _DishIngredientIdField;
        private System.Nullable<int> _DishTypeIdField;
        private System.Nullable<int> _DishSubtypeIdField;
        private System.Nullable<int> _DishCourseIdField;
        private System.Nullable<int> _DishOccasionIdField;
        private System.Nullable<int> _DishWorldIdField;
        private System.Nullable<int> _DishServingMaskField;
        private System.Nullable<int> _DishCookingMethodIdField;
        private System.Nullable<int> _SeasonMaskField;
        private System.Nullable<int> _ServiceRequestTypeMaskField;
        private System.Nullable<decimal> _ServingAmountField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public MasterMenuState State
        {
            get
            {
                return (MasterMenuState)((IDataItem)this).State;
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
        [Column(Name="PriceMarginId", IsNullable=false)]
        [XmlAttribute()]
        public int PriceMarginId
        {
            get
            {
                return this._PriceMarginIdField;
            }
            set
            {
                this._PriceMarginIdField = value;
                InvokePropertyChanged("PriceMarginId");
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
        [Column(Name="DishIngredientId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishIngredientId
        {
            get
            {
                return this._DishIngredientIdField;
            }
            set
            {
                this._DishIngredientIdField = value;
                InvokePropertyChanged("DishIngredientId");
            }
        }
        [Column(Name="DishTypeId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishTypeId
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
        [Column(Name="DishSubtypeId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishSubtypeId
        {
            get
            {
                return this._DishSubtypeIdField;
            }
            set
            {
                this._DishSubtypeIdField = value;
                InvokePropertyChanged("DishSubtypeId");
            }
        }
        [Column(Name="DishCourseId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishCourseId
        {
            get
            {
                return this._DishCourseIdField;
            }
            set
            {
                this._DishCourseIdField = value;
                InvokePropertyChanged("DishCourseId");
            }
        }
        [Column(Name="DishOccasionId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishOccasionId
        {
            get
            {
                return this._DishOccasionIdField;
            }
            set
            {
                this._DishOccasionIdField = value;
                InvokePropertyChanged("DishOccasionId");
            }
        }
        [Column(Name="DishWorldId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishWorldId
        {
            get
            {
                return this._DishWorldIdField;
            }
            set
            {
                this._DishWorldIdField = value;
                InvokePropertyChanged("DishWorldId");
            }
        }
        [Column(Name="DishServingMask", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishServingMask
        {
            get
            {
                return this._DishServingMaskField;
            }
            set
            {
                this._DishServingMaskField = value;
                InvokePropertyChanged("DishServingMask");
            }
        }
        [Column(Name="DishCookingMethodId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> DishCookingMethodId
        {
            get
            {
                return this._DishCookingMethodIdField;
            }
            set
            {
                this._DishCookingMethodIdField = value;
                InvokePropertyChanged("DishCookingMethodId");
            }
        }
        [Column(Name="SeasonMask", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> SeasonMask
        {
            get
            {
                return this._SeasonMaskField;
            }
            set
            {
                this._SeasonMaskField = value;
                InvokePropertyChanged("SeasonMask");
            }
        }
        [Column(Name="ServiceRequestTypeMask", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ServiceRequestTypeMask
        {
            get
            {
                return this._ServiceRequestTypeMaskField;
            }
            set
            {
                this._ServiceRequestTypeMaskField = value;
                InvokePropertyChanged("ServiceRequestTypeMask");
            }
        }
        [Column(Name="ServingAmount", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<decimal> ServingAmount
        {
            get
            {
                return this._ServingAmountField;
            }
            set
            {
                this._ServingAmountField = value;
                InvokePropertyChanged("ServingAmount");
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