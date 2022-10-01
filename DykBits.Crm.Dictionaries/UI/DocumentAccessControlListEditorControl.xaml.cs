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
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProjectTypeEditorControl.xaml
    /// </summary>
    public partial class DocumentAccessControlListEditorControl : EditorControlBase
    {
        public DocumentAccessControlListEditorControl()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.comboApplicationRole.SelectedIndex = 0;
        }

        DocumentAccessControlList Document
        {
            get { return (DocumentAccessControlList) this.DataSource; }
        }

        protected override void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
            base.OnDataSourceChanged(e);
            if (this.comboApplicationRole.SelectedIndex < 0)
            {
                this.comboApplicationRole.SelectedIndex = 0;
            }
            else
            {
                this.gridView.ItemsSource = Document.Rights.Where(t => t.ApplicationRoleId == (int)this.comboApplicationRole.SelectedValue);
            }
        }

        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            TableView view = sender as TableView;
            view.PostEditor();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.gridView.ItemsSource = Document.Rights.Where(t => t.ApplicationRoleId == (int)this.comboApplicationRole.SelectedValue);
        }
    }
}
