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
    /// Interaction logic for InvoiceByBudgetItemGridControl.xaml
    /// </summary>
    public partial class InvoiceByBudgetItemGridControl : DataGridControlBase
    {
        public InvoiceByBudgetItemGridControl()
        {
            InitializeComponent();
        }
        private void StandardTableView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.Column == columnInvoiceValue)
            {
                e.Cancel = !((InvoiceByBudgetItemItem)e.Row).InvoiceValue.HasValue;
                e.Handled = true;
            }
        }
        private InvoiceByBudgetItemFilter FilterInternal
        {
            get { return (InvoiceByBudgetItemFilter)this.DataSourceFilter; }
        }
        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (InvoiceByBudgetItemItem)this.GridView.SelectedItem;
            if (selectedItem.Direction == -1)
            {
                var window = DataGridWindow.Create("Полученные счета", typeof(PurchaseInvoiceGridControl), new PurchaseInvoiceFilter
                {
                    PeriodStart = this.FilterInternal.PeriodStart,
                    PeriodEnd = this.FilterInternal.PeriodEnd,
                    OrganizationId = this.FilterInternal.OrganizationId,
                    AllStates = this.FilterInternal.AllStates,
                    States = (byte[])this.FilterInternal.States.Clone(),
                    BudgetItemGroupIdIsSet = true,
                    BudgetItemGroupId = selectedItem.BudgetItemGroupId,
                    BudgetItemIdIsSet = true,
                    BudgetItemId = selectedItem.BudgetItemId
                });
                window.Show();
            }
            else
            {
                var window = DataGridWindow.Create("Полученные счета", typeof(SalesInvoiceGridControl), new SalesInvoiceFilter
                {
                    PeriodStart = this.FilterInternal.PeriodStart,
                    PeriodEnd = this.FilterInternal.PeriodEnd,
                    OrganizationId = this.FilterInternal.OrganizationId,
                    AllStates = this.FilterInternal.AllStates,
                    States = (byte[])this.FilterInternal.States.Clone(),
                    BudgetItemGroupIdIsSet = true,
                    BudgetItemGroupId = selectedItem.BudgetItemGroupId,
                    BudgetItemIdIsSet = true,
                    BudgetItemId = selectedItem.BudgetItemId
                });
                window.Show();
            }
        }
    }
}
