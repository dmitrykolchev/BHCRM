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
    /// Interaction logic for CreditUserControl.xaml
    /// </summary>
    public partial class CreditUserControl : UserControl
    {
        public CreditUserControl()
        {
            InitializeComponent();
        }

        private void docAccount_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = (AccountFilter)e.DataSourceFilter;
            filter.Presentation = "AllAccounts";
            filter.States = new byte[] { (byte)AccountState.Active };
            filter.AccountTypeId = AccountType.CustomerFlag | AccountType.EmployeeFlag | AccountType.OrgranizationFlag | AccountType.SupplierFlag;
        }
    }
}
