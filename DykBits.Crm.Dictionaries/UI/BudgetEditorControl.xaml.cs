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
using DevExpress.Xpf.Grid;
using System.IO;
using DykBits.Crm.Reports;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for BudgetEditorControl.xaml
    /// </summary>
    public partial class BudgetEditorControl : EditorControlBase
    {
        public static readonly DependencyProperty IsStandardColumnsVisibleProperty = DependencyProperty.Register("IsStandardColumnsVisible", typeof(bool), typeof(BudgetEditorControl),
            new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public bool IsStandardColumnsVisible
        {
            get { return (bool)GetValue(IsStandardColumnsVisibleProperty); }
            set { SetValue(IsStandardColumnsVisibleProperty, value); }
        }
        public BudgetEditorControl()
        {
            InitializeComponent();
        }
        protected override void Initialize()
        {
            base.Initialize();
            DocumentManager.AddEventListener(documentManager_DocumentOperationComplete);
        }
        void documentManager_DocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if (e.Data is CalculationStatement || e.Data is MoneyOperation || e.Data is PurchaseInvoice || e.Data is SalesInvoice
                || e.Data is CalculationStatementView || e.Data is MoneyOperationView || e.Data is PurchaseInvoiceView || e.Data is SalesInvoiceView)
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
            if (ParentWindow != null && object.ReferenceEquals(ParentWindow.ActiveView, this))
            {
                if (CrmApplicationCommands.Refresh.CanExecute(null, ParentWindow))
                    CrmApplicationCommands.Refresh.Execute(null, ParentWindow);
            }
            else
            {
                this._requireRefresh = true;
            }
        }
        private Budget Document
        {
            get { return (Budget)this.DataSource; }
        }
        private CalculationStatement FindOrCreateCalculation(int stage, Nullable<int> incomeBudgetItemId, Nullable<int> expenseBudgetItemId)
        {
            CalculationStatementDataAdapterProxy dataAdapter = new CalculationStatementDataAdapterProxy();
            var found = dataAdapter.Find(Document, stage, incomeBudgetItemId, expenseBudgetItemId);
            if (found != null)
                return found;

            if (stage == CalculationStage.Actual)
            {
                var source = dataAdapter.Find(Document, CalculationStage.Planned, incomeBudgetItemId, expenseBudgetItemId);
                if (source == null)
                    throw new CrmApplicationException("Необходимо заполнить плановые показатели.");
                var actualCalculation = source.Clone();
                actualCalculation.CalculationStage = CalculationStage.Actual;
                return actualCalculation;
            }
            else if (stage == CalculationStage.Planned)
            {
                found = dataAdapter.Find(Document, CalculationStage.Standard, incomeBudgetItemId, expenseBudgetItemId);
                if (found != null)
                {
                    var plannedCalculation = found.Clone();
                    plannedCalculation.CalculationStage = CalculationStage.Planned;
                    return plannedCalculation;
                }
                return dataAdapter.Create(Document, stage, incomeBudgetItemId, expenseBudgetItemId);
            }
            else
                throw new CrmApplicationException("Норматив отсутствует. Для создания норматива используйте операцию 'Пересчитать норматив'");
        }
        private DocumentRecordCollection _budgetItems;
        private DocumentRecordCollection BudgetItems
        {
            get
            {
                if (this._budgetItems == null)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._budgetItems = listManager.GetList(BudgetItem.DataItemClassName);
                }
                return this._budgetItems;
            }
        }
        private DocumentRecordCollection _budgetItemLinks;
        private DocumentRecordCollection BudgetItemLinks
        {
            get
            {
                if (this._budgetItemLinks == null)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    this._budgetItemLinks = listManager.GetList(BudgetItemLink.DataItemClassName);
                }
                return this._budgetItemLinks;
            }
        }
        private void OpenCalculation(int stage)
        {
            BudgetLineProxy item = (BudgetLineProxy)this.gridBudget.SelectedItem;
            BudgetItemView budgetItem = (BudgetItemView)BudgetItems[item.BudgetItemId];
            BudgetItemLinkView link;
            Nullable<int> incomeBudgetItemId = null;
            Nullable<int> expenseBudgetItemId = null;
            if (budgetItem.BudgetItemGroupId == BudgetItemGroup.Доходы_по_ОВД || budgetItem.BudgetItemGroupId == BudgetItemGroup.Прочие_доходы)
            {
                link = BudgetItemLinks.OfType<BudgetItemLinkView>().Where(t => t.IncomeBudgetItemId == budgetItem.Id).SingleOrDefault();
                incomeBudgetItemId = budgetItem.Id;
                if (link != null)
                    expenseBudgetItemId = link.ExpenseBudgetItemId;
            }
            else
            {
                link = BudgetItemLinks.OfType<BudgetItemLinkView>().Where(t => t.ExpenseBudgetItemId == budgetItem.Id).SingleOrDefault();
                expenseBudgetItemId = budgetItem.Id;
                if (link != null)
                    incomeBudgetItemId = link.IncomeBudgetItemId;
            }
            IDataItem document = FindOrCreateCalculation(stage, incomeBudgetItemId, expenseBudgetItemId);
            WindowManager.OpenDocument(document);
        }

        private static readonly int[] VATItems = { BudgetItem.Доходы_по_ОВД_НДС, BudgetItem.Расходы_по_ОВД_НДС, BudgetItem.Прочие_доходы_НДС, BudgetItem.Прочие_расходы_НДС };
        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            if (e.Node.Level < 2)
            {
                e.Cancel = true;
            }
            else
            {
                switch (Document.State)
                {
                    case BudgetState.StandardApproved:
                        if (e.Column == columnStandardValue && e.Value == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                        break;
                    case BudgetState.PlannedApproved:
                        if (e.Column == columnPlannedValue && e.Value == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                        break;
                    case BudgetState.ActualApproved:
                        if (e.Column == columnActualValue && e.Value == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                        break;
                }
                BudgetLineProxy item = (BudgetLineProxy)e.Node.Content;
                if (VATItems.Contains(item.BudgetItemId))
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void StandardCell_Click(object sender, RoutedEventArgs e)
        {
            OpenCalculation(CalculationStage.Standard);
        }
        private void PlannedCell_Click(object sender, RoutedEventArgs e)
        {
            OpenCalculation(CalculationStage.Planned);
        }
        private void ActualCell_Click(object sender, RoutedEventArgs e)
        {
            OpenCalculation(CalculationStage.Actual);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.ExportToExcel:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                    case UICommandId.None:
                        if (command.Text == "RecalculateStandard")
                            e.CanExecute = true;
                        else if (command.Text == "CreateActual")
                            e.CanExecute = this.Document.State != BudgetState.ActualApproved;
                        else if (command.Text == "ChangeAmountOfGuests")
                            e.CanExecute = true;
                        else if (command.Text == "ShowStandardColumns")
                            e.CanExecute = true;
                        else if (command.Text == "SubmitAllCalculations")
                            e.CanExecute = Document != null && (Document.State == BudgetState.StandardApproved || Document.State == BudgetState.PlannedApproved);
                        else if (command.Text == "ApproveAllCalculations")
                            e.CanExecute = Document != null && (Document.State == BudgetState.StandardApproved || Document.State == BudgetState.PlannedApproved);
                        e.Handled = true;
                        break;
                }
            }
        }

        private void ChangeCalculationState(int calculationStage, CalculationStatementState fromState, CalculationStatementState toState)
        {
            using (new WaitCursor())
            {
                CalculationStatementFilter filter = new CalculationStatementFilter();
                filter.States = new byte[] { (byte)fromState };
                filter.CalculationStage = calculationStage;
                filter.BudgetId = Document.Id;
                var calculations = DocumentManager.Browse<CalculationStatementView>(filter);
                foreach (var calculation in calculations)
                {
                    DocumentManager.ChangeDocumentState(calculation, (byte)toState, null);
                }
                this.RefreshGrid();
            }
        }

        [CommandHandler("SubmitAllCalculations")]
        private void SubmitAllCalculations(ExecutedRoutedEventArgs e)
        {
            if (Document.State == BudgetState.StandardApproved)
            {
                if (ApplicationManager.ShowWarning("Будут отправлены на утверждение все калькуляции в колонке 'План'. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ChangeCalculationState(CalculationStage.Planned, CalculationStatementState.Draft, CalculationStatementState.Submitted);
                }
            }
            else if (Document.State == BudgetState.PlannedApproved)
            {
                if (ApplicationManager.ShowWarning("Будут отправлены на утверждение все калькуляции в колонке 'Факт'. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ChangeCalculationState(CalculationStage.Actual, CalculationStatementState.Draft, CalculationStatementState.Submitted);
                }
            }
            e.Handled = true;
        }

        [CommandHandler("ApproveAllCalculations")]
        private void ApproveAllCalculations(ExecutedRoutedEventArgs e)
        {
            if (Document.State == BudgetState.StandardApproved)
            {
                if (ApplicationManager.ShowWarning("Будут утверждены все калькуляции в колонке 'План'. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ChangeCalculationState(CalculationStage.Planned, CalculationStatementState.Submitted, CalculationStatementState.Approved);
                }
            }
            else if (Document.State == BudgetState.PlannedApproved)
            {
                if (ApplicationManager.ShowWarning("Будут утверждены все калькуляции в колонке 'Факт'. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ChangeCalculationState(CalculationStage.Actual, CalculationStatementState.Submitted, CalculationStatementState.Approved);
                }
            }
            e.Handled = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            StandardCommandHandler.HandleExecutedCommand(this, e);
            if (e.Handled)
                return;
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.Refresh:
                        this.gridBudget.BeginDataUpdate();
                        ((Budget)this.gridBudget.DataContext).RefreshItems();
                        this.gridBudget.EndDataUpdate();
                        this._requireRefresh = false;
                        break;
                    case UICommandId.ExportToExcel:
                        DataExport.ExportToExcel((TreeListView)this.gridBudget.View, this.Document.FileAs);
                        e.Handled = true;
                        break;
                }
            }
        }
        [CommandHandler("ShowStandardColumns")]
        private void ShowStandardColumns(ExecutedRoutedEventArgs e)
        {
            IsStandardColumnsVisible = !IsStandardColumnsVisible;
            if (IsStandardColumnsVisible)
            {
                columnActualToStandard.VisibleIndex = int.MaxValue;
                columnPlannedToStandard.VisibleIndex = int.MaxValue;
            }
            e.Handled = true;
        }
        [CommandHandler("ChangeAmountOfGuests")]
        private void ChangeAmountOfGuests(ExecutedRoutedEventArgs e)
        {
            this.popupAmountOfGuests.IsOpen = true;
            this.textNewAmountOfGuests.Focus();
            e.Handled = true;
        }
        [CommandHandler("CreateActual")]
        private void CreateActualCalculations(ExecutedRoutedEventArgs e)
        {
            if (ParentWindow.ValidateDirtyState(false) != false)
            {
                using (new WaitCursor())
                {
                    ((EditorWindow)ParentWindow).CommandLocks[CrmApplicationCommands.Refresh].Lock();
                    try
                    {
                        this.Document.CreateBudgetActual();
                    }
                    finally
                    {
                        ((EditorWindow)ParentWindow).CommandLocks[CrmApplicationCommands.Refresh].Unlock();
                    }
                    RefreshGrid();
                }
            }
            e.Handled = true;
        }
        [CommandHandler("RecalculateStandard")]
        private void RecreateStandardCalculations(ExecutedRoutedEventArgs e)
        {
            if (ParentWindow.ValidateDirtyState(false) != false)
            {
                using (new WaitCursor())
                {
                    this.Document.RecreateBudgetStandard();
                    RefreshGrid();
                }
            }
            e.Handled = true;
        }
        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.popupAmountOfGuests.IsOpen = false;
            if (this.Document.NewAmountOfGuests != this.Document.AmountOfGuests)
            {
                if (ApplicationManager.ShowQuestion("Изменено количество гостей, необходимо пересчитать нормативы и плановые показатели в ПРС.\r\n\r\nПродолжить?"))
                {
                    BudgetDataAdapterProxy dataAdapter = new BudgetDataAdapterProxy();
                    using (new WaitCursor())
                    {
                        dataAdapter.ChangeAmountOfGuests(this.Document.Id, this.Document.NewAmountOfGuests.Value);
                        CrmApplicationCommands.Refresh.Execute(this, ParentWindow);
                        this.Document.RecreateBudgetStandard();
                        RefreshGrid();
                    }
                }
            }
            else
            {
                ApplicationManager.ShowMessage("Количество гостей не изменилось. Никаких действий предпринято не будет.");
            }
        }
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Document.NewAmountOfGuests = null;
            this.popupAmountOfGuests.IsOpen = false;
        }
    }
}
