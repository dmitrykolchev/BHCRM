using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DykBits.Crm.Data
{
    partial class DocumentNumberingRuleDataAdapterProxy
    {
        protected override DocumentNumberingRule CreateItemOverride(object dataContext)
        {
            DocumentNumberingRule document = base.CreateItemOverride(dataContext);

            document.Value = 1;
            document.Increment = 1;
            document.PeriodStart = DateTime.Today;
            document.FormatString = "{0:00000000}";
            document.FileAsFormatString = "№{0:00000000} от {1:dd.MM.yyyy}";

            return document;
        }
    }
}
