using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DykBits.Crm.Data
{
    public interface IDataQueryManager
    {
        IDataQuery Find(XmlDocument document);
    }
}
