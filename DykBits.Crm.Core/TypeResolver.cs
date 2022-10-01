using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    class TypeResolver: ITypeResolver
    {
        public Type ResolveType(string typeName)
        {
            return Type.GetType(typeName, true);
        }
    }
}
