using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class PurchaseInvoiceView
    {
        public decimal NotPayedValue
        {
            get { return this.Value - this.PayedValue; }
        }
    }
}
