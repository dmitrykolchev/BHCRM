using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DykBits.Crm.Data
{
    public class LocalConnectionManager: IConnectionManager
    {
        public LocalConnectionManager()
        {
        }
        public LocalConnectionManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public SqlConnection CreateLocalConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public string ConnectionString
        {
            get;
            set;
        }
        public bool IsRemote
        {
            get
            {
                return false;
            }
        }
    }
}
