using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BudgetTemplateFilter
    {
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)BudgetTemplateState.Active };
        }
    }
}
