using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace DykBits.DataService
{
    [MessageContract(IsWrapped = false)]
    public sealed class UploadBlobRequest: IDisposable
    {
        [MessageHeader(Namespace = ServiceParameters.ServiceNamespace)]
        public string MessageId { get; set; }

        [MessageBodyMember(Namespace = ServiceParameters.ServiceNamespace)]
        public Stream Data { get; set; }

        public void Dispose()
        {
            if (Data != null)
            {
                Data.Dispose();
            }
        }
    }

    [MessageContract(IsWrapped = false)]
    public sealed class DownloadBlobRequest
    {
        [MessageHeader(Namespace = ServiceParameters.ServiceNamespace)]
        public string MessageId { get; set; }
        [MessageHeader(Namespace = ServiceParameters.ServiceNamespace)]
        public long StartPosition { get; set; }
        [MessageHeader(Namespace = ServiceParameters.ServiceNamespace)]
        public int Length { get; set; }
    }

    [MessageContract(IsWrapped = false)]
    public sealed class DownloadBlobResponse: IDisposable
    {
        [MessageHeader(Namespace=ServiceParameters.ServiceNamespace)]
        public string MessageId { get; set; }
        [MessageHeader(Namespace = ServiceParameters.ServiceNamespace)]
        public long BlobLength { get; set; }
        [MessageBodyMember(Namespace=ServiceParameters.ServiceNamespace)]
        public Stream Data { get; set; }

        public void Dispose()
        {
            if (Data != null)
            {
                Data.Dispose();
            }
        }
    }


    [ServiceContract(Namespace=ServiceParameters.ServiceNamespace)]
    public interface IBlobService
    {
        [OperationContract]
        string CreateMessageId();
        [OperationContract]
        void UploadBlob(UploadBlobRequest message);
        [OperationContract]
        DownloadBlobResponse DownloadBlob(DownloadBlobRequest message);
    }
}
