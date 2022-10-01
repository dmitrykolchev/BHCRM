using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DishSubtypeDataAdapterProxy
    {
        protected override DishSubtype CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is DishType)
            {
                document.DishTypeId = ((DishType)dataContext).Id;
            }
            return document;
        }
    }
}
