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
    
    public partial class DocumentNumberingRuleDataAdapter : DataAdapterBase<DocumentNumberingRuleView, DocumentNumberingRule, DocumentNumberingRuleFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1OrganizationId;
        private int _ordinal1DocumentTypeId;
        private int _ordinal1PeriodStart;
        private int _ordinal1PeriodEnd;
        private int _ordinal1Value;
        private int _ordinal1Increment;
        private int _ordinal1FormatString;
        private int _ordinal1FileAsFormatString;
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
            this._ordinal1OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal1DocumentTypeId = reader.GetOrdinal("DocumentTypeId");
            this._ordinal1PeriodStart = reader.GetOrdinal("PeriodStart");
            this._ordinal1PeriodEnd = reader.GetOrdinal("PeriodEnd");
            this._ordinal1Value = reader.GetOrdinal("Value");
            this._ordinal1Increment = reader.GetOrdinal("Increment");
            this._ordinal1FormatString = reader.GetOrdinal("FormatString");
            this._ordinal1FileAsFormatString = reader.GetOrdinal("FileAsFormatString");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(DocumentNumberingRuleView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (DocumentNumberingRuleState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.OrganizationId = reader.GetInt32(this._ordinal1OrganizationId);
            item.DocumentTypeId = reader.GetInt32(this._ordinal1DocumentTypeId);
            if(reader.IsDBNull(_ordinal1PeriodStart)) item.PeriodStart = null; else item.PeriodStart = reader.GetDateTime(this._ordinal1PeriodStart);
            if(reader.IsDBNull(_ordinal1PeriodEnd)) item.PeriodEnd = null; else item.PeriodEnd = reader.GetDateTime(this._ordinal1PeriodEnd);
            item.Value = reader.GetInt32(this._ordinal1Value);
            item.Increment = reader.GetInt32(this._ordinal1Increment);
            if(reader.IsDBNull(_ordinal1FormatString)) item.FormatString = null; else item.FormatString = reader.GetString(this._ordinal1FormatString);
            if(reader.IsDBNull(_ordinal1FileAsFormatString)) item.FileAsFormatString = null; else item.FileAsFormatString = reader.GetString(this._ordinal1FileAsFormatString);
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
        private int _ordinal2OrganizationId;
        private int _ordinal2DocumentTypeId;
        private int _ordinal2PeriodStart;
        private int _ordinal2PeriodEnd;
        private int _ordinal2Value;
        private int _ordinal2Increment;
        private int _ordinal2FormatString;
        private int _ordinal2FileAsFormatString;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal2DocumentTypeId = reader.GetOrdinal("DocumentTypeId");
            this._ordinal2PeriodStart = reader.GetOrdinal("PeriodStart");
            this._ordinal2PeriodEnd = reader.GetOrdinal("PeriodEnd");
            this._ordinal2Value = reader.GetOrdinal("Value");
            this._ordinal2Increment = reader.GetOrdinal("Increment");
            this._ordinal2FormatString = reader.GetOrdinal("FormatString");
            this._ordinal2FileAsFormatString = reader.GetOrdinal("FileAsFormatString");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(DocumentNumberingRuleView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (DocumentNumberingRuleState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.OrganizationId = reader.GetInt32(this._ordinal2OrganizationId);
            item.DocumentTypeId = reader.GetInt32(this._ordinal2DocumentTypeId);
            if(reader.IsDBNull(_ordinal2PeriodStart)) item.PeriodStart = null; else item.PeriodStart = reader.GetDateTime(this._ordinal2PeriodStart);
            if(reader.IsDBNull(_ordinal2PeriodEnd)) item.PeriodEnd = null; else item.PeriodEnd = reader.GetDateTime(this._ordinal2PeriodEnd);
            item.Value = reader.GetInt32(this._ordinal2Value);
            item.Increment = reader.GetInt32(this._ordinal2Increment);
            if(reader.IsDBNull(_ordinal2FormatString)) item.FormatString = null; else item.FormatString = reader.GetString(this._ordinal2FormatString);
            if(reader.IsDBNull(_ordinal2FileAsFormatString)) item.FileAsFormatString = null; else item.FileAsFormatString = reader.GetString(this._ordinal2FileAsFormatString);
        }
        private bool _initialized0;
        private int _ordinal0Id;
        private int _ordinal0State;
        private int _ordinal0FileAs;
        private int _ordinal0OrganizationId;
        private int _ordinal0DocumentTypeId;
        private int _ordinal0PeriodStart;
        private int _ordinal0PeriodEnd;
        private int _ordinal0Value;
        private int _ordinal0Increment;
        private int _ordinal0FormatString;
        private int _ordinal0FileAsFormatString;
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
            this._ordinal0OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal0DocumentTypeId = reader.GetOrdinal("DocumentTypeId");
            this._ordinal0PeriodStart = reader.GetOrdinal("PeriodStart");
            this._ordinal0PeriodEnd = reader.GetOrdinal("PeriodEnd");
            this._ordinal0Value = reader.GetOrdinal("Value");
            this._ordinal0Increment = reader.GetOrdinal("Increment");
            this._ordinal0FormatString = reader.GetOrdinal("FormatString");
            this._ordinal0FileAsFormatString = reader.GetOrdinal("FileAsFormatString");
            this._ordinal0Comments = reader.GetOrdinal("Comments");
            this._ordinal0Created = reader.GetOrdinal("Created");
            this._ordinal0CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal0Modified = reader.GetOrdinal("Modified");
            this._ordinal0ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal0RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized0 = true;
        }
        protected override void BindGetItemResultToItem(DocumentNumberingRule item, SqlDataReader reader)
        {
            InitializeBindGetItemResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal0Id);
            item.State = (DocumentNumberingRuleState)reader.GetByte(this._ordinal0State);
            item.FileAs = reader.GetString(this._ordinal0FileAs);
            item.OrganizationId = reader.GetInt32(this._ordinal0OrganizationId);
            item.DocumentTypeId = reader.GetInt32(this._ordinal0DocumentTypeId);
            if(reader.IsDBNull(_ordinal0PeriodStart)) item.PeriodStart = null; else item.PeriodStart = reader.GetDateTime(this._ordinal0PeriodStart);
            if(reader.IsDBNull(_ordinal0PeriodEnd)) item.PeriodEnd = null; else item.PeriodEnd = reader.GetDateTime(this._ordinal0PeriodEnd);
            item.Value = reader.GetInt32(this._ordinal0Value);
            item.Increment = reader.GetInt32(this._ordinal0Increment);
            if(reader.IsDBNull(_ordinal0FormatString)) item.FormatString = null; else item.FormatString = reader.GetString(this._ordinal0FormatString);
            if(reader.IsDBNull(_ordinal0FileAsFormatString)) item.FileAsFormatString = null; else item.FileAsFormatString = reader.GetString(this._ordinal0FileAsFormatString);
            if(reader.IsDBNull(_ordinal0Comments)) item.Comments = null; else item.Comments = reader.GetString(this._ordinal0Comments);
            item.Created = reader.GetDateTime(this._ordinal0Created);
            item.CreatedBy = reader.GetInt32(this._ordinal0CreatedBy);
            item.Modified = reader.GetDateTime(this._ordinal0Modified);
            item.ModifiedBy = reader.GetInt32(this._ordinal0ModifiedBy);
            item.RowVersion = reader.GetSqlBinary(this._ordinal0RowVersion).Value;
        }
        protected override void BindCreateCommand(SqlCommand command, DocumentNumberingRule item)
        {
            command.Parameters["@FileAs"].Value = DbValueConverter.Convert(item.FileAs);
            command.Parameters["@OrganizationId"].Value = item.OrganizationId;
            command.Parameters["@DocumentTypeId"].Value = item.DocumentTypeId;
            command.Parameters["@PeriodStart"].Value = DbValueConverter.Convert(item.PeriodStart);
            command.Parameters["@PeriodEnd"].Value = DbValueConverter.Convert(item.PeriodEnd);
            command.Parameters["@Value"].Value = item.Value;
            command.Parameters["@Increment"].Value = item.Increment;
            command.Parameters["@FormatString"].Value = DbValueConverter.Convert(item.FormatString);
            command.Parameters["@FileAsFormatString"].Value = DbValueConverter.Convert(item.FileAsFormatString);
            command.Parameters["@Comments"].Value = DbValueConverter.Convert(item.Comments);
        }
        protected override void BindUpdateCommand(SqlCommand command, DocumentNumberingRule item)
        {
            command.Parameters["@Id"].Value = item.Id;
            command.Parameters["@FileAs"].Value = DbValueConverter.Convert(item.FileAs);
            command.Parameters["@OrganizationId"].Value = item.OrganizationId;
            command.Parameters["@DocumentTypeId"].Value = item.DocumentTypeId;
            command.Parameters["@PeriodStart"].Value = DbValueConverter.Convert(item.PeriodStart);
            command.Parameters["@PeriodEnd"].Value = DbValueConverter.Convert(item.PeriodEnd);
            command.Parameters["@Value"].Value = item.Value;
            command.Parameters["@Increment"].Value = item.Increment;
            command.Parameters["@FormatString"].Value = DbValueConverter.Convert(item.FormatString);
            command.Parameters["@FileAsFormatString"].Value = DbValueConverter.Convert(item.FileAsFormatString);
            command.Parameters["@Comments"].Value = DbValueConverter.Convert(item.Comments);
            command.Parameters["@RowVersion"].Value = DbValueConverter.Convert(item.RowVersion);
        }
    }
}