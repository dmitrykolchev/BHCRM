using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public abstract class XmlSerializableDataItem: IXmlSerializable
    {
        protected XmlSerializableDataItem()
        {
        }
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            DocumentSerializer serializer = new DocumentSerializer(this.GetType());
            serializer.DeserializeObject(this, reader);
        }
        public void WriteXml(XmlWriter writer)
        {
            DocumentSerializer serializer = new DocumentSerializer(this.GetType());
            serializer.Serialize(writer, this);
        }
    }
}
