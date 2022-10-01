using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class AdvanceItemFilter: Filter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<DateTime> PeriodStart { get; set; }
        public Nullable<DateTime> PeriodEnd { get; set; }
        [XmlArrayItem("ReportState")]
        public MoneyOperationState[] ReportStates { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)MoneyOperationState.Draft, (byte)MoneyOperationState.Approved, (byte)MoneyOperationState.Executed };
            this.ReportStates = new MoneyOperationState[] { MoneyOperationState.Draft, MoneyOperationState.Approved, MoneyOperationState.Executed };
        }
    }
}
