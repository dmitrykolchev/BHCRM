using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public static class DataAdapterExtensions
    {
        public static T GetItem<T>(this IDataAdapter dataAdapter, int id)
        {
            return (T)dataAdapter.GetItem(ItemKey.CreateKey<T>(id));
        }
    }
}
