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
using System.Dynamic;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for CalculationStatementTemplateAddGroupControl.xaml
    /// </summary>
    public partial class CalculationStatementTemplateAddSectionControl : UserControl, ICommandTarget
    {
        public CalculationStatementTemplateAddSectionControl()
        {
            InitializeComponent();
        }

        public void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null && command.Id == UICommandId.OK)
            {
                e.CanExecute = !string.IsNullOrWhiteSpace(textFileAs.Text) && comboProductCategory.SelectedValue != null;
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.comboProductCategory.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(textFileAs.Text))
                {
                    textFileAs.SetCurrentValue(TextBox.TextProperty, ((IDataItem)this.comboProductCategory.SelectedItem).FileAs);
                }
            }
        }
    }
}
