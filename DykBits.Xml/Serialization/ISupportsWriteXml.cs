using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DykBits.Xml.Serialization
{
    public interface ISupportsWriteXml
    {
        void WriteXml(XmlWriter writer);
    }
}
