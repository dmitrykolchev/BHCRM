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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for BeverageSelectorGridControl.xaml
    /// </summary>
    public partial class BeverageSelectorGridControl : SelectorGridControl
    {
        public BeverageSelectorGridControl()
        {
            InitializeComponent();
        }

        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            ((DataViewBase)sender).PostEditor();
        }
    }
}
