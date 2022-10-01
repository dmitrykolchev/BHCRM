using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class MoneyOperationDataAdapterProxy
    {
        protected override MoneyOperation CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is OperatingBudget)
            {
                document.OrganizationId = ((OperatingBudget)dataContext).OrganizationId;
                document.OperatingBudgetId = ((OperatingBudget)dataContext).Id;
            }
            else if (dataContext is Budget)
            {
                document.OrganizationId = ((Budget)dataContext).OrganizationId;
                document.BudgetId = ((Budget)dataContext).Id;
            }
            else if (dataContext is MoneyOperation)
            {
                MoneyOperation parent = (MoneyOperation)dataContext;
                document.ParentId = parent.Id;
                document.OrganizationId = parent.OrganizationId;
                document.OperatingBudgetId = parent.OperatingBudgetId;
                document.BudgetId = parent.BudgetId;
                document.BudgetItemGroupId = parent.BudgetItemGroupId;
                document.BudgetItemId = parent.BudgetItemId;
                document.BankAccountId = parent.BankAccountId;

                if (parent.MoneyOperationTypeId == MoneyOperationType.Advance)
                {
                    document.MoneyOperationTypeId = MoneyOperationType.PaymentOut;
                    document.EmployeeId = parent.EmployeeId;
                }
                else if (parent.MoneyOperationTypeId == MoneyOperationType.Credit)
                {
                    document.MoneyOperationTypeId = MoneyOperationType.CreditReturn;
                    document.AccountId = parent.AccountId;
                }
                else if (parent.MoneyOperationTypeId == MoneyOperationType.CreditIssue)
                {
                    document.MoneyOperationTypeId = MoneyOperationType.CreditIssueReturn;
                    document.AccountId = parent.AccountId;
                    document.MoneyOperationDirection = 1;
                }
            }
            else if (dataContext is SalesInvoice)
            {
                var invoice = (SalesInvoice)dataContext;
                document.SalesInvoiceId = invoice.Id;
                document.OrganizationId = invoice.OrganizationId;
                document.AccountId = invoice.AccountId;
                document.MoneyOperationTypeId = MoneyOperationType.PaymentIn;
                document.MoneyOperationDirection = MoneyOperationDirection.Incoming;
                document.BudgetId = invoice.BudgetId;
                document.OperatingBudgetId = invoice.OperatingBudgetId;
                document.Subject = "Оплата по счету №" + invoice.Number + " от " + invoice.DocumentDate.ToString("dd.MM.yyyy");
                document.Value = invoice.Value;
                document.VATRateId = invoice.VATRateId;
                document.VATValue = invoice.VATValue;
            }
            else if (dataContext is PurchaseInvoice)
            {
                var invoice = (PurchaseInvoice)dataContext;
                document.PurchaseInvoiceId = invoice.Id;
                document.OrganizationId = invoice.OrganizationId;
                document.AccountId = invoice.AccountId;
                document.MoneyOperationTypeId = MoneyOperationType.PaymentOut;
                document.MoneyOperationDirection = MoneyOperationDirection.Outgoing;
                document.BudgetId = invoice.BudgetId;
                document.OperatingBudgetId = invoice.OperatingBudgetId;
                document.Subject = "Оплата по счету №" + invoice.Number + " от " + invoice.DocumentDate.ToString("dd.MM.yyyy");
                document.Value = invoice.Value;
                document.VATRateId = invoice.VATRateId;
                document.VATValue = invoice.VATValue;
            }
            return document;
        }
        protected override void OnValidate(MoneyOperation item)
        {
            switch (item.MoneyOperationTypeId)
            {
                case MoneyOperationType.InitialValue:
                    item.AccountId = item.OrganizationId;
                    break;
                case MoneyOperationType.Transfer:
                    item.AccountId = item.OrganizationId;
                    break;
                case MoneyOperationType.Advance:
                    item.AccountId = item.OrganizationId;
                    break;
                case MoneyOperationType.CashReturn:
                    item.AccountId = item.OrganizationId;
                    break;
                case MoneyOperationType.Salary:
                    var employee = ListManager.GetItem<EmployeeView>(item.EmployeeId.Value);
                    item.AccountId = employee.EmployeeAccountId.Value;
                    break;
            }
            ValidateOperationDirection(item);
            base.OnValidate(item);
        }

        private void ValidateOperationDirection(MoneyOperation item)
        {
            Nullable<bool> isExpense = item.IsExpense;
            if (isExpense == true)
                item.MoneyOperationDirection = -1;
            else if (isExpense == false)
                item.MoneyOperationDirection = 1;
            else
                throw new InvalidOperationException("unknown money operation direction");
        }
    }
}
