using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DykBits.Crm.Data
{
    public interface INotifyObject
    {
        void InvokePropertyChanged(string propertyName);
    }
    public abstract class NotifyObject : INotifyPropertyChanged, INotifyObject
    {
        protected NotifyObject()
        {
        }
        void INotifyObject.InvokePropertyChanged(string propertyName)
        {
            InvokePropertyChanged(propertyName);
        }
        protected void InvokePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
