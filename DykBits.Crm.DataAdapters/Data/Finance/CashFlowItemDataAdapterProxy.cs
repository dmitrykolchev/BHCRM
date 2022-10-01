using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CashFlowItemDataAdapterProxy : ViewDataAdapterProxy<CashFlowItem, ConsolidatedBudgetItemFilter>
    {
        protected override IList<CashFlowItem> BrowseOverride(System.Xml.Linq.XElement filter)
        {
            var moneyOperationDataAdapter = new ConsolidatedMoneyOperationLineDataAdapterProxy();
            var moneyOperations = moneyOperationDataAdapter.Browse(filter);

            var budgetItems = ListManager.GetList<BudgetItemView>();
            var budgetItemGroups = ListManager.GetList<BudgetItemGroupView>();

            var reportGroups = new Dictionary<int, CashFlowItem>();
            var reportGroupItems = new Dictionary<int, CashFlowItem>();
            var factory = new CashFlowItemFactory();

            var startBalance = factory.CreateInstance("Начальное сальдо");
            var startBalanceNonCash = factory.CreateInstance("Банк", startBalance, 3);
            var startBalanceCash = factory.CreateInstance("Касса", startBalance, 3);


            var incomeGroup = factory.CreateInstance("Приход");
            var incomeItem = factory.CreateInstance("<>", incomeGroup , 3);
            var creditIncomeItem = factory.CreateInstance("Кредиты", incomeGroup, 3);
            var creditIssueIncomeItem = factory.CreateInstance("Расчеты с заемщиками", incomeGroup, 3);
            var advanceIncomeItem = factory.CreateInstance("Авансовый отчет", incomeGroup, 3);
            var projIncomeGroup = factory.CreateInstance("Приход по ПРС", incomeGroup);
            var operIncomeGroup = factory.CreateInstance("Операционные доходы", incomeGroup);


            var expenseGroup = factory.CreateInstance("Расход");
            var expenseItem = factory.CreateInstance("<>", expenseGroup, 3); expenseItem.Level = 3;
            var creditExpenseItem = factory.CreateInstance("Расчеты с кредиторами", expenseGroup, 3);
            var creditIssueExpenseItem = factory.CreateInstance("Выдача кредитов", expenseGroup, 3);
            var advanceExpenseItem = factory.CreateInstance("Под отчет", expenseGroup, 3);
            var projExpenseGroup = factory.CreateInstance("Расходы по ПРС", expenseGroup);
            var operExpenseGroup = factory.CreateInstance("Операционные расходы", expenseGroup);

            var endBalance = factory.CreateInstance("Конечное сальдо");
            var endBalanceNonCash = factory.CreateInstance("Банк", endBalance, 3);
            var endBalanceCash = factory.CreateInstance("Касса", endBalance, 3);

            foreach (var group in budgetItemGroups.OfType<BudgetItemGroupView>().OrderBy(t => t.Code))
            {
                CashFlowItem item;
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
                else if (group.BudgetItemGroupType == BudgetItemGroupType.MiscGroup)
                {
                    if (group.IsExpenseGroup)
                        item = factory.CreateInstance(group.FileAs, expenseGroup);
                    else
                        item = factory.CreateInstance(group.FileAs, incomeGroup);
                }
                else
                    throw new InvalidOperationException();
                reportGroups.Add(group.Id, item);
                item = factory.CreateInstance("<>", item, 3);
                reportGroupItems.Add(group.Id, item);
            }

            Dictionary<int, CashFlowItem> reportItems = new Dictionary<int, CashFlowItem>();
            foreach (var budgetItem in budgetItems.OfType<BudgetItemView>().OrderBy(t => t.Code))
            {
                var parent = reportGroups[budgetItem.BudgetItemGroupId];
                var item = factory.CreateInstance(budgetItem.FileAs, parent);
                reportItems.Add(budgetItem.Id, item);
            }

            foreach (var line in moneyOperations)
            {
                if (line.ViewGroup == 2)
                {
                    if (line.BudgetItemId.HasValue)
                    {
                        var reportItem = reportItems[line.BudgetItemId.Value];
                        reportItem.Value = line.Value;
                        var parent = reportItem.Parent;
                        parent.Value = parent.Value.Add(reportItem.Value);
                        parent = parent.Parent;
                        parent.Value = parent.Value.Add(reportItem.Value);
                    }
                    else if (line.BudgetItemGroupId.HasValue)
                    {
                        var reportItem = reportGroupItems[line.BudgetItemGroupId.Value];
                        reportItem.Value = reportItem.Value.Add(line.Value);
                        var parent = reportItem.Parent;
                        parent.Value = parent.Value.Add(reportItem.Value);
                        parent = parent.Parent;
                        parent.Value = parent.Value.Add(reportItem.Value);
                    }
                    else
                    {
                        if (line.MoneyOperationDirection > 0)
                        {
                            incomeItem.Value = incomeItem.Value.Add(line.Value);
                        }
                        else
                        {
                            expenseItem.Value = expenseItem.Value.Add(line.Value);
                        }
                    }
                }
                else if (line.ViewGroup == 1)
                {
                    if (line.CashAccount != 0)
                        startBalanceCash.Value = line.Value;
                    else
                        startBalanceNonCash.Value = line.Value;
                    startBalance.Value = startBalance.Value.Add(line.Value);
                }
                else if (line.ViewGroup == 3)
                {
                    if (line.CashAccount != 0)
                        endBalanceCash.Value = line.Value;
                    else
                        endBalanceNonCash.Value = line.Value;
                    endBalance.Value = endBalance.Value.Add(line.Value);
                }
                else if (line.ViewGroup == 4)
                {
                    if (line.MoneyOperationDirection > 0)
                        advanceIncomeItem.Value = advanceIncomeItem.Value.Add(line.Value);
                    else if (line.MoneyOperationDirection < 0)
                        advanceExpenseItem.Value = advanceExpenseItem.Value.Add(line.Value);
                    else
                        throw new InvalidOperationException();
                }
                else if (line.ViewGroup == 5)
                {
                    if (line.MoneyOperationDirection > 0)
                        creditIncomeItem.Value = creditIncomeItem.Value.Add(line.Value);
                    else if (line.MoneyOperationDirection < 0)
                        creditExpenseItem.Value = creditExpenseItem.Value.Add(line.Value);
                    else
                        throw new InvalidOperationException();
                }
                else if (line.ViewGroup == 6)
                {
                    if (line.MoneyOperationDirection > 0)
                        creditIssueIncomeItem.Value = creditIssueIncomeItem.Value.Add(line.Value);
                    else if (line.MoneyOperationDirection < 0)
                        creditIssueExpenseItem.Value = creditIssueExpenseItem.Value.Add(line.Value);
                    else
                        throw new InvalidOperationException();
                }
            }
            
            incomeGroup.Value = projIncomeGroup.Value.Add(operIncomeGroup.Value).Add(incomeItem.Value).Add(advanceIncomeItem.Value).Add(creditIncomeItem.Value);

            expenseGroup.Value = projExpenseGroup.Value.Add(operExpenseGroup.Value).Add(expenseItem.Value).Add(advanceExpenseItem.Value).Add(creditExpenseItem.Value);

            return factory.List;
        }
    }
}
