using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public abstract class ViewDataAdapterProxy<V, F> : IViewDataAdapter<V, F>, IViewDataAdapter
        where V : new()
        where F: Filter, new()
    {
        IViewDataAdapter<V, F> _realAdapter;
        static readonly V viewItemInstance = new V();
        public void VerifyAccess(GenericRight right)
        {
            VerifyAccessOverride(right);
        }
        protected virtual void VerifyAccessOverride(GenericRight right)
        {
        }
        private IViewDataAdapter<V, F> RealAdapter
        {
            get
            {
                if (this._realAdapter == null)
                    this._realAdapter = CreateRealDataAdapter();
                return this._realAdapter;
            }
        }
        private IViewDataAdapter<V, F> CreateRealDataAdapter()
        {
            IConnectionManager connectionManager = ServiceManager.GetService<IConnectionManager>();
            if (connectionManager.IsRemote)
            {
                return new RemoteViewDataAdapter<V, F>();
            }
            else
            {
                ViewDataManager viewDataManager = ServiceManager.GetService<ViewDataManager>();
                ViewMetadata metadata = viewDataManager.Views[typeof(V)];
                return (IViewDataAdapter<V, F>)ViewDataManager.CreateDataAdapter(metadata);
            }
        }
        public IList<V> Browse(XElement filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            VerifyAccess(GenericRight.Browse);
            return BrowseOverride(filter);
        }
        protected virtual IList<V> BrowseOverride(XElement filter)
        {
            return RealAdapter.Browse(filter);
        }
        public IList<V> GetList(XElement filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            return GetListOverride(filter);
        }
        protected virtual IList<V> GetListOverride(XElement filter)
        {
            return RealAdapter.GetList(filter);
        }
        IList IViewDataAdapter.GetList(XElement filter)
        {
            return (IList)GetList(filter);
        }
        IList IViewDataAdapter.Browse(XElement filter)
        {
            return (IList)Browse(filter);
        }
        public F CreateFilter(object dataContext, object parameter)
        {
            F filter = new F();
            filter.InitializeDefaults(dataContext, parameter);
            return filter;
        }
        Filter IViewDataAdapter.CreateFilter(object dataContext, object parameter)
        {
            return CreateFilter(dataContext, parameter);
        }
        public Type ViewItemType
        {
            get { return typeof(V); }
        }
        public Type FilterType
        {
            get { return typeof(F); }
        }
    }
}
