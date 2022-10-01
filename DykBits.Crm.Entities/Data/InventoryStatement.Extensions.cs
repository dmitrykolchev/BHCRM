using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(InventoryStatementLine))]
    partial class InventoryStatement
    {
        private InventoryStatementLineCollection _lines;
        public InventoryStatementLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new InventoryStatementLineCollection(this);
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
