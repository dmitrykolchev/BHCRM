using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Xml.Serialization
{
    public enum SerializationBindingMode
    {
        TwoWay,
        OneWay
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class SerializationBindingAttribute: Attribute
    {
        private SerializationBindingMode _mode;
        public SerializationBindingAttribute()
        {
            this._mode = SerializationBindingMode.TwoWay;
        }
        public SerializationBindingAttribute(SerializationBindingMode mode)
        {
            this._mode = mode;
        }
        public SerializationBindingMode Mode
        {
            get { return this._mode; }
        }
    }
}
