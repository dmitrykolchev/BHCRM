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
    /// Interaction logic for AccessRightEditorControl.xaml
    /// </summary>
    public partial class AccessRightEditorControl : MasterDetailsControlBase
    {
        public AccessRightEditorControl()
        {
            InitializeComponent();
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
            AccessRight document = (AccessRight)this.DataSource;
            document.Roles.Remove((ApplicationRoleAccessRight)this.items.SelectedItem);
        }

        private void AddItem()
        {
            DocumentSelectorWindow window = new DocumentSelectorWindow();
            window.DataControl = new ApplicationRoleGridControl();

            window.AddItemCallback = new Action<object>((t) =>
                {
                    AccessRight document = (AccessRight)this.DataSource;
                    ApplicationRoleView item = (ApplicationRoleView)t;
                    document.Roles.Add(new ApplicationRoleAccessRight { AccessRightId = document.Id, ApplicationRoleId = item.Id });
                });
            window.ShowDialog();
        }
    }
}
