using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DykBits.DataService
{

    [DataContract]
    public class DocumentServiceFault
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public byte[] ExceptionData
        {
            get;
            set;
        }
    }
}
