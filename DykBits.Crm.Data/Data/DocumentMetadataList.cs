using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [XmlType("DocumentMetadata")]
    public class DocumentMetadataList
    {
        public DocumentMetadataCollection _list = new DocumentMetadataCollection();

        public DocumentMetadataList()
        {
        }

        [XmlElement("DocumentType")]
        public DocumentMetadataCollection Items
        {
            get { return this._list; }
        }
    }
}
