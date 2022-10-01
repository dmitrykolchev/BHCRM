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

namespace DykBits.Crm.UI.CashFlow
{
    /// <summary>
    /// Interaction logic for TransferUserControl.xaml
    /// </summary>
    public partial class TransferUserControl : UserControl
    {
        public TransferUserControl()
        {
            InitializeComponent();
            this.Loaded += TransferUserControl_Loaded;
        }

        void TransferUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= TransferUserControl_Loaded;
        }

        internal Predicate<object> BankAccountFilter
        {
            set
            {
                comboDestinationBankAccount.Filter = value;
            }
        }
    }
}
