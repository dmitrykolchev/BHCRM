using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ViewDataManager
    {
        private ViewMetadataCollection _views = new ViewMetadataCollection();
        internal ViewDataManager()
        {
        }
        public ViewMetadataCollection Views
        {
            get { return this._views; }
        }
        private static ViewMetadata RegisterProxy(Type viewItemType, Type dataAdapterProxyType)
        {
            ViewMetadata metadata = new ViewMetadata(viewItemType, null, dataAdapterProxyType);
            ViewDataManager viewManager = ServiceManager.GetService<ViewDataManager>();
            viewManager.Views.Add(metadata);
            return metadata;
        }
        private static ViewMetadata Register(Type viewItemType, Type dataAdapterType)
        {
            ViewMetadata metadata = new ViewMetadata(viewItemType, dataAdapterType, null);
            ViewDataManager viewManager = ServiceManager.GetService<ViewDataManager>();
            viewManager.Views.Add(metadata);
            return metadata;
        }
        public static ViewMetadata Register<A>() where A: IViewDataAdapter, new()
        {
            A adapter = new A();
            return Register(adapter.ViewItemType, typeof(A));
        }
        public static ViewMetadata RegisterProxy<P>() where P: IViewDataAdapter, new()
        {
            P proxy = new P();
            return RegisterProxy(proxy.ViewItemType, typeof(P));
        }
        public static IViewDataAdapter CreateDataAdapter(ViewMetadata metadata)
        {
            return metadata.CreateDataAdapter();
        }
        public static IViewDataAdapter CreateDataAdapterProxy(ViewMetadata metadata)
        {
            return metadata.CreateDataAdapterProxy();
        }
        public static ViewMetadata GetMetadata(string className)
        {
            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className");
            ViewDataManager viewManager = ServiceManager.GetService<ViewDataManager>();
            if (viewManager != null)
            {
                return viewManager.Views[className];
            }
            return null;
        }
        public static ViewMetadata GetMetadata(Type viewItemType)
        {
            if (viewItemType == null)
                throw new ArgumentNullException("viewItemType");
            ViewDataManager viewManager = ServiceManager.GetService<ViewDataManager>();
            if (viewManager != null)
            {
                return viewManager.Views[viewItemType];
            }
            return null;
        }
        public IViewDataAdapter CreateDataAdapterProxy(string viewClassName)
        {
            return CreateDataAdapterProxy(this.Views[viewClassName]);
        }
        public IViewDataAdapter CreateDataAdapter(string viewClassName)
        {
            ViewMetadata metadata = this.Views[viewClassName];
            return CreateDataAdapter(metadata);
        }
    }
}
