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
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class CalculationStatementEditorControl : MasterDetailsControlBase
    {
        public CalculationStatementEditorControl()
        {
            InitializeComponent();
        }
        private CalculationStatement Document
        {
            get { return (CalculationStatement)this.DataSource; }
        }
        private IDetailsControl _detailsControl;
        public bool IsDurationVisible
        {
            get
            {
                switch (Document.ExpenseBudgetItemId.GetValueOrDefault())
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
        private IDetailsControl CreateDetailsControl()
        {
            if (IsDurationVisible)
                return new CalculationEditorControlWorkPlanGrid();
            if (Document.IncomeBudgetItemId == BudgetItem.Доходы_по_ОВД_Меню || Document.ExpenseBudgetItemId == BudgetItem.Расходы_по_ОВД_Продукты)
                return new CalculationEditorControlGrid(); //return new CalculationEditorControlMenuGrid();
            if (Document.IncomeBudgetItemId == BudgetItem.Доходы_по_ОВД_Напитки_алкогольные || Document.IncomeBudgetItemId == BudgetItem.Доходы_по_ОВД_Напитки_безалкогольные ||
                Document.ExpenseBudgetItemId == BudgetItem.Расходы_по_ОВД_Напитки_алкогольные || Document.ExpenseBudgetItemId == BudgetItem.Расходы_по_ОВД_Напитки_безалкогольные)
                return new CalculationEditorControlGrid();  //return new CalculationEditorControlBeveragesGrid();
            return new CalculationEditorControlGrid();
        }
        public override string GetReportSelector()
        {
            if (IsDurationVisible)
                return "Schedule";
            return "Standard";
        }
        protected override void Initialize()
        {
            this._detailsControl = CreateDetailsControl();
            this.content.Content = this._detailsControl;
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            if (this._detailsControl != null)
                this._detailsControl.CanExecute(e);
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            if (this._detailsControl != null)
                this._detailsControl.CanExecute(e);
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            if (this._detailsControl != null)
                this._detailsControl.Executed(e);
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            if (this._detailsControl != null)
                this._detailsControl.Executed(e);
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(this._detailsControl != null)
                this._detailsControl.CanExecute(e);
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this._detailsControl != null)
                this._detailsControl.Executed(e);
        }
    }
}
