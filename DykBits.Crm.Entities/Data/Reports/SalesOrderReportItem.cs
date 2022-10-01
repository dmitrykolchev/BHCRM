using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data.Reports
{
    public class SalesOrderReportItem
    {
        private SalesOrderLine _source;
        internal SalesOrderReportItem(SalesOrderLine source)
        {
            this._source = source;
        }
        public string FileAs
        {
            get {
                if(this._source.Product != null)
                    return this._source.Product.FileAs;
                return null;
            }
        }
        public string CategoryName
        {
            get
            {
                if (this._source.ProductCategoryId.HasValue)
                    return ListManager.GetItem<ProductCategoryView>(this._source.ProductCategoryId.Value).FileAs;
                return null;
            }
        }
        public string UnitOfMeasureCode
        {
            get
            {
                if (this._source.Product != null)
                    return ListManager.GetItem<UnitOfMeasureView>(this._source.Product.UnitOfMeasureId).Code;
                return null;
            }
        }
        public decimal Amount
        {
            get { return this._source.Amount; }
        }
        public decimal Cost
        {
            get { return this._source.Cost; }
        }
        public decimal TotalCost
        {
            get { return this.Amount * this.Cost; }
        }
        public decimal Price
        {
            get { return this._source.Price; }
        }
        public decimal Total
        {
            get { return this.Price * this.Amount; }
        }
    }
}
