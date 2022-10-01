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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for PriceListEditorControl.xaml
    /// </summary>
    public partial class PriceListEditorControl : MasterDetailsControlBase
    {
        public PriceListEditorControl()
        {
            InitializeComponent();
        }
        protected override void UnwireEvents()
        {
            this.comboProductCategory.SelectionChanged -= comboProductCategory_SelectionChanged;
        }
        protected override void WireEvents()
        {
            this.comboProductCategory.SelectionChanged += comboProductCategory_SelectionChanged;
        }
        private PriceList Document
        {
            get { return (PriceList)this.DataSource; }
        }
        protected override void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }
        protected override void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }
        protected override void AddDetailsRow(ExecutedRoutedEventArgs e)
        {

        }
        protected override void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {

        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.None:
                        if (command.Text == "Generate")
                        {
                            e.CanExecute = comboProductCategory != null && comboProductCategory.SelectedValue is int && Document != null && Document.Lines.Count == 0;
                            e.Handled = true;
                        }
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
                    case UICommandId.None:
                        if (command.Text == "Generate")
                        {
                            GeneratePriceList();
                            e.Handled = true;
                        }
                        break;
                }
            }
        }
        private void GeneratePriceList()
        {
            Document.Generate((int)this.comboProductCategory.SelectedValue);
        }
        private void TableView_ShowingEditor(object sender, DevExpress.Xpf.Grid.ShowingEditorEventArgs e)
        {
            if (e.Column.FieldName == "Price")
            {
                PriceListLine line = e.Row as PriceListLine;
                e.Cancel = line == null || line.PriceMarginId != 1;
            }
        }
        private void comboProductCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Document.Lines.Count > 0)
            {
                if (ApplicationManager.ShowQuestion("Попытка изменить категорию номенклатуры приведет к удалению строк прайс-листа. Продолжить?"))
                {
                    Document.Lines.Clear();
                }
                else
                {
                    this.comboProductCategory.SelectionChanged -= comboProductCategory_SelectionChanged;
                    try
                    {
                        this.comboProductCategory.SetCurrentValue(DataComboBox.SelectedValueProperty, e.RemovedItems[0]);
                    }
                    finally
                    {
                        this.comboProductCategory.SelectionChanged += comboProductCategory_SelectionChanged;
                    }
                }
            }
        }
    }
}
