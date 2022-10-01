﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DykBits.Crm.RemoteServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice", ConfigurationName="RemoteServices.IBlobService")]
    public interface IBlobService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dykbits.net/2014/crm/documentservice/IBlobService/CreateMessageId", ReplyAction="http://www.dykbits.net/2014/crm/documentservice/IBlobService/CreateMessageIdRespo" +
            "nse")]
        string CreateMessageId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dykbits.net/2014/crm/documentservice/IBlobService/CreateMessageId", ReplyAction="http://www.dykbits.net/2014/crm/documentservice/IBlobService/CreateMessageIdRespo" +
            "nse")]
        System.Threading.Tasks.Task<string> CreateMessageIdAsync();
        
        // CODEGEN: Generating message contract since the operation UploadBlob is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dykbits.net/2014/crm/documentservice/IBlobService/UploadBlob", ReplyAction="http://www.dykbits.net/2014/crm/documentservice/IBlobService/UploadBlobResponse")]
        DykBits.Crm.RemoteServices.UploadBlobResponse UploadBlob(DykBits.Crm.RemoteServices.UploadBlobRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dykbits.net/2014/crm/documentservice/IBlobService/UploadBlob", ReplyAction="http://www.dykbits.net/2014/crm/documentservice/IBlobService/UploadBlobResponse")]
        System.Threading.Tasks.Task<DykBits.Crm.RemoteServices.UploadBlobResponse> UploadBlobAsync(DykBits.Crm.RemoteServices.UploadBlobRequest request);
        
        // CODEGEN: Generating message contract since the operation DownloadBlob is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dykbits.net/2014/crm/documentservice/IBlobService/DownloadBlob", ReplyAction="http://www.dykbits.net/2014/crm/documentservice/IBlobService/DownloadBlobResponse" +
            "")]
        DykBits.Crm.RemoteServices.DownloadBlobResponse DownloadBlob(DykBits.Crm.RemoteServices.DownloadBlobRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dykbits.net/2014/crm/documentservice/IBlobService/DownloadBlob", ReplyAction="http://www.dykbits.net/2014/crm/documentservice/IBlobService/DownloadBlobResponse" +
            "")]
        System.Threading.Tasks.Task<DykBits.Crm.RemoteServices.DownloadBlobResponse> DownloadBlobAsync(DykBits.Crm.RemoteServices.DownloadBlobRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadBlobRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice")]
        public string MessageId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice", Order=0)]
        public System.IO.Stream Data;
        
        public UploadBlobRequest() {
        }
        
        public UploadBlobRequest(string MessageId, System.IO.Stream Data) {
            this.MessageId = MessageId;
            this.Data = Data;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadBlobResponse {
        
        public UploadBlobResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DownloadBlobRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice")]
        public int Length;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice")]
        public string MessageId;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice")]
        public long StartPosition;
        
        public DownloadBlobRequest() {
        }
        
        public DownloadBlobRequest(int Length, string MessageId, long StartPosition) {
            this.Length = Length;
            this.MessageId = MessageId;
            this.StartPosition = StartPosition;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DownloadBlobResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice")]
        public long BlobLength;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice")]
        public string MessageId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.dykbits.net/2014/crm/documentservice", Order=0)]
        public System.IO.Stream Data;
        
        public DownloadBlobResponse() {
        }
        
        public DownloadBlobResponse(long BlobLength, string MessageId, System.IO.Stream Data) {
            this.BlobLength = BlobLength;
            this.MessageId = MessageId;
            this.Data = Data;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBlobServiceChannel : DykBits.Crm.RemoteServices.IBlobService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BlobServiceClient : System.ServiceModel.ClientBase<DykBits.Crm.RemoteServices.IBlobService>, DykBits.Crm.RemoteServices.IBlobService {
        
        public BlobServiceClient() {
        }
        
        public BlobServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BlobServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlobServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlobServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string CreateMessageId() {
            return base.Channel.CreateMessageId();
        }
        
        public System.Threading.Tasks.Task<string> CreateMessageIdAsync() {
            return base.Channel.CreateMessageIdAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DykBits.Crm.RemoteServices.UploadBlobResponse DykBits.Crm.RemoteServices.IBlobService.UploadBlob(DykBits.Crm.RemoteServices.UploadBlobRequest request) {
            return base.Channel.UploadBlob(request);
        }
        
        public void UploadBlob(string MessageId, System.IO.Stream Data) {
            DykBits.Crm.RemoteServices.UploadBlobRequest inValue = new DykBits.Crm.RemoteServices.UploadBlobRequest();
            inValue.MessageId = MessageId;
            inValue.Data = Data;
            DykBits.Crm.RemoteServices.UploadBlobResponse retVal = ((DykBits.Crm.RemoteServices.IBlobService)(this)).UploadBlob(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DykBits.Crm.RemoteServices.UploadBlobResponse> DykBits.Crm.RemoteServices.IBlobService.UploadBlobAsync(DykBits.Crm.RemoteServices.UploadBlobRequest request) {
            return base.Channel.UploadBlobAsync(request);
        }
        
        public System.Threading.Tasks.Task<DykBits.Crm.RemoteServices.UploadBlobResponse> UploadBlobAsync(string MessageId, System.IO.Stream Data) {
            DykBits.Crm.RemoteServices.UploadBlobRequest inValue = new DykBits.Crm.RemoteServices.UploadBlobRequest();
            inValue.MessageId = MessageId;
            inValue.Data = Data;
            return ((DykBits.Crm.RemoteServices.IBlobService)(this)).UploadBlobAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DykBits.Crm.RemoteServices.DownloadBlobResponse DykBits.Crm.RemoteServices.IBlobService.DownloadBlob(DykBits.Crm.RemoteServices.DownloadBlobRequest request) {
            return base.Channel.DownloadBlob(request);
        }
        
        public long DownloadBlob(int Length, ref string MessageId, long StartPosition, out System.IO.Stream Data) {
            DykBits.Crm.RemoteServices.DownloadBlobRequest inValue = new DykBits.Crm.RemoteServices.DownloadBlobRequest();
            inValue.Length = Length;
            inValue.MessageId = MessageId;
            inValue.StartPosition = StartPosition;
            DykBits.Crm.RemoteServices.DownloadBlobResponse retVal = ((DykBits.Crm.RemoteServices.IBlobService)(this)).DownloadBlob(inValue);
            MessageId = retVal.MessageId;
            Data = retVal.Data;
            return retVal.BlobLength;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DykBits.Crm.RemoteServices.DownloadBlobResponse> DykBits.Crm.RemoteServices.IBlobService.DownloadBlobAsync(DykBits.Crm.RemoteServices.DownloadBlobRequest request) {
            return base.Channel.DownloadBlobAsync(request);
        }
        
        public System.Threading.Tasks.Task<DykBits.Crm.RemoteServices.DownloadBlobResponse> DownloadBlobAsync(int Length, string MessageId, long StartPosition) {
            DykBits.Crm.RemoteServices.DownloadBlobRequest inValue = new DykBits.Crm.RemoteServices.DownloadBlobRequest();
            inValue.Length = Length;
            inValue.MessageId = MessageId;
            inValue.StartPosition = StartPosition;
            return ((DykBits.Crm.RemoteServices.IBlobService)(this)).DownloadBlobAsync(inValue);
        }
    }
}