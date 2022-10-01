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
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class MoneyOperationEditorControl : EditorControlBase
    {
        public MoneyOperationEditorControl()
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
            this.comboMoneyOperationType.Filter = (t) => { return ((MoneyOperationTypeView)t).Id != MoneyOperationType.CashReturn && ((MoneyOperationTypeView)t).Id != MoneyOperationType.CreditReturn; };
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
        private Control _customContentControl;
        private void InitializeOperationTypeControl()
        {
            switch (Document.MoneyOperationTypeId)
            {
                case MoneyOperationType.Advance:
                    this._customContentControl = new AdvanceUserControl();
                    this.advanceReport.Content = new AdvanceReportGridControl();
                    this.advanceReport.Visibility = System.Windows.Visibility.Visible;
                    break;
                case MoneyOperationType.Transfer:
                    this._customContentControl = new TransferUserControl();
                    this.advanceReport.Content = null;
                    this.advanceReport.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case MoneyOperationType.Credit:
                    this._customContentControl = new CreditUserControl();
                    this.advanceReport.Content = new CreditReturnGridControl();
                    this.advanceReport.Visibility = System.Windows.Visibility.Visible;
                    break;
                case MoneyOperationType.PaymentIn:
                    this._customContentControl = new PaymentInUserControl();
                    this.advanceReport.Content = null;
                    this.advanceReport.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case MoneyOperationType.PaymentOut:
                    this._customContentControl = new PaymentOutUserControl();
                    this.advanceReport.Content = null;
                    this.advanceReport.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case MoneyOperationType.Salary:
                    this._customContentControl = new SalaryUserControl();
                    this.advanceReport.Content = null;
                    this.advanceReport.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case MoneyOperationType.CreditIssue:
                    this._customContentControl = new CreditIssueUserControl();
                    this.advanceReport.Content = new CreditReturnGridControl();
                    this.advanceReport.Visibility = System.Windows.Visibility.Visible;
                    break;
                default:
                    this._customContentControl = null;
                    this.advanceReport.Content = null;
                    this.advanceReport.Visibility = System.Windows.Visibility.Collapsed;
                    break;
            }
            this.customContent.Content = this._customContentControl;
        }
    }
}
