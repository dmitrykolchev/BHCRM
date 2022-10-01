using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DykBits.Crm
{
    public class TimeSpanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TimeSpan)
            {
                return ((TimeSpan)value).ToString(@"dd\.hh\:mm");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string && targetType == typeof(TimeSpan))
            {
                TimeSpan result;
                if (TimeSpan.TryParse((string)value, out result))
                    return result;
            }
            return value;
        }
    }
}
