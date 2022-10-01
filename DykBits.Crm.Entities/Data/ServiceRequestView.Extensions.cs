using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class ServiceRequestView
    {
        [XmlIgnore]
        public Nullable<decimal> ValuePerGuest
        {
            get
            {
                if (AmountOfGuests.HasValue && TotalValue.HasValue && AmountOfGuests.Value > 0)
                {
                        return Math.Round(TotalValue.Value / AmountOfGuests.Value, 0, MidpointRounding.AwayFromZero);
                }
                return null;
            }
        }
        [XmlIgnore]
        public bool HasAttachments
        {
            get { return this.AttachmentCount > 0; }
        }
        [XmlIgnore]
        public bool HasBudget
        {
            get { return this.BudgetValue.HasValue; }
        }
        [XmlIgnore]
        public decimal? TotalValue
        {
            get
            {
                return HasBudget ? this.BudgetValue.Value : this.Value; 
            }
        }
    }
}
