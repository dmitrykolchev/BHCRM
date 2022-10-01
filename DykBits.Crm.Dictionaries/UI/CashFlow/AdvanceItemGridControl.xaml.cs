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

namespace DykBits.Crm.UI.CashFlow
{
    /// <summary>
    /// Interaction logic for AdvanceItemGridControl.xaml
    /// </summary>
    public partial class AdvanceItemGridControl : DataGridControlBase
    {
        public AdvanceItemGridControl()
        {
            InitializeComponent();
        }

        protected override bool CanOpenSelectedItem()
        {
            return this.HasSelectedItems;
        }

        protected override void OnOpenEditorWindow(IDataItem item)
        {
            WindowManager.OpenDocument(item.GetKey());
        }
    }
}
