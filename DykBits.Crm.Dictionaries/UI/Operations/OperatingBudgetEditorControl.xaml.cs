// Copyright (c) 2014-2015 Dmitry Kolchev
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
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
using System.Dynamic;
using DevExpress.Xpf.Grid;
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI.Operations
{
    /// <summary>
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class OperatingBudgetEditorControl : EditorControlBase
    {
        public OperatingBudgetEditorControl()
        {
            InitializeComponent();
            this.Loaded += OperatingBudgetEditorControl_Loaded;
            this.Unloaded += OperatingBudgetEditorControl_Unloaded;
        }
        void OperatingBudgetEditorControl_Unloaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.RemoveEventListener(documentManager_DocumentOperationComplete);
        }
        void OperatingBudgetEditorControl_Loaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.AddEventListener(documentManager_DocumentOperationComplete);
        }
        void documentManager_DocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if (e.Data is OperatingCalculation || e.Data is MoneyOperation || e.Data is PurchaseInvoice || e.Data is SalesInvoice
                || e.Data is Payroll)
            {
                RefreshGrid();
            }
        }
        protected override void OnActivate()
        {
            base.OnActivate();
            if (this._requireRefresh)
                RefreshGrid();
        }
        private bool _requireRefresh;
        private void RefreshGrid()
        {
            if (object.ReferenceEquals(ParentWindow.ActiveView, this))
            {
                this.gridBudget.BeginDataUpdate();
                ((OperatingBudget)this.gridBudget.DataContext).RefreshItems();
                this.gridBudget.EndDataUpdate();
                ((TreeListView)this.gridBudget.View).ExpandAllNodes();
                this._requireRefresh = false;
            }
            else
            {
                this._requireRefresh = true;
            }
        }
        private void ActualCell_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument(CalculationStage.Actual);
        }
        private void PlannedCell_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument(CalculationStage.Planned);
        }
        private void OpenDocument(int stage)
        {
            OperatingBudgetLine item = (OperatingBudgetLine)this.gridBudget.SelectedItem;
            var document = GetSingleDocumentItem(item.BudgetItemId.Value, stage);
            if(document != null)
                WindowManager.OpenDocument(ItemKey.CreateKey(document.DocumentTypeId, document.DocumentId));
        }
        private OperatingBudget Document
        {
            get { return (OperatingBudget)this.DataSource; }
        }
        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            OperatingBudgetLine line = (OperatingBudgetLine)e.Node.Content;
            if (line.Level < 2)
            {
                e.Cancel = true;
                e.Handled = true;
                return;
            }
            if (e.Column == columnPlannedValue && e.Value == null)
            {
                e.Cancel = true;
                e.Handled = true;
                return;
            }
            if (e.Column == columnActualValue && e.Value == null)
            {
                e.Cancel = true;
                e.Handled = true;
                return;
            }
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.None)
                {
                    switch (command.Text)
                    {
                        case "CreatePayroll":
                            e.CanExecute = Document.State == OperatingBudgetState.Draft || Document.State == OperatingBudgetState.PlannedApproved;
                            e.Handled = true;
                            break;
                        case "CreateCalculation":
                            e.CanExecute = Document.State == OperatingBudgetState.Draft || Document.State == OperatingBudgetState.PlannedApproved;
                            e.Handled = true;
                            break;
                        case "CreateInvoice":
                            e.CanExecute = true;
                            e.Handled = true;
                            break;
                        case "CreatePayment":
                            e.CanExecute = true;
                            e.Handled = true;
                            break;

                    }
                }
            }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.None)
                {
                    switch (command.Text)
                    {
                        case "CreatePayroll":
                            CreateDocument<Payroll>();
                            e.Handled = true;
                            break;
                        case "CreateCalculation":
                            CreateDocument<OperatingCalculation>();
                            e.Handled = true;
                            break;
                        case "CreateInvoice":
                            CreateInvoice();
                            e.Handled = true;
                            break;
                        case "CreatePayment":
                            CreatePayment();
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        private void CreateInvoice()
        {
            TreeListView view = (TreeListView)this.gridBudget.View;
            int[] selectedRowHandles = this.gridBudget.GetSelectedRowHandles();
            if (selectedRowHandles.Length > 0)
            {
                TreeListNode node = view.GetNodeByRowHandle(selectedRowHandles[0]);
                OperatingBudgetLine line = (OperatingBudgetLine)node.Content;
            }
        }
        private void CreatePayment()
        {
        }
        private IDataItem CreateDocumentCopy(OperatingBudgetDocumentItem documentItem)
        {
            var original = DocumentManager.GetItem(ItemKey.CreateKey(documentItem.DocumentTypeId, documentItem.DocumentId));
            var copy = (IOperatingBudgetDocument)(((ICloneable)original).Clone());
            copy.CalculationStage = CalculationStage.Actual;
            copy.DocumentDate = DateTime.Today;
            return (IDataItem)copy;
        }

        private OperatingBudgetDocumentItem GetSingleDocumentItem(int budgetItemId, int calculationStage)
        {
            var documents = OperatingBudgetDataAdapterProxy.GetDocumentList(this.Document, budgetItemId, calculationStage);
            if (documents.Count == 0)
                return null;

            if (documents.Count == 1)
                return documents[0];

            dynamic data = new ExpandoObject();

            data.Items = documents;
            data.SelectedItem = null;

            ModalWindow dialog = ModalWindow.Create("Выберите документ из списка", new OperatingBudgetDocumentSelectorControl(), data, ParentWindow);
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    return data.SelectedItem;
                }
            }
            finally
            {
                dialog.Close();
            }
            return null;
        }

        private void CreateDocument<T>() where T: IDataItem, new()
        {
            var line = (OperatingBudgetLine)this.gridBudget.SelectedItem;

            if (this.Document.State == OperatingBudgetState.PlannedApproved)
            {
                var documentItem = GetSingleDocumentItem(line.BudgetItemId.Value, CalculationStage.Planned);
                if (documentItem != null)
                {
                    WindowManager.OpenDocument(CreateDocumentCopy(documentItem));
                    return;
                }
            }
            var document = DocumentManager.CreateItem<T>(this.Document);
            if (line.BudgetItemId.HasValue)
            {
                ((IOperatingBudgetDocument)document).BudgetItemId = line.BudgetItemId.Value;
            }
            WindowManager.OpenDocument(document);
        }
    }
}
