using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IDataItemWithKey
    {
        ItemKey GetKey();
    }

    public interface IDataItem: IDataItemWithKey
    {
        string DataItemClass { get; }
        int DataItemClassId { get; }
        DocumentMetadata Metadata { get; }
        bool IsReadOnly { get; }
        int Id { get; set; }
        byte State { get; set; }
        string FileAs { get; set; }
        string Comments { get; set; }
        DateTime Created { get; set; }
        int CreatedBy { get; set; }
        DateTime Modified { get; set; }
        int ModifiedBy { get; set; }
        byte[] RowVersion { get; set; }
        bool IsNew { get; }
    }
}
