using System;
using System.ComponentModel;
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
    /// Interaction logic for DocumentEmployeeAccessRightEditorControl.xaml
    /// </summary>
    public partial class DocumentEmployeeAccessRightEditorControl : EditorControlBase
    {
        public DocumentEmployeeAccessRightEditorControl()
        {
            InitializeComponent();
        }

        private DocumentEmployeeAccessRight Document
        {
            get { return (DocumentEmployeeAccessRight)this.DataSource; }
        }

        protected override void Initialize()
        {
            if(Document != null)
                Document.PropertyChanged += Document_PropertyChanged;
        }

        void Document_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }


    }
}
