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
    
    public partial class InventoryBalance : DataItemView
    {
        public const string DataItemClassName = "Product";
        private int _OrganizationIdField;
        private int _ProductClassField;
        private string _CodeField;
        private string _FullNameField;
        private System.Nullable<int> _AbstractProductIdField;
        private int _ProductTypeIdField;
        private int _ProductCategoryIdField;
        private System.Nullable<int> _ProductSubcategoryIdField;
        private int _ServiceLevelIdField;
        private System.Nullable<int> _CountryIdField;
        private string _ManufacturerField;
        private System.Nullable<int> _SupplierIdField;
        private decimal _ListPriceField;
        private int _PriceMarginIdField;
        private int _UnitOfMeasureIdField;
        private System.Nullable<decimal> _SizeField;
        private System.Nullable<int> _SizeUnitOfMeasureIdField;
        private System.Nullable<decimal> _WeightField;
        private System.Nullable<int> _WeightUnitOfMeasureIdField;
        private System.Nullable<System.DateTime> _DiscontinuedDateField;
        private int _StoragePlaceIdField;
        private System.Nullable<decimal> _IncomingAmountField;
        private System.Nullable<decimal> _IncomingTotalCostField;
        private System.Nullable<decimal> _OutgoingAmountField;
        private System.Nullable<decimal> _OutgoingTotalCostField;
        private System.Nullable<decimal> _ReservedAmountField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        public ProductState State
        {
            get
            {
                return (ProductState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        public int OrganizationId
        {
            get
            {
                return this._OrganizationIdField;
            }
            set
            {
                this._OrganizationIdField = value;
            }
        }
        public int ProductClass
        {
            get
            {
                return this._ProductClassField;
            }
            set
            {
                this._ProductClassField = value;
            }
        }
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
        public string FullName
        {
            get
            {
                return this._FullNameField;
            }
            set
            {
                this._FullNameField = value;
            }
        }
        public System.Nullable<int> AbstractProductId
        {
            get
            {
                return this._AbstractProductIdField;
            }
            set
            {
                this._AbstractProductIdField = value;
            }
        }
        public int ProductTypeId
        {
            get
            {
                return this._ProductTypeIdField;
            }
            set
            {
                this._ProductTypeIdField = value;
            }
        }
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
        public System.Nullable<int> ProductSubcategoryId
        {
            get
            {
                return this._ProductSubcategoryIdField;
            }
            set
            {
                this._ProductSubcategoryIdField = value;
            }
        }
        public int ServiceLevelId
        {
            get
            {
                return this._ServiceLevelIdField;
            }
            set
            {
                this._ServiceLevelIdField = value;
            }
        }
        public System.Nullable<int> CountryId
        {
            get
            {
                return this._CountryIdField;
            }
            set
            {
                this._CountryIdField = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return this._ManufacturerField;
            }
            set
            {
                this._ManufacturerField = value;
            }
        }
        public System.Nullable<int> SupplierId
        {
            get
            {
                return this._SupplierIdField;
            }
            set
            {
                this._SupplierIdField = value;
            }
        }
        public decimal ListPrice
        {
            get
            {
                return this._ListPriceField;
            }
            set
            {
                this._ListPriceField = value;
            }
        }
        public int PriceMarginId
        {
            get
            {
                return this._PriceMarginIdField;
            }
            set
            {
                this._PriceMarginIdField = value;
            }
        }
        public int UnitOfMeasureId
        {
            get
            {
                return this._UnitOfMeasureIdField;
            }
            set
            {
                this._UnitOfMeasureIdField = value;
            }
        }
        public System.Nullable<decimal> Size
        {
            get
            {
                return this._SizeField;
            }
            set
            {
                this._SizeField = value;
            }
        }
        public System.Nullable<int> SizeUnitOfMeasureId
        {
            get
            {
                return this._SizeUnitOfMeasureIdField;
            }
            set
            {
                this._SizeUnitOfMeasureIdField = value;
            }
        }
        public System.Nullable<decimal> Weight
        {
            get
            {
                return this._WeightField;
            }
            set
            {
                this._WeightField = value;
            }
        }
        public System.Nullable<int> WeightUnitOfMeasureId
        {
            get
            {
                return this._WeightUnitOfMeasureIdField;
            }
            set
            {
                this._WeightUnitOfMeasureIdField = value;
            }
        }
        public System.Nullable<System.DateTime> DiscontinuedDate
        {
            get
            {
                return this._DiscontinuedDateField;
            }
            set
            {
                this._DiscontinuedDateField = value;
            }
        }
        public int StoragePlaceId
        {
            get
            {
                return this._StoragePlaceIdField;
            }
            set
            {
                this._StoragePlaceIdField = value;
            }
        }
        public System.Nullable<decimal> IncomingAmount
        {
            get
            {
                return this._IncomingAmountField;
            }
            set
            {
                this._IncomingAmountField = value;
            }
        }
        public System.Nullable<decimal> IncomingTotalCost
        {
            get
            {
                return this._IncomingTotalCostField;
            }
            set
            {
                this._IncomingTotalCostField = value;
            }
        }
        public System.Nullable<decimal> OutgoingAmount
        {
            get
            {
                return this._OutgoingAmountField;
            }
            set
            {
                this._OutgoingAmountField = value;
            }
        }
        public System.Nullable<decimal> OutgoingTotalCost
        {
            get
            {
                return this._OutgoingTotalCostField;
            }
            set
            {
                this._OutgoingTotalCostField = value;
            }
        }
        public System.Nullable<decimal> ReservedAmount
        {
            get
            {
                return this._ReservedAmountField;
            }
            set
            {
                this._ReservedAmountField = value;
            }
        }
    }
}
