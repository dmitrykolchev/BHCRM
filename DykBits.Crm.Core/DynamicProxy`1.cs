using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;

namespace DykBits.Crm
{
    public class DynamicProxy<T> : IDynamicProxy, IDynamicMetaObjectProvider, INotifyPropertyChanged where T : class
    {
        private T _instance;
        private class ProxyMetaObject : DynamicMetaObject
        {
            public ProxyMetaObject(Expression expression, object value)
                : base(expression, BindingRestrictions.Empty, value)
            {
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                MethodInfo method = typeof(DynamicProxy<T>).GetMethod("SetPropertyValue", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(object) }, null);
                
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                Expression[] args = new Expression[] {
                    Expression.Constant(binder.Name),
                    Expression.Convert(value.Expression, typeof(object))
                };

                Expression self = Expression.Convert(Expression, LimitType);

                Expression methodCall = Expression.Call(self, method, args);
                
                return new DynamicMetaObject(methodCall, restrictions);
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                MethodInfo method = typeof(DynamicProxy<T>).GetMethod("GetPropertyValue", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
                
                BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                Expression[] args = new Expression[] { 
                    Expression.Constant(binder.Name) 
                };
                
                Expression self = Expression.Convert(Expression, LimitType);
                
                Expression methodCall = Expression.Call(self, method, args);
                
                return new DynamicMetaObject(methodCall, restrictions);
            }
        }

        internal DynamicProxy()
        {
        }

        object IDynamicProxy.RealObject
        {
            get { return this.RealObject; }
        }

        public T RealObject
        {
            get
            {
                return this._instance;
            }
            internal set
            {
                this._instance = value;
            }
        }
        public static dynamic Create(T instance)
        {
            DynamicProxy<T> proxy = new DynamicProxy<T>();
            proxy._instance = instance;
            return proxy;
        }
        private T Instance { get { return this._instance; } }
        private object SetPropertyValue(string propertyName, object value)
        {
            PropertyInfo property = Instance.GetType().GetProperty(propertyName);
            property.SetValue(Instance, value);
            this.InvokePropertyChanged(propertyName);
            return value;
        }
        private object GetPropertyValue(string propertyName)
        {
            PropertyInfo property = Instance.GetType().GetProperty(propertyName);
            return property.GetValue(Instance);
        }
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new ProxyMetaObject(parameter, this);
        }
        private void InvokePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
