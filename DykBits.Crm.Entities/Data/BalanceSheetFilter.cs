using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class BalanceSheetFilter : Filter
    {
        public Nullable<DateTime> BalanceDate { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        [XmlArrayItem("MoneyOperationState")]
        public MoneyOperationState[] MoneyOperationStates { get; set; }
        [XmlArrayItem("InvoiceState")]
        public PurchaseInvoiceState[] InvoiceStates { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            if(this.MoneyOperationStates == null)
                this.MoneyOperationStates = new MoneyOperationState[] { MoneyOperationState.Draft, MoneyOperationState.Approved, MoneyOperationState.Executed };
            if(this.InvoiceStates == null)
                this.InvoiceStates = new PurchaseInvoiceState[] { PurchaseInvoiceState.Draft, PurchaseInvoiceState.Approved, PurchaseInvoiceState.Payed };
            base.InitializeDefaults(dataContext, parameter);
            this.BalanceDate = DateTime.Today;
        }
    }
}
