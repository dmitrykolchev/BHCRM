using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DykBits.Crm.Data
{
    public class SqlHelper
    {
        private const string ParametersSQL = @"
DECLARE @name sysname, @schema sysname;
SELECT 
    @name = parsename(@objname, 1), 
	@schema = ISNULL(parsename(@objname, 2), 'dbo');
SELECT 
    * 
FROM 
    INFORMATION_SCHEMA.PARAMETERS
WHERE
	SPECIFIC_SCHEMA = @schema AND SPECIFIC_NAME = @name
ORDER BY 
	ORDINAL_POSITION;";


        public static IList<SqlParameter> DeriveParameters(string procedureName, SqlConnection connection)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            bool needClose = false;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                needClose = true;
            }
            try
            {
                using (SqlCommand select = new SqlCommand(ParametersSQL, connection))
                {
                    select.Parameters.AddWithValue("@objname", procedureName);
                    select.CommandType = CommandType.Text;
                    using (IDataReader reader = select.ExecuteReader())
                    {
                        SqlParameter returnValue = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        parameters.Add(returnValue);
                        while (reader.Read())
                        {
                            parameters.Add(CreateParameter(reader));
                        }
                        return parameters;
                    }
                }
            }
            finally
            {
                if (needClose)
                {
                    connection.Close();
                }
            }
        }

        private static SqlParameter CreateParameter(IDataRecord record)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = (string)record["PARAMETER_NAME"];

            parameter.SqlDbType = GetParameterType(((string)record["DATA_TYPE"]).ToLowerInvariant());

            if (record["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                parameter.Size = Convert.ToInt32(record["CHARACTER_MAXIMUM_LENGTH"]);

            if (record["NUMERIC_PRECISION"] != DBNull.Value)
                parameter.Precision = Convert.ToByte(record["NUMERIC_PRECISION"]);
            if (record["NUMERIC_SCALE"] != DBNull.Value)
                parameter.Scale = Convert.ToByte(record["NUMERIC_SCALE"]);

            string mode = ((string)record["PARAMETER_MODE"]).ToUpper();
            switch (mode)
            {
                case "IN":
                    parameter.Direction = ParameterDirection.Input;
                    break;
                case "OUT":
                    parameter.Direction = ParameterDirection.Output;
                    break;
                case "INOUT":
                    parameter.Direction = ParameterDirection.InputOutput;
                    break;
                default:
                    throw new InvalidOperationException("invalid parameter mode");
            }
            return parameter;
        }

        private static SqlDbType GetParameterType(string typeName)
        {
            if (typeName == "sql_variant")
                return SqlDbType.Variant;
            return (SqlDbType)Enum.Parse(typeof(SqlDbType), typeName, true);
        }
    }
}
