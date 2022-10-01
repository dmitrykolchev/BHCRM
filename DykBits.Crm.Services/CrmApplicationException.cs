using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DykBits.Crm
{
    [Serializable]
    public class CrmApplicationException: ApplicationException
    {
        public const string EmployeeNotFoundMessage = "EmployeeNotFound";
        public CrmApplicationException()
            : base()
        {
        }

        public CrmApplicationException(string message): base(message)
        {
        }

        public CrmApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CrmApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static CrmApplicationException EmployeeNotFound()
        {
            return new CrmApplicationException(EmployeeNotFoundMessage);
        }
    }
}
