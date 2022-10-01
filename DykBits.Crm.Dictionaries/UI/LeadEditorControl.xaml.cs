using System;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrganizationEditorControl.xaml
    /// </summary>
    public partial class LeadEditorControl : EditorControlBase
    {
        private PersonNameSuggestor _suggestor;
        public LeadEditorControl()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
            this.DataContextChanged += OnDataContextChanged;
        }

        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                UpdateFileAsCombo();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this._suggestor = new PersonNameSuggestor(this.comboFileAs, this.fullName, this.textAccountName);
                UpdateFileAsCombo();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void UpdateFileAsCombo()
        {
            if (this._suggestor != null)
            {
                this._suggestor.CanUpdateFileAsValue = DataSource.State == 0;
                this._suggestor.UpdateFileAsCombo();
            }
        }
    }
}
