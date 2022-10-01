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
    /// Interaction logic for OpportunityEditorControl.xaml
    /// </summary>
    public partial class ProjectEditorControl : EditorControlBase
    {
        public ProjectEditorControl()
        {
            InitializeComponent();
        }

        private Project Document
        {
            get { return (Project)this.DataSource; }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.Open:
                        e.CanExecute = Document != null && Document.HasServiceRequest;
                        e.Handled = true;
                        break;
                }
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.Open:
                        WindowManager.OpenDocument(ItemKey.CreateKey<ServiceRequest>(this.Document.ServiceRequestId.Value));
                        e.Handled = true;
                        break;
                }
            }
        }

        private void DocumentPicker_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            ContactFilter filter = (ContactFilter) e.DataSourceFilter;
            filter.AccountId = this.Document.AccountId;
        }

    }
}
