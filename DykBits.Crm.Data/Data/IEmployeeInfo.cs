using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IEmployeeInfo
    {
        int Id { get; }
        string FullName { get; }
        int OrganizationId { get; }
        int UserId { get; }
    }
}
