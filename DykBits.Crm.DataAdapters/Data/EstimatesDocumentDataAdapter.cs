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
    
    public partial class EstimatesDocumentDataAdapter : XmlDataAdapterBase<EstimatesDocumentView, EstimatesDocument, EstimatesDocumentFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1Number;
        private int _ordinal1DocumentDate;
        private int _ordinal1AccountId;
        private int _ordinal1VenueProviderId;
        private int _ordinal1ReasonId;
        private int _ordinal1ServiceRequestTypeId;
        private int _ordinal1OrganizationId;
        private int _ordinal1ServiceRequestId;
        private int _ordinal1VATRateId;
        private int _ordinal1ExtraCostRateId;
        private int _ordinal1Commission;
        private int _ordinal1Margin;
        private int _ordinal1Discount;
        private int _ordinal1TotalPrice;
        private int _ordinal1TotalCost;
        private int _ordinal1Income;
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
            this._ordinal1Number = reader.GetOrdinal("Number");
            this._ordinal1DocumentDate = reader.GetOrdinal("DocumentDate");
            this._ordinal1AccountId = reader.GetOrdinal("AccountId");
            this._ordinal1VenueProviderId = reader.GetOrdinal("VenueProviderId");
            this._ordinal1ReasonId = reader.GetOrdinal("ReasonId");
            this._ordinal1ServiceRequestTypeId = reader.GetOrdinal("ServiceRequestTypeId");
            this._ordinal1OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal1ServiceRequestId = reader.GetOrdinal("ServiceRequestId");
            this._ordinal1VATRateId = reader.GetOrdinal("VATRateId");
            this._ordinal1ExtraCostRateId = reader.GetOrdinal("ExtraCostRateId");
            this._ordinal1Commission = reader.GetOrdinal("Commission");
            this._ordinal1Margin = reader.GetOrdinal("Margin");
            this._ordinal1Discount = reader.GetOrdinal("Discount");
            this._ordinal1TotalPrice = reader.GetOrdinal("TotalPrice");
            this._ordinal1TotalCost = reader.GetOrdinal("TotalCost");
            this._ordinal1Income = reader.GetOrdinal("Income");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(EstimatesDocumentView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (EstimatesDocumentState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.Number = reader.GetString(this._ordinal1Number);
            item.DocumentDate = reader.GetDateTime(this._ordinal1DocumentDate);
            item.AccountId = reader.GetInt32(this._ordinal1AccountId);
            if(reader.IsDBNull(_ordinal1VenueProviderId)) item.VenueProviderId = null; else item.VenueProviderId = reader.GetInt32(this._ordinal1VenueProviderId);
            item.ReasonId = reader.GetInt32(this._ordinal1ReasonId);
            item.ServiceRequestTypeId = reader.GetInt32(this._ordinal1ServiceRequestTypeId);
            item.OrganizationId = reader.GetInt32(this._ordinal1OrganizationId);
            item.ServiceRequestId = reader.GetInt32(this._ordinal1ServiceRequestId);
            item.VATRateId = reader.GetInt32(this._ordinal1VATRateId);
            item.ExtraCostRateId = reader.GetInt32(this._ordinal1ExtraCostRateId);
            item.Commission = reader.GetDecimal(this._ordinal1Commission);
            item.Margin = reader.GetDecimal(this._ordinal1Margin);
            item.Discount = reader.GetDecimal(this._ordinal1Discount);
            if(reader.IsDBNull(_ordinal1TotalPrice)) item.TotalPrice = null; else item.TotalPrice = reader.GetDecimal(this._ordinal1TotalPrice);
            if(reader.IsDBNull(_ordinal1TotalCost)) item.TotalCost = null; else item.TotalCost = reader.GetDecimal(this._ordinal1TotalCost);
            if(reader.IsDBNull(_ordinal1Income)) item.Income = null; else item.Income = reader.GetDecimal(this._ordinal1Income);
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
        private int _ordinal2Number;
        private int _ordinal2DocumentDate;
        private int _ordinal2AccountId;
        private int _ordinal2VenueProviderId;
        private int _ordinal2ReasonId;
        private int _ordinal2ServiceRequestTypeId;
        private int _ordinal2OrganizationId;
        private int _ordinal2ServiceRequestId;
        private int _ordinal2VATRateId;
        private int _ordinal2ExtraCostRateId;
        private int _ordinal2Commission;
        private int _ordinal2Margin;
        private int _ordinal2Discount;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2Number = reader.GetOrdinal("Number");
            this._ordinal2DocumentDate = reader.GetOrdinal("DocumentDate");
            this._ordinal2AccountId = reader.GetOrdinal("AccountId");
            this._ordinal2VenueProviderId = reader.GetOrdinal("VenueProviderId");
            this._ordinal2ReasonId = reader.GetOrdinal("ReasonId");
            this._ordinal2ServiceRequestTypeId = reader.GetOrdinal("ServiceRequestTypeId");
            this._ordinal2OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal2ServiceRequestId = reader.GetOrdinal("ServiceRequestId");
            this._ordinal2VATRateId = reader.GetOrdinal("VATRateId");
            this._ordinal2ExtraCostRateId = reader.GetOrdinal("ExtraCostRateId");
            this._ordinal2Commission = reader.GetOrdinal("Commission");
            this._ordinal2Margin = reader.GetOrdinal("Margin");
            this._ordinal2Discount = reader.GetOrdinal("Discount");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(EstimatesDocumentView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (EstimatesDocumentState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.Number = reader.GetString(this._ordinal2Number);
            item.DocumentDate = reader.GetDateTime(this._ordinal2DocumentDate);
            item.AccountId = reader.GetInt32(this._ordinal2AccountId);
            if(reader.IsDBNull(_ordinal2VenueProviderId)) item.VenueProviderId = null; else item.VenueProviderId = reader.GetInt32(this._ordinal2VenueProviderId);
            item.ReasonId = reader.GetInt32(this._ordinal2ReasonId);
            item.ServiceRequestTypeId = reader.GetInt32(this._ordinal2ServiceRequestTypeId);
            item.OrganizationId = reader.GetInt32(this._ordinal2OrganizationId);
            item.ServiceRequestId = reader.GetInt32(this._ordinal2ServiceRequestId);
            item.VATRateId = reader.GetInt32(this._ordinal2VATRateId);
            item.ExtraCostRateId = reader.GetInt32(this._ordinal2ExtraCostRateId);
            item.Commission = reader.GetDecimal(this._ordinal2Commission);
            item.Margin = reader.GetDecimal(this._ordinal2Margin);
            item.Discount = reader.GetDecimal(this._ordinal2Discount);
        }
    }
}
