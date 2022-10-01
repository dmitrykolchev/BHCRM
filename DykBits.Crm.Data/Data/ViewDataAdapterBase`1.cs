using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public abstract class ViewDataAdapterBase<V, F> : ViewDataAdapterCore<V, F>
        where V : DataItemView, new()
        where F : Filter, new()
    {
        protected ViewDataAdapterBase()
        {
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
                using (SqlCommand command = CreateCommand(typeof(V), SqlProcedureType.Browse, connection))
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
                using (SqlCommand command = CreateCommand(typeof(V), SqlProcedureType.List, connection))
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
    }
}
