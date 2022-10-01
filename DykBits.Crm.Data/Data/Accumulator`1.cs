using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public static class AccumulatorExtensions
    {
        public static Nullable<decimal> Add(this Nullable<decimal> v1, Nullable<decimal> v2)
        {
            if (v1.HasValue || v2.HasValue)
                return v1.GetValueOrDefault() + v2.GetValueOrDefault();
            return null;
        }
        public static Nullable<decimal> Sub(this Nullable<decimal> v1, Nullable<decimal> v2)
        {
            if (v1.HasValue || v2.HasValue)
                return v1.GetValueOrDefault() - v2.GetValueOrDefault();
            return null;
        }
    }
    public class Accumulator<T> where T: struct
    {
        Nullable<T> _value;
        public Nullable<T> Add(Nullable<T> value)
        {
            if (value.HasValue)
            {
                if (!_value.HasValue)
                    _value = default(T);
                _value = Add(_value.Value, value.Value);
            }
            return _value;
        }

        public static Nullable<T> Add(Nullable<T> v1, Nullable<T> v2)
        {
            if (!v1.HasValue && v2.HasValue)
                return v2.Value;
            if (v1.HasValue && !v2.HasValue)
                return v1.Value;
            if (v1.HasValue && v2.HasValue)
                return Add(v1.Value, v2.Value);
            return null;
        }
        public static Nullable<T> Sub(Nullable<T> v1, Nullable<T> v2)
        {
            if (!v1.HasValue && v2.HasValue)
                return Sub(default(T), v2.Value);
            if (v1.HasValue && !v2.HasValue)
                return v1.Value;
            if (v1.HasValue && v2.HasValue)
                return Sub(v1.Value, v2.Value);
            return null;
        }
        static T Sub(T v1, T v2)
        {
            dynamic a1 = v1;
            dynamic a2 = v2;
            return a1 - a2;
        }
        static T Add(T v1, T v2)
        {
            dynamic a1 = v1;
            dynamic a2 = v2;
            return a1 + a2;
        }

        public void Reset()
        {
            this._value = default(Nullable<T>);
        }
        public Nullable<T> Value
        {
            get { return this._value; }
        }
    }
}
