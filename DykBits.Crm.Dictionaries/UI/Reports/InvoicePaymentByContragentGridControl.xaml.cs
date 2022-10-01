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
using DevExpress.Xpf.Grid;
using DykBits.Crm.Data;
using DykBits.Crm.UI.CashFlow;

namespace DykBits.Crm.UI.Reports
{
    /// <summary>
    /// Interaction logic for InvoicePaymentByContragentGridControl.xaml
    /// </summary>
    public partial class InvoicePaymentByContragentGridControl : DataGridControlBase
    {
        public InvoicePaymentByContragentGridControl()
        {
            InitializeComponent();
        }
        private void StandardTableView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.Column == columnPurchaseInvoiceValue)
            {
                e.Cancel = !((InvoicePaymentByContragentItem)e.Row).PurchaseInvoiceValue.HasValue;
                e.Handled = true;
            }
            else if (e.Column == columnSalesInvoiceValue)
            {
                e.Cancel = !((InvoicePaymentByContragentItem)e.Row).SalesInvoiceValue.HasValue;
                e.Handled = true;
            }
            else if (e.Column == columnSalesInvoicePayedValue)
            {
                e.Cancel = !((InvoicePaymentByContragentItem)e.Row).SalesInvoicePayedValue.HasValue;
                e.Handled = true;
            }
            else if (e.Column == columnPurchaseInvoicePayedValue)
            {
                e.Cancel = !((InvoicePaymentByContragentItem)e.Row).PurchaseInvoicePayedValue.HasValue;
                e.Handled = true;
            }
        }
        private InvoicePaymentByContragentFilter FilterInternal
        {
            get { return (InvoicePaymentByContragentFilter)this.DataSourceFilter; }
        }
        private void PurchaseInvoice_Click(object sender, RoutedEventArgs e)
        {
            var window = DataGridWindow.Create("Полученные счета", typeof(PurchaseInvoiceGridControl), new PurchaseInvoiceFilter
            {
                PeriodStart = this.FilterInternal.PeriodStart,
                PeriodEnd = this.FilterInternal.PeriodEnd,
                OrganizationId = this.FilterInternal.OrganizationId,
                AllStates = false,
                States = (byte[])this.FilterInternal.States.Clone(),
                AccountId = ((InvoicePaymentByContragentItem)this.GridView.SelectedItem).AccountId
            });
            window.Show();
        }
        private void SalesInvoice_Click(object sender, RoutedEventArgs e)
        {
            var window = DataGridWindow.Create("Выставленные счета", typeof(SalesInvoiceGridControl), new SalesInvoiceFilter
            {
                PeriodStart = this.FilterInternal.PeriodStart,
                PeriodEnd = this.FilterInternal.PeriodEnd,
                OrganizationId = this.FilterInternal.OrganizationId,
                AllStates = false,
                States = (byte[])this.FilterInternal.States.Clone(),
                AccountId = ((InvoicePaymentByContragentItem)this.GridView.SelectedItem).AccountId
            });
            window.Show();
        }

        private void PurchaseInvoicePayments_Click(object sender, RoutedEventArgs e)
        {
            var window = DataGridWindow.Create("Оплата поставщику", typeof(MoneyOperationGridControl), new MoneyOperationFilter
            {
                PeriodStart = null,
                PeriodEnd = null,
                OrganizationId = this.FilterInternal.OrganizationId,
                MoneyOperationDirection = MoneyOperationDirection.Outgoing,
                AllStates = false,
                States = new byte[] { (byte)MoneyOperationState.Draft, (byte)MoneyOperationState.Approved, (byte)MoneyOperationState.Executed },
                AccountId = ((InvoicePaymentByContragentItem)this.GridView.SelectedItem).AccountId
            });
            window.Show();

        }
        private void SalesInvoicePayments_Click(object sender, RoutedEventArgs e)
        {
            var window = DataGridWindow.Create("Платежи покупателя", typeof(MoneyOperationGridControl), new MoneyOperationFilter
            {
                PeriodStart = null,
                PeriodEnd = null,
                OrganizationId = this.FilterInternal.OrganizationId,
                MoneyOperationDirection = MoneyOperationDirection.Incoming,
                AllStates = false,
                States = new byte[] { (byte)MoneyOperationState.Draft, (byte)MoneyOperationState.Approved, (byte)MoneyOperationState.Executed },
                AccountId = ((InvoicePaymentByContragentItem)this.GridView.SelectedItem).AccountId
            });
            window.Show();
        }
    }
}
