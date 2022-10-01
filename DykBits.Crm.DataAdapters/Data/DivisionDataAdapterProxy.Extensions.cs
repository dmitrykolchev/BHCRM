using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DivisionDataAdapterProxy
    {
        protected override Division CreateItemOverride(object dataContext)
        {
            Division document = base.CreateItemOverride(dataContext);
            if (dataContext is Organization)
            {
                document.AccountId = ((Organization)dataContext).Id;
            }
            return document;
        }
    }
}
