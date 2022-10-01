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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProductCostStatementEditorControl.xaml
    /// </summary>
    public partial class ProductCostStatementEditorControl : MasterDetailsControlBase
    {
        public ProductCostStatementEditorControl()
        {
            InitializeComponent();
        }
        private ProductCostStatement Document
        {
            get { return (ProductCostStatement)this.DataSource; }
        }

        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Document != null && !Document.IsReadOnly;
            e.Handled = true;
        }

        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddProducts();
        }

        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Document != null && !Document.IsReadOnly && this.lines != null && this.lines.SelectedItem != null;
            base.CanDeleteRow(e);
        }

        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            this.Document.Lines.Remove((ProductCostStatementLine)this.lines.SelectedItem);
        }

        private void AddProducts()
        {
            ProductFilter filter = new ProductFilter { ProductTypeId = ProductType.Service, States = new byte[] { (byte)ProductState.Active } };

            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(ProductSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<ProductView>();
                ProductCostStatementLine newItem = null;
                this.Document.Lines.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        newItem = new ProductCostStatementLine
                        {
                            ProductId = item.Id,
                            Cost = item.StandardCost
                        };
                        this.Document.Lines.Add(newItem);
                    }
                }
                finally
                {
                    this.lines.EndDataUpdate();
                    this.lines.SelectedItem = newItem;
                }
            }
        }
    }
}
