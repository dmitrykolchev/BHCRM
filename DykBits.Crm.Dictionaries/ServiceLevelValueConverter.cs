using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class ServiceLevelValueConverter: IValueConverter
    {
        private IList<ServiceLevelView> _list;

        private IList<ServiceLevelView> List
        {
            get
            {
                if (this._list == null)
                {
                    IDataAdapter da = DocumentManager.CreateDataAdapterProxy<ServiceLevel>();
                    this._list = (IList<ServiceLevelView>)da.Browse(Filter.EmptyXml);
                }

                return this._list;
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int flags = (int)value;
            int searchFlag = 1;

            List<string> result = new List<string>();
            for (int index = 0; index < 32; index++)
            {
                if ((flags & searchFlag) != 0)
                {
                    ServiceLevelView item = FindItem(List, index);
                    if (item != null)
                        result.Add(item.FileAs);
                }
                searchFlag <<= 1;
            }
            return string.Join(", ", result.OrderBy(t => t));
        }

        private static ServiceLevelView FindItem(IList<ServiceLevelView> items, int index)
        {
            foreach (var item in items)
            {
                if (item.Id - 1 == index)
                    return item;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Collections.IEnumerable enumerable = (System.Collections.IEnumerable)value;
            int intValue = 0;
            foreach (ServiceLevelView item in enumerable)
            {
                intValue |= 1 << (item.Id - 1);
            }
            return intValue;
        }
    }
}
