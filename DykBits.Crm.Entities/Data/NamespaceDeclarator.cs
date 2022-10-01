using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    class NamespaceDeclarator
    {
        public const string Namespace = "urn:net-dykbits-crm";
        public static readonly XmlSerializerNamespaces SerializerNamespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] {
            new XmlQualifiedName("", Namespace)
        });
    }
}
