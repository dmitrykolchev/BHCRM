using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public static class DbValueConverter
    {
        public static object Convert(Nullable<Int32> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(Nullable<Byte> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(Nullable<Int16> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(Nullable<Int64> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(Nullable<Guid> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(Nullable<DateTime> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(Nullable<Decimal> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(Nullable<Boolean> value)
        {
            if (value.HasValue)
                return value.Value;
            return DBNull.Value;
        }

        public static object Convert(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();
            return DBNull.Value;
        }

        public static object Convert(byte[] value)
        {
            if (value != null)
                return value;
            return DBNull.Value;
        }
    }
}
