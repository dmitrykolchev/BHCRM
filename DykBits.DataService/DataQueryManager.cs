using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DykBits.Crm.Data;

namespace DykBits.DataService
{
    class DataQueryManager: IDataQueryManager
    {
        private Dictionary<string, List<DataQueryView>> _queries = new Dictionary<string,List<DataQueryView>>();
        private DataQueryManager()
        {
        }

        public static DataQueryManager Create()
        {
            DataQueryManager instance = new DataQueryManager();
            instance.Initialize();
            return instance;
        }

        private void Initialize()
        {
            RefreshQueries();
        }

        private void RefreshQueries()
        {
            this._queries.Clear();
            LocalDatabaseContext db = new LocalDatabaseContext();
            var dataQueries = db.GetDataQueries();
            foreach (var dataQuery in dataQueries)
            {
                List<DataQueryView> list;
                if (!this._queries.TryGetValue(dataQuery.DocumentElement, out list))
                {
                    list = new List<DataQueryView>();
                    this._queries.Add(dataQuery.DocumentElement, list);
                }
                list.Add(dataQuery);
            }
        }

        public IDataQuery Find(XmlDocument document)
        {
            IDataQuery query = FindQuery(document);
            if (query == null)
                RefreshQueries();
            return FindQuery(document);
        }

        private IDataQuery FindQuery(XmlDocument document)
        {
            List<DataQueryView> list;

            if (this._queries.TryGetValue(document.DocumentElement.LocalName, out list))
            {
                if (list.Count > 1)
                {
                    foreach (var dataQuery in list)
                    {
                        if (CheckSelector(dataQuery, document))
                            return dataQuery;
                    }
                }
                return list[0];
            }
            return null;
        }

        private static bool CheckSelector(DataQueryView dataQuery, XmlDocument document)
        {
            XmlNode node = document.SelectSingleNode(dataQuery.Selector);
            if (node == null)
                return false;
            if (dataQuery.Value == null)
                return true;
            if (node.NodeType == XmlNodeType.Element)
                return node.FirstChild.Value == dataQuery.Value;
            else if (node.NodeType == XmlNodeType.Attribute)
                return node.Value == dataQuery.Value;
            return false;
        }

    }
}
