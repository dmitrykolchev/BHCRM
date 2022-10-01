using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.UI
{
    public abstract class MonthEditItem
    {
        protected MonthEditItem()
        {
        }

        public int Value { get; set; }
        public abstract string CellText { get; }
        public virtual string HeaderText { get { return this.CellText; } }

        public static IList<MonthEditItem> GetMonthes()
        {
            List<MonthEditItem> items = new List<MonthEditItem>();
            for (int index = 0; index < 12; ++index)
            {
                items.Add(new MonthItem { Value = index + 1 });
            }
            return items;
        }

        public static IList<MonthEditItem> GetYears(int year)
        {
            List<MonthEditItem> items = new List<MonthEditItem>();
            for (int index = 0; index < 12; ++index)
            {
                items.Add(new YearItem { Value = year + index });
            }
            return items;
        }
        public static IList<MonthEditItem> GetDoezensYears(int year)
        {
            List<MonthEditItem> items = new List<MonthEditItem>();
            for (int index = 0; index < 12; ++index)
            {
                items.Add(new DoezenYearsItem { Value = year + index * 12 - 6 * 12 });
            }
            return items;
        }

        public class MonthItem : MonthEditItem
        {
            public MonthItem()
            {
            }

            public override string CellText
            {
                get
                {
                    return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[Value - 1];
                }
            }
        }

        public class YearItem : MonthEditItem
        {
            public YearItem()
            {
            }

            public override string CellText
            {
                get { return Value.ToString(); }
            }
        }

        public class DoezenYearsItem : MonthEditItem
        {
            public DoezenYearsItem()
            {
            }

            public override string CellText
            {
                get { return string.Format("{0}-\n{1}", Value, Value + 11); }
            }

            public override string HeaderText
            {
                get
                {
                    return string.Format("{0} - {1}", Value, Value + 11); ;
                }
            }
        }
    }

}
