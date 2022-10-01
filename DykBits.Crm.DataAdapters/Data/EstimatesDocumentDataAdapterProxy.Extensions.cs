using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class EstimatesDocumentDataAdapterProxy
    {
        protected override EstimatesDocument CreateItemOverride(object dataContext)
        {
            var document = base.CreateItemOverride(dataContext);
            document.VATRateId = 1;
            document.Commission = 0.1m;
            if (dataContext is ServiceRequest)
            {
                document.ServiceRequestId = ((ServiceRequest)dataContext).Id;
                document.OrganizationId = ((ServiceRequest)dataContext).OrganizationId;
            }
            return document;
        }
    }
}
