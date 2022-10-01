using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BudgetItemDataAdapterProxy
    {
        protected override BudgetItem CreateItemOverride(object dataContext)
        {
            BudgetItem document = base.CreateItemOverride(dataContext);
            if (dataContext is BudgetItemGroup)
                document.BudgetItemGroupId = ((BudgetItemGroup)dataContext).Id;
            return document;
        }
    }
}
