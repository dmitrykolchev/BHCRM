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

namespace DykBits.Crm.UI.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryStatementEditorControl.xaml
    /// </summary>
    public partial class InventoryStatementEditorControl : MasterDetailsControlBase
    {
        public InventoryStatementEditorControl()
        {
            InitializeComponent();
        }

        private InventoryStatement Document
        {
            get { return (InventoryStatement)this.DataSource; }
        }

        private bool CanAddRow()
        {
            return this.Document != null && this.Document.StoragePlaceId != 0 && !this.Document.IsReadOnly;
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.Handled = CanAddRow();
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !this.Document.IsReadOnly && this.grid != null && this.grid.SelectedItem != null &&
                ((InventoryStatementLine)this.grid.SelectedItem).ExpectedAmount == 0;
        }

        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddRow();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteItem();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        e.CanExecute = CanAddRow();
                        e.Handled = true;
                        break;
                }
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        Generate();
                        e.Handled = true;
                        break;
                }
            }
        }

        private void DeleteItem()
        {
            this.Document.Lines.Remove((InventoryStatementLine)this.grid.SelectedItem);
        }

        private void AddRow()
        {
            ProductFilter filter = new ProductFilter { ProductTypeId = ProductType.Storable, States = new byte[] { (byte)ProductState.Active } };
            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(ProductSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<ProductView>();
                InventoryStatementLine newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        newItem = new InventoryStatementLine
                        {
                            ProductId = item.Id,
                            ExpectedAmount = 0,
                            Amount = 0,
                            Cost = item.StandardCost
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

        private void Generate()
        {
            InventoryBalanceDataAdapterProxy dataAdapter = new InventoryBalanceDataAdapterProxy();
            InventoryBalanceFilter filter = new InventoryBalanceFilter
            {
                States = new byte[] { (byte)ProductState.Active },
                StoragePlaceId = this.Document.StoragePlaceId
            };
            var items = dataAdapter.Browse(filter.ToXml()).Where(t => t.IncomingAmount.GetValueOrDefault() - t.OutgoingAmount.GetValueOrDefault() > 0);
            this.Document.Lines.Clear();
            foreach (var item in items)
            {
                InventoryStatementLine line = new InventoryStatementLine
                {
                    ProductId = item.Id,
                    ExpectedAmount = item.IncomingAmount.GetValueOrDefault() - item.OutgoingAmount.GetValueOrDefault(),
                    Amount = item.IncomingAmount.GetValueOrDefault() - item.OutgoingAmount.GetValueOrDefault(),
                    Cost = item.Cost.GetValueOrDefault()
                };
                this.Document.Lines.Add(line);
            }
        }

        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            TableView view = (TableView)sender;
            view.PostEditor();
        }
    }
}
