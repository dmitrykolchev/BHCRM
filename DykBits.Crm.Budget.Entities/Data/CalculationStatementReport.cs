using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementReport : ReportDataSourceConverter
    {
        public CalculationStatementReport(CalculationStatement document)
            : base(document)
        {
        }

        public override DataSet[] GetReportData()
        {
            return ReportDataSourceConverter.GetReportData(this, this.Items);
        }

        private CalculationStatement Document
        {
            get { return (CalculationStatement)this.Source; }
        }
        private Budget Budget
        {
            get
            {
                return Document.Budget;
            }
        }
        private ServiceRequest ServiceRequest
        {
            get
            {
                return Document.ServiceRequest;
            }
        }
        public AccountView Account
        {
            get
            {
                return ListManager.GetItem<AccountView>(ServiceRequest.AccountId);
            }
        }
        public string Number
        {
            get { return this.Document.Number; }
        }
        public DateTime DocumentDate
        {
            get { return this.Document.DocumentDate; }
        }
        public string BudgetNumber
        {
            get { return this.Budget.Number; }
        }
        public string ServiceRequestNumber
        {
            get { return ServiceRequest.Number; }
        }
        public DateTime ServiceRequestDate
        {
            get { return ServiceRequest.DocumentDate; }
        }
        public Nullable<int> AmountOfGuests
        {
            get { return this.ServiceRequest.AmountOfGuests; }
        }
        public Nullable<DateTime> EventDate
        {
            get { return ServiceRequest.EventDate ?? ServiceRequest.EventMonth; }
        }
        public string OrganizationName
        {
            get { return ListManager.GetItem<AccountView>(this.Document.OrganizationId).FileAs; }
        }
        public string AccountName
        {
            get { return this.Account.FileAs; }
        }
        public string ServiceRequestType
        {
            get
            {
                return ListManager.GetItem<ServiceRequestTypeView>(this.ServiceRequest.ServiceRequestTypeId).FileAs;
            }
        }
        public string Reason
        {
            get
            {
                return ListManager.GetItem<ReasonView>(this.ServiceRequest.ReasonId).FileAs;
            }
        }
        public bool HasIncome
        {
            get { return this.Document.IncomeBudgetItemId.HasValue; }
        }
        public bool HasExpense
        {
            get { return this.Document.ExpenseBudgetItemId.HasValue; }
        }
        public string IncomeBudgetItemName
        {
            get
            {
                return this.Document.IncomeBudgetItemId.HasValue ? ListManager.GetItem<BudgetItemView>(this.Document.IncomeBudgetItemId.Value).FileAs : string.Empty;
            }
        }

        public string ExpenseBudgetItemName
        {
            get
            {
                return this.Document.ExpenseBudgetItemId.HasValue ? ListManager.GetItem<BudgetItemView>(this.Document.ExpenseBudgetItemId.Value).FileAs : string.Empty;
            }
        }

        public string CalculationStageName
        {
            get
            {
                return ListManager.GetItem<CalculationStageView>(this.Document.CalculationStage).FileAs;
            }
        }
        public string Comments
        {
            get { return this.Document.Comments; }
        }
        private IList<CalculationStatementReportItem> _items;
        public IList<CalculationStatementReportItem> Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = this.Document.Items.Select(t => new CalculationStatementReportItem(t)).ToList();
                }
                return this._items;
            }
        }
    }
}
