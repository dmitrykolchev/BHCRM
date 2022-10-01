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
    /// Interaction logic for AdvanceReportEditorControl.xaml
    /// </summary>
    public partial class AdvanceReportEditorControl : EditorControlBase, ICommandTarget
    {
        public AdvanceReportEditorControl()
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
            this.comboMoneyOperationType.Filter = (t) => { return ((MoneyOperationTypeView)t).Id == MoneyOperationType.PaymentOut || ((MoneyOperationTypeView)t).Id == MoneyOperationType.CashReturn; };
            InitializeOperationTypeControl();
        }

        protected override void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
            base.OnDataSourceChanged(e);
            InitializeOperationTypeControl();
        }

        protected override void UnwireEvents()
        {
            base.UnwireEvents();
            comboMoneyOperationType.SelectionChanged -= comboMoneyOperationType_SelectionChanged;
        }

        protected override void WireEvents()
        {
            base.WireEvents();
            comboMoneyOperationType.SelectionChanged += comboMoneyOperationType_SelectionChanged;
        }

        void comboMoneyOperationType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeOperationTypeControl();
        }

        private void InitializeOperationTypeControl()
        {
            var organizationId = this.Document.OrganizationId;
            switch (Document.MoneyOperationTypeId)
            {
                case MoneyOperationType.PaymentOut:
                    this.customContent.Content = new PaymentOutUserControl();
                    break;
                case MoneyOperationType.CashReturn:
                    this.customContent.Content = null;
                    break;
            }
        }
    }
}
