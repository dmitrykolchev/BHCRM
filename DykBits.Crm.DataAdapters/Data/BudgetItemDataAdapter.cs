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
    
    public partial class BudgetItemDataAdapter : XmlDataAdapterBase<BudgetItemView, BudgetItem, BudgetItemFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1Code;
        private int _ordinal1FileAs;
        private int _ordinal1BudgetItemGroupId;
        private int _ordinal1BudgetItemGroupType;
        private int _ordinal1IsExpenseGroup;
        private int _ordinal1BudgetItemType;
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
            this._ordinal1Code = reader.GetOrdinal("Code");
            this._ordinal1FileAs = reader.GetOrdinal("FileAs");
            this._ordinal1BudgetItemGroupId = reader.GetOrdinal("BudgetItemGroupId");
            this._ordinal1BudgetItemGroupType = reader.GetOrdinal("BudgetItemGroupType");
            this._ordinal1IsExpenseGroup = reader.GetOrdinal("IsExpenseGroup");
            this._ordinal1BudgetItemType = reader.GetOrdinal("BudgetItemType");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(BudgetItemView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (BudgetItemState)reader.GetByte(this._ordinal1State);
            item.Code = reader.GetString(this._ordinal1Code);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.BudgetItemGroupId = reader.GetInt32(this._ordinal1BudgetItemGroupId);
            item.BudgetItemGroupType = reader.GetInt32(this._ordinal1BudgetItemGroupType);
            item.IsExpenseGroup = reader.GetBoolean(this._ordinal1IsExpenseGroup);
            item.BudgetItemType = reader.GetInt32(this._ordinal1BudgetItemType);
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
        private int _ordinal2Code;
        private int _ordinal2FileAs;
        private int _ordinal2BudgetItemGroupId;
        private int _ordinal2BudgetItemGroupType;
        private int _ordinal2IsExpenseGroup;
        private int _ordinal2BudgetItemType;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2Code = reader.GetOrdinal("Code");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2BudgetItemGroupId = reader.GetOrdinal("BudgetItemGroupId");
            this._ordinal2BudgetItemGroupType = reader.GetOrdinal("BudgetItemGroupType");
            this._ordinal2IsExpenseGroup = reader.GetOrdinal("IsExpenseGroup");
            this._ordinal2BudgetItemType = reader.GetOrdinal("BudgetItemType");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(BudgetItemView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (BudgetItemState)reader.GetByte(this._ordinal2State);
            item.Code = reader.GetString(this._ordinal2Code);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.BudgetItemGroupId = reader.GetInt32(this._ordinal2BudgetItemGroupId);
            item.BudgetItemGroupType = reader.GetInt32(this._ordinal2BudgetItemGroupType);
            item.IsExpenseGroup = reader.GetBoolean(this._ordinal2IsExpenseGroup);
            item.BudgetItemType = reader.GetInt32(this._ordinal2BudgetItemType);
        }
    }
}
