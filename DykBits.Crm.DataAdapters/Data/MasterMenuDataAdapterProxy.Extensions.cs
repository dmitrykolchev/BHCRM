using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class MasterMenuDataAdapterProxy
    {
        protected override MasterMenu CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            document.ServiceLevelId = (int)(ServiceLevelFlag.Lowcost | ServiceLevelFlag.Standard | ServiceLevelFlag.Vip);
            IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
            document.OrganizationId = employee.OrganizationId;
            if (dataContext is AbstractProduct)
            {
                document.AbstractProductId = ((AbstractProduct)dataContext).Id;
            }
            else if (dataContext is ProductCategory)
            {
                document.ProductCategoryId = ((ProductCategory)dataContext).Id;
            }
            else if (dataContext is ProductSubcategory)
            {
                document.ProductSubcategoryId = ((ProductSubcategory)dataContext).Id;
            }
            return document;
        }
    }
}
