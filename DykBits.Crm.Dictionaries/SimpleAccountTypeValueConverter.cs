using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class SimpleAccountTypeValueConverter : IValueConverter
    {
        private IList<AccountTypeView> _list;

        private IList<AccountTypeView> List
        {
            get
            {
                if (this._list == null)
                {
                    AccountTypeDataAdapterProxy da = new AccountTypeDataAdapterProxy();
                    this._list = da.Browse(Filter.EmptyXml);
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
                    AccountTypeView item = FindItem(List, index);
                    if (item != null)
                        result.Add(item.FileAs);
                }
                searchFlag <<= 1;
            }
            return string.Join(", ", result.OrderBy(t => t));
        }

        private static AccountTypeView FindItem(IList<AccountTypeView> items, int index)
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
            foreach (AccountTypeView item in enumerable)
            {
                intValue |= 1 << (item.Id - 1);
            }
            return intValue;
        }
    }
}
