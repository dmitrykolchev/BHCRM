using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class PresentationNodeApplicationRole: XmlSerializableDataItem
    {
        [XmlAttribute]
        public int PresentationNodeId { get; set; }
        [XmlAttribute]
        public int ApplicationRoleId { get; set; }
    }
}
