using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DishSubtypeFilter
    {
        public Nullable<int> DishTypeId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)DishSubtypeState.Active };
            if (dataContext is DishType)
            {
                this.DishTypeId = ((DishType)dataContext).Id;
            }
        }
    }
}
