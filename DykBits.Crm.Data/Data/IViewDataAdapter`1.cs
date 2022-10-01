using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public interface IViewDataAdapter<V, F>
    {
        IList<V> Browse(XElement filter);
        IList<V> GetList(XElement filter);
        F CreateFilter(object dataContext, object parameter);
        Type ViewItemType { get; }
        Type FilterType { get; }
    }
}
