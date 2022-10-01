using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data.Reports
{
    public class BudgetReport : ReportDataSourceConverter
    {
        private Budget _document;
        private ServiceRequest _serviceRequest;
        private IList<BudgetReportItem> _items;
        private Account _account;
        private Account _venueProvider;
        public BudgetReport(Budget document)
            : base(document)
        {
            this._document = document;
        }
        public override ReportDataSourceConverter.DataSet[] GetReportData()
        {
            return ReportDataSourceConverter.GetReportData(this, this.Items);
        }
        public Budget Document
        {
            get { return _document; }
        }
        public ServiceRequest ServiceRequest
        {
            get
            {
                if (this._serviceRequest == null)
                    this._serviceRequest = DocumentManager.GetItem<ServiceRequest>(Document.ServiceRequestId);
                return this._serviceRequest;
            }
        }
        public Account Account
        {
            get
            {
                if (this._account == null)
                    this._account = DocumentManager.GetItem<Account>(ServiceRequest.AccountId);
                return this._account;
            }
        }
        public Account VenueProvider
        {
            get
            {
                if (this.ServiceRequest.VenueProviderId.HasValue)
                {
                    if (this._venueProvider == null)
                    {
                        this._venueProvider = DocumentManager.GetItem<Account>(ServiceRequest.VenueProviderId.Value);
                    }
                }
                return this._venueProvider;
            }
        }
        public string Number
        {
            get { return Document.Number; }
        }
        public DateTime DocumentDate
        {
            get { return Document.DocumentDate; }
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
        public string VenueProviderName
        {
            get
            {
                if (this.VenueProvider != null)
                    return this._venueProvider.FileAs;
                return string.Empty;
            }
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
        public string Comments
        {
            get { return this.Document.Comments; }
        }
        public IList<BudgetReportItem> Items
        {
            get
            {
                if (this._items == null)
                {
                    var list = new List<BudgetReportItem>(Document.Lines.Count);
                    InitializeItemList(list, this.Document.Items.Where(t => t.ParentId == 0));
                    this._items = list;
                }
                return this._items;
            }
        }

        private void InitializeItemList(IList<BudgetReportItem> list, IEnumerable<BudgetLineProxy> lines)
        {
            foreach (var line in lines)
            {
                list.Add(new BudgetReportItem(this, line));
                var children = Document.Items.Where(t => t.ParentId == line.Id);
                InitializeItemList(list, children);
            }
        }
    }
}
