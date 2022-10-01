using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DykBits.Crm
{
    [Serializable]
    public class CrmAccessDeniedException: CrmApplicationException
    {
        private const string HaveNoRightsMessage = "Недостаточно прав для выполнения этой операции. Обратитесь к администратору.";
        public CrmAccessDeniedException()
            : base(HaveNoRightsMessage)
        {
        }

        public CrmAccessDeniedException(string message): base(message)
        {
        }

        public CrmAccessDeniedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CrmAccessDeniedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
