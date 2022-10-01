using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BeverageSubtypeFilter
    {
        public Nullable<int> BeverageTypeId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            if (dataContext is BeverageType)
                this.BeverageTypeId = ((BeverageType)dataContext).Id;
        }
    }
}
