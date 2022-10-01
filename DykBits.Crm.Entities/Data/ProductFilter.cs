using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml;
using System.Xml;

namespace DykBits.Crm.Data
{
    partial class ProductFilter
    {
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<int> AbstractProductId { get; set; }
        public Nullable<int> ProductCategoryId { get; set; }
        public Nullable<int> ProductSubcategoryId { get; set; }
        public Nullable<int> BudgetItemId { get; set; }
        public Nullable<int> ServiceLevelId { get; set; }
        public Nullable<int> ProductTypeId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)ProductState.Active };
            if (dataContext is AbstractProduct)
            {
                this.AbstractProductId = ((AbstractProduct)dataContext).Id;
            }
            else if (dataContext is ProductCategory)
            {
                this.ProductCategoryId = ((ProductCategory)dataContext).Id;
            }
            else if (dataContext is ProductSubcategory)
            {
                this.ProductSubcategoryId = ((ProductSubcategory)dataContext).Id;
            }
        }
    }
}
