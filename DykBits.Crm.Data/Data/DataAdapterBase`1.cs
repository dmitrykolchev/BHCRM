using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public abstract class DataAdapterBase<V, T, F> : DataAdapterCore<V, T, F>
        where T : DataItem, new()
        where V : DataItemView, new()
        where F : Filter, new()
    {
        protected DataAdapterBase()
        {
        }

        protected override T GetItemOverride(ItemKey key)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.Get, connection))
                {
                    command.Parameters["@Id"].Value = key.Id;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new ArgumentException("cannot find specified item", "key");
                        T item = new T();
                        BindGetItemResultToItemInternal(item, reader);
                        return item;
                    }
                }
            }
        }

        private void BindGetItemResultToItemInternal(T item, SqlDataReader reader)
        {
            BindGetItemResultToItem(item, reader);
            item.InvokeDeseriaized();
        }
        protected abstract void BindGetItemResultToItem(T item, SqlDataReader reader);
        protected abstract void BindBrowseResultToItem(V item, SqlDataReader reader);
        protected abstract void BindListResultToItem(V item, SqlDataReader reader);
        protected abstract void BindCreateCommand(SqlCommand command, T item);
        protected abstract void BindUpdateCommand(SqlCommand command, T item);
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

        private object ToXml(F filter)
        {
            if (filter != null)
                return filter.ToXml();
            return DBNull.Value;
        }

        protected override T InsertItem(T item)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.Create, connection))
                {
                    BindCreateCommand(command, item);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException();
                        T result = new T();
                        BindGetItemResultToItemInternal(result, reader);
                        return result;
                    }
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
                    BindUpdateCommand(command, item);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException();
                        T result = new T();
                        BindGetItemResultToItemInternal(result, reader);
                        return result;
                    }
                }
            }
        }
    }
}
