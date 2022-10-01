using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public abstract class ViewDataAdapterCore<V, F>: IViewDataAdapter<V, F>, IViewDataAdapter 
        where V: new()
        where F: Filter, new()
    {
        static readonly V instance = new V();
        protected ViewDataAdapterCore()
        {
        }
        public void VerifyAccess(GenericRight right)
        {
            VerifyAccessOverride(right);
        }
        protected virtual void VerifyAccessOverride(GenericRight right)
        {
        }
        protected virtual SqlCommand CreateCommand(Type type, SqlProcedureType commandRole, SqlConnection connection)
        {
            return DataHelper.CreateProcedure(type, commandRole, connection);
        }
        public F CreateFilter(object dataContext, object parameter)
        {
            return CreateFilterOverride(dataContext, parameter);
        }
        protected virtual F CreateFilterOverride(object dataContext, object parameter)
        {
            return new F();
        }
        public IList<V> Browse(XElement filter)
        {
            VerifyAccess(GenericRight.Browse);
            return BrowseOverride(filter);
        }
        public IList<V> GetList(XElement filter)
        {
            return GetListOverride(filter);
        }
        protected abstract IList<V> BrowseOverride(XElement filter);
        protected abstract IList<V> GetListOverride(XElement filter);
        IList IViewDataAdapter.Browse(XElement filter)
        {
            return (IList)Browse(filter);
        }
        IList IViewDataAdapter.GetList(XElement filter)
        {
            return (IList)GetList(filter);
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
