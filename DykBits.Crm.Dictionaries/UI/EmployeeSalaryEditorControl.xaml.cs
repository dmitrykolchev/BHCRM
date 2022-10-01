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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class EmployeeSalaryEditorControl : MasterDetailsControlBase
    {
        public EmployeeSalaryEditorControl()
        {
            InitializeComponent();
        }

        private Employee Document
        {
            get { return (Employee)this.DataSource; }
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.grid != null && this.grid.SelectedItem != null;
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddRow();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteRow();
        }
        private void AddRow()
        {
            Document.Salaries.Add(new EmployeeSalary { ActiveFrom = DateTime.Today, CashValue = 0, Value = 0 });
        }

        private void DeleteRow()
        {
            Document.Salaries.Remove((EmployeeSalary)this.grid.SelectedItem);
        }
    }
}
