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
using DevExpress.Xpf.Grid;
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI.Inventory
{
    /// <summary>
    /// Interaction logic for PurchaseOrderEditorControl.xaml
    /// </summary>
    public partial class PurchaseOrderEditorControl : MasterDetailsControlBase
    {
        public PurchaseOrderEditorControl()
        {
            InitializeComponent();
        }
        public PurchaseOrder Document
        {
            get { return (PurchaseOrder)this.DataSource; }
        }
        protected override void Initialize()
        {
            base.Initialize();
            this.docSupplier.RequestFilterData += docSupplier_RequestFilterData;
        }
        protected override void WireEvents()
        {
            base.WireEvents();
        }
        protected override void UnwireEvents()
        {
            base.UnwireEvents();
        }
        void docSupplier_RequestFilterData(object sender, RequestFilterDataEventArgs e)
        {
            AccountFilter filter = (AccountFilter)e.DataSourceFilter;
            filter.States = new byte[] { (byte)AccountState.Active };
            filter.Presentation = AccountFilter.AllAccountsPresentation;
            filter.AccountTypeId = AccountType.SupplierFlag;
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Document.StoragePlaceId != 0 && !this.Document.IsReadOnly;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.grid != null && this.grid.SelectedItem != null && !this.Document.IsReadOnly;
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddItem();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteItem();
        }
        private void DeleteItem()
        {
            this.Document.Lines.Remove((PurchaseOrderLine)this.grid.SelectedItem);
        }
        private void AddItem()
        {
            ProductFilter filter = new ProductFilter { ProductTypeId = ProductType.Storable, States = new byte[] { (byte)ProductState.Active } };
            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(ProductSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<ProductView>();
                PurchaseOrderLine newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        newItem  = new PurchaseOrderLine 
                        {
                            ProductId = item.Id,
                            Amount = 1,
                            Cost = item.StandardCost
                        };
                        this.Document.Lines.Add(newItem);
                    }
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.SelectedItem = newItem;
                }
            }
        }
        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            TableView view = (TableView)sender;
            view.PostEditor();
        }
    }
}
