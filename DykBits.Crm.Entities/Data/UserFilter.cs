using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class UserFilter
    {
        public Nullable<int> ApplicationRoleId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)UserState.Active, (byte)UserState.Inactive };
            if (dataContext is ApplicationRole)
            {
                this.ApplicationRoleId = ((ApplicationRole)dataContext).Id;
            }
        }
    }
}
