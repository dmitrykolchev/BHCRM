using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProjectTaskFilter
    {
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> EmployeeId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)ProjectTaskState.Draft, (byte)ProjectTaskState.Assigned };
            if (dataContext is Project)
                this.ProjectId = ((Project)dataContext).Id;
            else if (dataContext is ServiceRequest)
                this.ProjectId = ((ServiceRequest)dataContext).ProjectId;
            else if (dataContext is Employee)
                this.EmployeeId = ((Employee)dataContext).Id;
        }
    }
}
