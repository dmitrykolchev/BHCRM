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
    /// Interaction logic for WriteoffStatementEditorControl.xaml
    /// </summary>
    public partial class WriteoffStatementEditorControl : MasterDetailsControlBase
    {
        public WriteoffStatementEditorControl()
        {
            InitializeComponent();
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
        private WriteoffStatement Document
        {
            get { return (WriteoffStatement)this.DataSource; }
        }

        private void DeleteItem()
        {
            WriteoffStatement document = (WriteoffStatement)this.DataSource;
            document.Lines.Remove((WriteoffStatementLine)this.grid.SelectedItem);
        }

        private void AddItem()
        {
            InventoryBalanceFilter filter = new InventoryBalanceFilter { StoragePlaceId = Document.StoragePlaceId, States = new byte[] { (byte)ProductState.Active } };
            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(InventoryBalanceSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<InventoryBalance>();
                WriteoffStatementLine newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        newItem = new WriteoffStatementLine
                        {
                            ProductId = item.Id,
                            Amount = 1,
                            Cost = item.Cost.GetValueOrDefault()
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
    }
}
