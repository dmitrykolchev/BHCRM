using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateLine: NotifyObject
    {
        public CalculationStatementTemplateLine()
        {
            DependsOnAmountOfPersons = true;
            Duration = 1;
        }
        [XmlAttribute]
        public int CalculationStatementTemplateLineId { get; set; }
        [XmlAttribute]
        public int CalculationStatementTemplateSectionId { get; set; }
        [XmlAttribute]
        public int CalculationStatementTemplateId { get; set; }
        [XmlAttribute]
        public int OrdinalPosition { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductId { get; set; }
        [XmlAttribute]
        public string FileAs { get; set; }
        [XmlAttribute]
        public string Comments { get; set; }
        [XmlAttribute]
        public decimal Duration { get; set; }
        [XmlAttribute]
        public decimal Amount { get; set; }
        [XmlAttribute]
        public bool DependsOnAmountOfPersons { get; set; }
        [XmlAttribute]
        public bool DependsOnEventDuration { get; set; }
        [XmlAttribute]
        public decimal Price { get; set; }
        [XmlAttribute]
        public decimal Cost { get; set; }
        [XmlIgnore]
        public CalculationStatementTemplate Parent { get; internal set; }
    }
}
