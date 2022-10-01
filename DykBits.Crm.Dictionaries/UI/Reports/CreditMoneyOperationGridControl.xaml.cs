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
    /// Interaction logic for CreditMoneyOperationGridControl.xaml
    /// </summary>
    public partial class CreditMoneyOperationGridControl : DataGridControlBase
    {
        public CreditMoneyOperationGridControl()
        {
            InitializeComponent();
        }
        protected override bool CanOpenSelectedItem()
        {
            return HasSelectedItems && WindowManager.IsEditorExists(SelectedDataItem);
        }
        protected override void OnOpenEditorWindow(IDataItem item)
        {
            base.OnOpenEditorWindow(item);
        }
    }
}
