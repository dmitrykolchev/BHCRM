using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ProductCostStatementLineCollection : DetailDataItemCollection<ProductCostStatement, ProductCostStatementLine>
    {
        internal ProductCostStatementLineCollection(ProductCostStatement owner)
            : base(owner)
        {
        }
    }
    public class ProductCostStatementLine: DetailDataItem<ProductCostStatement>
    {
        private int _productId;
        private decimal _cost;
        public int ProductCostStatementLineId { get; set; }
        public int ProductCostStatementId { get; set; }
        public int ProductId
        {
            get { return this._productId; }
            set
            {
                this._productId = value;
                InvokePropertyChanged();
            }
        }
        public Nullable<int> UnitOfMeasureId
        {
            get { return ListManager.GetItem<ProductView>(this.ProductId).UnitOfMeasureId; }
        }
        public decimal Cost
        {
            get { return this._cost; }
            set
            {
                this._cost = value;
                InvokePropertyChanged();
            }
        }
    }
}
