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
    
    public partial class DocumentTypeEntryDataAdapter : XmlDataAdapterBase<DocumentTypeEntryView, DocumentTypeEntry, DocumentTypeEntryFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1ClassName;
        private int _ordinal1TableName;
        private int _ordinal1SchemaName;
        private int _ordinal1ClrTypeName;
        private int _ordinal1DataAdapterTypeName;
        private int _ordinal1DataAdapterMode;
        private int _ordinal1IsNumbered;
        private int _ordinal1SmallImage;
        private int _ordinal1LargeImage;
        private int _ordinal1SupportsTransitionTemplates;
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
            this._ordinal1ClassName = reader.GetOrdinal("ClassName");
            this._ordinal1TableName = reader.GetOrdinal("TableName");
            this._ordinal1SchemaName = reader.GetOrdinal("SchemaName");
            this._ordinal1ClrTypeName = reader.GetOrdinal("ClrTypeName");
            this._ordinal1DataAdapterTypeName = reader.GetOrdinal("DataAdapterTypeName");
            this._ordinal1DataAdapterMode = reader.GetOrdinal("DataAdapterMode");
            this._ordinal1IsNumbered = reader.GetOrdinal("IsNumbered");
            this._ordinal1SmallImage = reader.GetOrdinal("SmallImage");
            this._ordinal1LargeImage = reader.GetOrdinal("LargeImage");
            this._ordinal1SupportsTransitionTemplates = reader.GetOrdinal("SupportsTransitionTemplates");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(DocumentTypeEntryView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (DocumentTypeEntryState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.ClassName = reader.GetString(this._ordinal1ClassName);
            item.TableName = reader.GetString(this._ordinal1TableName);
            item.SchemaName = reader.GetString(this._ordinal1SchemaName);
            if(reader.IsDBNull(_ordinal1ClrTypeName)) item.ClrTypeName = null; else item.ClrTypeName = reader.GetString(this._ordinal1ClrTypeName);
            if(reader.IsDBNull(_ordinal1DataAdapterTypeName)) item.DataAdapterTypeName = null; else item.DataAdapterTypeName = reader.GetString(this._ordinal1DataAdapterTypeName);
            if(reader.IsDBNull(_ordinal1DataAdapterMode)) item.DataAdapterMode = null; else item.DataAdapterMode = reader.GetString(this._ordinal1DataAdapterMode);
            item.IsNumbered = reader.GetBoolean(this._ordinal1IsNumbered);
            if(reader.IsDBNull(_ordinal1SmallImage)) item.SmallImage = null; else item.SmallImage = reader.GetSqlBinary(this._ordinal1SmallImage).Value;
            if(reader.IsDBNull(_ordinal1LargeImage)) item.LargeImage = null; else item.LargeImage = reader.GetSqlBinary(this._ordinal1LargeImage).Value;
            item.SupportsTransitionTemplates = reader.GetBoolean(this._ordinal1SupportsTransitionTemplates);
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
        private int _ordinal2ClassName;
        private int _ordinal2TableName;
        private int _ordinal2SchemaName;
        private int _ordinal2ClrTypeName;
        private int _ordinal2DataAdapterTypeName;
        private int _ordinal2DataAdapterMode;
        private int _ordinal2IsNumbered;
        private int _ordinal2SmallImage;
        private int _ordinal2LargeImage;
        private int _ordinal2SupportsTransitionTemplates;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2ClassName = reader.GetOrdinal("ClassName");
            this._ordinal2TableName = reader.GetOrdinal("TableName");
            this._ordinal2SchemaName = reader.GetOrdinal("SchemaName");
            this._ordinal2ClrTypeName = reader.GetOrdinal("ClrTypeName");
            this._ordinal2DataAdapterTypeName = reader.GetOrdinal("DataAdapterTypeName");
            this._ordinal2DataAdapterMode = reader.GetOrdinal("DataAdapterMode");
            this._ordinal2IsNumbered = reader.GetOrdinal("IsNumbered");
            this._ordinal2SmallImage = reader.GetOrdinal("SmallImage");
            this._ordinal2LargeImage = reader.GetOrdinal("LargeImage");
            this._ordinal2SupportsTransitionTemplates = reader.GetOrdinal("SupportsTransitionTemplates");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(DocumentTypeEntryView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (DocumentTypeEntryState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.ClassName = reader.GetString(this._ordinal2ClassName);
            item.TableName = reader.GetString(this._ordinal2TableName);
            item.SchemaName = reader.GetString(this._ordinal2SchemaName);
            if(reader.IsDBNull(_ordinal2ClrTypeName)) item.ClrTypeName = null; else item.ClrTypeName = reader.GetString(this._ordinal2ClrTypeName);
            if(reader.IsDBNull(_ordinal2DataAdapterTypeName)) item.DataAdapterTypeName = null; else item.DataAdapterTypeName = reader.GetString(this._ordinal2DataAdapterTypeName);
            if(reader.IsDBNull(_ordinal2DataAdapterMode)) item.DataAdapterMode = null; else item.DataAdapterMode = reader.GetString(this._ordinal2DataAdapterMode);
            item.IsNumbered = reader.GetBoolean(this._ordinal2IsNumbered);
            if(reader.IsDBNull(_ordinal2SmallImage)) item.SmallImage = null; else item.SmallImage = reader.GetSqlBinary(this._ordinal2SmallImage).Value;
            if(reader.IsDBNull(_ordinal2LargeImage)) item.LargeImage = null; else item.LargeImage = reader.GetSqlBinary(this._ordinal2LargeImage).Value;
            item.SupportsTransitionTemplates = reader.GetBoolean(this._ordinal2SupportsTransitionTemplates);
        }
    }
}
