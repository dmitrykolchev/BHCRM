using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using DykBits.Xml.Serialization;
using System.Windows;

namespace DykBits.Crm.Data
{
    public class DocumentManager
    {
        private DocumentMetadataCollection _documents;
        private Dictionary<DocumentMetadata, IDataAdapter> _dataAdapterCache = new Dictionary<DocumentMetadata, IDataAdapter>();
        private DocumentManager()
        {
        }
        public static DocumentManager Create()
        {
            DocumentManager documentManager = new DocumentManager();
            documentManager.Initialize();
            return documentManager;
        }
        public DocumentMetadataCollection Documents
        {
            get { return this._documents; }
        }
        #region Metadata methods

        public static DocumentMetadata GetMetadata<T>()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            return documentManager.Documents[typeof(T)];
        }
        public static DocumentMetadata GetMetadata(Type documentType)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            return documentManager.Documents[documentType];
        }
        public static DocumentMetadata GetMetadata(int documentTypeId)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            return documentManager.Documents.GetById(documentTypeId);
        }

        public static DocumentMetadata GetMetadata(string className)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            return documentManager.Documents[className];
        }

        #endregion

        #region DataAdapterProxy creation methods
        private IDataAdapter CreateDataAdapterProxy(DocumentMetadata metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            return metadata.CreateDataAdapterProxy();
        }
        public IDataAdapter CreateDataAdapterProxy(string className)
        {
            DocumentMetadata metadata = this.Documents[className];
            return CreateDataAdapterProxy(metadata);
        }
        public static IDataAdapter CreateDataAdapterProxy<T>()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            DocumentMetadata metadata = documentManager.Documents[typeof(T)];
            return documentManager.CreateDataAdapterProxy(metadata);
        }
        #endregion

        #region DataAdapter creation
        public IDataAdapter CreateDataAdapter(string className)
        {
            DocumentMetadata metadata = this.Documents[className];
            return CreateDataAdapter(metadata);
        }
        public static IDataAdapter CreateDataAdapter(DocumentMetadata metadata)
        {
            return metadata.CreateDataAdapter();
        }
        #endregion

        #region Data manipulation methods
        public static IList<V> Browse<V>(Filter filter)
            where V : IDataItem, new()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            V v = new V();
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(v.DataItemClass);
            return (IList<V>)dataAdapter.Browse(filter.ToXml());
        }
        public static T CreateItem<T>(object dataContext) where T : IDataItem, new()
        {
            IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<T>();
            return (T)dataAdapter.CreateItem(dataContext);
        }
        public IDataItem CreateDocument(DocumentMetadata metadata, object dataContext)
        {
            IDataAdapter dataAdapter = CreateDataAdapterProxy(metadata);
            return dataAdapter.CreateItem(dataContext);
        }
        public static T GetItem<T>(int id) where T : IDataItem, new()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            ItemKey key = ItemKey.CreateKey(typeof(T), id);
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(key.DocumentType);
            return (T)dataAdapter.GetItem(key);
        }
        public static IDataItem GetItem(ItemKey key)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(key.DocumentType);
            return dataAdapter.GetItem(key);
        }
        public static T SaveItem<T>(T item) where T : IDataItem
        {
            IDataAdapter dataAdapter = DocumentManager.CreateDataAdapterProxy<T>();
            T result = (T)dataAdapter.Save(item);
            InvokeDocumentOperationComplete(DocumentOperation.Save, result);
            return result;
        }
        public static IDataItem SaveItem(IDataItem item)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            DocumentMetadata metadata = documentManager.Documents.GetById(item.DataItemClassId);
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(metadata);
            IDataItem result = dataAdapter.Save(item);
            InvokeDocumentOperationComplete(DocumentOperation.Save, result);
            return result;
        }
        public static void DeleteItem<T>(int id)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            ItemKey key = ItemKey.CreateKey(typeof(T), id);
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(key.DocumentType);
            dataAdapter.Delete(key);
            documentManager.InvokeDocumentOperationCompleteInternal(DocumentOperation.Delete, key);
        }
        public static void DeleteItem(IDataItem item)
        {
            if (item == null)
                throw new ArgumentNullException("dataItem");
            if (!item.IsNew)
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                DocumentMetadata metadata = documentManager.Documents.GetById(item.DataItemClassId);
                IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(metadata);
                dataAdapter.Delete(item.GetKey());
                documentManager.InvokeDocumentOperationCompleteInternal(DocumentOperation.Delete, item);
            }
        }
        public static void ChangeDocumentState(IDataItem dataItem, DocumentState newState, object applicationData)
        {
            ChangeDocumentState(dataItem, newState.State, applicationData);
        }
        public static void ChangeDocumentState(IDataItem dataItem, byte newState, object applicationData)
        {
            if (dataItem == null)
                throw new ArgumentNullException("dataItem");
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(dataItem.DataItemClass);
            if (dataItem.IsNew)
                throw new InvalidOperationException();

            ItemKey itemKey = dataItem.GetKey();
            if (applicationData != null)
            {
                XDocument document = new XDocument();
                using (XmlWriter writer = document.CreateWriter())
                {
                    DataContractSerializer serializer = new DataContractSerializer(applicationData.GetType());
                    serializer.WriteObject(writer, applicationData);
                }
                dataAdapter.ChangeState(itemKey, newState, document.Root);
            }
            else
            {
                dataAdapter.ChangeState(itemKey, newState, null);
            }
            documentManager.InvokeDocumentOperationCompleteInternal(DocumentOperation.ChangeState, dataItem);
        }
        public static List<TResult> ExecuteObjectQuery<TParam, TResult>(TParam param) where TResult : new()
        {
            IDatabaseContext db = ServiceManager.GetService<IDatabaseContext>();
            using (Stream stream = DocumentSerializer.Serialize(param))
            {
                using (Stream result = db.ExecuteQuery(stream))
                {
                    return DocumentSerializer.DeserializeCollection<TResult>(result);
                }
            }
        }
        public static int ExecuteNonQuery<TParam>(TParam param)
        {
            IDatabaseContext db = ServiceManager.GetService<IDatabaseContext>();
            using (Stream stream = DocumentSerializer.Serialize(param))
            {
                return db.ExecuteNonQuery(stream);
            }
        }
        #endregion

        #region DocumentOperationComplete event handling

        private EventHandler<DocumentOperationCompleteEventArgs> _documentOperationComplete;

        public event EventHandler<DocumentOperationCompleteEventArgs> DocumentOperationComplete
        {
            add
            {
                _documentOperationComplete += value;  
            }
            remove
            {
                _documentOperationComplete -= value;
            }
        }
        public static void AddEventListener(EventHandler<DocumentOperationCompleteEventArgs> handler)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            WeakEventManager<DocumentManager, DocumentOperationCompleteEventArgs>.AddHandler(documentManager, "DocumentOperationComplete", handler);
            //documentManager.DocumentOperationComplete += handler;
        }
        public static void RemoveEventListener(EventHandler<DocumentOperationCompleteEventArgs> handler)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            WeakEventManager<DocumentManager, DocumentOperationCompleteEventArgs>.RemoveHandler(documentManager, "DocumentOperationComplete", handler);
            //documentManager.DocumentOperationComplete -= handler;
        }
        public static void InvokeDocumentOperationComplete(DocumentOperation operation, IDataItem data)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            documentManager.InvokeDocumentOperationCompleteInternal(operation, data);
        }
        public static void InvokeDocumentOperationComplete(DocumentOperation operation, ItemKey key)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            documentManager.InvokeDocumentOperationCompleteInternal(operation, key);
        }
        private void InvokeDocumentOperationCompleteInternal(DocumentOperation operation, ItemKey key)
        {
            DocumentOperationCompleteEventArgs e = new DocumentOperationCompleteEventArgs(operation, key);
            InvokeDocumentOperationCompleteInternal(e);
        }
        private void InvokeDocumentOperationCompleteInternal(DocumentOperation operation, IDataItem data)
        {
            DocumentOperationCompleteEventArgs e = new DocumentOperationCompleteEventArgs(operation, data);
            InvokeDocumentOperationCompleteInternal(e);
        }
        private void InvokeDocumentOperationCompleteInternal(DocumentOperationCompleteEventArgs e)
        {
            if (this._documentOperationComplete != null)
                this._documentOperationComplete(this, e);
        }
        #endregion

        private void Initialize()
        {
            IDatabaseContext db = ServiceManager.GetService<IDatabaseContext>();
            using (Stream stream = db.GetDocumentMetadata())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DocumentMetadataList));
                DocumentMetadataList list = (DocumentMetadataList)serializer.Deserialize(stream);
                this._documents = list.Items;
                ViewDataManager viewManager = new ViewDataManager();
                foreach (var item in list.Items)
                {
                    viewManager.Views.Add(item.CreateViewMetadata());

                    foreach (var view in item.Views)
                    {
                        viewManager.Views.Add(view);
                    }
                }
                ServiceManager.Instance.AddService(typeof(ViewDataManager), viewManager);
            }
        }
    }
}
