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
using System.Windows.Shapes;
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for LogonWindow.xaml
    /// </summary>
    public partial class LogonWindow : DevExpress.Xpf.Core.DXWindow
    {
        public LogonWindow()
        {
            InitializeComponent();
        }

        public static void VerifyConnection(string connectionString, string identity)
        {
            RemoteConnectionManager connectionManager = new RemoteConnectionManager(connectionString, identity);
            var connection = connectionManager.CreateConnection();
            connection.Ping("Hello World!");
        }

        public static void VerifyBlobConnection(string connectionString, string identity)
        {
            BlobServiceConnectionManager connectionManager = new BlobServiceConnectionManager(connectionString, identity);
            var connection = connectionManager.CreateConnection();
            connection.CreateMessageId();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.OK)
                {
                    SigninData data = (SigninData)this.DataContext;
                    data.Password = this.textPassword.Password;

                    try
                    {
                        VerifyConnection(data.ConnectionStringBuilder.ConnectionString, data.EndpointIdentity);
                        VerifyBlobConnection(data.BlobConnectionStringBuilder.ConnectionString, data.EndpointIdentity);
                        this.DialogResult = true;
                        e.Handled = true;
                    }
                    catch (Exception ex)
                    {
                        if (!data.ConnectionStringBuilder.IntegratedSecurity)
                            ApplicationManager.ShowError(new CrmApplicationException("Ошибка при входе в систему. Возможно неверно указаны имя пользователя и/или пароль.", ex));
                        else
                            ApplicationManager.ShowError(new CrmApplicationException("Ошибка при входе в систему. Обратитесь к администратору.", ex));
                        this.DialogResult = null;
                        e.Handled = true;
                    }
                }
                else if (command.Id == UICommandId.Cancel)
                {
                    this.DialogResult = false;
                    e.Handled = true;
                }
            }
        }

        private bool ValidateData()
        {
            if (comboAuthenticationMode.SelectedIndex == 0)
            {
                return !string.IsNullOrEmpty(textDataSource.Text) && !string.IsNullOrEmpty(textBlobDataSource.Text) && !string.IsNullOrEmpty(textUserID.Text) && !string.IsNullOrEmpty(textPassword.Password);
            }
            else if (comboAuthenticationMode.SelectedIndex == 1)
            {
                return !string.IsNullOrEmpty(textDataSource.Text) && !string.IsNullOrEmpty(textBlobDataSource.Text);
            }
            return false;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.OK)
                {
                    e.CanExecute = ValidateData();
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.Cancel)
                {
                    e.CanExecute = true;
                    e.Handled = true;
                }
            }
        }
    }
}
