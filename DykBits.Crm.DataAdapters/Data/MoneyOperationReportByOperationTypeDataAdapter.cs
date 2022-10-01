using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class MoneyOperationReportByOperationTypeDataAdapter : XmlViewDataAdapterBase<MoneyOperationReportByOperationTypeItem, MoneyOperationReportByOperationTypeFilter>
    {
        public MoneyOperationReportByOperationTypeDataAdapter()
            : base("[dbo].[MoneyOperationReportByOperationType]")
        {
        }
    }

    public class MoneyOperationReportByOperationTypeDataAdapterProxy : ViewDataAdapterProxy<MoneyOperationReportByOperationTypeItem, MoneyOperationReportByOperationTypeFilter>
    {
    }
}
