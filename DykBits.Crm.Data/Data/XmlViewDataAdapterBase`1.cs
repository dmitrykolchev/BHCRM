using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public abstract class XmlViewDataAdapterBase<V, F> : ViewDataAdapterCore<V, F> 
        where V : new()
        where F: Filter, new()
    {
        private string _commandName;
        protected XmlViewDataAdapterBase()
        {
        }
        protected XmlViewDataAdapterBase(string commandName)
        {
            this._commandName = commandName;
        }
        protected override IList<V> BrowseOverride(System.Xml.Linq.XElement filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(V), SqlProcedureType.Browse, connection))
                {
                    if (command.Parameters.Contains("@Filter"))
                    {
                        command.Parameters["@Filter"].Value = filter.ToString(SaveOptions.DisableFormatting);
                    }
                    using (XmlReader reader = command.ExecuteXmlReader())
                    {
                        List<V> list = new List<V>();
                        reader.MoveToContent();
                        if (reader.NodeType != XmlNodeType.None)
                        {
                            reader.ReadStartElement();
                            if (reader.NodeType != XmlNodeType.None)
                            {
                                while (reader.NodeType != XmlNodeType.EndElement)
                                {
                                    var item = new V();
                                    ((IXmlSerializable)item).ReadXml(reader);
                                    list.Add(item);
                                }
                                reader.ReadEndElement();
                            }
                            return list;
                        }
                        return new V[0];
                    }
                }
            }
        }
        public virtual string CommandName
        {
            get { return this._commandName; }
        }
        protected override SqlCommand CreateCommand(Type type, SqlProcedureType commandRole, SqlConnection connection)
        {
            if (commandRole == SqlProcedureType.Browse)
                return DataHelper.CreateProcedure(CommandName, connection);
            throw new InvalidOperationException();
        }
        protected override IList<V> GetListOverride(XElement filter)
        {
            return Browse(filter);
        }
    }
}
