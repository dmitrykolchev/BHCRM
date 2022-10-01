using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Markup;

namespace DykBits.Crm
{
    public class BudgetLevelValueConverter: MarkupExtension, IValueConverter
    {
        public BudgetLevelValueConverter()
        {
        }

        public int MaxValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                if (typeof(FontWeight).IsAssignableFrom(targetType))
                {
                    int level = (int)value;
                    if (level < MaxValue)
                        return FontWeights.Bold;
                    return FontWeights.Normal;
                }
                else if (typeof(Brush).IsAssignableFrom(targetType))
                {
                    int level = (int)value;
                    if (level < MaxValue)
                        return Brushes.WhiteSmoke;
                    return Brushes.Transparent;
                }
            }
            return null;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
