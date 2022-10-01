using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DykBits.Crm.Data
{
    [Serializable]
    public class DataValidationException : ApplicationException
    {
        public DataValidationException()
            : base()
        {
        }

        public DataValidationException(string message)
            : base(message)
        {
        }

        public DataValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DataValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }
}
