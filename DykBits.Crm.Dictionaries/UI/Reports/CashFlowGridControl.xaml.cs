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
    /// Interaction logic for CashFlowGridControl.xaml
    /// </summary>
    public partial class CashFlowGridControl : DataGridControlBase
    {
        public CashFlowGridControl()
        {
            InitializeComponent();
            this.Loaded += CashFlowGridControl_Loaded;
        }

        void CashFlowGridControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= CashFlowGridControl_Loaded;
            ((TreeListView)this.gridView.View).ExpandAllNodes();
            this.Filter = (t) => { return !((CashFlowItem)t).IsEmpty || ((CashFlowItem)t).Level < 3; };
        }

        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {

        }
    }
}
