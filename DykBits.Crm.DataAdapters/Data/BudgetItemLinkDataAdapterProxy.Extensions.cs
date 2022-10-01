using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BudgetItemLinkDataAdapterProxy
    {
        protected override BudgetItemLink CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            document.IncomeBudgetItemGroupId = BudgetItemGroup.Доходы_по_ОВД;
            document.ExpenseBudgetItemGroupId = BudgetItemGroup.Расходы_по_ОВД;
            return document;
        }

        protected override void OnValidate(BudgetItemLink item)
        {
            if (string.IsNullOrEmpty(item.FileAs))
            {
                var incomeItem = ListManager.GetItem<BudgetItemView>(item.IncomeBudgetItemId);
                var expenseItem = ListManager.GetItem<BudgetItemView>(item.ExpenseBudgetItemId);
                item.FileAs = incomeItem.FileAs + "/" + expenseItem.FileAs;
            }
            base.OnValidate(item);

        }
    }
}
