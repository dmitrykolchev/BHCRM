using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    class CalculationStatementStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is byte)
            {
                CalculationStatementState state = (CalculationStatementState)(byte)value;
                switch (state)
                {
                    case CalculationStatementState.Approved:
                        return DykBits.Crm.UI.ApplicationImages.Accepted;
                    case CalculationStatementState.Draft:
                        return DykBits.Crm.UI.ApplicationImages.Draft;
                    case CalculationStatementState.Submitted:
                        return DykBits.Crm.UI.ApplicationImages.Submitted;
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
