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
    [TypeMapping(typeof(ProductCostStatementLine))]
    partial class ProductCostStatement
    {
        private ProductCostStatementLineCollection _lines;
        public ProductCostStatementLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new ProductCostStatementLineCollection(this);
                    this._lines.CollectionChanged += _lines_CollectionChanged;
                }
                return this._lines;
            }
        }
        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Lines");
        }

    }
}
