using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class ProductIdToImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (typeof(CalculationStatementLineItem).IsAssignableFrom(value.GetType()))
                {
                    CalculationStatementLineItem line = (CalculationStatementLineItem)value;
                    if (line.ProductId == null)
                        return DykBits.Crm.UI.ApplicationImages.CustomFlag;
                }
                else if (typeof(CalculationStatementSectionItem).IsAssignableFrom(value.GetType()))
                {
                    CalculationStatementSectionItem section = (CalculationStatementSectionItem)value;
                    if (!section.ReadOnly)
                        return DykBits.Crm.UI.ApplicationImages.GroupRow;
                    return DykBits.Crm.UI.ApplicationImages.TotalSum;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
