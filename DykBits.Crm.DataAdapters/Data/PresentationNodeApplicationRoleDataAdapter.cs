using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class PresentationNodeApplicationRoleDataAdapter: XmlViewDataAdapterBase<PresentationNodeApplicationRole, EmptyFilter>
    {
        public PresentationNodeApplicationRoleDataAdapter()
            : base("[dbo].[PresentationNodeApplicationRoleBrowse]")
        {
        }
    }

    public class PresentationNodeApplicationRoleDataAdapterProxy : ViewDataAdapterProxy<PresentationNodeApplicationRole, EmptyFilter>
    {
    }
}
