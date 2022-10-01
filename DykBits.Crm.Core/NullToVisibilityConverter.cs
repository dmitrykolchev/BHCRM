using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DykBits.Crm
{
    public class NullToVisibilityConverter: IValueConverter
    {
        public NullToVisibilityConverter()
        {
            NullVisibility = Visibility.Hidden;
        }
        public Visibility NullVisibility
        {
            get;
            set;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return NullVisibility;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
