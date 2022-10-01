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

namespace DykBits.Crm.UI.Reports
{
    /// <summary>
    /// Interaction logic for InvoiceByContragentGridControl.xaml
    /// </summary>
    public partial class InvoiceByContragentGridControl : DataGridControlBase
    {
        public InvoiceByContragentGridControl()
        {
            InitializeComponent();
        }
        private void StandardTableView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.Column == columnPurchaseInvoiceValue)
            {
                e.Cancel = !((InvoiceByContragentItem)e.Row).PurchaseInvoiceValue.HasValue;
                e.Handled = true;
            }
            else if (e.Column == columnSalesInvoiceValue)
            {
                e.Cancel = !((InvoiceByContragentItem)e.Row).SalesInvoiceValue.HasValue;
                e.Handled = true;
            }
        }
        private InvoiceByContragentFilter InvoiceFilter
        {
            get { return (InvoiceByContragentFilter)this.DataSourceFilter; }
        }
        private void PurchaseInvoice_Click(object sender, RoutedEventArgs e)
        {
            var window = DataGridWindow.Create("Полученные счета", typeof(PurchaseInvoiceGridControl), new PurchaseInvoiceFilter
            {
                PeriodStart = this.InvoiceFilter.PeriodStart,
                PeriodEnd = this.InvoiceFilter.PeriodEnd,
                OrganizationId = this.InvoiceFilter.OrganizationId,
                AllStates = this.InvoiceFilter.AllStates,
                States = (byte[])this.InvoiceFilter.States.Clone(),
                AccountId = ((InvoiceByContragentItem)this.GridView.SelectedItem).AccountId
            });
            window.Show();
        }
        private void SalesInvoice_Click(object sender, RoutedEventArgs e)
        {
            var window = DataGridWindow.Create("Выставленные счета", typeof(SalesInvoiceGridControl), new SalesInvoiceFilter
            {
                PeriodStart = this.InvoiceFilter.PeriodStart,
                PeriodEnd = this.InvoiceFilter.PeriodEnd,
                OrganizationId = this.InvoiceFilter.OrganizationId,
                AllStates = this.InvoiceFilter.AllStates,
                States = (byte[])this.InvoiceFilter.States.Clone(),
                AccountId = ((InvoiceByContragentItem)this.GridView.SelectedItem).AccountId
            });
            window.Show();
        }
    }
}
