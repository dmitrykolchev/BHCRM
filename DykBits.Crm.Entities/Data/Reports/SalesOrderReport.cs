using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data.Reports
{
    public class SalesOrderReport : ReportDataSourceConverter
    {
        public SalesOrderReport(SalesOrder document)
            : base(document)
        {

        }
        public string Number
        {
            get
            {
                if (this.BudgetNumber != null)
                    return string.Format("{0}/{1}", this.Document.Number, this.BudgetNumber);
                return this.Document.Number;
            }
        }
        public DateTime DocumentDate
        {
            get { return this.Document.DocumentDate; }
        }
        private Budget _budget;
        public Budget Budget
        {
            get
            {
                if (this._budget != null)
                    return this._budget;
                if (this.Document.BudgetId.HasValue)
                {
                    this._budget = DocumentManager.GetItem<Budget>(this.Document.BudgetId.Value);
                    return this._budget;
                }
                return null;
            }
        }
        public string BudgetNumber
        {
            get { return this.Budget != null ? this.Budget.Number : null; }
        }
        public string BudgetItemGroupName
        {
            get
            {
                if (this.Document.BudgetItemGroupId.HasValue)
                    return ListManager.GetItem<BudgetItemGroupView>(this.Document.BudgetItemGroupId.Value).FileAs;
                return null;
            }
        }
        public string BudgetItemName
        {
            get
            {
                if (this.Document.BudgetItemId.HasValue)
                    return ListManager.GetItem<BudgetItemView>(this.Document.BudgetItemId.Value).FileAs;
                return null;
            }
        }
        public string OrganizationName
        {
            get { return ListManager.GetItem<OrganizationView>(this.Document.OrganizationId).FileAs; }
        }
        public string StoragePlaceName
        {
            get { return ListManager.GetItem<StoragePlaceView>(this.Document.StoragePlaceId).FileAs; }
        }
        public string CustomerName
        {
            get { return ListManager.GetItem<AccountView>(this.Document.CustomerId).FileAs; }
        }
        public decimal TotalCost
        {
            get { return this.Document.TotalCost; }
        }
        public decimal TotalPrice
        {
            get { return this.Document.TotalPrice; }
        }
        public string Comments
        {
            get { return this.Document.Comments; }
        }
        public override DataSet[] GetReportData()
        {
            return ReportDataSourceConverter.GetReportData(this, this.Items);
        }
        public SalesOrder Document
        {
            get { return (SalesOrder)this.Source; }
        }
        private IList<SalesOrderReportItem> _items;
        public IList<SalesOrderReportItem> Items
        {
            get
            {
                if (this._items == null)
                    this._items = this.Document.Lines.Select(t => new SalesOrderReportItem(t)).OrderBy(t => t.FileAs).ToList();
                return this._items;
            }
        }
    }
}
