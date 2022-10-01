using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;
using DykBits.Crm.UI;

namespace DykBits.Crm
{
    public class AccountEventDirectionConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int nValue = (int)value;
            switch (nValue)
            {
                case 1:
                    return ApplicationImages.OutgoingDirection;
                case 2:
                    return ApplicationImages.IncomingDirection;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
