using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IOperatingBudgetDocument
    {
        string Number { get; set; }
        int OrganizationId { get; set; }
        DateTime DocumentDate { get; set; }
        int OperatingBudgetId { get; set; }
        int CalculationStage { get; set; }
        int BudgetItemId { get; set; }
    }
}
