using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class BudgetTemplateDataAdapterProxy
    {
        protected override BudgetTemplate CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            document.AmountOfPersons = 100;
            int id = 0;
            var budgetItems = document.BudgetItems
                .OfType<BudgetItemView>()
                .Where(t=>t.State == BudgetItemState.Active && (t.BudgetItemGroupId == BudgetItemGroup.Доходы_по_ОВД || t.BudgetItemGroupId == BudgetItemGroup.Расходы_по_ОВД));
            foreach (BudgetItemView item in budgetItems)
            {
                document.Lines.Add(new BudgetTemplateLine { BudgetTemplateLineId = ++id, BudgetItemId = item.Id });
            }
            return document;
        }

        public BudgetTemplate CreateCopy(ItemKey key)
        {
            BudgetTemplate source = this.GetItem(key);
            BudgetTemplate copy = this.CreateItem(source);
            copy.FileAs = source.FileAs;
            copy.ServiceRequestTypeId = source.ServiceRequestTypeId;
            copy.ServiceLevelId = source.ServiceLevelId;
            copy.AmountOfPersons = source.AmountOfPersons;
            copy.EventDuration = source.EventDuration;
            copy.Comments = source.Comments;
            return copy;
        }
    }
}
