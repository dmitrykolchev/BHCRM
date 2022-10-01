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

namespace DykBits.Crm.UI.CashFlow
{
    /// <summary>
    /// Interaction logic for PaymentInUserControl.xaml
    /// </summary>
    public partial class PaymentInUserControl : UserControl
    {
        public PaymentInUserControl()
        {
            InitializeComponent();
        }
        private MoneyOperation Document
        {
            get
            {
                return (MoneyOperation)this.DataContext;
            }
        }
        private void docAccount_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = (AccountFilter)e.DataSourceFilter;
            filter.Presentation = "AllAccounts";
            filter.States = new byte[] { (byte)AccountState.Active };
            filter.AccountTypeId = AccountType.CustomerFlag;
        }
        private void docSalesInvoice_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            if (this.Document.OrganizationId != 0)
                ((SalesInvoiceFilter)e.DataSourceFilter).OrganizationId = this.Document.OrganizationId;
            if (this.Document.AccountId != 0)
                ((SalesInvoiceFilter)e.DataSourceFilter).AccountId = this.Document.AccountId;
        }
    }
}
