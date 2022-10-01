using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(ReturnStatementLine))]
    partial class ReturnStatement
    {
        private Nullable<int> _customertId;

        private ReturnStatementLineCollection _lines;
        public ReturnStatementLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new ReturnStatementLineCollection(this);
                    this._lines.CollectionChanged += _lines_CollectionChanged;
                }
                return this._lines;
            }
        }

        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Lines");
        }

        public Nullable<int> CustomerIdUI
        {
            get {
                if (!this._customertId.HasValue)
                {
                    if (SalesOrderId > 0)
                    {
                        var salesOrder = DocumentManager.GetItem<SalesOrder>(this.SalesOrderId);
                        this._customertId = salesOrder.CustomerId;
                    }
                }
                return this._customertId; 
            }
            private set
            {
                this._customertId = value;
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public int SalesOrderIdUI
        {
            get { return this.SalesOrderId; }
            set
            {
                this.SalesOrderId = value;
                InvokePropertyChanged();
                UpdateReturnStatement();
            }
        }
        private void UpdateReturnStatement()
        {
            Lines.Clear();
            if (this.SalesOrderId <= 0)
            {
                this.CustomerIdUI = null;
            }
            else
            {
                var salesOrder = DocumentManager.GetItem<SalesOrder>(this.SalesOrderId);
                this.CustomerIdUI = salesOrder.CustomerId;
                foreach (var orderLine in salesOrder.Lines)
                {
                    this.Lines.Add(new ReturnStatementLine { ProductId = orderLine.ProductId, PurchasedAmount = orderLine.Amount, Amount = 0, Price = orderLine.Price, Cost = orderLine.Cost });
                }
            }
        }
    }
}
