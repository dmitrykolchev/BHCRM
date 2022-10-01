using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace DykBits.Crm.Data
{
    partial class DocumentStateEntryView
    {
        private BitmapSource _overlayImageSource;
        public BitmapSource OverlayImageSource
        {
            get
            {
                if (this._overlayImageSource == null && this.OverlayImage != null)
                {
                    this._overlayImageSource = StaticMethods.ConvertBinaryToBitmap(this.OverlayImage);
                    this._overlayImageSource.Freeze();
                }
                return this._overlayImageSource;
            }
        }
    }
}
