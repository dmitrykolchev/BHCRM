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
    /// Interaction logic for MoneyOperationGridControl.xaml
    /// </summary>
    public partial class MoneyOperationGridControl : DataGridControlBase
    {
        public MoneyOperationGridControl()
        {
            InitializeComponent();
        }

        protected override void OnOpenEditorWindow(IDataItem item)
        {
            MoneyOperationView document = (MoneyOperationView)item;
            if (document.ParentId.HasValue)
            {
                WindowManager.OpenDocument(ItemKey.CreateKey(MoneyOperation.DataItemClassName, document.ParentId.Value));
                return;
            }
            base.OnOpenEditorWindow(item);
        }
    }
}
