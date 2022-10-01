using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [XmlRoot("MoneyOperation")]
    [XmlType("MoneyOperation")]
    public class MoneyOperationReportByOperationTypeItem : XmlSerializableDataItem
    {
        public int ViewGroup { get; set; }
        public Nullable<int> MoneyOperationTypeId { get; set; }
        public Nullable<int> BudgetItemGroupId { get; set; }
        public Nullable<int> BudgetItemId { get; set; }
        public Nullable<decimal> Income { get; set; }
        public Nullable<decimal> Expense { get; set; }
        public Nullable<decimal> Balance
        {
            get
            {
                if (Income.HasValue || Expense.HasValue)
                    return Income.GetValueOrDefault() - Expense.GetValueOrDefault();
                return null;
            }
        }
    }
}
