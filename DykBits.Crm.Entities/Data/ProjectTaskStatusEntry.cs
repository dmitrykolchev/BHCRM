using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ProjectTaskStatusEntry
    {
        public ProjectTaskStatusEntry()
        {
        }
        [XmlAttribute]
        public int ProjectTaskStatusEntryId { get; set; }
        [XmlAttribute]
        public int ProjectTaskId { get; set; }
        [XmlAttribute]
        public Nullable<int> ProjectTaskStatusId { get; set; }
        [XmlAttribute]
        public string ProjectTaskStatus { get; set; }
        [XmlAttribute]
        public Nullable<int> Color { get; set; }
        [XmlAttribute]
        public DateTime Created { get; set; }
        [XmlAttribute]
        public int CreatedBy { get; set; }
    }
}
