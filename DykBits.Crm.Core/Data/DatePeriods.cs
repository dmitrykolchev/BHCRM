using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DatePeriods
    {
        private static readonly DatePeriod sArbitrary = new ArbitraryPeriod();
        private static readonly DatePeriod sToday = new TodayPeriod();
        private static readonly DatePeriod sYesterday = new YesterdayPeriod();
        private static readonly DatePeriod sTomorrow = new TomorrowPeriod();
        private static readonly DatePeriod sCurrentWeek = new CurrentWeekPeriod();
        private static readonly DatePeriod sPreviousWeek = new PreviousWeekPeriod();
        private static readonly DatePeriod sNextWeek = new NextWeekPeriod();
        private static readonly DatePeriod sCurrentMonth = new CurrentMonthPeriod();
        private static readonly DatePeriod sPreviousMonth = new PreviousMonthPeriod();
        private static readonly DatePeriod sNextMonth = new NextMonthPeriod();
        private static readonly DatePeriod sCurrentQuarter = new CurrentQuarterPeriod();
        private static readonly DatePeriod sPreviousQuarter = new PreviousQuarterPeriod();
        private static readonly DatePeriod sNextQuarter = new NextQuarterPeriod();
        private static readonly DatePeriod sCurrentYear = new CurrentYearPeriod();
        private static readonly DatePeriod sPreviousYear = new PreviousYearPeriod();
        private static readonly DatePeriod sNextYear = new NextYearPeriod();
        private static readonly DatePeriod sDoesNotMatter = new DoesNotMatterPeriod();

        public static DatePeriod DoesNotMatter
        {
            get { return sDoesNotMatter; }
        }
        public static DatePeriod Arbitrary
        {
            get { return sArbitrary; }
        }
        public static DatePeriod Today
        {
            get { return sToday; }
        }

        public static DatePeriod Yesterday
        {
            get { return sYesterday; }
        }

        public static DatePeriod Tomorrow
        {
            get { return sTomorrow; }
        }

        public static DatePeriod CurrentWeek
        {
            get { return sCurrentWeek; }
        }
        public static DatePeriod PreviousWeek
        {
            get { return sPreviousWeek; }
        }
        public static DatePeriod NextWeek
        {
            get { return sNextWeek; }
        }
        public static DatePeriod CurrentMonth
        {
            get { return sCurrentMonth; }
        }
        public static DatePeriod PreviousMonth
        {
            get { return sPreviousMonth; }
        }
        public static DatePeriod NextMonth
        {
            get { return sNextMonth; }
        }
        public static DatePeriod CurrentQuarter
        {
            get { return sCurrentQuarter; }
        }
        public static DatePeriod PreviousQuarter
        {
            get { return sPreviousQuarter; }
        }
        public static DatePeriod NextQuarter
        {
            get { return sNextQuarter; }
        }
        public static DatePeriod CurrentYear
        {
            get { return sCurrentYear; }
        }
        public static DatePeriod PreviousYear
        {
            get { return sPreviousYear; }
        }
        public static DatePeriod NextYear
        {
            get { return sNextYear; }
        }
        private class DoesNotMatterPeriod : DatePeriod
        {
            internal DoesNotMatterPeriod()
                : base("(не важно)")
            {
            }

            public override DateTime Start
            {
                get { return DateTime.MinValue; }
            }

            public override DateTime End
            {
                get { return DateTime.MaxValue; }
            }
        }

        private class ArbitraryPeriod : DatePeriod
        {
            internal ArbitraryPeriod()
                : base("Произвольный")
            {
            }

            public override DateTime Start
            {
                get { return DateTime.MinValue; }
            }

            public override DateTime End
            {
                get { return DateTime.MaxValue; }
            }
        }

        private class TodayPeriod : DatePeriod
        {
            internal TodayPeriod()
                : base("Сегодня")
            {
            }
            public override DateTime Start
            {
                get { return DateTime.Today; }
            }
            public override DateTime End
            {
                get { return Start; }
            }
        }

        private class YesterdayPeriod : DatePeriod
        {
            internal YesterdayPeriod()
                : base("Вчера")
            {
            }
            public override DateTime Start
            {
                get { return DateTime.Today.AddDays(-1); }
            }
            public override DateTime End
            {
                get { return Start; }
            }
        }
        private class TomorrowPeriod : DatePeriod
        {
            internal TomorrowPeriod()
                : base("Завтра")
            {
            }
            public override DateTime Start
            {
                get { return DateTime.Today.AddDays(1); }
            }
            public override DateTime End
            {
                get { return Start; }
            }
        }

        private class CurrentWeekPeriod : DatePeriod
        {
            internal CurrentWeekPeriod()
                : base("Текщая неделя")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfWeek(DateTime.Today); }
            }

            public override DateTime End
            {
                get { return Start.AddDays(6); }
            }
        }
        private class PreviousWeekPeriod : DatePeriod
        {
            internal PreviousWeekPeriod()
                : base("Предыдущая неделя")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfWeek(DateTime.Today).AddDays(-7); }
            }

            public override DateTime End
            {
                get { return Start.AddDays(6); }
            }
        }
        private class NextWeekPeriod : DatePeriod
        {
            internal NextWeekPeriod()
                : base("Следующая неделя")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfWeek(DateTime.Today).AddDays(7); }
            }

            public override DateTime End
            {
                get { return Start.AddDays(6); }
            }
        }

        private class CurrentMonthPeriod : DatePeriod
        {
            internal CurrentMonthPeriod()
                : base("Текущий месяц")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfMonth(DateTime.Today); }
            }

            public override DateTime End
            {
                get { return Start.AddMonths(1).AddDays(-1); }
            }
        }

        private class PreviousMonthPeriod : DatePeriod
        {
            internal PreviousMonthPeriod()
                : base("Предыдущий месяц")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfMonth(DateTime.Today).AddMonths(-1); }
            }
            public override DateTime End
            {
                get { return Start.AddMonths(1).AddDays(-1); }
            }
        }
        private class NextMonthPeriod : DatePeriod
        {
            internal NextMonthPeriod()
                : base("Следующий месяц")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfMonth(DateTime.Today).AddMonths(1); }
            }
            public override DateTime End
            {
                get { return Start.AddMonths(1).AddDays(-1); }
            }
        }

        private class CurrentQuarterPeriod : DatePeriod
        {
            internal CurrentQuarterPeriod()
                : base("Текущий квартал")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfQuarter(DateTime.Today); }
            }

            public override DateTime End
            {
                get { return Start.AddMonths(3).AddDays(-1); }
            }
        }
        private class PreviousQuarterPeriod : DatePeriod
        {
            internal PreviousQuarterPeriod()
                : base("Предыдущий квартал")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfQuarter(DateTime.Today).AddMonths(-3); }
            }

            public override DateTime End
            {
                get { return Start.AddMonths(3).AddDays(-1); }
            }
        }

        private class NextQuarterPeriod : DatePeriod
        {
            internal NextQuarterPeriod()
                : base("Следующий квартал")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfQuarter(DateTime.Today).AddMonths(3); }
            }

            public override DateTime End
            {
                get { return Start.AddMonths(3).AddDays(-1); }
            }
        }

        private class CurrentYearPeriod : DatePeriod
        {
            internal CurrentYearPeriod()
                : base("Текущий год")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfYear(DateTime.Today); }
            }

            public override DateTime End
            {
                get { return Start.AddYears(1).AddDays(-1); }
            }
        }
        private class PreviousYearPeriod : DatePeriod
        {
            internal PreviousYearPeriod()
                : base("Предыдущий год")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfYear(DateTime.Today).AddYears(-1); }
            }

            public override DateTime End
            {
                get { return Start.AddYears(1).AddDays(-1); }
            }
        }
        private class NextYearPeriod : DatePeriod
        {
            internal NextYearPeriod()
                : base("Следующий год")
            {
            }

            public override DateTime Start
            {
                get { return DatePeriod.GetStartOfYear(DateTime.Today).AddYears(1); }
            }

            public override DateTime End
            {
                get { return Start.AddYears(1).AddDays(-1); }
            }
        }
    }
}
