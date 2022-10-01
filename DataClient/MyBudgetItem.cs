using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DataClient
{
    [XmlRoot("BudgetItem", Namespace="")]
    public class MyBudgetItem
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public byte State { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string FileAs { get; set; }
        [XmlAttribute]
        public int BudgetItemGroupId { get; set; }
        [XmlAttribute]
        public string Comments { get; set; }
        [XmlAttribute]
        public DateTime Created { get; set; }
        [XmlAttribute]
        public int CreatedBy { get; set; }
        [XmlAttribute]
        public DateTime Modified { get; set; }
        [XmlAttribute]
        public int ModifiedBy { get; set; }
        [XmlAttribute]
        public byte[] RowVersion { get; set; }
    }
}
