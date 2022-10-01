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
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for EstimatesTemplateSelectorControl.xaml
    /// </summary>
    public partial class EstimatesTemplateSelectorControl : UserControl, ICommandTarget
    {
        public EstimatesTemplateSelectorControl()
        {
            InitializeComponent();
            Loaded += EstimatesTemplateSelectorControl_Loaded;
        }
        void EstimatesTemplateSelectorControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.list.SetCurrentValue(ListBox.SelectedIndexProperty, 0);
        }
        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CrmApplicationCommands.OK.CanExecute(null, Window.GetWindow(this)))
                CrmApplicationCommands.OK.Execute(null, Window.GetWindow(this));
        }
        public void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null && command.Id == UICommandId.OK)
            {
                e.CanExecute = list.SelectedItem != null;
                e.Handled = true;
            }
        }
        public void Executed(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null && command.Id == UICommandId.OK)
            {
                e.Handled = true;
            }
        }
    }
}
