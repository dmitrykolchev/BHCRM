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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProductFilterControl.xaml
    /// </summary>
    public partial class ProductFilterControl : DataViewFilterControl
    {
        public ProductFilterControl()
        {
            InitializeComponent();
        }

        private void docSupplier_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = (AccountFilter)e.DataSourceFilter;
            filter.Presentation = AccountFilter.AllAccountsPresentation;
            filter.AccountTypeId = AccountType.SupplierFlag;
        }
    }
}
