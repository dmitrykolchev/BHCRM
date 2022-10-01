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
    public partial class AbstractProductEditorControl : EditorControlBase
    {
        public AbstractProductEditorControl()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            InitializeCategoriesCombo();
            this.comboProductCategory.SelectionChanged += comboProductCategory_SelectionChanged;
        }

        void comboProductCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                InitializeCategoriesCombo();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void InitializeCategoriesCombo()
        {
            if (this.comboProductSubcategory != null && this.comboProductCategory != null)
            {
                object value = this.comboProductCategory.SelectedValue;
                if (value == null)
                    this.comboProductSubcategory.Filter = (t) => { return false; };
                else
                    this.comboProductSubcategory.Filter = (t) => { return ((ProductSubcategoryView)t).ProductCategoryId == (int)value; };
            }
        }
    }
}
