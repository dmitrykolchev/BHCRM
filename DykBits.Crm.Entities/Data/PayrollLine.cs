using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class PayrollLine : DetailDataItem<Payroll>
    {
        [XmlAttribute]
        public int OrdinalPosition { get; set; }
        [XmlAttribute]
        public Nullable<int> AccountId { get; set; }
        [XmlAttribute]
        public Nullable<int> EmployeeId { get; set; }
        [XmlAttribute]
        public Nullable<int> DivisionId { get; set; }
        [XmlAttribute]
        public Nullable<int> PositionId { get; set; }
        [XmlAttribute]
        public string FileAs { get; set; }
        [XmlAttribute]
        public string Comments { get; set; }
        [XmlAttribute]
        public decimal SalaryTotal { get; set; }
        [XmlAttribute]
        public decimal SalaryBase { get; set; }
        [XmlAttribute]
        public decimal IncomeTax { get; set; }
        [XmlAttribute]
        public decimal SocialTax { get; set; }
        [XmlAttribute]
        public decimal Cashing { get; set; }
        [XmlAttribute]
        public decimal Total { get; set; }
    }

    public class PayrollLineCollection: DetailDataItemCollection<Payroll, PayrollLine>
    {
        internal PayrollLineCollection(Payroll owner): base(owner)
        {
        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            for (int index = 0; index < Count; ++index)
                this[index].OrdinalPosition = index + 1;
            base.OnCollectionChanged(e);
        }
    }
}
