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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ContactDetailsEditorControl.xaml
    /// </summary>
    public partial class ContactDetailsEditorControl : EditorControlBase
    {
        public ContactDetailsEditorControl()
        {
            InitializeComponent();
        }

        private void gridMarketingProgramTypes_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            try
            {
                ((DevExpress.Xpf.Grid.TableView)sender).PostEditor();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
    }
}
