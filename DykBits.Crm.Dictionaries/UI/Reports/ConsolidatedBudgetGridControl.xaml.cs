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

namespace DykBits.Crm.UI.Reports
{
    /// <summary>
    /// Interaction logic for ConsolidatedBudgetGridControl.xaml
    /// </summary>
    public partial class ConsolidatedBudgetGridControl : DataGridControlBase
    {
        public ConsolidatedBudgetGridControl()
        {
            InitializeComponent();
            this.Loaded += ConsolidatedBudgetGridControl_Loaded;
        }

        void ConsolidatedBudgetGridControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ConsolidatedBudgetGridControl_Loaded;
            ((TreeListView)this.gridView.View).ExpandAllNodes();
        }

        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {

        }
    }
}
