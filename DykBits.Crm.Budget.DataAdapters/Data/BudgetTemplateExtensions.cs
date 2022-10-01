using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public static class BudgetTemplateExtensions
    {
        public static Budget CreateBudget(this BudgetTemplate budgetTemplate, ServiceRequest serviceRequest)
        {
            BudgetDataAdapterProxy dataAdapter = new BudgetDataAdapterProxy();
            Budget budget = dataAdapter.CreateItem(serviceRequest);
            budget.BudgetTemplateId = budgetTemplate.Id;
            budget = dataAdapter.Save(budget);

            CalculationStatementDataAdapterProxy calculationDataAdapter = new CalculationStatementDataAdapterProxy();

            CalculationStatementTemplateDataAdapterProxy calculationTemplateDataAdapter = new CalculationStatementTemplateDataAdapterProxy();
            Filter calculationTemplateFilter = calculationTemplateDataAdapter.CreateFilter(budgetTemplate, null);
            var calculationTemplates = calculationTemplateDataAdapter.Browse(calculationTemplateFilter.ToXml());
            
            foreach (var item in calculationTemplates)
            {
                var calculationTemplate = calculationTemplateDataAdapter.GetItem(item.GetKey());
                if (NeedCreateCalculation(calculationTemplate))
                {
                    CalculationStatement calculation = calculationDataAdapter.CreateFromTemplate(budget, budgetTemplate, calculationTemplate);
                    calculation.CalculationStage = CalculationStage.Standard;
                    calculationDataAdapter.Save(calculation);

                    calculation = calculationDataAdapter.CreateFromTemplate(budget, budgetTemplate, calculationTemplate);
                    calculation.CalculationStage = CalculationStage.Planned;
                    calculationDataAdapter.Save(calculation);
                }
            }
            budget.RefreshItems();
            return budget;
        }

        private static bool NeedCreateCalculation(CalculationStatementTemplate calculationTemplate)
        {
            if (calculationTemplate.ExpenseBudgetItemId.HasValue)
            {
                var budgetItem = ListManager.GetItem<BudgetItemView>(calculationTemplate.ExpenseBudgetItemId.Value);
                if (budgetItem.State == BudgetItemState.Inactive)
                    return false;
            }
            if (calculationTemplate.IncomeBudgetItemId.HasValue)
            {
                var budgetItem = ListManager.GetItem<BudgetItemView>(calculationTemplate.IncomeBudgetItemId.Value);
                if (budgetItem.State == BudgetItemState.Inactive)
                    return false;
            }
            return true;
        }

        public static void RecreateBudgetStandard(this Budget budget)
        {
            CalculationStatementDataAdapterProxy calculationDataAdapter = new CalculationStatementDataAdapterProxy();
            CalculationStatementFilter filter = (CalculationStatementFilter)calculationDataAdapter.CreateFilter(budget, null);
            filter.CalculationStage = CalculationStage.Standard;
            var calculations = calculationDataAdapter.Browse(filter.ToXml());
            foreach (var calculation in calculations)
                calculationDataAdapter.Delete(calculation.GetKey());

            BudgetTemplate budgetTemplate = DocumentManager.GetItem<BudgetTemplate>(budget.BudgetTemplateId.Value);
            CalculationStatementTemplateDataAdapterProxy calculationTemplateDataAdapter = new CalculationStatementTemplateDataAdapterProxy();
            Filter calculationTemplateFilter = calculationTemplateDataAdapter.CreateFilter(budgetTemplate, null);
            var calculationTemplates = calculationTemplateDataAdapter.Browse(calculationTemplateFilter.ToXml());
            foreach(var item in calculationTemplates)
            {
                var calculationTemplate = calculationTemplateDataAdapter.GetItem(item.GetKey());
                if (NeedCreateCalculation(calculationTemplate))
                {
                    CalculationStatement calculation = calculationDataAdapter.CreateFromTemplate(budget, budgetTemplate, calculationTemplate);
                    calculation.CalculationStage = CalculationStage.Standard;
                    CalculationStatement created = calculationDataAdapter.Save(calculation);
                    calculationDataAdapter.ChangeState(created.GetKey(), (byte)CalculationStatementState.Approved, null);
                }
            }
            budget.RefreshItems();
        }

        public static void CreateBudgetActual(this Budget budget)
        {
            CalculationStatementDataAdapterProxy calculationDataAdapter = new CalculationStatementDataAdapterProxy();
            CalculationStatementFilter filter = (CalculationStatementFilter)calculationDataAdapter.CreateFilter(budget, null);
            filter.AllStates = false;
            filter.CalculationStage = CalculationStage.Actual;
            var calculations = calculationDataAdapter.Browse(filter.ToXml());
            foreach (var calculation in calculations)
                calculationDataAdapter.Delete(calculation.GetKey());

            filter.CalculationStage = CalculationStage.Planned;
            filter.AllStates = false;
            filter.States = new byte[] { (byte)CalculationStatementState.Approved };
            calculations = calculationDataAdapter.Browse(filter.ToXml());
            foreach (var calculation in calculations)
            {
                var source = DocumentManager.GetItem<CalculationStatement>(calculation.Id);
                var copy = source.Clone();
                copy.CalculationStage = CalculationStage.Actual;
                DocumentManager.SaveItem(copy);
            }

            budget.RefreshItems();
        }
    }
}
