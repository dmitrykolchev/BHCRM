using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for LeadConvertControl.xaml
    /// </summary>
    public partial class LeadConvertControl : UserControl, ICommandTarget
    {
        private Lead _dataSource;
        private Account _account;
        private Contact _contact;
        public LeadConvertControl()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Lead DataSource
        {
            get { return this._dataSource; }
            set
            {
                this._dataSource = value;
                OnDataSourceChanged();
            }
        }
        private void OnDataSourceChanged()
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();

            IDataAdapter accountDataAdapter = documentManager.CreateDataAdapterProxy(Account.DataItemClassName);
            this._account = (Account)accountDataAdapter.CreateItem(this.DataSource);
            this._account.PropertyChanged += OnDataPropertyChanged;

            IDataAdapter contactDataAdapter = documentManager.CreateDataAdapterProxy(Contact.DataItemClassName);
            this._contact = (Contact)contactDataAdapter.CreateItem(this.DataSource);
            this._contact.PropertyChanged += OnDataPropertyChanged;

            this.accountControl.DataContext = this._account;
            this.contactControl.DataContext = this._contact;
        }
        private void OnDataPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
        void ICommandTarget.CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.OK:
                    case UICommandId.Cancel:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                }
            }
        }

        void ICommandTarget.Executed(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.OK:
                        SaveData();
                        e.Handled = true;
                        break;
                }
            }
        }

        private void SaveData()
        {
            Account result = DocumentManager.SaveItem(this._account);
            this._contact.AccountId = result.Id;
            DocumentManager.SaveItem(this._contact);
            DocumentManager.ChangeDocumentState(this.DataSource, (byte)LeadState.Converted, null);
        }
    }
}
