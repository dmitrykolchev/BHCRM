using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace DykBits.Crm.Data
{
    public interface IDataAdapter<V, T, F> : IViewDataAdapter<V, F>
    {
        T CreateItem(object dataContext);
        T GetItem(ItemKey key);
        T Save(T item);
        T FromXml(XmlReader reader);
        Type DocumentType { get; }
    }
}
