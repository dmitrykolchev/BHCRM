using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(ProductSupplier))]
    partial class Product
    {
        private ProductSupplierCollection _suppliers;
        public ProductSupplierCollection Suppliers
        {
            get
            {
                if (this._suppliers == null)
                {
                    this._suppliers = new ProductSupplierCollection(this);
                    this._suppliers.CollectionChanged += _suppliers_CollectionChanged;
                }
                return this._suppliers;
            }
        }

        void _suppliers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Suppliers");
        }
    }
}
