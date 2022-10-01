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
    
    public partial class PayrollDataAdapter : XmlDataAdapterBase<PayrollView, Payroll, PayrollFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1Number;
        private int _ordinal1DocumentDate;
        private int _ordinal1OrganizationId;
        private int _ordinal1OperatingBudgetId;
        private int _ordinal1SalaryBudgetItemId;
        private int _ordinal1TaxBudgetItemId;
        private int _ordinal1CashingBudgetItemId;
        private int _ordinal1ExtraCostRateId;
        private int _ordinal1CalculationStage;
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
            this._ordinal1OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal1OperatingBudgetId = reader.GetOrdinal("OperatingBudgetId");
            this._ordinal1SalaryBudgetItemId = reader.GetOrdinal("SalaryBudgetItemId");
            this._ordinal1TaxBudgetItemId = reader.GetOrdinal("TaxBudgetItemId");
            this._ordinal1CashingBudgetItemId = reader.GetOrdinal("CashingBudgetItemId");
            this._ordinal1ExtraCostRateId = reader.GetOrdinal("ExtraCostRateId");
            this._ordinal1CalculationStage = reader.GetOrdinal("CalculationStage");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(PayrollView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (PayrollState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.Number = reader.GetString(this._ordinal1Number);
            item.DocumentDate = reader.GetDateTime(this._ordinal1DocumentDate);
            item.OrganizationId = reader.GetInt32(this._ordinal1OrganizationId);
            item.OperatingBudgetId = reader.GetInt32(this._ordinal1OperatingBudgetId);
            item.SalaryBudgetItemId = reader.GetInt32(this._ordinal1SalaryBudgetItemId);
            item.TaxBudgetItemId = reader.GetInt32(this._ordinal1TaxBudgetItemId);
            item.CashingBudgetItemId = reader.GetInt32(this._ordinal1CashingBudgetItemId);
            item.ExtraCostRateId = reader.GetInt32(this._ordinal1ExtraCostRateId);
            item.CalculationStage = reader.GetInt32(this._ordinal1CalculationStage);
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
        private int _ordinal2OrganizationId;
        private int _ordinal2OperatingBudgetId;
        private int _ordinal2SalaryBudgetItemId;
        private int _ordinal2TaxBudgetItemId;
        private int _ordinal2CashingBudgetItemId;
        private int _ordinal2ExtraCostRateId;
        private int _ordinal2CalculationStage;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2Number = reader.GetOrdinal("Number");
            this._ordinal2DocumentDate = reader.GetOrdinal("DocumentDate");
            this._ordinal2OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal2OperatingBudgetId = reader.GetOrdinal("OperatingBudgetId");
            this._ordinal2SalaryBudgetItemId = reader.GetOrdinal("SalaryBudgetItemId");
            this._ordinal2TaxBudgetItemId = reader.GetOrdinal("TaxBudgetItemId");
            this._ordinal2CashingBudgetItemId = reader.GetOrdinal("CashingBudgetItemId");
            this._ordinal2ExtraCostRateId = reader.GetOrdinal("ExtraCostRateId");
            this._ordinal2CalculationStage = reader.GetOrdinal("CalculationStage");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(PayrollView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (PayrollState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.Number = reader.GetString(this._ordinal2Number);
            item.DocumentDate = reader.GetDateTime(this._ordinal2DocumentDate);
            item.OrganizationId = reader.GetInt32(this._ordinal2OrganizationId);
            item.OperatingBudgetId = reader.GetInt32(this._ordinal2OperatingBudgetId);
            item.SalaryBudgetItemId = reader.GetInt32(this._ordinal2SalaryBudgetItemId);
            item.TaxBudgetItemId = reader.GetInt32(this._ordinal2TaxBudgetItemId);
            item.CashingBudgetItemId = reader.GetInt32(this._ordinal2CashingBudgetItemId);
            item.ExtraCostRateId = reader.GetInt32(this._ordinal2ExtraCostRateId);
            item.CalculationStage = reader.GetInt32(this._ordinal2CalculationStage);
        }
    }
}