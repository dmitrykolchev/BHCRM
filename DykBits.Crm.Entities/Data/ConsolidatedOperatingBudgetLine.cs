using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ConsolidatedOperatingBudgetLine: XmlSerializableDataItem
    {
        [XmlAttribute]
        public int BudgetItemId { get; set; }
        [XmlAttribute]
        public decimal PlannedValue { get; set; }
        [XmlAttribute]
        public decimal ActualValue { get; set; }
    }
}
