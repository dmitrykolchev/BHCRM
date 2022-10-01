using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DykBits.Crm.Data
{
    [DataContract(Namespace="http://schemas.dykbits.net/bhcrm")]
    public class ServiceRequestChangeStateData
    {
        [DataMember]
        public string Comments { get; set; }
    }
}
