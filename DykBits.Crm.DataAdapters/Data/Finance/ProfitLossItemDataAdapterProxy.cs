using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ProfitLossItemDataAdapterProxy : ViewDataAdapterProxy<ProfitLossItem, ConsolidatedBudgetItemFilter>
    {
        protected override IList<ProfitLossItem> BrowseOverride(System.Xml.Linq.XElement filter)
        {
            ConsolidatedBudgetLineDataAdapterProxy budgetDataAdapter = new ConsolidatedBudgetLineDataAdapterProxy();
            var budgetLines = budgetDataAdapter.Browse(filter);
            ConsolidatedOperatingBudgetLineDataAdapterProxy operatingBudgetDataAdapter = new ConsolidatedOperatingBudgetLineDataAdapterProxy();
            var operatingBudgetLines = operatingBudgetDataAdapter.Browse(filter);
            ConsolidatedAccrualLineDataAdapterProxy accrualDataAdapter = new ConsolidatedAccrualLineDataAdapterProxy();
            var accrualLines = accrualDataAdapter.Browse(filter);

            var budgetItems = ListManager.GetList<BudgetItemView>();
            var budgetItemGroups = ListManager.GetList<BudgetItemGroupView>();

            Dictionary<int, ProfitLossItem> reportGroups = new Dictionary<int, ProfitLossItem>();
            Dictionary<int, ProfitLossItem> reportGroupItems = new Dictionary<int, ProfitLossItem>();
            ProfitLossItemFactory factory = new ProfitLossItemFactory();

            var incomeGroup = factory.CreateInstance("Доходы");
            var projIncomeGroup = factory.CreateInstance("Доходы по ПРС", incomeGroup);
            var projIncomeItem = factory.CreateInstance("<>", projIncomeGroup); projIncomeItem.Level = 4;
            var operIncomeGroup = factory.CreateInstance("Операционные доходы", incomeGroup);


            var expenseGroup = factory.CreateInstance("Расходы");
            var projExpenseGroup = factory.CreateInstance("Расходы по ПРС", expenseGroup);
            var projExpenseItem = factory.CreateInstance("<>", projExpenseGroup); projExpenseItem.Level = 4;
            var operExpenseGroup = factory.CreateInstance("Операционные расходы", expenseGroup);

            var totalGroup = factory.CreateInstance("Прибыль/убыток");

            foreach (var group in budgetItemGroups.OfType<BudgetItemGroupView>().Where(t=>t.BudgetItemGroupType != BudgetItemGroupType.MiscGroup).OrderBy(t => t.Code))
            {
                ProfitLossItem item;
                if (group.BudgetItemGroupType == BudgetItemGroupType.ProjectsGroup)
                {
                    if (group.IsExpenseGroup)
                        item = factory.CreateInstance(group.FileAs, projExpenseGroup);
                    else
                        item = factory.CreateInstance(group.FileAs, projIncomeGroup);
                }
                else if (group.BudgetItemGroupType == BudgetItemGroupType.OperationsGroup)
                {
                    if (group.IsExpenseGroup)
                        item = factory.CreateInstance(group.FileAs, operExpenseGroup);
                    else
                        item = factory.CreateInstance(group.FileAs, operIncomeGroup);
                }
                //else if (group.BudgetItemGroupType == BudgetItemGroupType.MiscGroup)
                //{
                //    if (group.IsExpenseGroup)
                //        item = factory.CreateInstance(group.FileAs, expenseGroup);
                //    else
                //        item = factory.CreateInstance(group.FileAs, incomeGroup);
                //}
                else
                    throw new InvalidOperationException("unknown budget item group type");
                reportGroups.Add(group.Id, item);
                item = factory.CreateInstance("<>", item); item.Level = 4;
                reportGroupItems.Add(group.Id, item);
            }

            Dictionary<int, ProfitLossItem> reportItems = new Dictionary<int, ProfitLossItem>();
            foreach (var budgetItem in budgetItems.OfType<BudgetItemView>().OrderBy(t => t.Code))
            {
                var parent = reportGroups[budgetItem.BudgetItemGroupId];
                var item = factory.CreateInstance(budgetItem.FileAs, parent);
                reportItems.Add(budgetItem.Id, item);
            }

            foreach (var line in accrualLines)
            {
                ProfitLossItem item;
                switch (line.ViewGroup)
                {
                    case 1:
                    case 2:
                    case 3:
                        if (line.BudgetItemId.HasValue)
                            item = reportItems[line.BudgetItemId.Value];
                        else
                            item = reportGroupItems[line.BudgetItemGroupId.Value];
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                item.AccrualValue = item.AccrualValue.Add(line.Value);
                var parent = item.Parent;
                while (parent != null && parent.Level > 0)
                {
                    parent.AccrualValue = parent.AccrualValue.Add(line.Value);
                    parent = parent.Parent;
                }
            }

            foreach (var line in budgetLines)
            {
                var reportItem = reportItems[line.BudgetItemId];
                reportItem.StandardValue = line.StandardValue;
                reportItem.PlannedValue = line.PlannedValue;
                reportItem.ActualValue = line.ActualValue;

                var parent = reportItem.Parent;
                while (parent != null && parent.Level > 0)
                {
                    parent.StandardValue = parent.StandardValue.Add(reportItem.StandardValue);
                    parent.PlannedValue = parent.PlannedValue.Add(reportItem.PlannedValue);
                    parent.ActualValue = parent.ActualValue.Add(reportItem.ActualValue);
                    parent = parent.Parent;
                }
            }

            foreach (var line in operatingBudgetLines)
            {
                var reportItem = reportItems[line.BudgetItemId];
                reportItem.PlannedValue = line.PlannedValue;
                reportItem.ActualValue = line.ActualValue;
                var parent = reportItem.Parent;
                while (parent != null && parent.Level > 0)
                {
                    parent.PlannedValue = parent.PlannedValue.Add(reportItem.PlannedValue);
                    parent.ActualValue = parent.ActualValue.Add(reportItem.ActualValue);
                    parent = parent.Parent;
                }
            }
            foreach (var item in factory.List.Where(t => t.ParentId == incomeGroup.Id))
            {
                incomeGroup.StandardValue = incomeGroup.StandardValue.Add(item.StandardValue);
                incomeGroup.PlannedValue = incomeGroup.PlannedValue.Add(item.PlannedValue);
                incomeGroup.ActualValue = incomeGroup.ActualValue.Add(item.ActualValue);
                incomeGroup.AccrualValue = incomeGroup.AccrualValue.Add(item.AccrualValue);
            }
            foreach (var item in factory.List.Where(t => t.ParentId == expenseGroup.Id))
            {
                expenseGroup.StandardValue = expenseGroup.StandardValue.Add(item.StandardValue);
                expenseGroup.PlannedValue = expenseGroup.PlannedValue.Add(item.PlannedValue);
                expenseGroup.ActualValue = expenseGroup.ActualValue.Add(item.ActualValue);
                expenseGroup.AccrualValue = expenseGroup.AccrualValue.Add(item.AccrualValue);
            }

            totalGroup.StandardValue = incomeGroup.StandardValue.Sub(expenseGroup.StandardValue);
            totalGroup.PlannedValue = incomeGroup.PlannedValue.Sub(expenseGroup.PlannedValue);
            totalGroup.ActualValue = incomeGroup.ActualValue.Sub(expenseGroup.ActualValue);
            totalGroup.AccrualValue = incomeGroup.AccrualValue.Sub(expenseGroup.AccrualValue);

            return factory.List;
        }
    }
}
