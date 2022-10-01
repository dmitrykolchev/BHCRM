using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ProjectTaskStatusReportItem
    {
        public int Id { get; set; }
        public int TaskNo { get; set; }
        public string TaskSubject { get; set; }
        public byte TaskState { get; set; }
        public int ProjectTaskStatusId { get; set; }
        public string ProjectTaskStatus { get; set; }
        public Nullable<int> Color { get; set; }
        public bool Complete { get; set; }
        public int ServiceRequestId { get; set; }
        public string ServiceRequestNumber { get; set; }
        public int AccountId { get; set; }
        public string AccountFileAs { get; set; }
    }
}
