using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class UserConverter: IValueConverter
    {
        private DocumentRecordCollection _users;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            int intValue = (int)value;
            if (this.Users.Contains(intValue))
            {
                IDataItem dataItem = this.Users[(int)value];
                return dataItem.FileAs;
            }
            return intValue.ToString();
        }

        private DocumentRecordCollection Users
        {
            get
            {
                if (this._users == null)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._users = listManager.GetList("User");
                }
                return this._users;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
