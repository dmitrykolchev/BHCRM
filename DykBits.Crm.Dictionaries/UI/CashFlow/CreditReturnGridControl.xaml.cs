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
using DevExpress.Xpf.Grid;

namespace DykBits.Crm.UI.CashFlow
{
    /// <summary>
    /// Interaction logic for CreditReturnGridControl.xaml
    /// </summary>
    public partial class CreditReturnGridControl : UserControl
    {
        public CreditReturnGridControl()
        {
            InitializeComponent();
            this.Loaded += AdvanceReportGridControl_Loaded;
        }

        void AdvanceReportGridControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
            DocumentManager.AddEventListener(OnDocumentOperationComplete);
        }

        private void OnDocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if (e.Key.DocumentType == MoneyOperation.DataItemClassName)
                RefreshGrid();
        }

        private MoneyOperation Document
        {
            get { return (MoneyOperation)this.DataContext; }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddRow:
                        AddItem();
                        e.Handled = true;
                        break;
                    case UICommandId.EditRow:
                        EditItem();
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        DeleteItem();
                        e.Handled = true;
                        break;
                    case UICommandId.RefreshDetails:
                        RefreshGrid();
                        e.Handled = true;
                        break;
                }
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddRow:
                        e.CanExecute = Document != null && !Document.IsNew;
                        e.Handled = true;
                        break;
                    case UICommandId.EditRow:
                        e.CanExecute = Document != null && this.grid != null && this.grid.SelectedItem != null;
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        e.CanExecute = Document != null && this.grid != null && this.grid.SelectedItem != null;
                        e.Handled = true;
                        break;
                    case UICommandId.RefreshDetails:
                        e.CanExecute = Document != null && this.grid != null && !Document.IsNew;
                        e.Handled = true;
                        break;
                }
            }
        }

        private void RefreshGrid()
        {
            if(Document!= null && !Document.IsNew)
                this.grid.ItemsSource = Document.GetChildren();
        }

        private void AddItem()
        {
            MoneyOperation document = DocumentManager.CreateItem<MoneyOperation>(this.Document);
            if (this.Document.MoneyOperationTypeId == MoneyOperationType.Credit)
                WindowManager.OpenDocument(document, "CreditReturnWindow");
            else
                WindowManager.OpenDocument(document, "CreditIssueReturnWindow");
        }

        private void EditItem()
        {
            IDataItem dataItem = (IDataItem)this.grid.SelectedItem;
            MoneyOperation document = DocumentManager.GetItem<MoneyOperation>(dataItem.Id);
            if (this.Document.MoneyOperationTypeId == MoneyOperationType.Credit)
                WindowManager.OpenDocument(document, "CreditReturnWindow");
            else
                WindowManager.OpenDocument(document, "CreditIssueReturnWindow");
        }

        private void DeleteItem()
        {
            MessageBoxResult result = ApplicationManager.ShowWarning("Выделенный элемент будет удален без возможности восстановления.\r\nПродолжить?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (new WaitCursor())
                {
                    DocumentManager.DeleteItem((IDataItem)this.grid.SelectedItem);
                    CrmApplicationCommands.RefreshDetails.Execute(null, this);
                }
            }
        }

        private void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = grid.View.GetRowElementByMouseEventArgs(e);
            int rowHandle = grid.View.GetRowHandleByMouseEventArgs(e);
            if (rowHandle == GridControl.InvalidRowHandle)
            {
                TableView tableView = grid.View as TableView;
                TableViewHitInfo hitInfo = tableView.CalcHitInfo(e.OriginalSource as DependencyObject);
                if (hitInfo.HitTest == TableViewHitTest.DataArea)
                {
                    if (CrmApplicationCommands.AddRow.CanExecute(null, this))
                        CrmApplicationCommands.AddRow.Execute(null, this);
                }
            }
            else if (grid.IsGroupRowHandle(rowHandle))
            {
            }
            else if (grid.IsValidRowHandle(rowHandle))
            {
                if (CrmApplicationCommands.EditRow.CanExecute(null, this))
                    CrmApplicationCommands.EditRow.Execute(null, this);
            }
        }
    }
}
