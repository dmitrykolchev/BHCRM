using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class ItemPropertyChangedEventArgs<TItem>: EventArgs
    {
        private TItem _item;
        private string _propertyName;
        public ItemPropertyChangedEventArgs(TItem item, string propertyName)
        {
            this._item = item;
            this._propertyName = propertyName;
        }
        public TItem Item
        {
            get { return this._item; }
        }
        public string PropertyName
        {
            get { return this._propertyName; }
        }
    }
    public abstract class DetailDataItemCollection<TOwner, TItem>: ObservableCollection<TItem> where TItem: DetailDataItem<TOwner>
    {
        private TOwner _owner;
        private int _inDataUpdate;
        protected DetailDataItemCollection(TOwner owner)
        {
            this._owner = owner;
        }
        public TOwner Owner
        {
            get { return this._owner; }
        }
        protected override void InsertItem(int index, TItem item)
        {
            item.Parent = this._owner;
            base.InsertItem(index, item);
            item.PropertyChanged += item_PropertyChanged;
        }
        void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnItemPropertyChanged(new ItemPropertyChangedEventArgs<TItem>((TItem)sender, e.PropertyName));
        }
        protected virtual void OnItemPropertyChanged(ItemPropertyChangedEventArgs<TItem> e)
        {
            ((INotifyObject)this._owner).InvokePropertyChanged("Item[]");
        }
        protected override void RemoveItem(int index)
        {
            TItem item = this[index];
            item.PropertyChanged -= item_PropertyChanged;
            base.RemoveItem(index);
            item.Parent = default(TOwner);
        }
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(this._inDataUpdate == 0)
                base.OnCollectionChanged(e);
        }

        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(this._inDataUpdate == 0)
                base.OnPropertyChanged(e);
        }

        public void BeginDataUpdate()
        {
            this._inDataUpdate++;
        }

        public void EndDataUpdate()
        {
            if (this._inDataUpdate == 0)
                throw new InvalidOperationException();
            this._inDataUpdate--;
            if(this._inDataUpdate == 0)
                base.OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
        }
    }
}
