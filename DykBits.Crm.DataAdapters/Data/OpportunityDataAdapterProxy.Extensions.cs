using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class OpportunityDataAdapterProxy
    {
        protected override Opportunity CreateItemOverride(object dataContext)
        {
            var item  = base.CreateItemOverride(dataContext);
            item.DateClosed = DateTime.Today;
            item.EventDate = DateTime.Today;
            item.AmountOfGuests = 0;
            item.OpportunityTypeId = 1;
            item.Probability = 0.5m;
            return item;
        }
        protected override void OnValidate(Opportunity item)
        {
            item.FileAs = this.GetType().Name;
        }
    }
}
