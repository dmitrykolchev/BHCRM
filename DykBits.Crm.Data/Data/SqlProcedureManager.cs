using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DykBits.Crm.Data
{
    public class SqlProcedureManager
    {
        private Dictionary<string, IList<SqlParameter>> _parametersCache = new Dictionary<string, IList<SqlParameter>>();
        private object _sync = new object();

        public SqlProcedureManager()
        {
        }

        public SqlCommand GetProcedure(Type itemType, SqlProcedureType commandRole, SqlConnection connection)
        {
            string commandName = itemType.Name + commandRole.ToString();
            return GetProcedure(commandName, connection);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public SqlCommand GetProcedure(string procedureName, SqlConnection connection)
        {
            string connectionString = connection.ConnectionString;
            string key = procedureName + ":" + connectionString;
            IList<SqlParameter> parameters;
            lock (this._sync)
            {
                if (!_parametersCache.TryGetValue(key, out parameters))
                {
                    parameters = SqlHelper.DeriveParameters(procedureName, connection);
                    this._parametersCache.Add(key, parameters);
                }
            }
            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add((SqlParameter)((ICloneable)parameter).Clone());
            }
            return command;
        }
    }
}
