using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using DykBits.Xml.Serialization;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public abstract class XmlDataAdapterBase<V, T, F> : DataAdapterCore<V, T, F>
        where T : DataItem, new()
        where V : DataItemView, new()
        where F : Filter, new()
    {
        protected XmlDataAdapterBase()
        {
        }
        private string ToXml(T item)
        {
            StringBuilder builder = new StringBuilder();
            StringWriter writer = new StringWriter(builder);
            XmlWriterSettings settings = new XmlWriterSettings { NamespaceHandling = NamespaceHandling.Default, OmitXmlDeclaration = true, Encoding = Encoding.UTF8, Indent = false };
            using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
            {
                item.WriteXml(xmlWriter);
            }
            return builder.ToString();
        }
        private T FromXmlInternal(XmlReader reader)
        {
            T item = new T();
            item.ReadXml(reader);
            item.InvokeDeseriaized();
            return item;
        }
        protected T ExecuteItem(SqlCommand command)
        {
            using (XmlReader reader = command.ExecuteXmlReader())
            {
                if (!reader.Read())
                    throw new InvalidOperationException("указанный элемент не найден");
                return FromXmlInternal(reader);
            }
        }
        protected override T GetItemOverride(ItemKey key)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.Get, connection))
                {
                    command.Parameters["@Id"].Value = key.Id;
                    return ExecuteItem(command);
                }
            }
        }
        protected override T InsertItem(T item)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.Create, connection))
                {
                    command.Parameters["@xml"].Value = ToXml(item);
                    return ExecuteItem(command);
                }
            }
        }
        protected override T UpdateItem(T item)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.Update, connection))
                {
                    command.Parameters["@xml"].Value = ToXml(item);
                    return ExecuteItem(command);
                }
            }
        }
        protected abstract void BindBrowseResultToItem(V item, SqlDataReader reader);
        protected abstract void BindListResultToItem(V item, SqlDataReader reader);
        protected override IList<V> BrowseOverride(XElement filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.Browse, connection))
                {
                    if (command.Parameters.Contains("@Filter"))
                    {
                        command.Parameters["@Filter"].Value = filter.ToString(SaveOptions.DisableFormatting);
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<V> items = new List<V>();
                        while (reader.Read())
                        {
                            V item = new V();
                            BindBrowseResultToItem(item, reader);
                            items.Add(item);
                        }
                        return items;
                    }
                }
            }
        }
        protected override IList<V> GetListOverride(XElement filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.List, connection))
                {
                    if (command.Parameters.Contains("@Filter"))
                    {
                        command.Parameters["@Filter"].Value = filter.ToString(SaveOptions.DisableFormatting);
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<V> items = new List<V>();
                        while (reader.Read())
                        {
                            V item = new V();
                            BindListResultToItem(item, reader);
                            items.Add(item);
                        }
                        return items;
                    }
                }
            }
        }
    }
}

