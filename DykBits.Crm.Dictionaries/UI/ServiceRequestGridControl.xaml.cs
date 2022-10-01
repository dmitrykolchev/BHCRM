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
    /// Interaction logic for ServiceRequestTypeGridControl.xaml
    /// </summary>
    public partial class ServiceRequestGridControl : DataGridControlBase
    {
        private const string ProjectMemberChangeCommand = "ProjectMemberChange";
        public ServiceRequestGridControl()
        {
            InitializeComponent();
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.None:
                        if (command.Text == ProjectMemberChangeCommand)
                        {
                            e.CanExecute = this.HasSelectedItems;
                            e.Handled = true;
                        }
                        break;
                }
            }
        }

        private void ProjectMemberChange_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ProjectMemberChangeData data = new ProjectMemberChangeData { IncludeInProject = true };
            data.Items = this.GetSelectedDataItems();
            ProjectMemberBatchChangerControl control = new ProjectMemberBatchChangerControl();
            if (UserControlDialogBox.ShowDialog(ParentWindow, control, "Изменение рабочей группы проекта", data) == true)
            {
                using (new WaitCursor())
                {
                    ServiceRequestDataAdapterProxy dataAdapter = new ServiceRequestDataAdapterProxy();
                    dataAdapter.ProjectMemberChange(data);
                    if (CrmApplicationCommands.Refresh.CanExecute(null, this))
                        CrmApplicationCommands.Refresh.Execute(null, this);
                }
            }
            e.Handled = true;
        }
    }
}
