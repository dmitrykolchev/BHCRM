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
    /// Interaction logic for EmployeeEditorControl.xaml
    /// </summary>
    public partial class EmployeeEditorControl : EditorControlBase
    {
        private PersonNameSuggestor _suggestor;
        public EmployeeEditorControl()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
            this.DataContextChanged += OnDataContextChanged;

        }
        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue != null)
                UpdateFileAsCombo();
        }
        private Employee Document
        {
            get { return (Employee)this.DataSource; }
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            this._suggestor = new PersonNameSuggestor(this.comboFileAs, this.fullName, this.comboOrganization);
            UpdateFileAsCombo();
        }
        private void UpdateFileAsCombo()
        {
            if (this._suggestor != null)
            {
                this._suggestor.CanUpdateFileAsValue = DataSource.State == 0;
                this._suggestor.UpdateFileAsCombo();
            }
        }
        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = Document;
            employee.AlternateAddressCity = employee.PrimaryAddressCity;
            employee.AlternateAddressCountry = employee.PrimaryAddressCountry;
            employee.AlternateAddressPostalCode = employee.PrimaryAddressPostalCode;
            employee.AlternateAddressRegion = employee.PrimaryAddressRegion;
            employee.AlternateAddressStreet = employee.PrimaryAddressStreet;
        }

    }
}
