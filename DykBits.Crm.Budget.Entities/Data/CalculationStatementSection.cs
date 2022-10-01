using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class CalculationStatementSection
    {
        private static int CurrentId = 0;
        public CalculationStatementSection()
        {
            CalculationStatementSectionId = -System.Threading.Interlocked.Increment(ref CurrentId);
        }
        [XmlAttribute]
        public int CalculationStatementSectionId { get; set; }
        [XmlAttribute]
        public int CalculationStatementId { get; set; }
        [XmlAttribute]
        public int OrdinalPosition { get; set; }
        [XmlAttribute]
        public string FileAs { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductCategoryId { get; set; }
        [XmlAttribute]
        public string Comments { get; set; }
        [XmlAttribute]
        public Nullable<decimal> StandardAmount { get; set; }
        [XmlAttribute]
        public Nullable<decimal> StandardTotalCost { get; set; }
        [XmlAttribute]
        public Nullable<decimal> StandardTotalPrice { get; set; }
        [XmlIgnore]
        public CalculationStatement Parent { get; internal set; }
    }
}
