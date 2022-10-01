using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace DykBits.Crm.Data
{
    class StaticMethods
    {
        public static BitmapSource ConvertBinaryToBitmap(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException();

            BitmapImage imageSource = new BitmapImage();
            MemoryStream stream = new MemoryStream(buffer);
            imageSource.BeginInit();
            imageSource.StreamSource = stream;
            imageSource.EndInit();
            return imageSource;
        }
    }
}
