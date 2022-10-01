using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    [Flags]
    public enum ServiceLevelFlag
    {
        Lowcost = 1,
        Standard = 2,
        Vip = 3
    }
}
