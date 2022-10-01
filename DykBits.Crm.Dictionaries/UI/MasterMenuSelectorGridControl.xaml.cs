using System;
using System.Collections;
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
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for MasterMenuSelectorWindow.xaml
    /// </summary>
    public partial class MasterMenuSelectorGridControl : SelectorGridControl
    {
        public MasterMenuSelectorGridControl()
        {
            InitializeComponent();
        }
        private void TableView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            DataViewBase view = (DataViewBase)sender;
            view.PostEditor();
        }
    }
}
