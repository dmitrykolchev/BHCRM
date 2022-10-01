using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class SalesOrderLineCollection : DetailDataItemCollection<SalesOrder, SalesOrderLine>
    {
        internal SalesOrderLineCollection(SalesOrder owner)
            : base(owner)
        {
        }
    }
    public class SalesOrderLine : DetailDataItem<SalesOrder>
    {
        public const string TotalCostProperty = "TotalCost";
        public const string TotalPriceProperty = "TotalPrice";

        private Nullable<int> _productId;
        private ProductView _product;
        private decimal _amount;
        private decimal _cost;
        private decimal _price;
        [XmlAttribute]
        public int SalesOrderLineId { get; set; }
        [XmlAttribute]
        public int SalesOrderId { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
                this._product = null;
                InvokePropertyChanged();
                InvokePropertyChanged("Product");
                InvokePropertyChanged("UnitOfMeasureId");
                InvokePropertyChanged("ProductCategoryId");
            }
        }
        [XmlIgnore]
        public ProductView Product
        {
            get
            {
                if (!this.ProductId.HasValue)
                    return null;
                if (this._product == null)
                    this._product = ListManager.GetItem<ProductView>(ProductId.Value);
                return this._product;
            }
        }
        [XmlIgnore]
        public Nullable<int> UnitOfMeasureId
        {
            get
            {
                if (this.Product != null)
                    return this.Product.UnitOfMeasureId;
                return null;
            }
        }
        [XmlIgnore]
        public Nullable<int> ProductCategoryId
        {
            get
            {
                if (this.Product != null)
                    return this.Product.ProductCategoryId;
                return null;
            }
        }
        [XmlAttribute]
        public decimal Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalPriceProperty);
                InvokePropertyChanged(TotalCostProperty);
            }
        }
        [XmlAttribute]
        public decimal Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalPriceProperty);
            }
        }
        [XmlIgnore]
        public decimal TotalPrice
        {
            get { return Amount * Price; }
        }
        [XmlAttribute]
        public decimal Cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                this._cost = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalCostProperty);
            }
        }
        [XmlIgnore]
        public decimal TotalCost
        {
            get { return Amount * Cost; }
        }
    }
}
