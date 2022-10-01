using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for DocumentStateEntryGridControl.xaml
    /// </summary>
    public partial class DocumentStateEntryGridControl : DataGridControlBase
    {
        public DocumentStateEntryGridControl()
        {
            InitializeComponent();
            this.Loaded += DocumentStateEntryGridControl_Loaded;
        }

        void DocumentStateEntryGridControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Loaded -= DocumentStateEntryGridControl_Loaded;
                if (ParentWindow is EditorWindow)
                {
                    this.gridView.Columns["DocumentType"].GroupIndex = -1;
                    this.gridView.Columns["DocumentType"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
    }
}
