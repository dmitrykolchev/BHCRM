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
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class EstimatesTemplateEditorControl : EditorControlBase
    {
        public EstimatesTemplateEditorControl()
        {
            InitializeComponent();
        }

        private EstimatesTemplate Document
        {
            get { return (EstimatesTemplate)this.DataSource; }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.MoveDown:
                        e.CanExecute = this.grid != null && this.grid.SelectedItem != null && Document.Sections.IndexOf((EstimatesTemplateSection)this.grid.SelectedItem) < Document.Sections.Count - 1;
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        e.CanExecute = this.grid != null && this.grid.SelectedItem != null && Document.Sections.IndexOf((EstimatesTemplateSection)this.grid.SelectedItem) > 0;
                        e.Handled = true;
                        break;
                }
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            int index;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.MoveDown:
                        index = Document.Sections.IndexOf((EstimatesTemplateSection)this.grid.SelectedItem);
                        Document.Sections.Move(index, index + 1);
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        index = Document.Sections.IndexOf((EstimatesTemplateSection)this.grid.SelectedItem);
                        Document.Sections.Move(index, index - 1);
                        e.Handled = true;
                        break;
                }
            }
        }
    }
}
