using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ProductClass
    {
        public const int ProductClassUnknown = 0;
        public const int ProductClassProduct = 1;
        public const int ProductClassMasterMenu = 2;
        public const int ProductClassBeverage = 3;

        public int Id { get; set; }
        public string FileAs { get; set; }
    }

    public class ProductClassCollection : Collection<ProductClass>
    {
        public ProductClassCollection()
        {
            Add(new ProductClass { Id = ProductClass.ProductClassUnknown, FileAs = "(не указан)" });
            Add(new ProductClass { Id = ProductClass.ProductClassProduct, FileAs = "Прочее" });
            Add(new ProductClass { Id = ProductClass.ProductClassMasterMenu, FileAs = "Продукты питания" });
            Add(new ProductClass { Id = ProductClass.ProductClassBeverage, FileAs = "Напитки" });
        }
    }
}
