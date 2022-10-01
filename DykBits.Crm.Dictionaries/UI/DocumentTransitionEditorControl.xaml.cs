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
    /// Interaction logic for DocumentTransitionEditorControl.xaml
    /// </summary>
    public partial class DocumentTransitionEditorControl : MasterDetailsControlBase
    {
        public DocumentTransitionEditorControl()
        {
            InitializeComponent();
        }

        private DocumentTransition Document
        {
            get { return (DocumentTransition) this.DataSource; }
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.items != null && this.items.SelectedItem != null;
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddItem();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteItem();
        }
        private void DeleteItem()
        {
            Document.Roles.Remove((DocumentTransitionAccess)this.items.SelectedItem);
        }
        private void AddItem()
        {
            DocumentSelectorWindow window = new DocumentSelectorWindow();
            try
            {
                window.DataControl = new ApplicationRoleGridControl();
                window.AddItemCallback = new Action<object>((t) =>
                {
                    var item = (ApplicationRoleView)t;
                    Document.Roles.Add(new DocumentTransitionAccess { DocumentTransitionId = Document.Id, ApplicationRoleId = item.Id });
                });
                window.ShowDialog();
            }
            finally
            {
                window.Close();
            }
        }
    }
}
