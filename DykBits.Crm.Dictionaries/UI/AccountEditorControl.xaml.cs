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
using Microsoft.Win32;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for AccountEditorControl.xaml
    /// </summary>
    public partial class AccountEditorControl : EditorControlBase
    {
        public AccountEditorControl()
        {
            InitializeComponent();
            this.Unloaded += AccountEditorControl_Unloaded;
        }

        void AccountEditorControl_Unloaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.RemoveEventListener(OnDocumentOperationComplete);
        }

        protected override void Initialize()
        {
            base.Initialize();
            DocumentManager.AddEventListener(OnDocumentOperationComplete);
            comboBudgetItem.Filter = (t) =>
            {
                BudgetItemView item = (BudgetItemView)t;
                return item.IsExpenseGroup && item.Id != BudgetItem.Расходы_по_ОВД_НДС && item.Id != BudgetItem.Прочие_расходы_НДС && item.BudgetItemGroupType == BudgetItemGroupType.ProjectsGroup;
            };
        }
        void OnDocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if (e.Data is Contact && this.DataSource != null && this.DataSource.State != 0)
            {
                if (((Contact)e.Data).AccountId == this.DataSource.Id)
                {
                    if (this.DataSource is Venue)
                    {
                        ((Venue)this.DataSource).Contacts.Refresh();
                    }
                    else if (this.DataSource is Account)
                    {
                        ((Account)this.DataSource).Contacts.Refresh();
                    }
                }
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (CrmApplicationCommands.EditRow.CanExecute(null, this))
                    CrmApplicationCommands.EditRow.Execute(null, this);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    if (command.Id == UICommandId.AddRow)
                    {
                        e.CanExecute = DataSource.State != 0;
                        e.Handled = true;
                    }
                    else if (command.Id == UICommandId.EditRow)
                    {
                        e.CanExecute = listContacts.SelectedItem != null;
                        e.Handled = true;
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
                if (command != null)
                {
                    if (command.Id == UICommandId.AddRow)
                    {
                        AddContact();
                        e.Handled = true;
                    }
                    else if (command.Id == UICommandId.EditRow)
                    {
                        OpenContact();
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void OpenContact()
        {
            if (listContacts.SelectedItem != null)
            {
                WindowManager.OpenDocument(((IDataItem)listContacts.SelectedItem).GetKey());
            }
        }

        private void AddContact()
        {
            WindowManager.CreateDocument(DocumentManager.GetMetadata<Contact>(), this.DataSource);
        }
    }
}
