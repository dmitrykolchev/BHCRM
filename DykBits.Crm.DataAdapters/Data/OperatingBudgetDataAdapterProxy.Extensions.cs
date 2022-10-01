using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class OperatingBudgetDataAdapterProxy
    {
        protected override OperatingBudget CreateItemOverride(object dataContext)
        {
            return base.CreateItemOverride(dataContext);
        }
        public static List<OperatingBudgetDocumentItem> GetDocumentList(OperatingBudget budget, int budgetItemId, int calculationStage)
        {
            OperatingBudgetDocumentBrowse data = new OperatingBudgetDocumentBrowse
            {
                BudgetItemId = budgetItemId,
                CalculationStage = calculationStage,
                OperatingBudgetId = budget.Id
            };
            return DocumentManager.ExecuteObjectQuery<OperatingBudgetDocumentBrowse, OperatingBudgetDocumentItem>(data);
        }
    }
}
