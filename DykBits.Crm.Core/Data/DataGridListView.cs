using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class DataGridListView : IList, System.Collections.Specialized.INotifyCollectionChanged
    {
        private List<object> _items;
        private List<object> _view;
        private Predicate<object> _filter;

        public DataGridListView()
        {
            this._items = new List<object>();
            this._view = this._items;
        }

        public Predicate<object> Filter
        {
            get { return this._filter; }
            set
            {
                this._filter = value;
                this._view = null;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        private List<object> View
        {
            get
            {
                if (this._view == null)
                    this._view = CreateView();
                return this._view;
            }
        }
        private List<object> CreateView()
        {
            if (this._filter == null)
                return this._items;
            var view = new List<object>();
            foreach (object item in this._items)
            {
                if (this._filter(item))
                    view.Add(item);
            }
            return view;
        }
        public void Refresh(IEnumerable items)
        {
            this._items.Clear();
            foreach (var item in items)
                this._items.Add(item);
            this._view = null;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public int Add(object value)
        {
            throw new NotSupportedException();
        }
        public void Clear()
        {
            this._items.Clear();
            this._view = null;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(object value)
        {
            return View.Contains(value);
        }

        public int IndexOf(object value)
        {
            return View.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            throw new NotSupportedException();
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Remove(object value)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public object this[int index]
        {
            get
            {
                return View[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotSupportedException();
        }

        public int Count
        {
            get { return View.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public IEnumerator GetEnumerator()
        {
            return View.GetEnumerator();
        }

        public event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, e);
        }
    }
}
