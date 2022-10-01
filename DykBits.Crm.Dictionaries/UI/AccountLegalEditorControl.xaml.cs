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
using Microsoft.Win32;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for AccountLegalEditorControl.xaml
    /// </summary>
    public partial class AccountLegalEditorControl : EditorControlBase
    {
        public AccountLegalEditorControl()
        {
            InitializeComponent();
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account account = (Account)DataSource;
                account.ShippingAddressCity = account.BillingAddressCity;
                account.ShippingAddressCountry = account.BillingAddressCountry;
                account.ShippingAddressPostalCode = account.BillingAddressPostalCode;
                account.ShippingAddressRegion = account.BillingAddressRegion;
                account.ShippingAddressStreet = account.BillingAddressStreet;
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
    }
}
