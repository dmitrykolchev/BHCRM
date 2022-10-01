using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProjectMemberFilter
    {
        public Nullable<int> ProjectId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)ProjectMemberState.Active };
            if (dataContext is Project)
            {
                this.ProjectId = ((Project)dataContext).Id;
            }
            else if (dataContext is ServiceRequest)
            {
                this.ProjectId = ((ServiceRequest)dataContext).ProjectId;
            }
        }
    }
}
