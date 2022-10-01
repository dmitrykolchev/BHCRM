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
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class BudgetTemplateEditorControl : EditorControlBase
    {
        public BudgetTemplateEditorControl()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();
            TreeListView view = (TreeListView)gridBudget.View;
            view.ExpandAllNodes();
            DocumentManager.AddEventListener(documentManager_DocumentOperationComplete);
        }

        private BudgetTemplate Document
        {
            get { return (BudgetTemplate)this.DataSource; }
        }

        void documentManager_DocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            if (e.Data is CalculationStatementTemplate && Document != null)
            {
                Document.RefreshItems();
            }
        }

        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            e.Cancel = e.Node.Level < 2;
        }

        private CalculationStatementTemplate FindOrCreateCalculationTemplate(Nullable<int> incomeBudgetItemId, Nullable<int> expenseBudgetItemId)
        {
            CalculationStatementTemplateDataAdapterProxy dataAdapter = new CalculationStatementTemplateDataAdapterProxy();
            BudgetTemplate budgetTemplate = (BudgetTemplate)this.DataSource;
            return dataAdapter.FindOrCreate(budgetTemplate, incomeBudgetItemId, expenseBudgetItemId);
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

        private void OpenCalculationTemplate()
        {
            BudgetTemplateLineProxy item = (BudgetTemplateLineProxy)this.gridBudget.SelectedItem;
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
            IDataItem document = FindOrCreateCalculationTemplate(incomeBudgetItemId, expenseBudgetItemId);
            WindowManager.OpenDocument(document);
        }


        private void StandardCell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.DataSource.State == 0)
                {
                    throw new ApplicationException("Необходимо сохранить шаблон ПРС.");
                }
                OpenCalculationTemplate();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.None:
                        if (command.Text == "CreateTemplateCopy")
                        {
                            CreateTemplateCopy();
                            e.Handled = true;
                        }
                        break;
                    case UICommandId.AddRow:
                        AddBudgetItem();
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        DeleteBudgetItem();
                        e.Handled = true;
                        break;
                }
            }
        }
        private void CreateTemplateCopy()
        {
            if (ParentWindow.ValidateDirtyState() == false)
                return;
            BudgetTemplateDataAdapterProxy dataAdapter = new BudgetTemplateDataAdapterProxy();
            BudgetTemplate copy = dataAdapter.CreateCopy(this.Document.GetKey());

            var ctDataAdapter = new CalculationStatementTemplateDataAdapterProxy();
            var ctFilter = (CalculationStatementTemplateFilter)ctDataAdapter.CreateFilter(this.Document, null);
            var cts = ctDataAdapter.Browse(ctFilter.ToXml());
            var ctCopies = new List<CalculationStatementTemplate>();
            foreach (var ct in cts)
            {
                ctCopies.Add(ctDataAdapter.CreateCopy(ct.GetKey()));
            }

            copy = dataAdapter.Save(copy);

            foreach (var item in ctCopies)
            {
                item.BudgetTemplateId = copy.Id;
                ctDataAdapter.Save(item);
            }
            DocumentManager.InvokeDocumentOperationComplete(DocumentOperation.Save, copy);
            WindowManager.OpenDocument(copy.GetKey());
        }

        private void AddBudgetItem()
        {
        }

        private void DeleteBudgetItem()
        {
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.None:
                        if (command.Text == "CreateTemplateCopy")
                        {
                            e.CanExecute = !Document.IsNew;
                            e.Handled = true;
                        }
                        break;
                    case UICommandId.AddRow:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        if (this.gridBudget != null)
                        {
                            BudgetTemplateLineProxy line = this.gridBudget.SelectedItem as BudgetTemplateLineProxy;
                            if (line != null)
                            {
                                e.CanExecute = line.Level == 2;
                            }
                        }
                        e.Handled = true;
                        break;
                }
            }
        }
    }
}
