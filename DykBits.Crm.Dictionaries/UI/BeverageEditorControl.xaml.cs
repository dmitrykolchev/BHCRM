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
    /// Interaction logic for BeverageEditorControl.xaml
    /// </summary>
    public partial class BeverageEditorControl : EditorControlBase
    {
        public BeverageEditorControl()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();
            InitializeCategoriesCombo();
            InitializeBeverageSubtypeCombo();
            this.comboBeverageType.SelectionChanged += comboBeverageType_SelectionChanged;
            this.comboProductCategory.SelectionChanged += comboProductCategory_SelectionChanged;
            this.comboAbstractProduct.SelectionChanged += comboAbstractProduct_SelectionChanged;
        }

        void comboBeverageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                InitializeBeverageSubtypeCombo();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        void comboAbstractProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IDataItem dataItem = comboAbstractProduct.SelectedItem;
            if (dataItem != null)
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(dataItem.DataItemClass);
                ItemKey itemKey = dataItem.GetKey();
                AbstractProduct abstractProduct = (AbstractProduct)dataAdapter.GetItem(itemKey);
                dynamic dataContext = this.DataContext;
                dataContext.FileAs = abstractProduct.FileAs;
                dataContext.ProductCategoryId = abstractProduct.ProductCategoryId;
                dataContext.ProductSubcategoryId = abstractProduct.ProductSubcategoryId;
                dataContext.UnitOfMeasureId = abstractProduct.UnitOfMeasureId;
            }
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
        private void InitializeBeverageSubtypeCombo()
        {
            if (this.comboBeverageSubtype != null && this.comboBeverageType != null)
            {
                object value = this.comboBeverageType.SelectedValue;
                if (value == null)
                    this.comboBeverageSubtype.Filter = (t) => { return false; };
                else
                    this.comboBeverageSubtype.Filter = (t) => { return ((BeverageSubtypeView)t).BeverageTypeId == (int)value; };
            }
        }
    }
}
