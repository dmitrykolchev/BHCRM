using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class PayrollDataAdapterProxy
    {
        protected override Payroll CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            if (dataContext is OperatingBudget)
            {
                var budget = (OperatingBudget)dataContext;
                document.OrganizationId = budget.OrganizationId;
                document.DocumentDate = budget.DocumentDate;
                document.OperatingBudgetId = budget.Id;
                switch(budget.State)
                {
                    case OperatingBudgetState.Draft:
                        document.CalculationStage = CalculationStage.Planned;
                        break;
                    case OperatingBudgetState.PlannedApproved:
                        document.CalculationStage = CalculationStage.Actual;
                        break;
                    default:
                        throw new CrmApplicationException("Для бюджета в текущем состоянии невозможно создать расчетную ведомость.");
                }
                EmployeeFilter filter = new EmployeeFilter
                {
                    States = new byte[] { (byte)EmployeeState.Active },
                    OrganizationId = budget.OrganizationId
                };
                var employees = DocumentManager.Browse<EmployeeView>(filter);
                foreach (var employee in employees)
                {
                    document.Lines.Add(new PayrollLine
                    {
                        AccountId = employee.EmployeeAccountId,
                        DivisionId = employee.DivisionId,
                        EmployeeId = employee.Id,
                        PositionId = employee.PositionId,
                        FileAs = employee.FileAs
                    });
                }
            }
            return document;
        }
    }
}
