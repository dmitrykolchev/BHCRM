using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface INumberedDataItem: IDataItem
    {
        string Number { get; set; }
        DateTime DocumentDate { get; set; }
        int OrganizationId { get; set; }
    }
}
