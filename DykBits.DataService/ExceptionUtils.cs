using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization.Formatters.Binary;

namespace DykBits.DataService
{
    static class ExceptionUtils
    {
        public static byte[] GetExceptionData(Exception ex)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, ex);
            stream.Position = 0;
            return stream.ToArray();
        }

        public static FaultException<DocumentServiceFault> CreateFault(Exception ex)
        {
            return new FaultException<DocumentServiceFault>(new DocumentServiceFault { ExceptionData = GetExceptionData(ex), Message = ex.Message }, new FaultReason(ex.Message));
        }

        public static FaultException<DocumentServiceFault> CreateFault(string reason)
        {
            return new FaultException<DocumentServiceFault>(new DocumentServiceFault { Message = reason }, new FaultReason(reason));
        }
    }
}
