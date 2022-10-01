using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class AccountEventView
    {
        public TimeSpan Duration
        {
            get { return EventEnd - EventStart; }
        }
        public DateTime EventStartDate
        {
            get { return this.EventStart.Date; }
        }
        public DateTime EventStartTime
        {
            get { return EventStart; }
        }
        public DateTime EventEndDate
        {
            get { return EventEnd.Date; }
        }
        public DateTime EventEndTime
        {
            get { return EventEnd; }
        }
    }
}
