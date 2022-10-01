using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class PresentationNodeFilter
    {
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> DocumentTypeId { get; set; }
        public bool AllNodes { get; set; }
        public bool AllNodeTypes { get; set; }
        [XmlArrayItem("NodeType")]
        public int[] NodeTypes { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)PresentationNodeState.Active, (byte)PresentationNodeState.Inactive };
            this.AllNodeTypes = true;
            if (dataContext is PresentationNode)
            {
                this.ParentId = ((PresentationNode)dataContext).Id;
            }
            else if (dataContext is DocumentTypeEntry)
            {
                this.DocumentTypeId = ((DocumentTypeEntry)dataContext).Id;
            }
        }
    }
}
