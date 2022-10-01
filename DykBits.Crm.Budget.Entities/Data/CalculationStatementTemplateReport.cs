using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateReport: ReportDataSourceConverter
    {
        public CalculationStatementTemplateReport(CalculationStatementTemplate document)
            : base(document)
        {
        }

        public override DataSet[] GetReportData()
        {
            return ReportDataSourceConverter.GetReportData(this, this.Items);
        }
        private CalculationStatementTemplate Document
        {
            get { return (CalculationStatementTemplate)this.Source; }
        }
        private BudgetTemplate _budgetTemplate;
        private BudgetTemplate BudgetTemplate
        {
            get
            {
                if(this._budgetTemplate == null)
                    this._budgetTemplate = Document.BudgetTemplate;
                return this._budgetTemplate;
            }
        }
        public string BudgetTemplateFileAs
        {
            get { return BudgetTemplate.FileAs; }
        }
        public int AmountOfGuests
        {
            get { return this.BudgetTemplate.AmountOfPersons; }
        }
        public string ServiceRequestType
        {
            get
            {
                return ListManager.GetItem<ServiceRequestTypeView>(this.BudgetTemplate.ServiceRequestTypeId).FileAs;
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
        public string Comments
        {
            get { return this.Document.Comments; }
        }
        private IList<CalculationStatementTemplateReportItem> _items;
        public IList<CalculationStatementTemplateReportItem> Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = this.Document.Items.Select(t => new CalculationStatementTemplateReportItem(t)).ToList();
                }
                return this._items;
            }
        }
    }
}
