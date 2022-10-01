using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public class RemoteDataAdapter<V, T, F> : RemoteViewDataAdapter<V, F>, IDataAdapter<V, T, F>, IDataAdapter
        where T : DataItem, new()
        where V : DataItemView, new()
        where F : Filter, new()
    {
        public RemoteDataAdapter()
        {
        }
        public T CreateItem(object dataContext)
        {
            return CreateItemOverride(dataContext);
        }
        protected virtual T CreateItemOverride(object dataContext)
        {
            return new T();
        }

        public T GetItem(ItemKey key)
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                using (Stream stream = client.GetDocument(key))
                {
                    return CreateDocumentFromStream(stream);
                }
            }
            finally
            {
                client.Close();
            }
        }
        private T CreateDocumentFromStream(Stream stream)
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                T item = new T();
                item.ReadXml(reader);
                item.InvokeDeseriaized();
                return item;
            }
        }

        private Stream DocumentToStream(T item)
        {
            MemoryStream stream = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                item.WriteXml(writer);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
        }

        public T Save(T item)
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                foreach (AttachmentItem attachment in item.Attachments)
                    attachment.CreateBlobEntry();
                using (Stream stream = DocumentToStream(item))
                {
                    using (Stream results = client.Save(stream))
                    {
                        return CreateDocumentFromStream(results);
                    }
                }
            }
            finally
            {
                client.Close();
            }
        }

        public void Delete(ItemKey key)
        {
            RemoteDataService client = new RemoteDataService();

            try
            {
                client.DeleteDocument(key);
            }
            finally
            {
                client.Close();
            }
        }

        public void ChangeState(ItemKey key, byte newState, XElement applicationData)
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                client.ChangeDocumentState(key, newState, applicationData);
            }
            finally
            {
                client.Close();
            }
        }

        #region IDataAdapter interface

        IDataItem IDataAdapter.CreateItem(object dataContext)
        {
            return CreateItem(dataContext);
        }

        IDataItem IDataAdapter.GetItem(ItemKey key)
        {
            return GetItem(key);
        }

        IDataItem IDataAdapter.Save(IDataItem item)
        {
            return this.Save((T)item);
        }

        #endregion

        public T FromXml(XmlReader reader)
        {
            T item = new T();
            item.ReadXml(reader);
            return item;
        }

        IDataItem IDataAdapter.FromXml(XmlReader reader)
        {
            return FromXml(reader);
        }

        public Type DocumentType
        {
            get { return typeof(T); }
        }

        public virtual bool ValidateAccess(ItemKey key)
        {
            return true;
        }
    }
}
