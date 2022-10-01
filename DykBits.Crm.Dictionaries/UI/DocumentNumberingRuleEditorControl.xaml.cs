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
    /// Interaction logic for DocumentNumberingRuleEditorControl.xaml
    /// </summary>
    public partial class DocumentNumberingRuleEditorControl : EditorControlBase
    {
        public DocumentNumberingRuleEditorControl()
        {
            InitializeComponent();
        }
        private DocumentNumberingRule Document
        {
            get { return (DocumentNumberingRule)this.DataSource; }
        }

        protected override void Initialize()
        {
            ListManager listManager = ServiceManager.GetService<ListManager>();
            this.comboDocumentType.ItemsSource = listManager.GetList(DocumentTypeEntry.DataItemClassName, (t) => { return ((DocumentTypeEntryView)t).IsNumbered; });
        }
    }
}
