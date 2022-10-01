using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CreditMoneyOperation: XmlSerializableDataItem
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime DocumentDate { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public Nullable<decimal> ReturnValue { get; set; }
        public Nullable<DateTime> LastPaymentDate { get; set; }
        public decimal Delta
        {
            get
            {
                return Value - ReturnValue.GetValueOrDefault();
            }
        }
    }
}
