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
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for EmployeeGridControl.xaml
    /// </summary>
    public partial class ProjectMemberGridControl : DataGridControlBase
    {
        public ProjectMemberGridControl()
        {
            InitializeComponent();
        }
        protected override void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.Create)
                {
                    e.CanExecute = false;
                    e.Handled = true;
                    return;
                }
            }
            base.CanExecute(e);
        }
    }
}
