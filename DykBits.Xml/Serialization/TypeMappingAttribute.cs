using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Xml.Serialization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TypeMappingAttribute : Attribute
    {
        private Type _type;
        private string _elementName;
        public TypeMappingAttribute(Type type)
        {
            this._type = type;
        }

        public string ElementName
        {
            get
            {
                if (string.IsNullOrEmpty(this._elementName))
                    return Type.Name;
                return this._elementName;
            }
            set
            {
                this._elementName = value;
            }
        }

        public Type Type
        {
            get { return this._type; }
        }
    }
}
