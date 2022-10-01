using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ListManager
    {
        private Dictionary<string, DocumentRecordCollection> _lists = new Dictionary<string, DocumentRecordCollection>();
        private object _sync = new object();
        private ViewDataManager _viewDataManager;
        public ListManager()
        {
            
        }
        private ViewDataManager ViewDataManager
        {
            get
            {
                if (this._viewDataManager == null)
                {
                    this._viewDataManager = ServiceManager.GetService<ViewDataManager>();
                    DocumentManager.AddEventListener(_documentManager_DocumentOperationComplete);
                }
                return this._viewDataManager;
            }
        }
        void _documentManager_DocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if(e.Key != null)
                InvalidateList(e.Key.DocumentType);
        }
        public static V GetItem<V>(int id) where V: IDataItem, new()
        {
            V itemView = new V();
            ListManager listManager = ServiceManager.GetService<ListManager>();
            return (V)listManager.GetItem(ItemKey.CreateKey(itemView.DataItemClass, id));
        }
        private IList GetListInternal(string className)
        {
            IViewDataAdapter dataAdapter = ViewDataManager.CreateDataAdapterProxy(className);
            return dataAdapter.GetList(Filter.EmptyXml);
        }
        private DocumentRecordCollection GetCachedListInternal(string className)
        {
            lock (this._sync)
            {
                DocumentRecordCollection list;
                if (!this._lists.TryGetValue(className, out list))
                {
                    list = new DocumentRecordCollection(GetListInternal(className));
                    this._lists.Add(className, list);
                }
                return list;
            }
        }
        private void InvalidateList(string className)
        {
            lock (this._sync)
            {
                this._lists.Remove(className);
            }
        }
        public bool TryGetItem(ItemKey itemKey, out IDataItem value)
        {
            DocumentRecordCollection list = GetCachedListInternal(itemKey.DocumentType);
            if (!list.Contains(itemKey.Id))
            {
                InvalidateList(itemKey.DocumentType);
                list = GetCachedListInternal(itemKey.DocumentType);
            }
            if (list.Contains(itemKey.Id))
            {
                value = list[itemKey.Id];
                return true;
            }
            value = null;
            return false;
        }
        public IDataItem GetItem(ItemKey itemKey)
        {
            DocumentRecordCollection list = GetCachedListInternal(itemKey.DocumentType);
            if (!list.Contains(itemKey.Id))
            {
                InvalidateList(itemKey.DocumentType);
                list = GetCachedListInternal(itemKey.DocumentType);
            }
            return list[itemKey.Id];
        }
        public IEnumerable<IDataItem> Lookup(string className, Func<IDataItem, bool> predicate)
        {
            return GetListInternal(className).OfType<IDataItem>().Where(predicate);
        }
        public IDataItem Lookup(ItemKey key)
        {
            return GetListInternal(key.DocumentType).OfType<IDataItem>().Where(t => t.Id == key.Id).Single();
        }
        public DocumentRecordCollection GetList(string className)
        {
            var list = GetListInternal(className).OfType<IDataItem>().OrderBy(t => t.FileAs);
            return new DocumentRecordCollection(list);
        }
        public DocumentRecordCollection GetListOrderById(string className)
        {
            var list = GetListInternal(className).OfType<IDataItem>().OrderBy(t => t.Id);
            return new DocumentRecordCollection(list);
        }
        public DocumentRecordCollection GetList(string className, Func<IDataItem, bool> predicate)
        {
            var list = GetListInternal(className).OfType<IDataItem>().Where(predicate).OrderBy(t => t.FileAs);
            return new DocumentRecordCollection(list);
        }

        public static IList<T> GetList<T, TKey>(Func<T, bool> predicate , Func<T, TKey> order) where T: IDataItem, new()
        {
            T instance = new T();
            ListManager listManager = ServiceManager.GetService<ListManager>();
            return listManager.GetListInternal(instance.DataItemClass).OfType<T>().Where(predicate).OrderBy(order).ToList();
        }
        public static IList<T> GetList<T>(Func<T, bool> predicate) where T : IDataItem, new()
        {
            T instance = new T();
            ListManager listManager = ServiceManager.GetService<ListManager>();
            return listManager.GetListInternal(instance.DataItemClass).OfType<T>().Where(predicate).ToList();
        }
        public static IList<T> GetList<T, TKey>(Func<T, TKey> order) where T : IDataItem, new()
        {
            T instance = new T();
            ListManager listManager = ServiceManager.GetService<ListManager>();
            return listManager.GetListInternal(instance.DataItemClass).OfType<T>().OrderBy(order).ToList();
        }
        public static IList<T> GetList<T>() where T : IDataItem, new()
        {
            T instance = new T();
            ListManager listManager = ServiceManager.GetService<ListManager>();
            return listManager.GetListInternal(instance.DataItemClass).OfType<T>().ToList();
        }
    }
}
