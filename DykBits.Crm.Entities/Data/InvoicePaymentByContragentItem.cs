using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace DykBits.Crm.Data
{
    public class InvoicePaymentByContragentItem: XmlSerializableDataItem
    {
        [XmlAttribute]
        public int AccountId { get; set; }
        [XmlAttribute]
        public Nullable<decimal> PurchaseInvoiceValue { get; set; }
        [XmlAttribute]
        public Nullable<decimal> PurchaseInvoiceVATValue { get; set; }
        [XmlAttribute]
        public Nullable<decimal> PurchaseInvoicePayedValue { get; set; }
        [XmlIgnore]
        public Nullable<decimal> PurchaseInvoiceDelta
        {
            get
            {
                if (PurchaseInvoiceValue.HasValue || PurchaseInvoicePayedValue.HasValue)
                    return PurchaseInvoiceValue.GetValueOrDefault() - PurchaseInvoicePayedValue.GetValueOrDefault();
                return null;
            }
        }
        [XmlAttribute]
        public Nullable<decimal> SalesInvoiceValue { get; set; }
        [XmlAttribute]
        public Nullable<decimal> SalesInvoiceVATValue { get; set; }
        [XmlAttribute]
        public Nullable<decimal> SalesInvoicePayedValue { get; set; }
        [XmlIgnore]
        public Nullable<decimal> SalesInvoiceDelta
        {
            get
            {
                if (SalesInvoiceValue.HasValue || SalesInvoicePayedValue.HasValue)
                    return SalesInvoiceValue.GetValueOrDefault() - SalesInvoicePayedValue.GetValueOrDefault();
                return null;
            }
        }

        private AccountView _account;
        [XmlIgnore]
        public AccountView Account
        {
            get
            {
                if(this._account == null)
                    this._account = ListManager.GetItem<AccountView>(this.AccountId);
                return this._account;
            }
        }
        [XmlIgnore]
        public decimal Delta
        {
            get
            {
                return SalesInvoiceDelta.GetValueOrDefault() - PurchaseInvoiceDelta.GetValueOrDefault();
            }
        }
    }

    public class InvoicePaymentByContragentFilter : Filter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            this.States = new byte[] { (byte)SalesInvoiceState.Draft, (byte)SalesInvoiceState.Approved, (byte)SalesInvoiceState.Payed };
            base.InitializeDefaults(dataContext, parameter);
        }
    }
}
