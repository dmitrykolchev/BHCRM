using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IApplicationRole
    {
        int Id { get; }
        string Code { get; }
        string FileAs { get; }
        string Comments { get; }
    }
}
