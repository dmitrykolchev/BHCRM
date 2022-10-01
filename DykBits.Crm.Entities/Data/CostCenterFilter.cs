using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class CostCenterFilter
    {
        public int? AccountId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)CostCenterState.Active };
            if (dataContext is Account)
            {
                this.AccountId = ((Account)dataContext).Id;
            }
            else if (dataContext is Organization)
            {
                this.AccountId = ((Organization)dataContext).Id;
            }
        }
    }
}
