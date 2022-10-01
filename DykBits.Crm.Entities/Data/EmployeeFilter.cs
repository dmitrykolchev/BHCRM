using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DykBits.Crm.Data
{
    partial class EmployeeFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> ProjectMemberRoleId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)EmployeeState.Active };
            if (dataContext is Organization)
            {
                this.OrganizationId = ((Organization)dataContext).Id;
            }
            else if (dataContext is Account)
            {
                this.OrganizationId = ((Account)dataContext).Id;
            }
            else if (dataContext is Division)
            {
                this.DivisionId = ((Division)dataContext).Id;
            }
        }
    }
}
