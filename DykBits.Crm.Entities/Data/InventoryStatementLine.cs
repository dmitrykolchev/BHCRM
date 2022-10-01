using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class InventoryStatementLineCollection : DetailDataItemCollection<InventoryStatement, InventoryStatementLine>
    {
        internal InventoryStatementLineCollection(InventoryStatement owner): base(owner)
        {
        }
    }
    public class InventoryStatementLine: DetailDataItem<InventoryStatement>
    {
        public const string TotalCostProperty = "TotalCost";
        public const string DifferenceProperty = "Difference";
        public const string DifferenceCostProperty = "DifferenceCost";

        private decimal _amount;
        private decimal _amountInStock;
        private decimal _cost;
        private ProductView _product;
        [XmlAttribute]
        public Nullable<int> InventoryStatementLineId { get; set; }
        [XmlAttribute]
        public Nullable<int> InventoryStatementId { get; set; }
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
        public Nullable<int> UnitOfMeasureId {
            get
            {
                if(this.Product != null)
                    return this.Product.UnitOfMeasureId;
                return null;
            }
        }
        [XmlAttribute]
        public decimal ExpectedAmount
        {
            get { return this._amountInStock; }
            set
            {
                this._amountInStock = value;
                InvokePropertyChanged();
                InvokePropertyChanged(DifferenceProperty);
                InvokePropertyChanged(DifferenceCostProperty);
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
                InvokePropertyChanged(DifferenceProperty);
                InvokePropertyChanged(DifferenceCostProperty);
            }
        }
        [XmlIgnore]
        public decimal Difference
        {
            get { return this.Amount - this.ExpectedAmount; }
        }
        [XmlIgnore]
        public decimal DifferenceCost
        {
            get { return Difference * Cost; }
        }
        [XmlAttribute]
        public decimal Cost
        {
            get { return this._cost; }
            set
            {
                this._cost = value;
                InvokePropertyChanged();
                InvokePropertyChanged(TotalCostProperty);
                InvokePropertyChanged(DifferenceCostProperty);
            }
        }
        [XmlIgnore]
        public decimal TotalCost
        {
            get { return Amount * Cost; }
        }
    }
}
