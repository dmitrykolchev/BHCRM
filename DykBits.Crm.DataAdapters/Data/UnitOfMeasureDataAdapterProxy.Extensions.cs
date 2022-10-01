using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class UnitOfMeasureDataAdapterProxy
    {
        protected override UnitOfMeasure CreateItemOverride(object dataContext)
        {
            UnitOfMeasure document= base.CreateItemOverride(dataContext);
            document.Multiplier = 1;
            document.Divider = 1;
            return document;
        }
    }
}
