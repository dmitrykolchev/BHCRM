using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BeverageSubtypeDataAdapterProxy
    {
        protected override BeverageSubtype CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is BeverageType)
                document.BeverageTypeId = ((BeverageType)dataContext).Id;
            return document;
        }
    }
}
