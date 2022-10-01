using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProductDataAdapterProxy
    {
        protected override Product CreateItemOverride(object dataContext)
        {
            Product product = base.CreateItemOverride(dataContext);
            product.ProductClass = ProductClass.ProductClassProduct;
            product.ServiceLevelId = (int)(ServiceLevelFlag.Lowcost | ServiceLevelFlag.Standard | ServiceLevelFlag.Vip);
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            product.OrganizationId = employee.OrganizationId;
            if (dataContext is AbstractProduct)
            {
                product.AbstractProductId = ((AbstractProduct)dataContext).Id;
            }
            else if (dataContext is ProductCategory)
            {
                product.ProductCategoryId = ((ProductCategory)dataContext).Id;
            }
            else if (dataContext is ProductSubcategory)
            {
                product.ProductSubcategoryId = ((ProductSubcategory)dataContext).Id;
            }
            return product;
        }
    }
}
