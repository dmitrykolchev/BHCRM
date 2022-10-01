using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ReturnStatementLineCollection : DetailDataItemCollection<ReturnStatement, ReturnStatementLine>
    {
        internal ReturnStatementLineCollection(ReturnStatement owner)
            : base(owner)
        {
        }
    }
    public class ReturnStatementLine: DetailDataItem<ReturnStatement>
    {
        public const string TotalCostProperty = "TotalCost";
        public const string TotalPriceProperty = "TotalPrice";

        private ProductView _product;
        private decimal _amount;
        private decimal _cost;
        private decimal _price;
        [XmlAttribute]
        public int ReturnStatementLineId { get; set; }
        [XmlAttribute]
        public int ReturnStatementId { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductId { get; set; }
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
        public decimal PurchasedAmount
        {
            get;
            set;
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
