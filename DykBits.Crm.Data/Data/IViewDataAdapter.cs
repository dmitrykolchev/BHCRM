using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public interface IViewDataAdapter
    {
        IList Browse(XElement filter);
        IList GetList(XElement filter);
        Filter CreateFilter(object dataContext, object parameter);
        Type ViewItemType { get; }
        Type FilterType { get; }
    }
}
