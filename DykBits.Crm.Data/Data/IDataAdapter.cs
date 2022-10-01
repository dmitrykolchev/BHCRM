using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace DykBits.Crm.Data
{
    public interface IDataAdapter: IViewDataAdapter
    {
        IDataItem CreateItem(object dataContext);
        IDataItem GetItem(ItemKey key);
        IDataItem Save(IDataItem item);
        void Delete(ItemKey key);
        void ChangeState(ItemKey key, byte newState, XElement applicationData);
        IDataItem FromXml(XmlReader reader);
        bool ValidateAccess(ItemKey key);
        Type DocumentType { get; }
    }
}
