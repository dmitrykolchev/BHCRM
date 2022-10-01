using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DykBits.Crm
{
    public class ColorToValueConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                if (targetType == typeof(Color))
                {
                    int intValue = (int)value;
                    byte r = (byte)((intValue >> 16) & 0xFF);
                    byte g = (byte)((intValue >> 8) & 0xFF);
                    byte b = (byte)((intValue >> 0) & 0xFF);
                    return Color.FromRgb(r, g, b);
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color)
            {
                Color colorValue = (Color)value;
                return (colorValue.R << 16) | (colorValue.G << 8) | colorValue.B;
            }
            return value;
        }
    }
}
