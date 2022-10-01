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
    public partial class DocumentStateEntryEditorControl : EditorControlBase
    {
        public DocumentStateEntryEditorControl()
        {
            InitializeComponent();
        }

        private DocumentStateEntry Document
        {
            get { return (DocumentStateEntry)this.DataSource; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Document != null)
                Document.OverlayImage = null;
        }
    }
}
