using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data.Reports
{
    public class PurchaseOrderReport: ReportDataSourceConverter
    {
        public PurchaseOrderReport(PurchaseOrder document)
            : base(document)
        {

        }
        public string Number
        {
            get { return this.Document.Number; }
        }
        public DateTime DocumentDate
        {
            get { return this.Document.DocumentDate; }
        }
        public string OrganizationName
        {
            get { return ListManager.GetItem<OrganizationView>(this.Document.OrganizationId).FileAs; }
        }
        public string StoragePlaceName
        {
            get { return ListManager.GetItem<StoragePlaceView>(this.Document.StoragePlaceId).FileAs; }
        }
        public string SupplierName
        {
            get { return ListManager.GetItem<AccountView>(this.Document.SupplierId).FileAs; }
        }
        public decimal TotalCost
        {
            get { return this.Document.TotalCost; }
        }
        public string Comments
        {
            get { return this.Document.Comments; }
        }
        public override DataSet[] GetReportData()
        {
            return ReportDataSourceConverter.GetReportData(this, this.Items);
        }
        public PurchaseOrder Document
        {
            get { return (PurchaseOrder)this.Source; }
        }
        private IList<PurchaseOrderReportItem> _items;
        public IList<PurchaseOrderReportItem> Items
        {
            get
            {
                if(this._items == null)
                    this._items = this.Document.Lines.Select(t => new PurchaseOrderReportItem(t)).OrderBy(t => t.FileAs).ToList();
                return this._items;
            }
        }
    }
}
