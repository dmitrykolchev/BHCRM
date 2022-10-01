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
using DevExpress.Data;
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for CalculationEditorControlMenuGrid.xaml
    /// </summary>
    public partial class CalculationEditorControlMenuGrid : CalculationDetailsEditorControlBase
    {
        public CalculationEditorControlMenuGrid()
        {
            InitializeComponent();
        }
        protected override void AddList()
        {
            CalculationStatementItem selectedItem = (CalculationStatementItem)this.grid.SelectedItem;
            CalculationStatementSectionItem section = selectedItem.SectionItem;
            MasterMenuFilter filter = new MasterMenuFilter { ProductCategoryId = section.ProductCategoryId, States = new byte[] { (byte)MasterMenuState.Active } };
            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(MasterMenuSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<MasterMenuView>();
                CalculationStatementLineItem newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        CalculationStatementLine line = new CalculationStatementLine
                        {
                            ProductId = item.Id,
                            FileAs = item.FileAs,
                            Comments = item.Comments,
                            Amount = 1,
                            Price = item.ListPrice,
                            Cost = item.StandardCost
                        };
                        newItem = this.Document.Items.Add(section, line);
                    }
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.SelectedItem = newItem;
                }
            }
        }
        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            CalculationStatementItem item = (CalculationStatementItem)e.Node.Content;
            if (item.ReadOnly)
            {
                e.Cancel = item.ReadOnly;
                e.Handled = true;
                return;
            }
            if (item.Level == 0)
            {
                e.Cancel = e.Column != columnFileAs && e.Column != columnComments;
                e.Handled = true;
            }
            else
            {
                if (e.Column == columnFileAs || e.Column == columnPrice || e.Column == columnCost)
                {
                    e.Cancel = item.ProductId != null;
                    e.Handled = true;
                }
            }
        }
        private void TreeListView_CellValueChanging(object sender, DevExpress.Xpf.Grid.TreeList.TreeListCellValueChangedEventArgs e)
        {
            TreeListView view = (TreeListView)sender;
            view.PostEditor();
        }
    }
}
