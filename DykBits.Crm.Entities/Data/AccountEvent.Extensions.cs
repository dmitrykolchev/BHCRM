using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class AccountEvent
    {
        [XmlIgnore]
        public TimeSpan Duration
        {
            get { return EventEnd - EventStart; }
        }
        [XmlIgnore]
        public DateTime EventStartDate
        {
            get { return this.EventStart.Date; }
            set
            {
                this.EventStart = value.Date + EventStart.TimeOfDay;
                InvokePropertyChanged("EventStartDate");
                if (EventEndDate < EventStartDate)
                    EventEndDate = EventStartDate;
            }
        }
        [XmlIgnore]
        public DateTime EventStartTime
        {
            get { return EventStart; }
            set
            {
                this.EventStart = EventStart.Date + value.TimeOfDay;
                InvokePropertyChanged("EventStartTime");
                if (EventEnd < EventStart)
                    EventEnd = EventStart;
            }
        }
        [XmlIgnore]
        public DateTime EventEndDate
        {
            get { return EventEnd.Date; }
            set
            {
                EventEnd = value.Date + EventEnd.TimeOfDay;
                InvokePropertyChanged("EventEndDate");
            }
        }
        [XmlIgnore]
        public DateTime EventEndTime
        {
            get { return EventEnd; }
            set
            {
                this.EventEnd = EventEnd.Date + value.TimeOfDay;
                InvokePropertyChanged("EventEndTime");
            }
        }

        private bool _recursive;

        partial void NotifyPropertyChangedInternal(string propertyName)
        {
            if (!this._recursive)
            {
                this._recursive = true;
                try
                {
                    if (propertyName == EventEndProperty)
                    {
                        InvokePropertyChanged("EventEndDate");
                        InvokePropertyChanged("EventEndTime");
                    }
                    else if (propertyName == EventStartProperty)
                    {
                        InvokePropertyChanged("EventStartDate");
                        InvokePropertyChanged("EventStartTime");
                    }
                }
                finally
                {
                    this._recursive = false;
                }
            }
        }

        protected override string ValidateProperty(System.Reflection.PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (propertyInfo.Name == ContactIdProperty)
            {
                if (this.ContactId == 0)
                    return "Необходимо указать контакт";
            }
            else if (propertyInfo.Name == AccountIdProperty)
            {
                if (this.AccountId == 0)
                    return "Необходимо указать контрагента";
            }
            else if (propertyInfo.Name == EmployeeIdProperty)
            {
                if (this.EmployeeId == 0)
                    return "Необходимо указать сотрудника";
            }
            return base.ValidateProperty(propertyInfo, columnAttribute);
        }
    }
}
