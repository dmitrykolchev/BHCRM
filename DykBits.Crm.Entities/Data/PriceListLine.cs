using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class PriceListLine : NotifyObject
    {
        private ProductView _product;
        private int _priceMarginId;
        private decimal _price;
        private PriceList _priceList;
        public PriceListLine()
        {
        }
        public PriceListLine(ProductView product)
        {
            this._product = product;
            this.ProductId = this._product.Id;
            this.Price = this._product.ListPrice;
            this.PriceMarginId = this._product.PriceMarginId;
        }
        [XmlIgnore]
        internal PriceList PriceList
        {
            get { return this._priceList; }
            set
            {
                this._priceList = value;
                SetPrice();
            }
        }
        [XmlAttribute]
        public int PriceListLineId { get; set; }
        [XmlAttribute]
        public int PriceListId { get; set; }
        [XmlIgnore]
        public ProductView Product
        {
            get
            {
                if (this._product == null)
                {
                    if (this.PriceList != null)
                    {
                        this._product = (ProductView)this.PriceList.Products[this.ProductId];
                    }
                }
                return this._product;
            }
        }
        [XmlAttribute]
        public int ProductId { get; set; }
        public int PriceMarginId
        {
            get { return this._priceMarginId; }
            set
            {
                this._priceMarginId = value;
                SetPrice();
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public decimal Cost
        {
            get
            {
                if (this.Product != null)
                    return this.Product.StandardCost;
                return 0;
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
            }
        }
        private void SetPrice()
        {
            if (this.PriceList != null && this.Product != null)
            {
                if (this._priceMarginId > 1)
                {
                    PriceMarginView priceMargin = (PriceMarginView)this.PriceList.Margins[this._priceMarginId];
                    this.Price = Math.Round(Product.StandardCost * (1 + priceMargin.Margin), 2, MidpointRounding.AwayFromZero);
                }
            }
        }
    }
}
