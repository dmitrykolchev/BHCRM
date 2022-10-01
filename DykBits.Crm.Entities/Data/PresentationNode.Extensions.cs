using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{

    [TypeMapping(typeof(PresentationNodeApplicationRole))]
    partial class PresentationNode
    {
        private PresentationNodeApplicationRoleCollection _roles;
        public PresentationNodeApplicationRoleCollection Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new PresentationNodeApplicationRoleCollection();
                    this._roles.CollectionChanged += _roles_CollectionChanged;
                }
                return this._roles;
            }
        }
        void _roles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Roles");
        }

        private BitmapSource _smallImage;
        private BitmapSource _largeImage;
        [XmlIgnore]
        public BitmapSource SmallImage
        {
            get
            {
                if (this.SmallImageData == null || this.SmallImageData.Length == 0)
                    return null;
                if (this._smallImage == null)
                {
                    this._smallImage = CreateImage(SmallImageData);
                }
                return this._smallImage;
            }
            set
            {
                if (value != null)
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(value));
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        encoder.Save(stream);
                        SmallImageData = stream.ToArray();
                    }
                }
                else
                {
                    SmallImageData = null;
                }
                this._smallImage = value;
            }
        }
        public bool IsViewsVisible
        {
            get { return this.NodeType == PresentationNodeType.PresentationSet; }
        }
        [XmlIgnore]
        public BitmapSource LargeImage
        {
            get
            {
                if (this.LargeImageData == null || this.LargeImageData.Length == 0)
                    return null;
                if (this._largeImage == null)
                {
                    this._largeImage = CreateImage(LargeImageData);
                }
                return this._largeImage;
            }
            set
            {
                if (value != null)
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(value));
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        encoder.Save(stream);
                        LargeImageData = stream.ToArray();
                    }
                }
                else
                {
                    LargeImageData = null;
                }
                this._largeImage = value;
            }
        }
        internal static BitmapImage CreateImage(byte[] data)
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
        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (propertyName == LargeImageDataProperty)
            {
                this._largeImage = null;
                InvokePropertyChanged("LargeImage");
            }
            else if (propertyName == SmallImageDataProperty)
            {
                this._smallImage = null;
                InvokePropertyChanged("SmallImage");
            }
        }

        ObservableCollectionWithRefresh<PresentationNodeView> _views;
        IList<PresentationNodeView> GetViews()
        {
            PresentationNodeFilter filter = new PresentationNodeFilter();
            filter.InitializeDefaults(this, null);
            filter.NodeTypes = new int[] { PresentationNodeType.Folder, PresentationNodeType.Presentation };
            return DocumentManager.Browse<PresentationNodeView>(filter);
        }
        [XmlIgnore]
        public ObservableCollectionWithRefresh<PresentationNodeView> Views
        {
            get
            {
                if (this._views == null)
                {
                    this._views = new ObservableCollectionWithRefresh<PresentationNodeView>(GetViews);
                }
                return this._views;
            }
        }
    }
}
