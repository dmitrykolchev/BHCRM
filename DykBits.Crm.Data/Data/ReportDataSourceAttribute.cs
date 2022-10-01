using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ReportDataSourceAttribute: Attribute
    {
        private Type _dataSourceType;
        public ReportDataSourceAttribute(Type dataSourceType)
        {
            if (dataSourceType == null)
                throw new ArgumentNullException("dataSourceType");
            this._dataSourceType = dataSourceType;
        }
        public Type DataSourceType
        {
            get { return this._dataSourceType; }
        }
    }
}
