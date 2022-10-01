using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class CalculationStatementLine
    {
        private static readonly DateTime FixedDate = new DateTime(2000, 1, 1);
        private static readonly TimeSpan OneDay = TimeSpan.FromHours(24);

        private Nullable<DateTime> _startTime;
        private Nullable<DateTime> _endTime;
        [XmlAttribute]
        public int CalculationStatementLineId { get; set; }
        [XmlAttribute]
        public int CalculationStatementSectionId { get; set; }
        [XmlAttribute]
        public int CalculationStatementId { get; set; }
        [XmlAttribute]
        public int OrdinalPosition { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductId { get; set; }
        [XmlAttribute]
        public string FileAs { get; set; }
        [XmlAttribute]
        public string Comments { get; set; }
        [XmlAttribute]
        public Nullable<DateTime> StartTime
        {
            get { return this._startTime; }
            set
            {
                this._startTime = value;
                CoalesceDuration();
            }
        }
        [XmlAttribute]
        public Nullable<DateTime> EndTime
        {
            get { return this._endTime; }
            set
            {
                this._endTime = value;
                CoalesceDuration();
            }
        }
        private void CoalesceDuration()
        {
            if (StartTime.HasValue)
            {
                this._startTime = FixedDate + StartTime.Value.TimeOfDay;
            }
            
            if (EndTime.HasValue)
            {
                this._endTime = FixedDate + EndTime.Value.TimeOfDay;
            }

            if (StartTime.HasValue && EndTime.HasValue)
            {
                if (EndTime.Value <= StartTime.Value)
                    this._endTime = EndTime.Value.AddDays(1);
            }
        }
        [XmlIgnore]
        public Nullable<decimal> Duration
        {
            get
            {
                if (StartTime.HasValue && EndTime.HasValue)
                    return (decimal)(EndTime.Value - StartTime.Value).TotalHours;
                return null;
            }
        }
        [XmlAttribute]
        public decimal Amount { get; set; }
        [XmlAttribute]
        public Nullable<decimal> AmountPerGuest { get; set; }
        [XmlAttribute]
        public decimal Factor { get; set; }
        [XmlAttribute]
        public decimal Cost { get; set; }
        [XmlAttribute]
        public decimal Price { get; set; }
        [XmlIgnore]
        public CalculationStatement Parent { get; internal set; }
    }
}
