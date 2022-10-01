using System;
using System.ComponentModel;
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
    public partial class ServiceRequestEditorControl : EditorControlBase
    {
        public ServiceRequestEditorControl()
        {
            InitializeComponent();
            this.Loaded += ServiceRequestEditorControl_Loaded;
            this.Unloaded += ServiceRequestEditorControl_Unloaded;
        }

        void ServiceRequestEditorControl_Unloaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.RemoveEventListener(documentManager_DocumentOperationComplete);
        }

        void ServiceRequestEditorControl_Loaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.AddEventListener(documentManager_DocumentOperationComplete);
        }
        void documentManager_DocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if (e.Data.DataItemClass == ProjectMember.DataItemClassName)
            {
                if (CrmApplicationCommands.Refresh.CanExecute(null, ParentWindow))
                    CrmApplicationCommands.Refresh.Execute(null, ParentWindow);
            }
        }

        protected override void WireEvents()
        {
            this.numericAmountOfGuests.EditValueChanged += numericAmountOfGuests_EditValueChanged;
            this.numericValue.EditValueChanged += numericValue_EditValueChanged;
            this.numericValuePerGuest.EditValueChanged += numericValuePerGuest_EditValueChanged;
            this.ParentWindow.DocumentStateChanging += ParentWindow_DocumentStateChanging;
            this.ParentWindow.DocumentStateChanged += ParentWindow_DocumentStateChanged;
        }

        protected override void UnwireEvents()
        {
            this.numericAmountOfGuests.EditValueChanged -= numericAmountOfGuests_EditValueChanged;
            this.numericValue.EditValueChanged -= numericValue_EditValueChanged;
            this.numericValuePerGuest.EditValueChanged -= numericValuePerGuest_EditValueChanged;
            this.ParentWindow.DocumentStateChanging -= ParentWindow_DocumentStateChanging;
            this.ParentWindow.DocumentStateChanged -= ParentWindow_DocumentStateChanged;
        }

        void ParentWindow_DocumentStateChanged(object sender, DocumentStateChangedEventArgs e)
        {
            
        }

        void ParentWindow_DocumentStateChanging(object sender, DocumentStateChangingEventArgs e)
        {
            if (ApplicationManager.ShowWarning("Изменить состояние", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                ServiceRequestChangeStateData data = new ServiceRequestChangeStateData { Comments = "Hello, world!" };
                e.ApplicationData = data;
            }
        }

        private ServiceRequest Document
        {
            get { return (ServiceRequest)this.DataSource; }
        }

        private bool _recursive;

        private void numericValue_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (!this._recursive)
            {
                this._recursive = true;
                try
                {
                    if (Document.AmountOfGuests.HasValue && e.NewValue is decimal && Document.AmountOfGuests.Value != 0)
                    {
                        Document.ValuePerGuest = (decimal)e.NewValue / Document.AmountOfGuests.Value;
                    }
                    else
                    {
                        Document.ValuePerGuest = 0;
                    }
                }
                finally
                {
                    this._recursive = false;
                }
            }
        }

        private void numericValuePerGuest_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (!this._recursive)
            {
                this._recursive = true;
                try
                {
                    if (Document.AmountOfGuests.HasValue && e.NewValue is decimal)
                    {
                        Document.Value = Document.AmountOfGuests.Value * (decimal)e.NewValue;
                    }
                    else
                    {
                        Document.Value = 0;
                    }
                }
                finally
                {
                    this._recursive = false;
                }
            }
        }

        private void numericAmountOfGuests_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (!this._recursive)
            {
                this._recursive = true;
                try
                {
                    if (e.NewValue is int)
                    {
                        Document.Value = Document.ValuePerGuest * (int)e.NewValue;
                    }
                    else
                    {
                        Document.Value = 0;
                    }
                }
                finally
                {
                    this._recursive = false;
                }
            }
        }

        private void DocumentPicker_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            ContactFilter filter = (ContactFilter)e.DataSourceFilter;
            if (Document.IsCustomer)
                filter.AccountId = this.Document.CustomerId;
            else if (Document.IsAgent)
                filter.AccountId = this.Document.AgentId;
            else if (Document.IsVenueProvider)
                filter.AccountId = this.Document.VenueProviderId;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.EditRow)
                {
                    EditProjectMember();
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.None)
                {
                    if (command.Text == "OpenEstimatesDocument")
                    {
                        OpenEstimatesDocument();
                        e.Handled = true;
                    }
                }
            }
        }

        private void OpenEstimatesDocument()
        {
            var document = DocumentManager.GetItem<EstimatesDocument>(this.Document.EstimatesDocumentId.Value);
            WindowManager.OpenDocument(document);
        }

        private void EditProjectMember()
        {
            ProjectMemberView item = (ProjectMemberView)this.listProjectMembers.SelectedItem;
            WindowManager.OpenDocument(item.GetKey());
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.EditRow)
                {
                    e.CanExecute = this.listProjectMembers != null && this.listProjectMembers.SelectedItem != null;
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.None)
                {
                    if (command.Text == "OpenEstimatesDocument")
                    {
                        e.CanExecute = this.Document.EstimatesDocumentId.HasValue;
                        e.Handled = true;
                    }
                }
            }
        }

        private void listProjectMembers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CrmApplicationCommands.EditRow.CanExecute(null, this))
                CrmApplicationCommands.EditRow.Execute(null, this);
        }

        private void listBudgets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BudgetView item = this.listBudgets.SelectedItem as BudgetView;
            if (item != null)
            {
                WindowManager.OpenDocument(item.GetKey());
            }
        }
    }
}
