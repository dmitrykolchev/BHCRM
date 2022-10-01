using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProjectMemberDataAdapterProxy
    {
        protected override ProjectMember CreateItemOverride(object dataContext)
        {
            ProjectMember document = base.CreateItemOverride(dataContext);
            if (dataContext is Project)
            {
                document.ProjectId = ((Project)dataContext).Id;
            }
            else if (dataContext is ServiceRequest)
            {
                document.ProjectId = ((ServiceRequest)dataContext).ProjectId;
            }
            return document;
        }
        protected override void OnValidate(ProjectMember item)
        {
            if (item.EmployeeId != null)
            {
                var employee = DocumentManager.GetItem<Employee>(item.EmployeeId.Value);
                item.FileAs = employee.FileAs;
            }
            else
            {
                var memberRole = DocumentManager.GetItem<ProjectMemberRole>(item.ProjectMemberRoleId);
                item.FileAs = memberRole.FileAs;
            }
            base.OnValidate(item);
        }
    }
}
