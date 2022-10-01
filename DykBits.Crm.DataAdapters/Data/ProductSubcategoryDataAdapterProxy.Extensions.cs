using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProductSubcategoryDataAdapterProxy
    {
        protected override ProductSubcategory CreateItemOverride(object dataContext)
        {
            ProductSubcategory item = new ProductSubcategory();
            ProductCategory category = dataContext as ProductCategory;
            if (category != null && !category.IsNew)
            {
                item.ProductCategoryId = category.Id;
            }
            return item;
        }
    }
}
