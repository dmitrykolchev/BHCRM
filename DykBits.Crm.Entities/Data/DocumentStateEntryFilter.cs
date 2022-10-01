using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class DocumentStateEntryFilter
    {
        public Nullable<int> DocumentTypeId { get; set; }

        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            if (dataContext is DocumentTypeEntry)
            {
                this.DocumentTypeId = ((DocumentTypeEntry)dataContext).Id;
            }
        }
    }
}
