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
    /// Interaction logic for SalesInvoiceEditorControl.xaml
    /// </summary>
    public partial class SalesInvoiceEditorControl : EditorControlBase
    {
        public SalesInvoiceEditorControl()
        {
            InitializeComponent();
        }

        private SalesInvoice Document
        {
            get { return (SalesInvoice)this.DataSource; }
        }

        private void DocumentPicker_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = e.DataSourceFilter as AccountFilter;
            filter.AccountTypeId = AccountType.CustomerFlag | AccountType.EmployeeFlag | AccountType.Organization;
            filter.ExcludedAccountTypeId = 0;
            filter.States = new byte[] { (byte)AccountState.Active };
            filter.Presentation = AccountFilter.AllAccountsPresentation;
        }

        private void documentServiceRequest_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            ServiceRequestFilter filter = e.DataSourceFilter as ServiceRequestFilter;
            if (this.documentOrganization.SelectedValue is int)
                filter.OrganizationId = (int)this.documentOrganization.SelectedValue;
        }
    }
}
