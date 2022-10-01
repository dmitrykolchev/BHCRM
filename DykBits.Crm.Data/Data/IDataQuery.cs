using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IDataQuery
    {
        string DocumentElement { get; }
        string Selector { get; }
        string Value { get; }
        string SchemaName { get; }
        string ProcedureName { get; }
    }
}
