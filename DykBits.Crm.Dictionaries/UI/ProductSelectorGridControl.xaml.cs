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
    /// Interaction logic for ProductSelectorGridControl.xaml
    /// </summary>
    public partial class ProductSelectorGridControl : SelectorGridControl
    {
        public ProductSelectorGridControl()
        {
            InitializeComponent();
        }
        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            DataViewBase view = (DataViewBase)sender;
            view.PostEditor();
        }
    }
}
