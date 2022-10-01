using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class NotifyDataObjectProperty
    {
        private static int PropertyId = 0;

        private int _id;
        private string _propertyName;
        private Type _propertyType;
        private Type _ownerType;

        private NotifyDataObjectProperty(string propertyName, Type propertyType, Type ownerType)
        {
            this._id = System.Threading.Interlocked.Increment(ref PropertyId);
            this._propertyName = propertyName;
            this._propertyType = propertyType;
            this._ownerType = ownerType;
        }
        public static NotifyDataObjectProperty Register<P, O>(string propertyName)
        {
            NotifyDataObjectProperty property = new NotifyDataObjectProperty(propertyName, typeof(P), typeof(O));
            return property;
        }
        public int Id
        {
            get { return this._id; }
        }
        public string PropertyName
        {
            get
            {
                return this._propertyName;
            }
        }
        public Type PropertyType
        {
            get { return this._propertyType; }
        }
        public Type OwnerType
        {
            get { return this._ownerType; }
        }
        public override int GetHashCode()
        {
            return this._id;
        }
    }
}
