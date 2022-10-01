using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Generator
{
    public class SqlColumnInfo
    {
        public int ColumnOrdinal { get; set; }
        public string ColumnName { get; set; }
        public int ColumnSize { get; set; }
        public string DataType { get; set; }
        public short NumericPrecision { get; set; }
        public short NumericScale { get; set; }
        public bool IsNullable { get; set; }

        public bool CanBeNull()
        {
            if (this.IsNullable)
                return true;
            switch (this.DataType.ToLower())
            {
                case "binary":
                case "varbinary":
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                case "image":
                case "timestamp":
                    return true;
                case "float":
                case "real":
                case "bit":
                case "tinyint":
                case "smallint":
                case "int":
                case "bingint":
                case "date":
                case "decimal":
                case "money":
                case "datetime":
                case "uniqueidentifier":
                    return false;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
    public class SqlCommandResults
    {
        public static IList<SqlColumnInfo> GetViewColumns(string commandText, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(command);
            foreach (SqlParameter parameter in command.Parameters)
            {
                parameter.Value = DBNull.Value;
            }

            SqlCommand setFmtCommand = new SqlCommand("set fmtonly on", connection);
            setFmtCommand.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                DataTable dataTable = reader.GetSchemaTable();
                return dataTable.Rows.OfType<DataRow>()
                    .Select(t => new SqlColumnInfo
                    {
                        ColumnOrdinal = (int)t["ColumnOrdinal"],
                        ColumnName = (string)t["ColumnName"],
                        ColumnSize = (int)t["ColumnSize"],
                        DataType = (string)t["DataTypeName"],
                        NumericPrecision = (short)t["NumericPrecision"],
                        NumericScale = (short)t["NumericScale"],
                        IsNullable = (bool)t["AllowDBNull"]
                    })
                   .OrderBy(t => t.ColumnOrdinal)
                   .ToArray();
            }
        }
    }
}
