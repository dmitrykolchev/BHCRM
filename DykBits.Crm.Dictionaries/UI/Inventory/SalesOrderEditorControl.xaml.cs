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
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI.Inventory
{
    /// <summary>
    /// Interaction logic for SalesOrderEditorControl.xaml
    /// </summary>
    public partial class SalesOrderEditorControl : MasterDetailsControlBase
    {
        public SalesOrderEditorControl()
        {
            InitializeComponent();
        }

        private SalesOrder Document
        {
            get { return (SalesOrder)this.DataSource; }
        }

        protected override void WireEvents()
        {
            base.WireEvents();
            this.docBudget.SelectionChanged += docBudget_SelectionChanged;
        }

        void docBudget_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.docBudget.SelectedItem != null)
                this.Document.CustomerId = ((BudgetView)this.docBudget.SelectedItem).AccountId;
        }

        protected override void UnwireEvents()
        {
            base.UnwireEvents();
            this.docBudget.SelectionChanged -= docBudget_SelectionChanged;
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Document.StoragePlaceId != 0 && !this.Document.IsReadOnly;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.grid != null && this.grid.SelectedItem != null && !this.Document.IsReadOnly;
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddItem();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteItem();
        }
        private void DeleteItem()
        {
            Document.Lines.Remove((SalesOrderLine)this.grid.SelectedItem);
        }

        private void AddItem()
        {
            InventoryBalanceFilter filter = new InventoryBalanceFilter {  StoragePlaceId = Document.StoragePlaceId, States = new byte[] { (byte)ProductState.Active } };
            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(InventoryBalanceSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<InventoryBalance>();
                SalesOrderLine newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        newItem = new SalesOrderLine
                        {
                            ProductId = item.Id,
                            Amount = 1,
                            Cost = item.Cost.GetValueOrDefault(),
                            Price = item.ListPrice
                        };
                        this.Document.Lines.Add(newItem);
                    }
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.SelectedItem = newItem;
                }
            }
        }

        private void DocumentPicker_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {

        }

        private void DocumentPicker_RequestFilterData_1(object sender, RequestFilterDataEventArgs e)
        {
            var filter = (AccountFilter)e.DataSourceFilter;
            filter.AccountTypeId = AccountType.CustomerFlag;
            filter.States = new byte[] { (byte)AccountTypeState.Active };
            filter.Presentation = AccountFilter.AllAccountsPresentation;
        }
    }
}
