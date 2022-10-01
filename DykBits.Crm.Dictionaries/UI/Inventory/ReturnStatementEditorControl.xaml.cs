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
using DevExpress.Xpf.Grid;

namespace DykBits.Crm.UI.Inventory
{
    /// <summary>
    /// Interaction logic for ReturnStatementEditorControl.xaml
    /// </summary>
    public partial class ReturnStatementEditorControl : MasterDetailsControlBase
    {
        public ReturnStatementEditorControl()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.docCustomer.RequestFilterData += docCustomer_RequestFilterData;
        }

        void docCustomer_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = (AccountFilter)e.DataSourceFilter;
            filter.States = new byte[] { (byte)AccountState.Active };
            filter.AccountTypeId = AccountType.CustomerFlag;
            filter.Presentation = AccountFilter.AllAccountsPresentation;
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.products != null && this.products.SelectedItem != null;
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddItem();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteItem();
        }
        private ReturnStatement Document
        {
            get { return (ReturnStatement)this.DataSource; }
        }
        private void DeleteItem()
        {
            Document.Lines.Remove((ReturnStatementLine)this.products.SelectedItem);
        }

        private void AddItem()
        {
            DocumentSelectorWindow window = new DocumentSelectorWindow();
            window.DataControl = new ProductGridControl();

            window.AddItemCallback = new Action<object>((t) =>
            {
                ProductView product = (ProductView)t;
                Document.Lines.Add(new ReturnStatementLine { ProductId = product.Id });
            });
            window.ShowDialog();
        }

        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            TableView view = (TableView)sender;
            view.PostEditor();
        }
    }
}
