using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class ProductIdToCategoryConverter: IValueConverter
    {
        private Dictionary<int, AbstractProductView> _products;
        private Dictionary<int, ProductCategoryView> _categories;

        private void Initialize()
        {
            if (this._products == null)
            {
                AbstractProductDataAdapterProxy da = (AbstractProductDataAdapterProxy)DocumentManager.CreateDataAdapterProxy<AbstractProduct>();
                this._products = da.Browse(Filter.EmptyXml).ToDictionary(t => t.Id);

                ProductCategoryDataAdapterProxy pcda = (ProductCategoryDataAdapterProxy)DocumentManager.CreateDataAdapterProxy<ProductCategory>();
                this._categories = pcda.Browse(Filter.EmptyXml).ToDictionary(t => t.Id);
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Initialize();
            if (value is int)
            {
                int id = (int)value;
                return this._categories[this._products[id].ProductCategoryId].FileAs;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
