using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class CalculationStatementFilter
    {
        public Nullable<int> BudgetId { get; set; }
        public Nullable<int> ServiceRequestId { get; set; }
        public Nullable<int> CalculationStage { get; set; }
        public Nullable<int> IncomeBudgetItemId { get; set; }
        public Nullable<int> ExpenseBudgetItemId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)CalculationStatementState.Approved, (byte)CalculationStatementState.Draft };
            if (dataContext is Budget)
            {
                this.BudgetId = ((Budget)dataContext).Id;
            }
            else if (dataContext is ServiceRequest)
            {
                this.ServiceRequestId = ((ServiceRequest)dataContext).Id;
            }
        }
    }
}
