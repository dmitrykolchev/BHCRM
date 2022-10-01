using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class CalculationStatementTemplateFilter
    {
        public Nullable<int> BudgetTemplateId { get; set; }
        public Nullable<int> IncomeBudgetItemId { get; set; }
        public Nullable<int> ExpenseBudgetItemId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)CalculationStatementTemplateState.Active }; 
            if (dataContext is BudgetTemplate)
                this.BudgetTemplateId = ((BudgetTemplate)dataContext).Id;
        }
    }
}
