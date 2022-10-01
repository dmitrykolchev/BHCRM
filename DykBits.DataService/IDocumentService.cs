using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using DykBits.Crm.Data;

namespace DykBits.DataService
{
    [ServiceContract(Namespace=ServiceParameters.ServiceNamespace)]
    public interface IDocumentService
    {
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        string Ping(string message);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        Stream Browse(string documentType, System.Xml.Linq.XElement filter);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        Stream GetList(string documentType, System.Xml.Linq.XElement filter);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        Stream GetDocument(ItemKey key);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        void DeleteDocument(ItemKey key);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        void ChangeDocumentState(ItemKey key, byte newState, System.Xml.Linq.XElement applicationData);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        Stream Save(Stream documentData);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        DocumentNumberInfo GetDocumentNumberInfo(string className, int organizationId, DateTime documentDate);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        Stream GetDocumentMetadata();
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        Stream GetCurrentEmployee();
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        Stream ExecuteQuery(Stream stream);
        [OperationContract]
        [FaultContract(typeof(DocumentServiceFault))]
        int ExecuteNonQuery(Stream stream);
    }
}
