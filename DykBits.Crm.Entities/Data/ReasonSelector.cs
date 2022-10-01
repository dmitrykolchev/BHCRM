using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ReasonSelector: NotifyObject, ISelectableDataItem
    {
        private bool _selected;
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public int ReasonTypeId { get; set; }
        [XmlAttribute]
        public bool Selected
        {
            get { return this._selected; }
            set
            {
                this._selected = value;
                InvokePropertyChanged("Selected");
            }
        }

    }
}
