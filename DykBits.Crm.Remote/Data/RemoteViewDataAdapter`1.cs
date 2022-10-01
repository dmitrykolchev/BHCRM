using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public class RemoteViewDataAdapter<V, F> : IViewDataAdapter<V, F>, IViewDataAdapter
        where V : new()
        where F : Filter, new()
    {
        public RemoteViewDataAdapter()
        {
        }

        private Type ViewType
        {
            get { return typeof(V); }
        }
        public IList<V> Browse(System.Xml.Linq.XElement filter)
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                using (Stream stream = client.Browse(ViewType.Name, filter))
                {
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        List<V> list = new List<V>();
                        reader.MoveToContent();
                        reader.ReadStartElement();
                        if (reader.NodeType != XmlNodeType.None)
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                V item = new V();
                                ((IXmlSerializable)item).ReadXml(reader);
                                list.Add(item);
                            }
                            reader.ReadEndElement();
                        }
                        return list;
                    }
                }
            }
            finally
            {
                client.Close();
            }
        }
        public IList<V> GetList(System.Xml.Linq.XElement filter)
        {
            RemoteDataService client = new RemoteDataService();
            try
            {
                using (Stream stream = client.GetList(ViewType.Name, filter))
                {
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        List<V> list = new List<V>();
                        reader.MoveToContent();
                        reader.ReadStartElement();
                        if (reader.NodeType != XmlNodeType.None)
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                V item = new V();
                                ((IXmlSerializable)item).ReadXml(reader);
                                list.Add(item);
                            }
                            reader.ReadEndElement();
                        }
                        return list;
                    }
                }
            }
            finally
            {
                client.Close();
            }
        }
        public F CreateFilter(object dataContext, object parameter)
        {
            return CreateFilterOverride(dataContext, parameter);
        }
        Filter IViewDataAdapter.CreateFilter(object dataContext, object parameter)
        {
            return CreateFilterOverride(dataContext, parameter);
        }

        protected virtual F CreateFilterOverride(object dataContext, object parameter)
        {
            return new F();
        }
        IList IViewDataAdapter.Browse(XElement filter)
        {
            return (IList)Browse(filter);
        }
        IList IViewDataAdapter.GetList(XElement filter)
        {
            return (IList)GetList(filter);
        }
        public Type ViewItemType
        {
            get { return typeof(V); }
        }
        public Type FilterType
        {
            get { return typeof(F); }
        }
    }
}
