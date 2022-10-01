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
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI.Operations
{
    /// <summary>
    /// Interaction logic for PayrollEditorControl.xaml
    /// </summary>
    public partial class PayrollEditorControl : MasterDetailsControlBase
    {
        public PayrollEditorControl()
        {
            InitializeComponent();
        }
        protected override void Initialize()
        {
            base.Initialize();
            this.comboSalaryBudgetItem.Filter = (t) => { return ((BudgetItemView)t).BudgetItemGroupType == BudgetItemGroupType.OperationsGroup && ((BudgetItemView)t).IsExpenseGroup; };
            this.comboTaxBudgetItem.Filter = (t) => { return ((BudgetItemView)t).BudgetItemGroupType == BudgetItemGroupType.OperationsGroup && ((BudgetItemView)t).IsExpenseGroup; };
            this.comboCashingBudgetItem.Filter = (t) => { return ((BudgetItemView)t).BudgetItemGroupType == BudgetItemGroupType.OperationsGroup && ((BudgetItemView)t).IsExpenseGroup; };
        }
        private TaxRateView IncomeTaxRate
        {
            get
            {
                return ListManager.GetItem<TaxRateView>(TaxRate.IncomeTaxRate);
            }
        }
        private TaxRateView SocialTaxRate
        {
            get
            {
                return ListManager.GetItem<TaxRateView>(TaxRate.SocialTaxRate);
            }
        }

        private decimal ExtraCostRate
        {
            get
            {
                var item = (ExtraCostRateView)comboExtraCostRate.SelectedItem;
                if (item == null)
                    return 0;
                return item.Value;
            }
        }

        protected override void UnwireEvents()
        {
            this.comboExtraCostRate.SelectionChanged -= comboExtraCostRate_SelectionChanged;
        }
        protected override void WireEvents()
        {
            this.comboExtraCostRate.SelectionChanged += comboExtraCostRate_SelectionChanged;
        }

        void comboExtraCostRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in Document.Items.Where(t => t.Level == 1))
            {
                item.Cashing = (item.SalaryTotal - item.SalaryBase) * ExtraCostRate / (1 - ExtraCostRate);
            }
        }

        private Payroll Document
        {
            get { return (Payroll)this.DataSource; }
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
        }
        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            if (Document.IsReadOnly)
            {
                e.Cancel = true;
                e.Handled = true;

            }
            else
            {
                var line = (PayrollItemBase)e.Node.Content;
                if (line.Level == 0)
                {
                    e.Cancel = true;
                    e.Handled = true;
                }
                else if (line.Level == 1)
                {
                    if (e.Column == columnFileAs)
                    {
                        e.Cancel = line.EmployeeId.HasValue;
                        e.Handled = true;
                    }
                }
            }
        }
        private void TreeListView_CellValueChanging(object sender, DevExpress.Xpf.Grid.TreeList.TreeListCellValueChangedEventArgs e)
        {
            TreeListView view = (TreeListView)sender;
            view.PostEditor();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
