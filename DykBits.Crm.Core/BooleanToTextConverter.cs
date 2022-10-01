using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DykBits.Crm
{
    public class BooleanToTextConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool && parameter is string)
            {
                string text = (string)parameter;
                var index = text.IndexOf(';');
                if (index >= 0)
                {
                    if ((bool)value)
                        return text.Substring(index + 1);
                    return text.Substring(0, index);
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
