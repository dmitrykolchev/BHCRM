using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class OperatingCalculationDataAdapterProxy
    {
        protected override OperatingCalculation CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is OperatingBudget)
            {
                var budget = (OperatingBudget)dataContext;
                document.OperatingBudgetId = budget.Id;
                document.OrganizationId = budget.OrganizationId;
                switch (budget.State)
                {
                    case OperatingBudgetState.Draft:
                        document.CalculationStage = CalculationStage.Planned;
                        break;
                    case OperatingBudgetState.PlannedApproved:
                        document.CalculationStage = CalculationStage.Actual;
                        break;
                    default:
                        throw new CrmApplicationException("Для бюджета в текущем состоянии невозможно создать калькуляцию.");
                }
            }
            return document;
        }
        public OperatingCalculation Find(OperatingBudget budget, int calculationStage, int budgetItemId)
        {
            if (budget.IsNew)
                throw new ArgumentException("Необходимо сохранить бюджет", "budget");
            var filter = (OperatingCalculationFilter)this.CreateFilter(budget, null);
            filter.AllStates = true;
            filter.BudgetItemId = budgetItemId;
            filter.CalculationStage = calculationStage;
            OperatingCalculationView itemView = this.Browse(filter.ToXml()).FirstOrDefault();
            if (itemView == null)
                return null;
            return this.GetItem(itemView.GetKey());
        }
        public OperatingCalculation Create(OperatingBudget budget, int calculationStage, int budgetItemId)
        {
            if (budget.IsNew)
                throw new ArgumentException("Необходимо сохранить бюджет", "budget");
            var document = this.CreateItem(budget);
            document.CalculationStage = calculationStage;
            document.BudgetItemId = budgetItemId;
            return document;
        }
    }
}
