using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DykBits.Crm.Data
{
    [XmlType("ViewMetadata")]
    public sealed class ViewMetadata : ViewMetadataBase
    {
        private DocumentMetadata _documentMetadata;

        internal ViewMetadata(Type itemType, Type dataAdapterType, Type dataAdapterProxyType)
            : base(itemType, dataAdapterType, dataAdapterProxyType)
        {
        }
        public ViewMetadata()
        {
        }
        internal IViewDataAdapter CreateDataAdapterProxy()
        {
            return (IViewDataAdapter)Activator.CreateInstance(DataAdapterProxyType);
        }
        internal IViewDataAdapter CreateDataAdapter()
        {
            return (IViewDataAdapter)Activator.CreateInstance(LocalDataAdapterType);
        }
        [XmlIgnore]
        public DocumentMetadata Document
        {
            get
            {
                return this._documentMetadata;
            }
            internal set
            {
                this._documentMetadata = value;
            }
        }
    }
}
