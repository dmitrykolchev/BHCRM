using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class SalesOrderDataAdapterProxy
    {
        protected override SalesOrder CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is Budget)
            {
                document.BudgetId = ((Budget)dataContext).Id;
                document.CustomerId = ((Budget)dataContext).ServiceRequest.AccountId;
                document.BudgetItemGroupId = BudgetItemGroup.Расходы_по_ОВД;
            }
            return document;
        }
    }
}
