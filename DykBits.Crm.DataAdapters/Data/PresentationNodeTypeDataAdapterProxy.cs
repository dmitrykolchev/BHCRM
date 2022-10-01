using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class PresentationNodeTypeDataAdapterProxy: ViewDataAdapterProxy<PresentationNodeType, EmptyFilter>
    {
        protected override IList<PresentationNodeType> BrowseOverride(System.Xml.Linq.XElement filter)
        {
            List<PresentationNodeType> nodes = new List<PresentationNodeType>();
            nodes.Add(new PresentationNodeType { Id = PresentationNodeType.Folder, FileAs = "Папка" });
            nodes.Add(new PresentationNodeType { Id = PresentationNodeType.PresentationSet, FileAs = "Набор представлений" });
            nodes.Add(new PresentationNodeType { Id = PresentationNodeType.Presentation, FileAs = "Представление" });
            return nodes;
        }

        protected override IList<PresentationNodeType> GetListOverride(System.Xml.Linq.XElement filter)
        {
            return Browse(filter);
        }
    }
}
