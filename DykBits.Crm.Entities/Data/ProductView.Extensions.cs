using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class ProductView: ISelectableDataItem
    {
        [XmlIgnore]
        public bool Selected { get; set; }
    }
}
