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
    
    public partial class DataQueryDataAdapter : XmlDataAdapterBase<DataQueryView, DataQuery, DataQueryFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1DocumentElement;
        private int _ordinal1Selector;
        private int _ordinal1Value;
        private int _ordinal1SchemaName;
        private int _ordinal1ProcedureName;
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
            this._ordinal1DocumentElement = reader.GetOrdinal("DocumentElement");
            this._ordinal1Selector = reader.GetOrdinal("Selector");
            this._ordinal1Value = reader.GetOrdinal("Value");
            this._ordinal1SchemaName = reader.GetOrdinal("SchemaName");
            this._ordinal1ProcedureName = reader.GetOrdinal("ProcedureName");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(DataQueryView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (DataQueryState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.DocumentElement = reader.GetString(this._ordinal1DocumentElement);
            if(reader.IsDBNull(_ordinal1Selector)) item.Selector = null; else item.Selector = reader.GetString(this._ordinal1Selector);
            if(reader.IsDBNull(_ordinal1Value)) item.Value = null; else item.Value = reader.GetString(this._ordinal1Value);
            item.SchemaName = reader.GetString(this._ordinal1SchemaName);
            item.ProcedureName = reader.GetString(this._ordinal1ProcedureName);
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
        private int _ordinal2DocumentElement;
        private int _ordinal2Selector;
        private int _ordinal2Value;
        private int _ordinal2SchemaName;
        private int _ordinal2ProcedureName;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2DocumentElement = reader.GetOrdinal("DocumentElement");
            this._ordinal2Selector = reader.GetOrdinal("Selector");
            this._ordinal2Value = reader.GetOrdinal("Value");
            this._ordinal2SchemaName = reader.GetOrdinal("SchemaName");
            this._ordinal2ProcedureName = reader.GetOrdinal("ProcedureName");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(DataQueryView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (DataQueryState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.DocumentElement = reader.GetString(this._ordinal2DocumentElement);
            if(reader.IsDBNull(_ordinal2Selector)) item.Selector = null; else item.Selector = reader.GetString(this._ordinal2Selector);
            if(reader.IsDBNull(_ordinal2Value)) item.Value = null; else item.Value = reader.GetString(this._ordinal2Value);
            item.SchemaName = reader.GetString(this._ordinal2SchemaName);
            item.ProcedureName = reader.GetString(this._ordinal2ProcedureName);
        }
    }
}
