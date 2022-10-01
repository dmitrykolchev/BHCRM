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

namespace DykBits.Crm.UI.CashFlow
{
    /// <summary>
    /// Interaction logic for CreditReturnEditorControl.xaml
    /// </summary>
    public partial class CreditReturnEditorControl : EditorControlBase, ICommandTarget
    {
        public CreditReturnEditorControl()
        {
            InitializeComponent();
        }
        private MoneyOperation Document
        {
            get
            {
                return (MoneyOperation)this.DataSource;
            }
        }
        protected override void Initialize()
        {
            base.Initialize();
            this.comboMoneyOperationType.Filter = (t) => { return ((MoneyOperationTypeView)t).Id == MoneyOperationType.CreditReturn; };
        }
    }
}
