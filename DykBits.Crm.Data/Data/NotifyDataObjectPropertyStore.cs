using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class NotifyDataObjectPropertyStore
    {
        private Dictionary<NotifyDataObjectProperty, object> _values = new Dictionary<NotifyDataObjectProperty, object>();

        public object GetValue(NotifyDataObjectProperty property)
        {
            object value;
            if (this._values.TryGetValue(property, out value))
                return value;
            return Unset.Value;
        }
        public void SetValue(NotifyDataObjectProperty property, object value)
        {
            if (value == Unset.Value)
                this._values.Remove(property);
            this._values[property] = value;
        }
        public void ClearValue(NotifyDataObjectProperty property)
        {
            SetValue(property, Unset.Value);
        }
    }
}
