using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DocumentReportFilter
    {
        public Nullable<int> DocumentTypeId { get; set; }
        public string Code { get; set; }
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)DocumentReportState.Active };
            if (dataContext is DocumentMetadata)
            {
                this.DocumentTypeId = ((DocumentMetadata)dataContext).Id;
            }
        }
    }
}
