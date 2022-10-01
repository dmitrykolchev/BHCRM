using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DykBits.Crm.Data
{
    partial class EmployeeDataAdapter
    {
        public Employee GetCurrentEmployee()
        {
            SqlProcedureManager commandManager = ServiceManager.GetService<SqlProcedureManager>();
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = commandManager.GetProcedure("[dbo].[CurrentEmployeeGet]", connection))
                {
                    return ExecuteItem(command);
                }
            }
        }
    }
}
