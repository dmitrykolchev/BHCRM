using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.UI
{
    public class DataSourceChangedEventArgs: EventArgs
    {
        internal DataSourceChangedEventArgs(object oldDataSource, object newDataSource)
        {
            OldDataSource = oldDataSource;
            NewDataSource = newDataSource;
        }
        public object OldDataSource { get; private set; }
        public object NewDataSource { get; private set; }
    }
}
