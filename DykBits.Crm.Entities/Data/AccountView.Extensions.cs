using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class AccountView: ISelectableDataItem
    {
        private IList<AccountEventView> _events;

        [XmlIgnore]
        public IList<AccountEventView> Events
        {
            get
            {
                if (this._events == null)
                {
                    IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<AccountEvent>();
                    Filter filter = dataAdapter.CreateFilter(this, null);
                    filter.Presentation = "AllAccountEvents";
                    filter.InitializeDefaults(this, null);
                    this._events = (IList<AccountEventView>) dataAdapter.Browse(filter.ToXml());
                }
                return this._events;
            }
        }
        [XmlIgnore]
        public bool Selected { get; set; }
    }
}
