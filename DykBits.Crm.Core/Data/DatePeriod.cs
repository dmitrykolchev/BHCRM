using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DykBits.Crm.Data
{
    public abstract class DatePeriod
    {
        protected DatePeriod()
        {
        }

        protected DatePeriod(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get;
            set;
        }

        public abstract DateTime Start
        {
            get;
        }

        public abstract DateTime End
        {
            get;
        }

        public static DateTime GetStartOfWeek(DateTime dt)
        {
            int firstDayOfWeek = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            return dt.AddDays(-((7 + (int)dt.DayOfWeek - (int)firstDayOfWeek) % 7));
        }

        public static DateTime GetStartOfMonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime GetStartOfQuarter(DateTime dt)
        {
            int month = (dt.Month - 1) / 3;
            return new DateTime(dt.Year, month * 3 + 1, 1);
        }

        public static DateTime GetStartOfYear(DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }

    }
}
