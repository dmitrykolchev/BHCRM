using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;
using System.IO;

namespace DykBits.Crm.Data
{
    partial class ProjectTaskDataAdapterProxy
    {
        protected override ProjectTask CreateItemOverride(object dataContext)
        {
            ProjectTask document = base.CreateItemOverride(dataContext);
            if (dataContext is Project)
                document.ProjectId = ((Project)dataContext).Id;
            else if(dataContext is ServiceRequest)
                document.ProjectId = ((ServiceRequest)dataContext).ProjectId;
            document.TaskStart = DateTime.Today;
            document.TaskFinish = DateTime.Today;
            document.Importance = Importance.Normal;
            return document;
        }
        protected override void OnValidate(ProjectTask item)
        {
            base.OnValidate(item);
            item.Complete = Math.Max(0m, Math.Min(1m, item.Complete));
        }
        public ProjectTaskStatusReportData BrowseProjectTaskStatusReport(ProjectTaskStatusReport data)
        {
            var items = DocumentManager.ExecuteObjectQuery<ProjectTaskStatusReport, ProjectTaskStatusReportItem>(data);
            return new ProjectTaskStatusReportData(items);
        }
    }
}
