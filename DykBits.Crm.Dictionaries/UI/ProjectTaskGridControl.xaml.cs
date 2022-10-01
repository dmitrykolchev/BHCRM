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
using System.Dynamic;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for EmployeeGridControl.xaml
    /// </summary>
    public partial class ProjectTaskGridControl : DataGridControlBase
    {
        public ProjectTaskGridControl()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                UICommand command = e.Command as UICommand;
                if (command.Id == UICommandId.None)
                {
                    switch (command.Text)
                    {
                        case "CreateTasksFromTemplate":
                            e.CanExecute = ParentWindow != null && (ParentWindow.DataContext is Project || ParentWindow.DataContext is ServiceRequest);
                            e.Handled = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                UICommand command = e.Command as UICommand;
                if (command.Id == UICommandId.None)
                {
                    switch (command.Text)
                    {
                        case "CreateTasksFromTemplate":
                            CreateTasksFromProjectTemplate();
                            e.Handled = true;
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void CreateTasksFromProjectTemplate()
        {
            dynamic data = new ExpandoObject();
            data.ProjectTemplateId = null;
            if (UserControlDialogBox.ShowDialog(Window.GetWindow(this), new ProjectTemplateSelectorControl(), "Выберите шаблон проекта", data) == true)
            {
                if(this.DataContext is ServiceRequest)
                    ProjectDataAdapterProxy.CreateTasksFromProjectTemplate((ServiceRequest)this.DataContext, data.ProjectTemplateId);
                else if(this.DataContext is Project)
                    ProjectDataAdapterProxy.CreateTasksFromProjectTemplate((Project)this.DataContext, data.ProjectTemplateId);

                if (CrmApplicationCommands.Refresh.CanExecute(null, this.ParentWindow))
                {
                    CrmApplicationCommands.Refresh.Execute(null, ParentWindow);
                }
            }
        }
    }
}
