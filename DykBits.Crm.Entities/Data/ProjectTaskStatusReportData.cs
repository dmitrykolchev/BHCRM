using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ProjectTaskStatusReportData
    {
        private List<ProjectTaskStatusReportItem> _items;
        private List<TaskInfo> _rows;
        private List<ServiceRequestInfo> _columns;
        public ProjectTaskStatusReportData(List<ProjectTaskStatusReportItem> items)
        {
            this._items = items;
        }
        public ProjectTaskStatusReportItem GetItem(TaskInfo task, ServiceRequestInfo serviceRequest)
        {
            var s = this._items.Where(t => t.TaskSubject == task.Subject && t.ServiceRequestId == serviceRequest.Id).SingleOrDefault();
            return s;
        }
        public List<TaskInfo> Rows
        {
            get
            {
                if (this._rows == null)
                {
                    this._rows = this._items.OrderBy(t => t.TaskNo).Select(t => t.TaskSubject).Distinct().Select(t => new TaskInfo { Subject = t }).ToList();
                }
                return this._rows;
            }
        }
        public List<ServiceRequestInfo> Columns
        {
            get
            {
                if (this._columns == null)
                {
                    Dictionary<int, int> d = new Dictionary<int, int>();
                    this._columns = new List<ServiceRequestInfo>();
                    for (int index = 0; index < this._items.Count; ++index)
                    {
                        var key = this._items[index].ServiceRequestId;
                        if (!d.ContainsKey(key))
                        {
                            ProjectTaskStatusReportItem item = this._items[index];
                            this._columns.Add(new ServiceRequestInfo { Number = item.ServiceRequestNumber, AccountName = item.AccountFileAs, Id = item.ServiceRequestId, AccountId = item.AccountId });
                            d.Add(key, key);
                        }
                    }
                }
                return this._columns;
            }
        }
        public class ServiceRequestInfo
        {
            public int Id { get; set; }
            public string Number { get; set; }
            public int AccountId { get; set; }
            public string AccountName { get; set; }
            public object Tag { get; set; }
        }
        public class TaskInfo
        {
            public TaskInfo()
            {
            }

            public string Subject { get; set; }
        }
    }
}
