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
    /// Interaction logic for PaymentOutUserControl.xaml
    /// </summary>
    public partial class PaymentOutUserControl : UserControl
    {
        public PaymentOutUserControl()
        {
            InitializeComponent();
        }

        private EditorControlBase _parent;
        private EditorControlBase ParentControl
        {
            get
            {
                if (this._parent == null)
                    this._parent = Utils.FindVisualParent<EditorControlBase>(this);
                return this._parent;
            }
        }
        private MoneyOperation Document
        {
            get
            {
                return (MoneyOperation)ParentControl.DataSource;
            }
        }
        private void docInvoice_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            if (this.Document.OrganizationId != 0)
                ((PurchaseInvoiceFilter)e.DataSourceFilter).OrganizationId = this.Document.OrganizationId;
            if (this.Document.AccountId != 0)
                ((PurchaseInvoiceFilter)e.DataSourceFilter).AccountId = this.Document.AccountId;
        }

        private void docAccount_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = (AccountFilter)e.DataSourceFilter;
            filter.Presentation = "AllAccounts";
            filter.States = new byte[] { (byte)AccountState.Active };
            filter.AccountTypeId = AccountType.SupplierFlag;
        }
    }
}
