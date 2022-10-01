using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface ICurrentUser
    {
        int Id { get; }
        string FileAs { get;  }
        bool Locked { get; }
        string Comments { get; }
        IDictionary<string, IApplicationRole> Roles { get; }
        IDictionary<int, IGenericRight> GenericRights { get; }
        IDictionary<string, IAccessRight> Rights { get; }
        bool HasRight(string right);
        bool IsMemberOf(string role);
    }
}
