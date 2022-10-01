using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DykBits.Crm.Data
{
    partial class ProductSubcategoryFilter
    {
        public Nullable<int> ProductCategoryId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            if (dataContext is ProductCategory)
            {
                this.ProductCategoryId = ((ProductCategory)dataContext).Id;
            }
        }
    }
}
