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
    /// Interaction logic for PurchaseInvoiceEditorControl.xaml
    /// </summary>
    public partial class PurchaseInvoiceEditorControl : EditorControlBase
    {
        public PurchaseInvoiceEditorControl()
        {
            InitializeComponent();
        }
        private PurchaseInvoice Document
        {
            get { return (PurchaseInvoice)this.DataSource; }
        }
        private void DocumentPicker_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = e.DataSourceFilter as AccountFilter;
            filter.AccountTypeId = AccountType.SupplierFlag | AccountType.EmployeeFlag | AccountType.Organization;
            filter.ExcludedAccountTypeId = 0;
            filter.States = new byte[] { (byte)AccountState.Active };
            filter.Presentation = AccountFilter.AllAccountsPresentation;
        }
        private void documentBudget_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            var filter = e.DataSourceFilter as BudgetFilter;
            filter.OrganizationId = Document.OrganizationId;
        }
    }
}
