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

namespace DykBits.Crm.UI.Operations
{
    /// <summary>
    /// Interaction logic for OperatingCalculationEditorControl.xaml
    /// </summary>
    public partial class OperatingCalculationEditorControl : MasterDetailsControlBase
    {
        public OperatingCalculationEditorControl()
        {
            InitializeComponent();
        }
        protected override void Initialize()
        {
            base.Initialize();
            this.comboBudgetItem.Filter = (t) => { return ((BudgetItemView)t).BudgetItemGroupType == BudgetItemGroupType.OperationsGroup && ((BudgetItemView)t).IsExpenseGroup; };
        }
        private OperatingCalculation Document
        {
            get { return (OperatingCalculation)this.DataSource; }
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Document != null && (!Document.IsReadOnly);
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            OperatingCalculationLine line = this.grid.SelectedItem as OperatingCalculationLine;
            e.CanExecute = e.CanExecute = Document != null && (!Document.IsReadOnly) && (line != null);
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.grid == null)
                return;
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.MoveUp:
                        {
                            OperatingCalculationLine line = this.grid.SelectedItem as OperatingCalculationLine;
                            e.CanExecute = line != null && line.CanMoveUp && !Document.IsReadOnly;
                            e.Handled = true;
                        }
                        break;
                    case UICommandId.MoveDown:
                        {
                            OperatingCalculationLine line = this.grid.SelectedItem as OperatingCalculationLine;
                            e.CanExecute = line != null && line.CanMoveDown && !Document.IsReadOnly;
                            e.Handled = true;
                        }
                        break;
                    case UICommandId.AddEmptyRow:
                        e.CanExecute = Document != null && (!Document.IsReadOnly);
                        e.Handled = true;
                        break;
                }
            }
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddRow();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteRow();
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    switch (command.Id)
                    {
                        case UICommandId.AddEmptyRow:
                            AddEmptyRow();
                            e.Handled = true;
                            break;
                        case UICommandId.MoveDown:
                            MoveDown();
                            e.Handled = true;
                            break;
                        case UICommandId.MoveUp:
                            MoveUp();
                            e.Handled = true;
                            break;
                    }
                }
        }
        private void AddEmptyRow()
        {
            var line = new OperatingCalculationLine { Amount = 1 };
            this.grid.BeginDataUpdate();
            try
            {
                Document.Lines.Add(line);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.SelectedItem = line;
            }
        }
        private void DeleteRow()
        {
            var line = (OperatingCalculationLine)this.grid.SelectedItem;
            this.grid.BeginDataUpdate();
            try
            {
                Document.Lines.Remove(line);
            }
            finally
            {
                this.grid.EndDataUpdate();
            }
        }
        private void AddRow()
        {
            var filter = new AccountFilter { States = new byte[] { (byte)ProductState.Active }, AccountTypeId = AccountType.SupplierFlag | AccountType.EmployeeFlag };

            SelectorDialogBox window = SelectorDialogBox.Create("Контрагенты", typeof(AccountSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<AccountView>();
                OperatingCalculationLine newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        var line = new OperatingCalculationLine
                        {
                            AccountId = item.Id,
                            FileAs = item.FileAs,
                            Amount = 1,
                        };
                        this.Document.Lines.Add(line);
                        newItem = line;
                    }
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.SelectedItem = newItem;
                }
            }
        }

        private void MoveUp()
        {
            this.grid.BeginDataUpdate();
            var line = (OperatingCalculationLine)this.grid.SelectedItem;
            try
            {
                Document.Lines.MoveUp(line);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = line;
            }
        }

        private void MoveDown()
        {
            this.grid.BeginDataUpdate();
            var line = (OperatingCalculationLine)this.grid.SelectedItem;
            try
            {
                Document.Lines.MoveDown(line);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = line;
            }
        }
        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            if (Document.IsReadOnly)
            {
                e.Cancel = true;
                e.Handled = true;
            }
            else
            {
                var line = (OperatingCalculationLine)e.Node.Content;
                if (e.Column == this.columnFileAs)
                {
                    e.Cancel = line.AccountId.HasValue;
                    e.Handled = true;
                }
            }
        }
        private void TreeListView_CellValueChanging(object sender, DevExpress.Xpf.Grid.TreeList.TreeListCellValueChangedEventArgs e)
        {
            ((TreeListView)this.grid.View).PostEditor();
        }
    }
}
