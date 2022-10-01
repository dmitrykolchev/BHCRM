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
    using System.Data;
    using System.Data.SqlClient;
    
    public partial class BeverageDataAdapter : XmlDataAdapterBase<BeverageView, Beverage, BeverageFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1OrganizationId;
        private int _ordinal1Code;
        private int _ordinal1FileAs;
        private int _ordinal1FullName;
        private int _ordinal1AbstractProductId;
        private int _ordinal1ProductTypeId;
        private int _ordinal1ProductCategoryId;
        private int _ordinal1ProductSubcategoryId;
        private int _ordinal1ServiceLevelId;
        private int _ordinal1AllowNegativeBalance;
        private int _ordinal1CountryId;
        private int _ordinal1Manufacturer;
        private int _ordinal1SupplierId;
        private int _ordinal1ItemColorId;
        private int _ordinal1ListPrice;
        private int _ordinal1StandardCost;
        private int _ordinal1UnitOfMeasureId;
        private int _ordinal1Size;
        private int _ordinal1SizeUnitOfMeasureId;
        private int _ordinal1Weight;
        private int _ordinal1WeightUnitOfMeasureId;
        private int _ordinal1DiscontinuedDate;
        private int _ordinal1BeverageTypeId;
        private int _ordinal1BeverageSubtypeId;
        private int _ordinal1BeveragePackId;
        private int _ordinal1BeverageMiscId;
        private int _ordinal1Volume;
        private int _ordinal1Comments;
        private int _ordinal1Created;
        private int _ordinal1CreatedBy;
        private int _ordinal1Modified;
        private int _ordinal1ModifiedBy;
        private int _ordinal1RowVersion;
        private void InitializeBindBrowseResultToItem(SqlDataReader reader)
        {
            if (this._initialized1) return;
            this._ordinal1Id = reader.GetOrdinal("Id");
            this._ordinal1State = reader.GetOrdinal("State");
            this._ordinal1OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal1Code = reader.GetOrdinal("Code");
            this._ordinal1FileAs = reader.GetOrdinal("FileAs");
            this._ordinal1FullName = reader.GetOrdinal("FullName");
            this._ordinal1AbstractProductId = reader.GetOrdinal("AbstractProductId");
            this._ordinal1ProductTypeId = reader.GetOrdinal("ProductTypeId");
            this._ordinal1ProductCategoryId = reader.GetOrdinal("ProductCategoryId");
            this._ordinal1ProductSubcategoryId = reader.GetOrdinal("ProductSubcategoryId");
            this._ordinal1ServiceLevelId = reader.GetOrdinal("ServiceLevelId");
            this._ordinal1AllowNegativeBalance = reader.GetOrdinal("AllowNegativeBalance");
            this._ordinal1CountryId = reader.GetOrdinal("CountryId");
            this._ordinal1Manufacturer = reader.GetOrdinal("Manufacturer");
            this._ordinal1SupplierId = reader.GetOrdinal("SupplierId");
            this._ordinal1ItemColorId = reader.GetOrdinal("ItemColorId");
            this._ordinal1ListPrice = reader.GetOrdinal("ListPrice");
            this._ordinal1StandardCost = reader.GetOrdinal("StandardCost");
            this._ordinal1UnitOfMeasureId = reader.GetOrdinal("UnitOfMeasureId");
            this._ordinal1Size = reader.GetOrdinal("Size");
            this._ordinal1SizeUnitOfMeasureId = reader.GetOrdinal("SizeUnitOfMeasureId");
            this._ordinal1Weight = reader.GetOrdinal("Weight");
            this._ordinal1WeightUnitOfMeasureId = reader.GetOrdinal("WeightUnitOfMeasureId");
            this._ordinal1DiscontinuedDate = reader.GetOrdinal("DiscontinuedDate");
            this._ordinal1BeverageTypeId = reader.GetOrdinal("BeverageTypeId");
            this._ordinal1BeverageSubtypeId = reader.GetOrdinal("BeverageSubtypeId");
            this._ordinal1BeveragePackId = reader.GetOrdinal("BeveragePackId");
            this._ordinal1BeverageMiscId = reader.GetOrdinal("BeverageMiscId");
            this._ordinal1Volume = reader.GetOrdinal("Volume");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(BeverageView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (BeverageState)reader.GetByte(this._ordinal1State);
            item.OrganizationId = reader.GetInt32(this._ordinal1OrganizationId);
            if(reader.IsDBNull(_ordinal1Code)) item.Code = null; else item.Code = reader.GetString(this._ordinal1Code);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            if(reader.IsDBNull(_ordinal1FullName)) item.FullName = null; else item.FullName = reader.GetString(this._ordinal1FullName);
            if(reader.IsDBNull(_ordinal1AbstractProductId)) item.AbstractProductId = null; else item.AbstractProductId = reader.GetInt32(this._ordinal1AbstractProductId);
            item.ProductTypeId = reader.GetInt32(this._ordinal1ProductTypeId);
            item.ProductCategoryId = reader.GetInt32(this._ordinal1ProductCategoryId);
            if(reader.IsDBNull(_ordinal1ProductSubcategoryId)) item.ProductSubcategoryId = null; else item.ProductSubcategoryId = reader.GetInt32(this._ordinal1ProductSubcategoryId);
            item.ServiceLevelId = reader.GetInt32(this._ordinal1ServiceLevelId);
            item.AllowNegativeBalance = reader.GetBoolean(this._ordinal1AllowNegativeBalance);
            if(reader.IsDBNull(_ordinal1CountryId)) item.CountryId = null; else item.CountryId = reader.GetInt32(this._ordinal1CountryId);
            if(reader.IsDBNull(_ordinal1Manufacturer)) item.Manufacturer = null; else item.Manufacturer = reader.GetString(this._ordinal1Manufacturer);
            if(reader.IsDBNull(_ordinal1SupplierId)) item.SupplierId = null; else item.SupplierId = reader.GetInt32(this._ordinal1SupplierId);
            if(reader.IsDBNull(_ordinal1ItemColorId)) item.ItemColorId = null; else item.ItemColorId = reader.GetInt32(this._ordinal1ItemColorId);
            item.ListPrice = reader.GetDecimal(this._ordinal1ListPrice);
            item.StandardCost = reader.GetDecimal(this._ordinal1StandardCost);
            item.UnitOfMeasureId = reader.GetInt32(this._ordinal1UnitOfMeasureId);
            if(reader.IsDBNull(_ordinal1Size)) item.Size = null; else item.Size = reader.GetDecimal(this._ordinal1Size);
            if(reader.IsDBNull(_ordinal1SizeUnitOfMeasureId)) item.SizeUnitOfMeasureId = null; else item.SizeUnitOfMeasureId = reader.GetInt32(this._ordinal1SizeUnitOfMeasureId);
            if(reader.IsDBNull(_ordinal1Weight)) item.Weight = null; else item.Weight = reader.GetDecimal(this._ordinal1Weight);
            if(reader.IsDBNull(_ordinal1WeightUnitOfMeasureId)) item.WeightUnitOfMeasureId = null; else item.WeightUnitOfMeasureId = reader.GetInt32(this._ordinal1WeightUnitOfMeasureId);
            if(reader.IsDBNull(_ordinal1DiscontinuedDate)) item.DiscontinuedDate = null; else item.DiscontinuedDate = reader.GetDateTime(this._ordinal1DiscontinuedDate);
            if(reader.IsDBNull(_ordinal1BeverageTypeId)) item.BeverageTypeId = null; else item.BeverageTypeId = reader.GetInt32(this._ordinal1BeverageTypeId);
            if(reader.IsDBNull(_ordinal1BeverageSubtypeId)) item.BeverageSubtypeId = null; else item.BeverageSubtypeId = reader.GetInt32(this._ordinal1BeverageSubtypeId);
            if(reader.IsDBNull(_ordinal1BeveragePackId)) item.BeveragePackId = null; else item.BeveragePackId = reader.GetInt32(this._ordinal1BeveragePackId);
            if(reader.IsDBNull(_ordinal1BeverageMiscId)) item.BeverageMiscId = null; else item.BeverageMiscId = reader.GetInt32(this._ordinal1BeverageMiscId);
            if(reader.IsDBNull(_ordinal1Volume)) item.Volume = null; else item.Volume = reader.GetDecimal(this._ordinal1Volume);
            if(reader.IsDBNull(_ordinal1Comments)) item.Comments = null; else item.Comments = reader.GetString(this._ordinal1Comments);
            item.Created = reader.GetDateTime(this._ordinal1Created);
            item.CreatedBy = reader.GetInt32(this._ordinal1CreatedBy);
            item.Modified = reader.GetDateTime(this._ordinal1Modified);
            item.ModifiedBy = reader.GetInt32(this._ordinal1ModifiedBy);
            item.RowVersion = reader.GetSqlBinary(this._ordinal1RowVersion).Value;
        }
        private bool _initialized2;
        private int _ordinal2Id;
        private int _ordinal2State;
        private int _ordinal2OrganizationId;
        private int _ordinal2Code;
        private int _ordinal2FileAs;
        private int _ordinal2FullName;
        private int _ordinal2AbstractProductId;
        private int _ordinal2ProductTypeId;
        private int _ordinal2ProductCategoryId;
        private int _ordinal2ProductSubcategoryId;
        private int _ordinal2ServiceLevelId;
        private int _ordinal2AllowNegativeBalance;
        private int _ordinal2CountryId;
        private int _ordinal2Manufacturer;
        private int _ordinal2SupplierId;
        private int _ordinal2ItemColorId;
        private int _ordinal2ListPrice;
        private int _ordinal2StandardCost;
        private int _ordinal2UnitOfMeasureId;
        private int _ordinal2Size;
        private int _ordinal2SizeUnitOfMeasureId;
        private int _ordinal2Weight;
        private int _ordinal2WeightUnitOfMeasureId;
        private int _ordinal2DiscontinuedDate;
        private int _ordinal2BeverageTypeId;
        private int _ordinal2BeverageSubtypeId;
        private int _ordinal2BeveragePackId;
        private int _ordinal2BeverageMiscId;
        private int _ordinal2Volume;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal2Code = reader.GetOrdinal("Code");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2FullName = reader.GetOrdinal("FullName");
            this._ordinal2AbstractProductId = reader.GetOrdinal("AbstractProductId");
            this._ordinal2ProductTypeId = reader.GetOrdinal("ProductTypeId");
            this._ordinal2ProductCategoryId = reader.GetOrdinal("ProductCategoryId");
            this._ordinal2ProductSubcategoryId = reader.GetOrdinal("ProductSubcategoryId");
            this._ordinal2ServiceLevelId = reader.GetOrdinal("ServiceLevelId");
            this._ordinal2AllowNegativeBalance = reader.GetOrdinal("AllowNegativeBalance");
            this._ordinal2CountryId = reader.GetOrdinal("CountryId");
            this._ordinal2Manufacturer = reader.GetOrdinal("Manufacturer");
            this._ordinal2SupplierId = reader.GetOrdinal("SupplierId");
            this._ordinal2ItemColorId = reader.GetOrdinal("ItemColorId");
            this._ordinal2ListPrice = reader.GetOrdinal("ListPrice");
            this._ordinal2StandardCost = reader.GetOrdinal("StandardCost");
            this._ordinal2UnitOfMeasureId = reader.GetOrdinal("UnitOfMeasureId");
            this._ordinal2Size = reader.GetOrdinal("Size");
            this._ordinal2SizeUnitOfMeasureId = reader.GetOrdinal("SizeUnitOfMeasureId");
            this._ordinal2Weight = reader.GetOrdinal("Weight");
            this._ordinal2WeightUnitOfMeasureId = reader.GetOrdinal("WeightUnitOfMeasureId");
            this._ordinal2DiscontinuedDate = reader.GetOrdinal("DiscontinuedDate");
            this._ordinal2BeverageTypeId = reader.GetOrdinal("BeverageTypeId");
            this._ordinal2BeverageSubtypeId = reader.GetOrdinal("BeverageSubtypeId");
            this._ordinal2BeveragePackId = reader.GetOrdinal("BeveragePackId");
            this._ordinal2BeverageMiscId = reader.GetOrdinal("BeverageMiscId");
            this._ordinal2Volume = reader.GetOrdinal("Volume");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(BeverageView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (BeverageState)reader.GetByte(this._ordinal2State);
            item.OrganizationId = reader.GetInt32(this._ordinal2OrganizationId);
            if(reader.IsDBNull(_ordinal2Code)) item.Code = null; else item.Code = reader.GetString(this._ordinal2Code);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            if(reader.IsDBNull(_ordinal2FullName)) item.FullName = null; else item.FullName = reader.GetString(this._ordinal2FullName);
            if(reader.IsDBNull(_ordinal2AbstractProductId)) item.AbstractProductId = null; else item.AbstractProductId = reader.GetInt32(this._ordinal2AbstractProductId);
            item.ProductTypeId = reader.GetInt32(this._ordinal2ProductTypeId);
            item.ProductCategoryId = reader.GetInt32(this._ordinal2ProductCategoryId);
            if(reader.IsDBNull(_ordinal2ProductSubcategoryId)) item.ProductSubcategoryId = null; else item.ProductSubcategoryId = reader.GetInt32(this._ordinal2ProductSubcategoryId);
            item.ServiceLevelId = reader.GetInt32(this._ordinal2ServiceLevelId);
            item.AllowNegativeBalance = reader.GetBoolean(this._ordinal2AllowNegativeBalance);
            if(reader.IsDBNull(_ordinal2CountryId)) item.CountryId = null; else item.CountryId = reader.GetInt32(this._ordinal2CountryId);
            if(reader.IsDBNull(_ordinal2Manufacturer)) item.Manufacturer = null; else item.Manufacturer = reader.GetString(this._ordinal2Manufacturer);
            if(reader.IsDBNull(_ordinal2SupplierId)) item.SupplierId = null; else item.SupplierId = reader.GetInt32(this._ordinal2SupplierId);
            if(reader.IsDBNull(_ordinal2ItemColorId)) item.ItemColorId = null; else item.ItemColorId = reader.GetInt32(this._ordinal2ItemColorId);
            item.ListPrice = reader.GetDecimal(this._ordinal2ListPrice);
            item.StandardCost = reader.GetDecimal(this._ordinal2StandardCost);
            item.UnitOfMeasureId = reader.GetInt32(this._ordinal2UnitOfMeasureId);
            if(reader.IsDBNull(_ordinal2Size)) item.Size = null; else item.Size = reader.GetDecimal(this._ordinal2Size);
            if(reader.IsDBNull(_ordinal2SizeUnitOfMeasureId)) item.SizeUnitOfMeasureId = null; else item.SizeUnitOfMeasureId = reader.GetInt32(this._ordinal2SizeUnitOfMeasureId);
            if(reader.IsDBNull(_ordinal2Weight)) item.Weight = null; else item.Weight = reader.GetDecimal(this._ordinal2Weight);
            if(reader.IsDBNull(_ordinal2WeightUnitOfMeasureId)) item.WeightUnitOfMeasureId = null; else item.WeightUnitOfMeasureId = reader.GetInt32(this._ordinal2WeightUnitOfMeasureId);
            if(reader.IsDBNull(_ordinal2DiscontinuedDate)) item.DiscontinuedDate = null; else item.DiscontinuedDate = reader.GetDateTime(this._ordinal2DiscontinuedDate);
            if(reader.IsDBNull(_ordinal2BeverageTypeId)) item.BeverageTypeId = null; else item.BeverageTypeId = reader.GetInt32(this._ordinal2BeverageTypeId);
            if(reader.IsDBNull(_ordinal2BeverageSubtypeId)) item.BeverageSubtypeId = null; else item.BeverageSubtypeId = reader.GetInt32(this._ordinal2BeverageSubtypeId);
            if(reader.IsDBNull(_ordinal2BeveragePackId)) item.BeveragePackId = null; else item.BeveragePackId = reader.GetInt32(this._ordinal2BeveragePackId);
            if(reader.IsDBNull(_ordinal2BeverageMiscId)) item.BeverageMiscId = null; else item.BeverageMiscId = reader.GetInt32(this._ordinal2BeverageMiscId);
            if(reader.IsDBNull(_ordinal2Volume)) item.Volume = null; else item.Volume = reader.GetDecimal(this._ordinal2Volume);
        }
    }
}
