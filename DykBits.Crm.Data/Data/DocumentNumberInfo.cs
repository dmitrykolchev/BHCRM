using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DykBits.Crm.Data
{
    [DataContract]
    public class DocumentNumberInfo
    {
        [DataMember]
        public int Number { get; set; }

        [DataMember]
        public string FormattedNumber { get; set; }

        [DataMember]
        public string FileAs { get; set; }
    }
}
