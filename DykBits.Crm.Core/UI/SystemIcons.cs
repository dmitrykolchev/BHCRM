using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace DykBits.Crm.UI
{
    public class SystemIcons
    {
        private static BitmapSource _error;
        private static BitmapSource _information;
        private static BitmapSource _question;
        public static BitmapSource Error
        {
            get
            {
                if (_error == null)
                {
                    _error = GetIcon(System.Drawing.SystemIcons.Error);
                }
                return _error;
            }
        }
        public static BitmapSource Information
        {
            get
            {
                if (_information == null)
                {
                    _information = GetIcon(System.Drawing.SystemIcons.Information);
                }
                return _information;
            }
        }

        public static BitmapSource Question
        {
            get
            {
                if (_question == null)
                {
                    _question = GetIcon(System.Drawing.SystemIcons.Question);
                }
                return _question;
            }
        }


        private static BitmapSource GetIcon(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
