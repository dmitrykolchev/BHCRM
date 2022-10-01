using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public abstract class NumberedDataItemView: DataItemView, INumberedDataItem
    {
        protected NumberedDataItemView()
        {
        }

        public string Number { get; set; }
        public DateTime DocumentDate { get; set; }
        public int OrganizationId { get; set; }
    }
}
