using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ConsolidatedMoneyOperationLine: XmlSerializableDataItem
    {
        [XmlAttribute]
        public int ViewGroup { get; set; }
        [XmlAttribute]
        public int CashAccount { get; set; }
        [XmlAttribute]
        public int MoneyOperationDirection { get; set; }
        [XmlAttribute]
        public Nullable<int> BudgetItemGroupId { get; set; }
        [XmlAttribute]
        public Nullable<int> BudgetItemId { get; set; }
        [XmlAttribute]
        public Nullable<decimal> Value { get; set; }
    }
}
