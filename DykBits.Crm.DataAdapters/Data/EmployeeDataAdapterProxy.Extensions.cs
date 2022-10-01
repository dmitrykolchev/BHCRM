using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class EmployeeDataAdapterProxy
    {
        protected override Employee CreateItemOverride(object dataContext)
        {
            Employee employee = base.CreateItemOverride(dataContext);
            if (dataContext is Organization)
            {
                employee.AccountId = ((Organization)dataContext).Id;
            }
            else if (dataContext is Account)
            {
                employee.AccountId = ((Account)dataContext).Id;
            }
            else if (dataContext is Division)
            {
                employee.DivisionId = ((Division)dataContext).Id;
                employee.AccountId = ((Division)dataContext).AccountId;
            }
            return employee;
        }
        protected override void OnValidate(Employee item)
        {
            base.OnValidate(item);
            if (item.Id == item.ReportsToEmployeeId)
                throw new ArgumentException("Сотрудник не может быть собственным руководителем");
            if (item.AccountId == 0)
                throw new DataValidationException("Необходимо указать организацию");
        }
    }
}
