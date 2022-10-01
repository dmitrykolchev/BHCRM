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
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for IncomeTypeEditorControl.xaml
    /// </summary>
    public partial class BudgetItemEditorControl : MasterDetailsControlBase
    {
        public BudgetItemEditorControl()
        {
            InitializeComponent();
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.details != null && this.details.SelectedItem != null;
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
            var document = (BudgetItem)this.DataSource;
            document.Lines.Remove((BudgetItemProductCategory)this.details.SelectedItem);
        }

        private void AddItem()
        {
            DocumentSelectorWindow window = new DocumentSelectorWindow();
            window.DataControl = new ProductCategoryGridControl();

            window.AddItemCallback = new Action<object>((t) =>
            {
                var document = (BudgetItem)this.DataSource;
                ProductCategoryView item = (ProductCategoryView)t;
                document.Lines.Add(new BudgetItemProductCategory { ProductCategoryId = item.Id });
            });
            window.ShowDialog();
        }
    }
}
