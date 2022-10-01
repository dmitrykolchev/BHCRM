using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class MoneyOperationReportByOperationTypeFilter: Filter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> BankAccountId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            this.States = new byte[] { (byte)MoneyOperationState.Draft, (byte)MoneyOperationState.Approved };
            base.InitializeDefaults(dataContext, parameter);
        }
    }
}
