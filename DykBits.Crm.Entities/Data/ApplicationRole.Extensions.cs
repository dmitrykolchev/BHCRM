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
    partial class ApplicationRole: IApplicationRole
    {
        public const string ApplicationUser = "ApplicationUser";
        public const string SecurityAdministrator = "SecurityAdministrator";
        public const string SuperUser = "SuperUser";
        public const string SalesManager = "SalesManager";
        public const string HeadOfSales = "HeadOfSales";
        public const string AccountManager = "AccountManager";
        public const string ReadOnlyUser = "ReadOnlyUser";
        public const string ProductManager = "ProductManager";
        public const string BudgetTemplateManager = "BudgetTemplateManager";
        public const string Accountant = "Accountant";
        public const string ChiefAccountant = "ChiefAccountant";
        public const string EventManager = "EventManager";
        public const string ChiefEventManager = "ChiefEventManager";
        public const string Storekeeper = "Storekeeper";
        public const string ChiefStorekeeper = "ChiefStorekeeper";

        private ObservableCollection<UserApplicationRole> _users;
        public ObservableCollection<UserApplicationRole> Users
        {
            get
            {
                if (this._users == null)
                {
                    this._users = new ObservableCollection<UserApplicationRole>();
                    this._users.CollectionChanged += _users_CollectionChanged;
                }
                return this._users;
            }
        }
        void _users_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Users");
        }
    }
}
