using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ProductSupplier: DetailDataItem<Product>
    {
        [XmlAttribute]
        public int ProductId { get; set; }
        [XmlAttribute]
        public int SupplierId { get; set; }
    }

    public class ProductSupplierCollection : DetailDataItemCollection<Product, ProductSupplier>
    {
        internal ProductSupplierCollection(Product owner)
            : base(owner)
        {
        }
    }
}
