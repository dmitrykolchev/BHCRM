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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for OrganizationEditorControl.xaml
    /// </summary>
    public partial class OrganizationEditorControl : EditorControlBase
    {
        public OrganizationEditorControl()
        {
            InitializeComponent();
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Organization organization = (Organization)DataSource;
                organization.ShippingAddressCity = organization.BillingAddressCity;
                organization.ShippingAddressCountry = organization.BillingAddressCountry;
                organization.ShippingAddressPostalCode = organization.BillingAddressPostalCode;
                organization.ShippingAddressRegion = organization.BillingAddressRegion;
                organization.ShippingAddressStreet = organization.BillingAddressStreet;
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
    }
}
