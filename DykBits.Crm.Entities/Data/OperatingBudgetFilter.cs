using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class OperatingBudgetFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)OperatingBudgetState.Draft, (byte)OperatingBudgetState.PlannedApproved, (byte)OperatingBudgetState.ActualApproved, (byte)OperatingBudgetState.Closed };
        }
    }
}
