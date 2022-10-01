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
    /// Interaction logic for UserEditorControl.xaml
    /// </summary>
    public partial class UserEditorControl : MasterDetailsControlBase
    {
        public UserEditorControl()
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
            var document = (User)this.DataSource;
            document.Roles.Remove((UserApplicationRole)this.items.SelectedItem);
        }
        private void AddItem()
        {
            DocumentSelectorWindow window = new DocumentSelectorWindow();
            try
            {
                window.DataControl = new ApplicationRoleGridControl();

                window.AddItemCallback = new Action<object>((t) =>
                {
                    var document = (User)this.DataSource;
                    var item = (ApplicationRoleView)t;
                    document.Roles.Add(new UserApplicationRole { UserId = document.Id, ApplicationRoleId = item.Id });
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
