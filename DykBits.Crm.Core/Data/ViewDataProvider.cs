using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;

namespace DykBits.Crm.Data
{
    public class ViewDataProvider: DataSourceProvider
    {
        private bool _isAsynchronous;
        private Type _objectType;
        public bool IsAsynchronous
        {
            get { return this._isAsynchronous; }
            set
            {
                this._isAsynchronous = value;
                OnPropertyChanged("IsAsynchronous");
            }
        }
        public Type ObjectType
        {
            get { return this._objectType; }
            set
            {
                this._objectType = value;
                OnPropertyChanged("ObjectType");
            }
        }
        protected override void BeginQuery()
        {
            if (this.IsAsynchronous)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.QueryWorker), null);
            }
            else
            {
                this.QueryWorker(null);
            }
        }
        private void QueryWorker(object state)
        {
            Exception ex = null;
            object newData = null;
            if (this.ObjectType == null)
            {
                ex = new InvalidOperationException("data provider has no source");
            }
            else
            {
                var metadata = ViewDataManager.GetMetadata(this.ObjectType);
                var dataAdapter = ViewDataManager.CreateDataAdapterProxy(metadata);
                Filter filter = dataAdapter.CreateFilter(null, null);
                newData = dataAdapter.Browse(filter.ToXml());
            }
            OnQueryFinished(newData, ex, null, null);
        }
        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
