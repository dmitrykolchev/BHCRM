using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    public class RequestFilterDataEventArgs: EventArgs
    {
        public RequestFilterDataEventArgs(string dataSource, Filter filter)
        {
            this.DataSource = dataSource;
            this.DataSourceFilter = filter;
        }
        public string DataSource { get; private set; }
        public Filter DataSourceFilter { get; private set; }
    }
}
