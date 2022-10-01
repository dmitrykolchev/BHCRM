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
using System.IO;
using DevExpress.Xpf.Grid;
using DykBits.Crm.Reports;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for CalculationStatementTemplateEditorControl.xaml
    /// </summary>
    public partial class CalculationStatementTemplateEditorControl : MasterDetailsControlBase
    {
        public CalculationStatementTemplateEditorControl()
        {
            InitializeComponent();
        }
        protected override void Initialize()
        {
            base.Initialize();
            this.comboIncomeBudgetItem.Filter = (t) => { return ((BudgetItemView)t).BudgetItemGroupId == BudgetItemGroup.Доходы_по_ОВД; };
            this.comboExpenseBudgetItem.Filter = (t) => { return ((BudgetItemView)t).BudgetItemGroupId == BudgetItemGroup.Расходы_по_ОВД; };
            this.columnDuration.Visible = IsDurationVisible;
        }
        public bool IsDurationVisible
        {
            get
            {
                switch(Document.ExpenseBudgetItemId.GetValueOrDefault())
                {
                    case BudgetItem.Расходы_по_ОВД_Персонал_Проведение:
                    case BudgetItem.Расходы_по_ОВД_Персонал_Производство:
                    case BudgetItem.Расходы_по_ОВД_Персонал_Склад:
                    case BudgetItem.Расходы_по_ОВД_Транспорт:
                        return true;
                }
                switch (Document.IncomeBudgetItemId.GetValueOrDefault())
                {
                    case BudgetItem.Доходы_по_ОВД_Персонал:
                    case BudgetItem.Доходы_по_ОВД_Транспорт:
                        return true;
                }
                return false;
            }
        }
        public CalculationStatementTemplate Document
        {
            get { return (CalculationStatementTemplate)this.DataSource; }
        }
        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            CalculationStatementTemplateItem item = (CalculationStatementTemplateItem)e.Node.Content;
            if (item.Level == 0)
            {
                e.Cancel = item.ReadOnly || 
                    (e.Column.Name != "columnFileAs" && 
                    e.Column.Name != "columnComments" && 
                    e.Column.Name != "columnDependsOnAmountOfPersons" && 
                    e.Column.Name != "columnDependsOnEventDuration");
            }
            else
            {
                if (item.ReadOnly)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (e.Column.Name == "columnFileAs")
                    {
                        e.Cancel = item.ProductId != null;
                    }
                }
            }
        }
        private bool CanExecuteAddRow()
        {
            if (this.grid != null)
            {
                CalculationStatementTemplateItem item = (CalculationStatementTemplateItem)this.grid.SelectedItem;
                return item != null && !item.SectionItem.ReadOnly;
            }
            return false;
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanExecuteAddRow();
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            if (this.grid != null)
            {
                CalculationStatementTemplateItem item = this.grid.SelectedItem as CalculationStatementTemplateItem;
                e.CanExecute = item != null && !item.ReadOnly;
            }
        }

        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddList();
        }

        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteItem();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        e.CanExecute = this.grid != null;
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        if (this.grid != null)
                        {
                            if (this.grid.SelectedItem is CalculationStatementTemplateItem)
                            {
                                CalculationStatementTemplateItem item = (CalculationStatementTemplateItem)this.grid.SelectedItem;
                                e.CanExecute = !item.ReadOnly && item.CanMoveUp;
                                e.Handled = true;
                            }
                        }
                        break;
                    case UICommandId.MoveDown:
                        if (this.grid != null)
                        {
                            if (this.grid.SelectedItem is CalculationStatementTemplateItem)
                            {
                                CalculationStatementTemplateItem item = (CalculationStatementTemplateItem)this.grid.SelectedItem;
                                e.CanExecute = !item.ReadOnly && item.CanMoveDown;
                                e.Handled = true;
                            }
                        }
                        break;
                    case UICommandId.AddEmptyRow:
                        e.CanExecute = CanExecuteAddRow();
                        e.Handled = true;
                        break;
                }
            }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        AddGroup();
                        e.Handled = true;
                        break;
                    case UICommandId.AddEmptyRow:
                        AddItem();
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        MoveUp();
                        e.Handled = true;
                        break;
                    case UICommandId.MoveDown:
                        MoveDown();
                        e.Handled = true;
                        break;
                }
            }
        }
        private void MoveUp()
        {
            this.grid.BeginDataUpdate();
            CalculationStatementTemplateItem item = (CalculationStatementTemplateItem)grid.SelectedItem;
            try
            {
                if (item is CalculationStatementTemplateSectionItem)
                    Document.Items.MoveUp((CalculationStatementTemplateSectionItem)item);
                else if (item is CalculationStatementTemplateLineItem)
                    Document.Items.MoveUp((CalculationStatementTemplateLineItem)item);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = item;
            }
        }
        private void MoveDown()
        {
            this.grid.BeginDataUpdate();
            CalculationStatementTemplateItem item = (CalculationStatementTemplateItem)grid.SelectedItem;
            try
            {
                if (item is CalculationStatementTemplateSectionItem)
                    Document.Items.MoveDown((CalculationStatementTemplateSectionItem)item);
                else if (item is CalculationStatementTemplateLineItem)
                    Document.Items.MoveDown((CalculationStatementTemplateLineItem)item);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = item;
            }
        }
        private void AddGroup()
        {
            CalculationStatementTemplateSection section = new CalculationStatementTemplateSection();
            ModalWindow window = ModalWindow.Create("Добавить раздел калькуляции", new CalculationStatementTemplateAddSectionControl(), section, this.ParentWindow);
            if (window.ShowDialog() == true)
            {
                this.grid.BeginDataUpdate();
                CalculationStatementTemplateSectionItem sectionItem = null;
                try
                {
                    sectionItem = Document.Items.Add(section);
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.RefreshData();
                    this.grid.SelectedItem = sectionItem;
                }
            }
            window.Close();
        }
        private void AddList()
        {
            CalculationStatementTemplateItem selectedItem = (CalculationStatementTemplateItem)this.grid.SelectedItem;
            CalculationStatementTemplateSectionItem section = selectedItem.SectionItem;
            ProductFilter filter = new ProductFilter { ProductCategoryId = section.ProductCategoryId, States = new byte[] { (byte)ProductState.Active } };
            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(ProductSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<ProductView>();
                CalculationStatementTemplateLineItem newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        CalculationStatementTemplateLine line = new CalculationStatementTemplateLine
                        {
                            ProductId = item.Id,
                            FileAs = item.FileAs,
                            Comments = item.Comments,
                            Amount = 1,
                            Price = Document.AmountOnly ? 0 : item.ListPrice,
                            Cost = Document.AmountOnly ? 0 : item.StandardCost
                        };
                        newItem = Document.Items.Add(section, line);
                    }
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.SelectedItem = newItem;
                }
            }
        }
        private void AddItem()
        {
            CalculationStatementTemplateItem selectedItem = (CalculationStatementTemplateItem)this.grid.SelectedItem;
            CalculationStatementTemplateLine line = new CalculationStatementTemplateLine();
            CalculationStatementTemplateLineItem newItem = null;
            this.grid.BeginDataUpdate();
            try
            {
                newItem = Document.Items.Add(selectedItem.SectionItem, line);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.SelectedItem = newItem;
            }
        }
        private void DeleteItem()
        {
            CalculationStatementTemplateItem selectedItem = (CalculationStatementTemplateItem)this.grid.SelectedItem;
            if (selectedItem is CalculationStatementTemplateLineItem)
            {
                this.grid.BeginDataUpdate();
                try
                {
                    Document.Items.Remove((CalculationStatementTemplateLineItem)selectedItem);
                }
                finally
                {
                    this.grid.EndDataUpdate();
                }
            }
            else
            {
                if (ApplicationManager.ShowQuestion("Предпринимается попытка удалить раздел калькуляции. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.grid.BeginDataUpdate();
                    try
                    {
                        Document.Items.Remove(selectedItem.SectionItem);
                    }
                    finally
                    {
                        this.grid.EndDataUpdate();
                    }
                }
            }
        }
        private void TreeListView_CellValueChanging(object sender, DevExpress.Xpf.Grid.TreeList.TreeListCellValueChangedEventArgs e)
        {
            TreeListView view = (TreeListView)sender;
            view.PostEditor();
        }
    }
}
