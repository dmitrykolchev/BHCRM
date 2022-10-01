using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DocumentEmployeeAccessRightFilter
    {
        public int DocumentTypeId { get; set; }
        public int DocumentId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            IDataItem dataItem = (IDataItem)dataContext;
            this.DocumentTypeId = dataItem.DataItemClassId;
            this.DocumentId = dataItem.Id;
        }
    }
}
