using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(ApplicationRoleAccessRight))]
    partial class AccessRight: IAccessRight
    {
        public const string ViewAllAccountDetails = "ViewAllAccountDetails";

        private ObservableCollection<ApplicationRoleAccessRight> _roles;

        public ObservableCollection<ApplicationRoleAccessRight> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new ObservableCollection<ApplicationRoleAccessRight>();
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
