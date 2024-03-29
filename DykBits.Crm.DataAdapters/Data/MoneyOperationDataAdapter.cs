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
    
    public partial class MoneyOperationDataAdapter : XmlDataAdapterBase<MoneyOperationView, MoneyOperation, MoneyOperationFilter>
    {
        private bool _initialized1;
        private int _ordinal1Id;
        private int _ordinal1State;
        private int _ordinal1FileAs;
        private int _ordinal1Number;
        private int _ordinal1DocumentDate;
        private int _ordinal1OrganizationId;
        private int _ordinal1ParentId;
        private int _ordinal1BankAccountId;
        private int _ordinal1MoneyOperationTypeId;
        private int _ordinal1MoneyOperationDirection;
        private int _ordinal1BudgetId;
        private int _ordinal1BudgetNumber;
        private int _ordinal1OperatingBudgetId;
        private int _ordinal1OperatingBudgetDate;
        private int _ordinal1OperatingBudgetNumber;
        private int _ordinal1BudgetItemGroupId;
        private int _ordinal1BudgetItemId;
        private int _ordinal1SalesInvoiceId;
        private int _ordinal1PurchaseInvoiceId;
        private int _ordinal1AccountId;
        private int _ordinal1EmployeeId;
        private int _ordinal1Subject;
        private int _ordinal1Value;
        private int _ordinal1VATRateId;
        private int _ordinal1VATValue;
        private int _ordinal1InValue;
        private int _ordinal1OutValue;
        private int _ordinal1InVATValue;
        private int _ordinal1OutVATValue;
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
            this._ordinal1ParentId = reader.GetOrdinal("ParentId");
            this._ordinal1BankAccountId = reader.GetOrdinal("BankAccountId");
            this._ordinal1MoneyOperationTypeId = reader.GetOrdinal("MoneyOperationTypeId");
            this._ordinal1MoneyOperationDirection = reader.GetOrdinal("MoneyOperationDirection");
            this._ordinal1BudgetId = reader.GetOrdinal("BudgetId");
            this._ordinal1BudgetNumber = reader.GetOrdinal("BudgetNumber");
            this._ordinal1OperatingBudgetId = reader.GetOrdinal("OperatingBudgetId");
            this._ordinal1OperatingBudgetDate = reader.GetOrdinal("OperatingBudgetDate");
            this._ordinal1OperatingBudgetNumber = reader.GetOrdinal("OperatingBudgetNumber");
            this._ordinal1BudgetItemGroupId = reader.GetOrdinal("BudgetItemGroupId");
            this._ordinal1BudgetItemId = reader.GetOrdinal("BudgetItemId");
            this._ordinal1SalesInvoiceId = reader.GetOrdinal("SalesInvoiceId");
            this._ordinal1PurchaseInvoiceId = reader.GetOrdinal("PurchaseInvoiceId");
            this._ordinal1AccountId = reader.GetOrdinal("AccountId");
            this._ordinal1EmployeeId = reader.GetOrdinal("EmployeeId");
            this._ordinal1Subject = reader.GetOrdinal("Subject");
            this._ordinal1Value = reader.GetOrdinal("Value");
            this._ordinal1VATRateId = reader.GetOrdinal("VATRateId");
            this._ordinal1VATValue = reader.GetOrdinal("VATValue");
            this._ordinal1InValue = reader.GetOrdinal("InValue");
            this._ordinal1OutValue = reader.GetOrdinal("OutValue");
            this._ordinal1InVATValue = reader.GetOrdinal("InVATValue");
            this._ordinal1OutVATValue = reader.GetOrdinal("OutVATValue");
            this._ordinal1Comments = reader.GetOrdinal("Comments");
            this._ordinal1Created = reader.GetOrdinal("Created");
            this._ordinal1CreatedBy = reader.GetOrdinal("CreatedBy");
            this._ordinal1Modified = reader.GetOrdinal("Modified");
            this._ordinal1ModifiedBy = reader.GetOrdinal("ModifiedBy");
            this._ordinal1RowVersion = reader.GetOrdinal("RowVersion");
            this._initialized1 = true;
        }
        protected override void BindBrowseResultToItem(MoneyOperationView item, SqlDataReader reader)
        {
            InitializeBindBrowseResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal1Id);
            item.State = (MoneyOperationState)reader.GetByte(this._ordinal1State);
            item.FileAs = reader.GetString(this._ordinal1FileAs);
            item.Number = reader.GetString(this._ordinal1Number);
            item.DocumentDate = reader.GetDateTime(this._ordinal1DocumentDate);
            item.OrganizationId = reader.GetInt32(this._ordinal1OrganizationId);
            if(reader.IsDBNull(_ordinal1ParentId)) item.ParentId = null; else item.ParentId = reader.GetInt32(this._ordinal1ParentId);
            item.BankAccountId = reader.GetInt32(this._ordinal1BankAccountId);
            item.MoneyOperationTypeId = reader.GetInt32(this._ordinal1MoneyOperationTypeId);
            item.MoneyOperationDirection = reader.GetInt32(this._ordinal1MoneyOperationDirection);
            if(reader.IsDBNull(_ordinal1BudgetId)) item.BudgetId = null; else item.BudgetId = reader.GetInt32(this._ordinal1BudgetId);
            if(reader.IsDBNull(_ordinal1BudgetNumber)) item.BudgetNumber = null; else item.BudgetNumber = reader.GetString(this._ordinal1BudgetNumber);
            if(reader.IsDBNull(_ordinal1OperatingBudgetId)) item.OperatingBudgetId = null; else item.OperatingBudgetId = reader.GetInt32(this._ordinal1OperatingBudgetId);
            if(reader.IsDBNull(_ordinal1OperatingBudgetDate)) item.OperatingBudgetDate = null; else item.OperatingBudgetDate = reader.GetDateTime(this._ordinal1OperatingBudgetDate);
            if(reader.IsDBNull(_ordinal1OperatingBudgetNumber)) item.OperatingBudgetNumber = null; else item.OperatingBudgetNumber = reader.GetString(this._ordinal1OperatingBudgetNumber);
            if(reader.IsDBNull(_ordinal1BudgetItemGroupId)) item.BudgetItemGroupId = null; else item.BudgetItemGroupId = reader.GetInt32(this._ordinal1BudgetItemGroupId);
            if(reader.IsDBNull(_ordinal1BudgetItemId)) item.BudgetItemId = null; else item.BudgetItemId = reader.GetInt32(this._ordinal1BudgetItemId);
            if(reader.IsDBNull(_ordinal1SalesInvoiceId)) item.SalesInvoiceId = null; else item.SalesInvoiceId = reader.GetInt32(this._ordinal1SalesInvoiceId);
            if(reader.IsDBNull(_ordinal1PurchaseInvoiceId)) item.PurchaseInvoiceId = null; else item.PurchaseInvoiceId = reader.GetInt32(this._ordinal1PurchaseInvoiceId);
            item.AccountId = reader.GetInt32(this._ordinal1AccountId);
            if(reader.IsDBNull(_ordinal1EmployeeId)) item.EmployeeId = null; else item.EmployeeId = reader.GetInt32(this._ordinal1EmployeeId);
            if(reader.IsDBNull(_ordinal1Subject)) item.Subject = null; else item.Subject = reader.GetString(this._ordinal1Subject);
            item.Value = reader.GetDecimal(this._ordinal1Value);
            if(reader.IsDBNull(_ordinal1VATRateId)) item.VATRateId = null; else item.VATRateId = reader.GetInt32(this._ordinal1VATRateId);
            item.VATValue = reader.GetDecimal(this._ordinal1VATValue);
            if(reader.IsDBNull(_ordinal1InValue)) item.InValue = null; else item.InValue = reader.GetDecimal(this._ordinal1InValue);
            if(reader.IsDBNull(_ordinal1OutValue)) item.OutValue = null; else item.OutValue = reader.GetDecimal(this._ordinal1OutValue);
            if(reader.IsDBNull(_ordinal1InVATValue)) item.InVATValue = null; else item.InVATValue = reader.GetDecimal(this._ordinal1InVATValue);
            if(reader.IsDBNull(_ordinal1OutVATValue)) item.OutVATValue = null; else item.OutVATValue = reader.GetDecimal(this._ordinal1OutVATValue);
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
        private int _ordinal2ParentId;
        private int _ordinal2BankAccountId;
        private int _ordinal2MoneyOperationTypeId;
        private int _ordinal2MoneyOperationDirection;
        private int _ordinal2BudgetId;
        private int _ordinal2OperatingBudgetId;
        private int _ordinal2BudgetItemGroupId;
        private int _ordinal2BudgetItemId;
        private int _ordinal2SalesInvoiceId;
        private int _ordinal2PurchaseInvoiceId;
        private int _ordinal2AccountId;
        private int _ordinal2EmployeeId;
        private int _ordinal2Subject;
        private int _ordinal2Value;
        private int _ordinal2VATRateId;
        private int _ordinal2VATValue;
        private void InitializeBindListResultToItem(SqlDataReader reader)
        {
            if (this._initialized2) return;
            this._ordinal2Id = reader.GetOrdinal("Id");
            this._ordinal2State = reader.GetOrdinal("State");
            this._ordinal2FileAs = reader.GetOrdinal("FileAs");
            this._ordinal2Number = reader.GetOrdinal("Number");
            this._ordinal2DocumentDate = reader.GetOrdinal("DocumentDate");
            this._ordinal2OrganizationId = reader.GetOrdinal("OrganizationId");
            this._ordinal2ParentId = reader.GetOrdinal("ParentId");
            this._ordinal2BankAccountId = reader.GetOrdinal("BankAccountId");
            this._ordinal2MoneyOperationTypeId = reader.GetOrdinal("MoneyOperationTypeId");
            this._ordinal2MoneyOperationDirection = reader.GetOrdinal("MoneyOperationDirection");
            this._ordinal2BudgetId = reader.GetOrdinal("BudgetId");
            this._ordinal2OperatingBudgetId = reader.GetOrdinal("OperatingBudgetId");
            this._ordinal2BudgetItemGroupId = reader.GetOrdinal("BudgetItemGroupId");
            this._ordinal2BudgetItemId = reader.GetOrdinal("BudgetItemId");
            this._ordinal2SalesInvoiceId = reader.GetOrdinal("SalesInvoiceId");
            this._ordinal2PurchaseInvoiceId = reader.GetOrdinal("PurchaseInvoiceId");
            this._ordinal2AccountId = reader.GetOrdinal("AccountId");
            this._ordinal2EmployeeId = reader.GetOrdinal("EmployeeId");
            this._ordinal2Subject = reader.GetOrdinal("Subject");
            this._ordinal2Value = reader.GetOrdinal("Value");
            this._ordinal2VATRateId = reader.GetOrdinal("VATRateId");
            this._ordinal2VATValue = reader.GetOrdinal("VATValue");
            this._initialized2 = true;
        }
        protected override void BindListResultToItem(MoneyOperationView item, SqlDataReader reader)
        {
            InitializeBindListResultToItem(reader);
            item.Id = reader.GetInt32(this._ordinal2Id);
            item.State = (MoneyOperationState)reader.GetByte(this._ordinal2State);
            item.FileAs = reader.GetString(this._ordinal2FileAs);
            item.Number = reader.GetString(this._ordinal2Number);
            item.DocumentDate = reader.GetDateTime(this._ordinal2DocumentDate);
            item.OrganizationId = reader.GetInt32(this._ordinal2OrganizationId);
            if(reader.IsDBNull(_ordinal2ParentId)) item.ParentId = null; else item.ParentId = reader.GetInt32(this._ordinal2ParentId);
            item.BankAccountId = reader.GetInt32(this._ordinal2BankAccountId);
            item.MoneyOperationTypeId = reader.GetInt32(this._ordinal2MoneyOperationTypeId);
            item.MoneyOperationDirection = reader.GetInt32(this._ordinal2MoneyOperationDirection);
            if(reader.IsDBNull(_ordinal2BudgetId)) item.BudgetId = null; else item.BudgetId = reader.GetInt32(this._ordinal2BudgetId);
            if(reader.IsDBNull(_ordinal2OperatingBudgetId)) item.OperatingBudgetId = null; else item.OperatingBudgetId = reader.GetInt32(this._ordinal2OperatingBudgetId);
            if(reader.IsDBNull(_ordinal2BudgetItemGroupId)) item.BudgetItemGroupId = null; else item.BudgetItemGroupId = reader.GetInt32(this._ordinal2BudgetItemGroupId);
            if(reader.IsDBNull(_ordinal2BudgetItemId)) item.BudgetItemId = null; else item.BudgetItemId = reader.GetInt32(this._ordinal2BudgetItemId);
            if(reader.IsDBNull(_ordinal2SalesInvoiceId)) item.SalesInvoiceId = null; else item.SalesInvoiceId = reader.GetInt32(this._ordinal2SalesInvoiceId);
            if(reader.IsDBNull(_ordinal2PurchaseInvoiceId)) item.PurchaseInvoiceId = null; else item.PurchaseInvoiceId = reader.GetInt32(this._ordinal2PurchaseInvoiceId);
            item.AccountId = reader.GetInt32(this._ordinal2AccountId);
            if(reader.IsDBNull(_ordinal2EmployeeId)) item.EmployeeId = null; else item.EmployeeId = reader.GetInt32(this._ordinal2EmployeeId);
            if(reader.IsDBNull(_ordinal2Subject)) item.Subject = null; else item.Subject = reader.GetString(this._ordinal2Subject);
            item.Value = reader.GetDecimal(this._ordinal2Value);
            if(reader.IsDBNull(_ordinal2VATRateId)) item.VATRateId = null; else item.VATRateId = reader.GetInt32(this._ordinal2VATRateId);
            item.VATValue = reader.GetDecimal(this._ordinal2VATValue);
        }
    }
}
