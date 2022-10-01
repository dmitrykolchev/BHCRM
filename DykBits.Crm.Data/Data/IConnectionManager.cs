using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DykBits.Crm.Data
{
    public interface IConnectionManager
    {
        string ConnectionString { get; set; }
        bool IsRemote { get; }
    }
}
