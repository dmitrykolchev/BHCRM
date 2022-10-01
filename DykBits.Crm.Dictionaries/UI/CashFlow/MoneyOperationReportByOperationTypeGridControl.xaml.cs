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

namespace DykBits.Crm.UI.CashFlow
{
    /// <summary>
    /// Interaction logic for MoneyOperationReportByOperationTypeGridControl.xaml
    /// </summary>
    public partial class MoneyOperationReportByOperationTypeGridControl : DataGridControlBase
    {
        public MoneyOperationReportByOperationTypeGridControl()
        {
            InitializeComponent();
        }

        private void DocumentPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoneyOperationReportByOperationTypeFilter filter = (MoneyOperationReportByOperationTypeFilter) this.DataSourceFilter;
            this.comboBankAccount.Filter = (t) => { return ((BankAccountView)t).AccountId == filter.OrganizationId; };
        }
    }
}
