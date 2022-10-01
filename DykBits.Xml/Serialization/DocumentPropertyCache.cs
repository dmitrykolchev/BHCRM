using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DykBits.Xml.Serialization
{
    public sealed class DocumentPropertyCache
    {
        public static readonly DocumentPropertyCache Instance = new DocumentPropertyCache();

        private ConcurrentDictionary<PropertyInfo, bool> _canSerialize = new ConcurrentDictionary<PropertyInfo, bool>();
        private ConcurrentDictionary<PropertyInfo, bool> _canDeserialize = new ConcurrentDictionary<PropertyInfo, bool>();
        private DocumentPropertyCache()
        {
        }

        public bool? IsSerializable(PropertyInfo propertyInfo)
        {
            bool value;
            if (_canSerialize.TryGetValue(propertyInfo, out value))
                return value;
            return null;
        }

        public bool? IsDeserializable(PropertyInfo propertyInfo)
        {
            bool value;
            if (_canDeserialize.TryGetValue(propertyInfo, out value))
                return value;
            return null;
        }

        public void AddToSerializable(PropertyInfo propertyInfo, bool serializable)
        {
            this._canSerialize.TryAdd(propertyInfo, serializable);
        }

        public void AddToDeserializable(PropertyInfo propertyInfo, bool deserializable)
        {
            this._canDeserialize.TryAdd(propertyInfo, deserializable);
        }

    }
}
