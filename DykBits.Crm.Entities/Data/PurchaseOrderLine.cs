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
    public class PurchaseOrderLineCollection : DetailDataItemCollection<PurchaseOrder, PurchaseOrderLine>
    {
        internal PurchaseOrderLineCollection(PurchaseOrder owner): base(owner)
        {
        }
    }
    public class PurchaseOrderLine : DetailDataItem<PurchaseOrder>
    {
        public const string TotalCostProperty = "TotalCost";

        private ProductView _product;
        private decimal _amount;
        private decimal _cost;
        [XmlAttribute]
        public int PurchaseOrderLineId { get; set; }
        [XmlAttribute]
        public int PurchaseOrderId { get; set; }
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
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged("TotalCostUI");
            }
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
                InvokePropertyChanged("TotalCostUI");
            }
        }
        [XmlIgnore]
        public decimal TotalCost
        {
            get { return Amount * Cost; }
        }
        [XmlIgnore]
        public decimal TotalCostUI
        {
            get
            {
                return TotalCost;
            }
            set
            {
                if (this.Amount != 0)
                {
                    this._cost = Math.Round(value / this.Amount, 4, MidpointRounding.AwayFromZero);
                }
                InvokePropertyChanged();
                InvokePropertyChanged("Cost");
            }
        }
    }
}
