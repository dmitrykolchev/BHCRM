using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;
using System.Windows.Markup;

namespace DykBits.Crm
{
    public class DocumentIdConverter : IValueConverter
    {
        private ListManager _listManager;

        public DocumentIdConverter()
        {
            this._listManager = ServiceManager.GetService<ListManager>();
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || (value is int && (int)value == 0))
                return "(не указано)";
            string className = (string)parameter;
            if (!string.IsNullOrEmpty(className))
            {
                int index = className.IndexOf('.');
                if (index >= 0)
                {
                    string propertyName = className.Substring(index + 1);
                    className = className.Substring(0, index);
                    IDataItem item = GetRecord(className, (int)value);
                    if (item != null)
                    {
                        System.Reflection.PropertyInfo property = item.GetType().GetProperty(propertyName);
                        if (property != null)
                            return property.GetValue(item);
                    }
                }
                else
                {
                    IDataItem item = GetRecord(className, (int)value);
                    if (item != null)
                        return item.FileAs;
                }
            }
            return "#ошибка#";
        }

        private IDataItem GetRecord(string className, int id)
        {
            IDataItem item;
            if (this._listManager.TryGetItem(ItemKey.CreateKey(className, id), out item))
                return item;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
