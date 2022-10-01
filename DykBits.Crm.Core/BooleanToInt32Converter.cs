using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace DykBits.Crm
{
    public class BooleanToInt32Converter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return 0;

            bool bValue = (bool)value;

            if (bValue == true)
                return 1;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value == null)
                return false;
            if((int)value == 0)
                return false;
            return true;
        }
    }
}
