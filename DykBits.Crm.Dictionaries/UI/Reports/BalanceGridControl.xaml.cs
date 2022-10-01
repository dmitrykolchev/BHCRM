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
    /// Interaction logic for BalanceGridControl.xaml
    /// </summary>
    public partial class BalanceGridControl : DataGridControlBase
    {
        public BalanceGridControl()
        {
            InitializeComponent();
            this.Loaded += BalanceGridControl_Loaded;
        }

        void BalanceGridControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= BalanceGridControl_Loaded;
            ((TreeListView)this.gridView.View).ExpandAllNodes();
        }

        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {

        }
    }
}
