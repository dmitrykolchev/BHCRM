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
    
    public partial class CostCenterDataAdapter : DataAdapterBase<CostCenterView, CostCenter, CostCenterFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1AccountId;
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
            this._ordinal1FileAs = reader.GetOrdinal("FileAs");
            this._ordinal1AccountId = reader.GetOrdinal("AccountId");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(CostCenterView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (CostCenterState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.AccountId = reader.GetInt32(this._ordinal1AccountId);
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
        private int _ordinal2FileAs;
        private int _ordinal2AccountId;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2AccountId = reader.GetOrdinal("AccountId");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(CostCenterView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (CostCenterState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.AccountId = reader.GetInt32(this._ordinal2AccountId);
        }
        private bool _initialized0;
        private int _ordinal0Id;
        private int _ordinal0State;
        private int _ordinal0FileAs;
        private int _ordinal0AccountId;
        private int _ordinal0Comments;
        private int _ordinal0Created;
        private int _ordinal0CreatedBy;
        private int _ordinal0Modified;
        private int _ordinal0ModifiedBy;
        private int _ordinal0RowVersion;
        private void InitializeBindGetItemResultToItem(SqlDataReader reader)
        {
            if (this._initialized0) return;
            this._ordinal0Id = reader.GetOrdinal("Id");
            this._ordinal0State = reader.GetOrdinal("State");
            this._ordinal0FileAs = reader.GetOrdinal("FileAs");
            this._ordinal0AccountId = reader.GetOrdinal("AccountId");
            this._ordinal0Comments = reader.GetOrdinal("Comments");
            this._ordinal0Created = reader.GetOrdinal("Created");
            this._ordinal0CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal0Modified = reader.GetOrdinal("Modified");
            this._ordinal0ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal0RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized0 = true;
        }
        protected override void BindGetItemResultToItem(CostCenter item, SqlDataReader reader)
        {
            InitializeBindGetItemResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal0Id);
            item.State = (CostCenterState)reader.GetByte(this._ordinal0State);
            item.FileAs = reader.GetString(this._ordinal0FileAs);
            item.AccountId = reader.GetInt32(this._ordinal0AccountId);
            if(reader.IsDBNull(_ordinal0Comments)) item.Comments = null; else item.Comments = reader.GetString(this._ordinal0Comments);
            item.Created = reader.GetDateTime(this._ordinal0Created);
            item.CreatedBy = reader.GetInt32(this._ordinal0CreatedBy);
            item.Modified = reader.GetDateTime(this._ordinal0Modified);
            item.ModifiedBy = reader.GetInt32(this._ordinal0ModifiedBy);
            item.RowVersion = reader.GetSqlBinary(this._ordinal0RowVersion).Value;
        }
        protected override void BindCreateCommand(SqlCommand command, CostCenter item)
        {
            command.Parameters["@FileAs"].Value = DbValueConverter.Convert(item.FileAs);
            command.Parameters["@AccountId"].Value = item.AccountId;
            command.Parameters["@Comments"].Value = DbValueConverter.Convert(item.Comments);
        }
        protected override void BindUpdateCommand(SqlCommand command, CostCenter item)
        {
            command.Parameters["@Id"].Value = item.Id;
            command.Parameters["@FileAs"].Value = DbValueConverter.Convert(item.FileAs);
            command.Parameters["@AccountId"].Value = item.AccountId;
            command.Parameters["@Comments"].Value = DbValueConverter.Convert(item.Comments);
            command.Parameters["@RowVersion"].Value = DbValueConverter.Convert(item.RowVersion);
        }
    }
}
