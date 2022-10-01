using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class CurrentUserDataAdapterProxy
    {
        protected override void VerifyAccessOverride(GenericRight right)
        {
            if (right != GenericRight.Browse && right != GenericRight.Get)
                base.VerifyAccessOverride(right);
        }
    }
}
