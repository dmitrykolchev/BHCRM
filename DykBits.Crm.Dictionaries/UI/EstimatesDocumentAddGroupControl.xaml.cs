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
    /// Interaction logic for EstimatesDocumentAddGroupControl.xaml
    /// </summary>
    public partial class EstimatesDocumentAddGroupControl : UserControl, ICommandTarget
    {
        public EstimatesDocumentAddGroupControl()
        {
            InitializeComponent();
        }

        private EstimatesDocumentSection Document
        {
            get
            {
                return (EstimatesDocumentSection)this.DataContext;
            }
        }

        public void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null && command.Id == UICommandId.OK)
            {
                e.CanExecute = !string.IsNullOrWhiteSpace(Document.FileAs) && Document.ProductCategoryId > 0;
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
                if (string.IsNullOrEmpty(Document.FileAs))
                {
                    Document.FileAs = ((IDataItem)this.comboProductCategory.SelectedItem).FileAs;
                }
            }
        }
    }
}
