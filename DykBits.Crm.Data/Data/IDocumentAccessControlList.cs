using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IDocumentAccessControlList
    {
        IList<IGenericRight> Rights { get; }
    }

    public interface IDocumentStateAccessControlList
    {
        IList<IDocumentStateGenericRight> Rights { get; }
    }
}
