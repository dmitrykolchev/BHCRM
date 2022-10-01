using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DykBits.Crm.UI
{
    class ImageHelper
    {
        public static BitmapImage CreateImage(byte[] data)
        {
            if (data != null && data.Length != 0)
            {
                BitmapImage image = new BitmapImage();
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream(data, false))
                {
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = stream;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
            return null;
        }
    }
}
