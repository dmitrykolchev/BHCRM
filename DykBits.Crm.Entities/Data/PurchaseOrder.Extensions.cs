using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(PurchaseOrderLine))]
    [ReportDataSource(typeof(Reports.PurchaseOrderReport))]
    partial class PurchaseOrder
    {
        private PurchaseOrderLineCollection _lines;
        public PurchaseOrderLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new PurchaseOrderLineCollection(this);
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
