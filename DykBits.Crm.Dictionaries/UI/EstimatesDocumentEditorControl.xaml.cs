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
using System.IO;
using DykBits.Crm.Reports;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class EstimatesDocumentEditorControl : MasterDetailsControlBase
    {
        public EstimatesDocumentEditorControl()
        {
            InitializeComponent();
        }

        public EstimatesDocument Document
        {
            get { return (EstimatesDocument)this.DataSource; }
        }

        private void TreeListView_ShowingEditor(object sender, DevExpress.Xpf.Grid.TreeList.TreeListShowingEditorEventArgs e)
        {
            EstimatesDocumentItem item = (EstimatesDocumentItem)e.Node.Content;
            if (item.Level == 0)
            {
                e.Cancel = item.ReadOnly || (e.Column.Name != "columnFileAs" && e.Column.Name != "columnComments");
            }
            else
            {
                if (item.ReadOnly)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (e.Column.Name == "columnFileAs")
                    {
                        e.Cancel = item.ProductId != null;
                    }
                }
            }
        }

        private bool CanAddRow()
        {
            if (this.grid != null)
            {
                EstimatesDocumentItem item = (EstimatesDocumentItem)this.grid.SelectedItem;
                return item != null && !item.SectionItem.ReadOnly;
            }
            return false;
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanAddRow();
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            if (this.grid != null)
            {
                EstimatesDocumentItem item = this.grid.SelectedItem as EstimatesDocumentItem;
                e.CanExecute = item != null && !item.ReadOnly;
            }
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
            AddList();
        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
            DeleteItem();
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        e.CanExecute = this.grid != null;
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        if (this.grid != null)
                        {
                            if (this.grid.SelectedItem is EstimatesDocumentSectionItem)
                            {
                                EstimatesDocumentSectionItem sectionItem = (EstimatesDocumentSectionItem)this.grid.SelectedItem;
                                e.CanExecute = !sectionItem.ReadOnly && this.Document.Sections.Count > 0 && sectionItem != this.Document.Items.FirstSection;
                                e.Handled = true;
                            }
                            else if (this.grid.SelectedItem is EstimatesDocumentLineItem)
                            {
                                EstimatesDocumentLineItem item = (EstimatesDocumentLineItem)this.grid.SelectedItem;
                                e.CanExecute = !item.ReadOnly && item.CanMoveUp;
                                e.Handled = true;
                            }
                        }
                        break;
                    case UICommandId.MoveDown:
                        if (this.grid != null)
                        {
                            if (this.grid.SelectedItem is EstimatesDocumentSectionItem)
                            {
                                EstimatesDocumentSectionItem item = (EstimatesDocumentSectionItem)this.grid.SelectedItem;
                                e.CanExecute = !item.ReadOnly && this.Document.Sections.Count > 0 && item != this.Document.Items.LastSection;
                                e.Handled = true;
                            }
                            else if (this.grid.SelectedItem is EstimatesDocumentLineItem)
                            {
                                EstimatesDocumentLineItem item = (EstimatesDocumentLineItem)this.grid.SelectedItem;
                                e.CanExecute = !item.ReadOnly && item.CanMoveDown;
                                e.Handled = true;
                            }
                        }
                        break;
                    case UICommandId.AddEmptyRow:
                        e.CanExecute = CanAddRow();
                        e.Handled = true;
                        break;
                }
            }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddGroup:
                        AddGroup();
                        e.Handled = true;
                        break;
                    case UICommandId.AddEmptyRow:
                        AddItem();
                        e.Handled = true;
                        break;
                    case UICommandId.MoveUp:
                        MoveUp();
                        e.Handled = true;
                        break;
                    case UICommandId.MoveDown:
                        MoveDown();
                        e.Handled = true;
                        break;
                }
            }
        }

        private void MoveUp()
        {
            this.grid.BeginDataUpdate();
            EstimatesDocumentItem item = (EstimatesDocumentItem)grid.SelectedItem;
            try
            {
                if (item is EstimatesDocumentSectionItem)
                    Document.Items.MoveUp((EstimatesDocumentSectionItem)item);
                else if (item is EstimatesDocumentLineItem)
                    Document.Items.MoveUp((EstimatesDocumentLineItem)item);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = item;
            }
        }

        private void MoveDown()
        {
            this.grid.BeginDataUpdate();
            EstimatesDocumentItem item = (EstimatesDocumentItem)grid.SelectedItem;
            try
            {
                if (item is EstimatesDocumentSectionItem)
                    Document.Items.MoveDown((EstimatesDocumentSectionItem)item);
                else if (item is EstimatesDocumentLineItem)
                    Document.Items.MoveDown((EstimatesDocumentLineItem)item);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.RefreshData();
                this.grid.SelectedItem = item;
            }
        }

        private void AddGroup()
        {
            EstimatesDocumentSection section = new EstimatesDocumentSection();
            ModalWindow window = ModalWindow.Create("Добавить раздел сметы", new EstimatesDocumentAddGroupControl(), section, this.ParentWindow);
            if (window.ShowDialog() == true)
            {
                this.grid.BeginDataUpdate();
                var sectionItem = new EstimatesDocumentSectionItem(section);
                try
                {
                    Document.Sections.Add(section);
                    Document.Items.Insert(Document.Sections.Count - 1, sectionItem);
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.RefreshData();
                    this.grid.SelectedItem = sectionItem;
                }
            }
            window.Close();
        }

        private void AddList()
        {
            EstimatesDocumentItem selectedItem = (EstimatesDocumentItem)this.grid.SelectedItem;
            EstimatesDocumentSectionItem section = selectedItem.SectionItem;

            ProductFilter filter = new ProductFilter { ProductCategoryId = section.ProductCategoryId, States = new byte[] { (byte)ProductState.Active } };
            SelectorDialogBox window = SelectorDialogBox.Create("Номенклатура", typeof(ProductSelectorGridControl), filter);
            window.SelectionMode = SelectionMode.MultiplyWithCheckBox;
            
            window.Owner = Window.GetWindow(this);
            if (window.ShowDialog() == true)
            {
                var items = window.SelectedItems.OfType<ProductView>();
                EstimatesDocumentLineItem newItem = null;
                this.grid.BeginDataUpdate();
                try
                {
                    foreach (var item in items)
                    {
                        string fileAs;
                        if (item.AbstractProductId.HasValue)
                        {
                            ListManager listManager = ServiceManager.GetService<ListManager>();
                            AbstractProductView dataItem = ListManager.GetItem<AbstractProductView>(item.AbstractProductId.Value);
                            fileAs = dataItem.FileAs + "/" + item.FileAs;
                        }
                        else
                        {
                            fileAs = item.FileAs;
                        }
                        EstimatesDocumentLine line = new EstimatesDocumentLine
                        {
                            ProductId = item.Id,
                            FileAs = fileAs,
                            Comments = item.Comments,
                            UnitOfMeasureId = item.UnitOfMeasureId,
                            Amount = 1,
                            Price = item.ListPrice,
                            NonCashCost = item.StandardCost
                        };
                        newItem = Document.Items.Add(section, line);
                    }
                }
                finally
                {
                    this.grid.EndDataUpdate();
                    this.grid.SelectedItem = newItem;
                }
            }
        }

        private void AddItem()
        {
            EstimatesDocumentItem selectedItem = (EstimatesDocumentItem)this.grid.SelectedItem;
            EstimatesDocumentLine line = new EstimatesDocumentLine();
            EstimatesDocumentLineItem newItem = null;
            this.grid.BeginDataUpdate();
            try
            {
                newItem = Document.Items.Add(selectedItem.SectionItem, line);
            }
            finally
            {
                this.grid.EndDataUpdate();
                this.grid.SelectedItem = newItem;
            }
        }

        private void DeleteItem()
        {
            EstimatesDocumentItem selectedItem = (EstimatesDocumentItem)this.grid.SelectedItem;
            if (selectedItem is EstimatesDocumentLineItem)
            {
                this.grid.BeginDataUpdate();
                try
                {
                    Document.Items.Remove(selectedItem.SectionItem, (EstimatesDocumentLineItem)selectedItem);
                }
                finally
                {
                    this.grid.EndDataUpdate();
                }
            }
            else
            {
                if (ApplicationManager.ShowQuestion("Предпринимается попытка удалить раздел сметы со всеми статьями. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.grid.BeginDataUpdate();
                    try
                    {
                        Document.Items.Remove(selectedItem.SectionItem);
                    }
                    finally
                    {
                        this.grid.EndDataUpdate();
                    }
                }
            }
        }
    }
}
