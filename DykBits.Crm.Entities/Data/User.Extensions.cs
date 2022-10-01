using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(UserApplicationRole))]
    partial class User
    {
        private ObservableCollection<UserApplicationRole> _roles;

        public ObservableCollection<UserApplicationRole> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new ObservableCollection<UserApplicationRole>();
                    this._roles.CollectionChanged += _roles_CollectionChanged;
                }
                return this._roles;
            }
        }

        void _roles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Roles");
        }
    }


}
