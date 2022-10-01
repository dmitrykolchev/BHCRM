using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public abstract class DetailDataItem<TParent>: NotifyObject
    {
        protected DetailDataItem()
        {
        }
        [XmlIgnore]
        public TParent Parent { get; set; }
    }
}
