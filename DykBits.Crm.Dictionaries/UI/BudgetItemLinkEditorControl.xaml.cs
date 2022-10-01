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
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class BudgetItemLinkEditorControl : EditorControlBase
    {
        public BudgetItemLinkEditorControl()
        {
            InitializeComponent();
        }

        private BudgetItemLink Document
        {
            get { return (BudgetItemLink)this.DataSource; }
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.comboIncomeBudgetItemGroup.Filter = (r) => { return ((IDataItem)r).Id == BudgetItemGroup.Доходы_по_ОВД || ((IDataItem)r).Id == BudgetItemGroup.Прочие_доходы; };
            this.comboExpenseBudgetItemGroup.Filter = (r) => { return ((IDataItem)r).Id == BudgetItemGroup.Расходы_по_ОВД || ((IDataItem)r).Id == BudgetItemGroup.Прочие_расходы; };
            InitializeBudgetItemCombo(comboIncomeBudgetItemGroup, comboIncomeBudgetItem);
            this.comboIncomeBudgetItemGroup.SelectionChanged += comboIncomeBudgetItemGroup_SelectionChanged;
            InitializeBudgetItemCombo(comboExpenseBudgetItemGroup, comboExpenseBudgetItem);
            this.comboExpenseBudgetItemGroup.SelectionChanged += comboExpenseBudgetItemGroup_SelectionChanged;
        }

        void comboExpenseBudgetItemGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeBudgetItemCombo(comboExpenseBudgetItemGroup, comboExpenseBudgetItem);
        }

        void comboIncomeBudgetItemGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeBudgetItemCombo(comboIncomeBudgetItemGroup, comboIncomeBudgetItem);
        }

        private void InitializeBudgetItemCombo(DataComboBox group, DataComboBox item)
        {

            if (group != null && item != null)
            {
                object value = group.SelectedValue;
                if (value == null)
                    item.Filter = (t) => { return false; };
                else
                    item.Filter = (t) => { return ((BudgetItemView)t).BudgetItemGroupId == (int)value; };
            }
        }
    }
}
