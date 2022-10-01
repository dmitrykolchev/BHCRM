using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class OpportunityFilter
    {
        public Nullable<int> AccountId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            if (dataContext is Account)
            {
                this.AccountId = ((Account)dataContext).Id;
            }
        }
    }
}
