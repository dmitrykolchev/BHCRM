using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DykBits.Crm
{
    public sealed class ServiceManager: IServiceProvider
    {
        private static readonly ServiceManager instance = new ServiceManager();

        private Dictionary<Type, object> _services = new Dictionary<Type, object>();
        private Dictionary<Type, Type> _singletons = new Dictionary<Type, Type>();

        private ServiceManager()
        {
        }
        public static ServiceManager Instance
        {
            get { return instance; }
        }
        public void AddService(Type serviceType, object instance)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");
            if (instance == null)
                throw new ArgumentNullException("instance");
            this._services.Add(serviceType, instance);
        }
        public void AddService<T>(object instance)
        {
            AddService(typeof(T), instance);
        }
        public void AddSingleton(Type serviceType, Type instanceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");
            if (instanceType == null)
                throw new ArgumentNullException("instanceType");
            if (!serviceType.IsAssignableFrom(instanceType))
                throw new ArgumentException("instance type incompatible with service type", "instanceType");
            this._singletons.Add(serviceType, instanceType);
        }
        public void AddSingleton<T>(Type instanceType)
        {
            AddSingleton(typeof(T), instanceType);
        }
        public object GetService(Type serviceType)
        {
            object instance;
            if (!this._services.TryGetValue(serviceType, out instance))
            {
                Type singletonType;
                if (!this._singletons.TryGetValue(serviceType, out singletonType))
                {
                    return null;
                }
                instance = Activator.CreateInstance(singletonType);
                this._services.Add(serviceType, instance);
            }
            return instance;
        }
        public static T GetService<T>()
        {
            return (T)instance.GetService(typeof(T));
        }
    }
}
