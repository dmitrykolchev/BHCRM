using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;
using System.Windows;
using System.Windows.Media;

namespace DykBits.Crm.UI.CashFlow
{
    public class MoneyOperationTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            MoneyOperationReportByOperationTypeItem item = value as MoneyOperationReportByOperationTypeItem;
            if (item != null)
            {
                if ("FontWeight".Equals(parameter))
                {
                    if (item.ViewGroup == 2)
                        return FontWeights.Normal;
                    return FontWeights.Bold;
                }
                else
                {
                    if (item.ViewGroup == 2)
                    {
                        if (item.MoneyOperationTypeId.HasValue)
                            return ListManager.GetItem<MoneyOperationTypeView>(item.MoneyOperationTypeId.Value).FileAs;
                        return null;
                    }
                    else if (item.ViewGroup == 1)
                        return "Начальное сальдо";
                    else if (item.ViewGroup == 3)
                        return "Конечное сальдо";
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
