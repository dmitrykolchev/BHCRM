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
using PresentationNodeData = DykBits.Crm.Data.PresentationNode;

namespace DykBits.Crm.UI.Configuration
{
    /// <summary>
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class PresentationNodeEditorControl : EditorControlBase
    {
        public PresentationNodeEditorControl()
        {
            InitializeComponent();
            this.Loaded += PresentationNodeEditorControl_Loaded;
            this.Unloaded += PresentationNodeEditorControl_Unloaded;
        }
        void PresentationNodeEditorControl_Unloaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.RemoveEventListener(OnDocumentOperationComplete);
        }
        void PresentationNodeEditorControl_Loaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.AddEventListener(OnDocumentOperationComplete);
        }
        private void OnDocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if (e.Key.DocumentType == PresentationNodeData.DataItemClassName)
                Document.Views.Refresh();
        }
        PresentationNodeData Document
        {
            get { return (PresentationNodeData)this.DataSource; }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddRow:
                        PresentationNodeData newItem = DocumentManager.CreateItem<PresentationNodeData>(this.DataSource);
                        newItem.ParentId = Document.Id;
                        WindowManager.OpenDocument(newItem);
                        e.Handled = true;
                        break;
                    case UICommandId.EditRow:
                        PresentationNodeView editItem = this.listViews.SelectedItem as PresentationNodeView;
                        WindowManager.OpenDocument(editItem.GetKey());
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        PresentationNodeView deleteItem = this.listViews.SelectedItem as PresentationNodeView;
                        DocumentManager.DeleteItem(deleteItem);
                        e.Handled = true;
                        break;
                    case UICommandId.None:
                        if (command.Text == "AddRole")
                        {
                            AddRole();
                            e.Handled = true;
                        }
                        else if (command.Text == "DeleteRole")
                        {
                            DeleteRole();
                            e.Handled = true;
                        }
                        else if (command.Text == "PropagateToChildren")
                        {
                            PropagateToChildren();
                            e.Handled = true;
                        }
                        break;
                }
            }
        }
        private void PropagateToChildren()
        {
            throw new NotImplementedException();
        }
        private void AddRole()
        {
            DocumentSelectorWindow window = new DocumentSelectorWindow();
            try
            {
                window.DataControl = new ApplicationRoleGridControl();
                window.AddItemCallback = new Action<object>((t) =>
                {
                    var item = (ApplicationRoleView)t;
                    Document.Roles.Add(new PresentationNodeApplicationRole { PresentationNodeId = Document.Id, ApplicationRoleId = item.Id });
                });
                window.ShowDialog();
            }
            finally
            {
                window.Close();
            }
        }
        private void DeleteRole()
        {
            Document.Roles.Remove((PresentationNodeApplicationRole)this.gridRoles.SelectedItem);
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddRow:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                    case UICommandId.EditRow:
                        e.CanExecute = listViews.SelectedItem != null;
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        e.CanExecute = listViews.SelectedItem != null;
                        e.Handled = true;
                        break;
                    case UICommandId.None:
                        if (command.Text == "AddRole")
                        {
                            e.CanExecute = true;
                            e.Handled = true;
                        }
                        else if (command.Text == "DeleteRole")
                        {
                            e.CanExecute = this.gridRoles != null && this.gridRoles.SelectedItem != null;
                            e.Handled = true;
                        }
                        else if (command.Text == "PropagateToChildren")
                        {
                            e.CanExecute = true;
                            e.Handled = true;
                        }
                        break;
                }
            }
        }

        private void DocumentPicker_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            PresentationNodeFilter filter = (PresentationNodeFilter)e.DataSourceFilter;
            filter.NodeTypes = new int[] { PresentationNodeType.Folder, PresentationNodeType.PresentationSet };
            filter.AllNodeTypes = false;
            filter.AllNodes = true;
        }
    }
}
