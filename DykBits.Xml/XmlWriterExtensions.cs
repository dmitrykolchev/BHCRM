using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DykBits.Xml
{
    public static class XmlWriterExtensions
    {
        public static void WriteElementString(this XmlWriter writer, string localName, Nullable<int> value)
        {
            if (value.HasValue)
                writer.WriteElementString(localName, XmlConvert.ToString(value.Value));
        }
    }
}
