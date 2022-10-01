using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class NotifyDataObject : NotifyObject
    {
        private NotifyDataObjectPropertyStore _store = new NotifyDataObjectPropertyStore();
        public NotifyDataObject()
        {
        }
        public T GetValue<T>(NotifyDataObjectProperty property)
        {
            object value = this._store.GetValue(property);
            if (value != Unset.Value)
                return (T)value;
            return default(T);
        }
        public void SetValue<T>(NotifyDataObjectProperty property, T value)
        {
            if(!property.PropertyType.IsAssignableFrom(typeof(T)))
                throw new InvalidOperationException();
            this._store.SetValue(property, value);
            InvokePropertyChanged(property.PropertyName);
        }
        protected void WriteValue<T>(NotifyDataObjectProperty property, T value)
        {
            if (!property.PropertyType.IsAssignableFrom(typeof(T)))
                throw new InvalidOperationException();
            this._store.SetValue(property, value);
        }
        public void ClearValue(NotifyDataObjectProperty property)
        {
            this._store.ClearValue(property);
            InvokePropertyChanged(property.PropertyName);
        }
    }
}
