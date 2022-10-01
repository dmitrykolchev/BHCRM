using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using System.Diagnostics;
using DykBits.Crm.UI;

namespace DykBits.Crm.Data
{
    [XmlType(AnonymousType = true)]
    public sealed class DocumentMetadata: ViewMetadataBase
    {
        private ImageSource _smallImage;
        private ImageSource _largeImage;
        private DocumentStateCollection _states;
        private DocumentTransitionTemplateCollection _transitions;
        private ViewMetadataCollection _views;

        public DocumentMetadata()
        {
            this._states = new DocumentStateCollection(this);
            this._transitions = new DocumentTransitionTemplateCollection(this);
            this._views = new ViewMetadataCollection(this);
        }
        internal IDataAdapter CreateDataAdapterProxy()
        {
            return (IDataAdapter)Activator.CreateInstance(DataAdapterProxyType);
        }
        internal IDataAdapter CreateDataAdapter()
        {
            return (IDataAdapter)Activator.CreateInstance(LocalDataAdapterType);
        }
        [XmlElement("State")]
        public DocumentStateCollection States
        {
            get { return this._states; }
        }
        [XmlElement("Transition")]
        public DocumentTransitionTemplateCollection Transitions
        {
            get
            {
                return this._transitions;
            }
        }
        [XmlIgnore]
        public bool CanCreate
        {
            get
            {
                if (this.SupportsTransitionTemplates)
                    return this.Transitions.Where(t => t.HasAccessRight && t.FromStateValue == DocumentState.NotExist && t.ToStateValue != DocumentState.NotExist).Count() > 0;
                return this.IsAllowed(GenericRight.EditOwn);
            }
        }
        [XmlElement("View")]
        public ViewMetadataCollection Views
        {
            get { return this._views; }
        }
        internal ViewMetadata CreateViewMetadata()
        {
            return new ViewMetadata(this.ViewItemType, this.LocalDataAdapterType, this.DataAdapterProxyType)
            {
                Id = Id,
                ViewName = ViewName,
                ClassName = ClassName,
                Document = this
            };
        }
        [XmlAttribute("IsNumbered")]
        public bool IsNumbered { get; set; }
        [XmlAttribute("SupportsTransitionTemplates")]
        public bool SupportsTransitionTemplates { get; set; }
        [XmlAttribute("SmallImage")]
        public byte[] SmallImageData { get; set; }
        [XmlAttribute("LargeImage")]
        public byte[] LargeImageData { get; set; }
        [XmlIgnore]
        public ImageSource SmallImage
        {
            get
            {
                if (this._smallImage == null && this.SmallImageData != null)
                {
                    this._smallImage = ImageHelper.CreateImage(this.SmallImageData);
                }
                return this._smallImage;
            }
        }
        [XmlIgnore]
        public ImageSource LargeImage
        {
            get
            {
                if (this._largeImage == null && this.LargeImageData != null)
                {
                    this._largeImage = ImageHelper.CreateImage(this.LargeImageData);
                }
                return this._largeImage;
            }
        }
        private IList<IDocumentReportInfo> _reports;
        public IList<IDocumentReportInfo> Reports
        {
            get
            {
                if (this._reports == null)
                {
                    DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                    IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy("DocumentReport");
                    Filter filter = dataAdapter.CreateFilter(this, null);
                    this._reports = dataAdapter.Browse(filter.ToXml()).OfType<IDocumentReportInfo>().OrderBy(t => t.FileAs).ToList();
                }
                return this._reports;
            }
        }

        private Type _documentType;
        internal Type DocumentType
        {
            get
            {
                if (this._documentType == null)
                    EnsureTypesDefined();
                return this._documentType;
            }
            private set
            {
                this._documentType = value;
            }
        }


        protected override void EnsureTypesDefined()
        {
            Type dataAdapterType = DataAdapterProxyType;
            if (dataAdapterType == null)
                dataAdapterType = LocalDataAdapterType;
            var dataAdapter = (IDataAdapter)Activator.CreateInstance(dataAdapterType);
            this.ViewItemType = dataAdapter.ViewItemType;
            this.DocumentType = dataAdapter.DocumentType;
        }
    }
}
