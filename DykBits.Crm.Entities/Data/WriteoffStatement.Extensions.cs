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
    [TypeMapping(typeof(WriteoffStatementLine))]
    partial class WriteoffStatement
    {
        private WriteoffStatementLineCollection _lines;

        public WriteoffStatementLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new WriteoffStatementLineCollection(this);
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
