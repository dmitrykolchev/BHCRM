using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data.Reports
{
    public class EstimatesDocumentReport : ReportDataSourceConverter
    {
        private EstimatesDocument _document;
        private ServiceRequest _serviceRequest;
        private Organization _organization;
        private Account _account;
        private IList<EstimatesDocumentReportItem> _items;

        public EstimatesDocumentReport(EstimatesDocument document)
            : base(document)
        {
            this._document = document;
        }
        public override ReportDataSourceConverter.DataSet[] GetReportData()
        {
            return ReportDataSourceConverter.GetReportData(this, this.Items);
        }
        private EstimatesDocument Document
        {
            get { return this._document; }
        }
        public string Number
        {
            get { return this.Document.Number; }
        }
        public DateTime DocumentDate
        {
            get { return this.Document.DocumentDate; }
        }
        public string Comments
        {
            get { return this.Document.Comments; }
        }
        private ServiceRequest ServiceRequest
        {
            get
            {
                if (this._serviceRequest == null)
                {
                    this._serviceRequest = DocumentManager.GetItem<ServiceRequest>(this._document.ServiceRequestId);
                }
                return this._serviceRequest;
            }
        }

        private Organization Organization
        {
            get
            {
                if (this._organization == null)
                {
                    this._organization = DocumentManager.GetItem<Organization>(this._document.OrganizationId);
                }
                return this._organization;
            }
        }

        private Account Account
        {
            get
            {
                if (this._account == null)
                {
                    this._account = DocumentManager.GetItem<Account>(this.ServiceRequest.AccountId);
                }
                return this._account;
            }
        }

        public string ServiceRequestNumber
        {
            get { return this.ServiceRequest.Number; }
        }

        public DateTime ServiceRequestDate
        {
            get { return this.ServiceRequest.DocumentDate; }
        }

        public DateTime? EventDate
        {
            get
            {
                return this.ServiceRequest.EventDate == null ? this.ServiceRequest.EventMonth : this.ServiceRequest.EventDate;
            }
        }

        public string OrganizationName
        {
            get
            {
                return this.Organization.FileAs;
            }
        }

        public string OrganizationFullName
        {
            get { return this.Organization.FullName; }
        }

        public string AccountName
        {
            get { return this.Account.FileAs; }
        }

        public string AccountFullName
        {
            get { return this.Account.FullName; }
        }

        public IList<EstimatesDocumentReportItem> Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = CreateItemsCollection();
                }
                return this._items;
            }
        }

        private IList<EstimatesDocumentReportItem> CreateItemsCollection()
        {
            List<EstimatesDocumentReportItem> items = new List<EstimatesDocumentReportItem>();
            var sections = this.Document.Items.OfType<EstimatesDocumentSectionItem>().Where(t => !t.ReadOnly).OrderBy(t => t.OrdinalPosition);
            foreach (var section in sections)
            {
                var sectionItems = this.Document.Items.OfType<EstimatesDocumentLineItem>().Where(t => t.ParentId == section.Id).OrderBy(t => t.OrdinalPosition).ToList();
                if (sectionItems.Count > 0)
                {
                    items.Add(new EstimatesDocumentReportItem(section));
                    foreach (var sectionItem in sectionItems)
                        items.Add(new EstimatesDocumentReportItem(sectionItem));
                }
            }
            items.Add(new EstimatesDocumentReportItem(this.Document.SubtotalItem));
            items.Add(new EstimatesDocumentReportItem(this.Document.CommissionItem));
            items.Add(new EstimatesDocumentReportItem(this.Document.SubtotalWithCommissionItem));
            items.Add(new EstimatesDocumentReportItem(this.Document.VATItem));
            items.Add(new EstimatesDocumentReportItem(this.Document.SubtotalWithVATItem));
            return items;
        }
    }

    public class EstimatesDocumentReportItem
    {
        private EstimatesDocumentItem _item;
        public EstimatesDocumentReportItem(EstimatesDocumentLineItem lineItem)
        {
            this._item = lineItem;
        }

        public EstimatesDocumentReportItem(EstimatesDocumentSectionItem sectionItem)
        {
            IsSection = true;
            this._item = sectionItem;
        }

        public bool IsSection
        {
            get;
            private set;
        }

        public string FileAs
        {
            get { return this._item.FileAs; }
        }

        public string Comments
        {
            get { return this._item.Comments; }
        }

        public decimal? Amount
        {
            get { return this._item.Amount; }
        }

        public decimal? Price
        {
            get { return this._item.Price; }
        }

        public decimal TotalPrice
        {
            get { return this._item.TotalPrice; }
        }

        public decimal CashCost
        {
            get { return this._item.CashCost; }
        }

        public decimal NonCashCost
        {
            get { return this._item.NonCashCost; }
        }

        public decimal ExtraCost
        {
            get { return this._item.ExtraCost; }
        }

        public decimal TotalCost
        {
            get { return this._item.TotalCost; }
        }

        public decimal Income
        {
            get { return this._item.Income; }
        }
    }
}
