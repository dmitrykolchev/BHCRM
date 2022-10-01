using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.UI
{
    public interface IActionProvider
    {
        UIActionCollection Actions { get; }
    }
}
