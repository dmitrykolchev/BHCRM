using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(OperatingBudgetLine))]
    partial class OperatingBudget
    {
        private OperatingBudgetLineCollection _lines;
        
        [SerializationBinding(SerializationBindingMode.OneWay)]
        public OperatingBudgetLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new OperatingBudgetLineCollection(this);
                }
                return this._lines;
            }
        }
        private IList<PurchaseInvoiceView> _purchaseInvoices;
        [XmlIgnore]
        public IList<PurchaseInvoiceView> PurchaseInvoices
        {
            get
            {
                if (this._purchaseInvoices == null)
                {
                    PurchaseInvoiceFilter filter = new PurchaseInvoiceFilter { AllStates = true, OperatingBudgetId = this.Id };
                    this._purchaseInvoices = DocumentManager.Browse<PurchaseInvoiceView>(filter);
                }
                return this._purchaseInvoices;
            }
        }
        private IList<SalesInvoiceView> _salesInvoices;
        [XmlIgnore]
        public IList<SalesInvoiceView> SalesInvoices
        {
            get
            {
                if (this._salesInvoices == null)
                {
                    SalesInvoiceFilter filter = new SalesInvoiceFilter { AllStates = true, OperatingBudgetId = this.Id };
                    this._salesInvoices = DocumentManager.Browse<SalesInvoiceView>(filter);
                }
                return this._salesInvoices;
            }
        }
        private IList<MoneyOperationView> _paymentInList;
        [XmlIgnore]
        public IList<MoneyOperationView> PaymentInList
        {
            get
            {
                if (this._paymentInList == null)
                {
                    var filter = new MoneyOperationFilter { AllStates = true, OperatingBudgetId = this.Id, MoneyOperationDirection = MoneyOperationDirection.Incoming, IncludeChildren = false };
                    this._paymentInList = DocumentManager.Browse<MoneyOperationView>(filter);
                }
                return this._paymentInList;
            }
        }

        private IList<MoneyOperationView> _paymentOutList;
        [XmlIgnore]
        public IList<MoneyOperationView> PaymentOutList
        {
            get
            {
                if (this._paymentOutList == null)
                {
                    var filter = new MoneyOperationFilter { AllStates = true, OperatingBudgetId = this.Id, MoneyOperationDirection = MoneyOperationDirection.Outgoing, IncludeChildren = false };
                    this._paymentOutList = DocumentManager.Browse<MoneyOperationView>(filter);
                }
                return this._paymentOutList;
            }
        }

        public void RefreshItems()
        {
            this._paymentInList = null;
            this._paymentOutList = null;
            this._purchaseInvoices = null;
            this._salesInvoices = null;
            this.Lines.BeginDataUpdate();
            try
            {
                this.Lines.Clear();
                var document = DocumentManager.GetItem<OperatingBudget>(this.Id);
                foreach (var line in document.Lines)
                {
                    this.Lines.Add(line.Clone());
                }
            }
            finally
            {
                this.Lines.EndDataUpdate();
            }
        }
    }
}
