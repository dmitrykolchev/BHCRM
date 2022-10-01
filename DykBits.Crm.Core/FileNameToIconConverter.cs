using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DykBits.Crm
{
    public class FileNameToIconConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                if ((string)parameter == "Small")
                    return Shell.ShellIcon.GetShellIcon(System.IO.Path.GetExtension((string)value), IconSize.Small);
                return Shell.ShellIcon.GetShellIcon(System.IO.Path.GetExtension((string)value), IconSize.Normal);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
