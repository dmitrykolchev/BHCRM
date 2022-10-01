using System;
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
    /// Interaction logic for AccountGridControl.xaml
    /// </summary>
    public partial class AccountGridControl : DataGridControlBase
    {
        private const string SetAccountAccessCommand = "SetAccountAccess";

        public AccountGridControl()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.None:
                        if (command.Text == SetAccountAccessCommand)
                        {
                            e.CanExecute = this.HasSelectedItems;
                            e.Handled = true;
                        }
                        break;
                }
            }
        }

        private void SetAccountAccess_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AccountChangeAccessData data = new AccountChangeAccessData();
            data.Accounts = this.GetSelectedDataItems();
            AccountChangeAccessControl control = new AccountChangeAccessControl();
            if (UserControlDialogBox.ShowDialog(ParentWindow, control, "Изменение доступа к контрагентам", data) == true)
            {
                AccountDataAdapterProxy dataAdapter = new AccountDataAdapterProxy();
                dataAdapter.ChangeAccessRights(data);
                if(CrmApplicationCommands.Refresh.CanExecute(null, this))
                    CrmApplicationCommands.Refresh.Execute(null, this);
            }
            e.Handled = true;
        }
    }
}
