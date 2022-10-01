using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace DykBits.Crm.Data
{
    partial class MasterMenu
    {

        [XmlIgnore]
        public int ServiceRequestType
        {
            get
            {
                if (ServiceRequestTypeMask.HasValue)
                    return ServiceRequestTypeMask.Value;
                return 0;
            }
            set
            {
                ServiceRequestTypeMask = value;
                InvokePropertyChanged();
            }
        }
    }
}
