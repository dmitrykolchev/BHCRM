using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ProjectTaskStatusReport: Filter
    {
        public ProjectTaskStatusReport()
        {
            this.States = new byte[] { (byte)ServiceRequestState.Prospecting, (byte)ServiceRequestState.Qualification, (byte)ServiceRequestState.Won };
        }
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> TradeMarkId { get; set; }
        public Nullable<int> ProjectManagerId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        protected override string DocumentElement
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
