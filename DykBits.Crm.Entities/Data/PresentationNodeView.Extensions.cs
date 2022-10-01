using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Media.Imaging;

namespace DykBits.Crm.Data
{
    partial class PresentationNodeView
    {
        private BitmapImage _smallImage;
        private BitmapImage _largeImage;
        [XmlIgnore]
        public BitmapImage SmallImage
        {
            get
            {
                if (this.SmallImageData == null || this.SmallImageData.Length == 0)
                    return null;
                if (this._smallImage == null)
                {
                    this._smallImage = PresentationNode.CreateImage(SmallImageData);
                }
                return this._smallImage;
            }
        }
        [XmlIgnore]
        public BitmapImage LargeImage
        {
            get
            {
                if (this.LargeImageData == null || this.LargeImageData.Length == 0)
                    return null;
                if (this._largeImage == null)
                {
                    this._largeImage = PresentationNode.CreateImage(LargeImageData);
                }
                return this._largeImage;
            }
        }
    }
}
