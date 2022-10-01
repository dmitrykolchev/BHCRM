using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    [Flags]
    public enum GenericRight
    {
        Browse = 0x0002,
        Get = 0x0004,
        Create = 0x0008,
        EditOwn = 0x0010,
        EditAll = 0x0020,
        ChangeState = 0x0040,
        DeleteOwn = 0x0080,
        DeleteAll = 0x0100,
        ReadOnly = Browse | Get,
        All = Browse | Get | EditOwn | EditAll | DeleteOwn | DeleteAll | Create | ChangeState
    }
    public interface IGenericRight
    {
        int DocumentTypeId { get; }
        int ApplicationRoleId { get;}
        GenericRight Rights { get; }
    }

    public interface IDocumentStateGenericRight
    {
        int DocumentTypeId { get; }
        byte DocumentState { get; }
        int ApplicationRoleId { get; }
        GenericRight Rights { get; }
    }
}
