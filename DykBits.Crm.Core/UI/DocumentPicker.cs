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
using System.Reflection;
using DevExpress.Xpf.Editors;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DykBits.Crm.UI"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DykBits.Crm.UI;assembly=DykBits.Crm.UI"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:DocumentPicker/>
    ///
    /// </summary>
    public class DocumentPicker : Control
    {
        #region IDataItem SelectedItem { get; set; }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(IDataItem), typeof(DocumentPicker),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnSelectedItemPropertyChanged));

        private bool _internalChange;
        private static void OnSelectedItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DocumentPicker control = (DocumentPicker)d;
            IDataItem dataItem = (IDataItem)e.NewValue;
            if (!control._internalChange)
            {
                control._internalChange = true;
                try
                {
                    if (dataItem != null)
                        control.SetCurrentValue(SelectedValueProperty, dataItem.Id);
                    else
                        control.SetCurrentValue(SelectedValueProperty, null);
                }
                finally
                {
                    control._internalChange = false;
                }
            }
            control.UpdateButtonText();
            control.RaiseEvent(new SelectionChangedEventArgs(SelectionChangedEvent, new object[] { e.OldValue }, new object[] { e.NewValue }));
        }

        public IDataItem SelectedItem
        {
            get { return (IDataItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        #endregion

        #region public object SelectedValue { get; set; }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(object), typeof(DocumentPicker),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedValuePropertyChanged));

        private static void OnSelectedValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DocumentPicker control = (DocumentPicker)d;
            control.UpdateSelectedItem();
        }

        public object SelectedValue
        {
            get { return GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        #endregion

        #region public string NullText { get; set; }

        public static readonly DependencyProperty NullTextProperty = DependencyProperty.Register("NullText", typeof(string), typeof(DocumentPicker),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None, OnNullTextPropertyChanged));

        private static void OnNullTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public string NullText
        {
            get { return (string)GetValue(NullTextProperty); }
            set { SetValue(NullTextProperty, value); }
        }

        #endregion

        #region public string DataSource { get; set; }

        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof(string), typeof(DocumentPicker),
            new PropertyMetadata(string.Empty, OnDataSourcePropertyChanged));

        private static void OnDataSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DocumentPicker control = (DocumentPicker)d;
            control.UpdateSelectedItem();
        }

        public string DataSource
        {
            get { return (string)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        #endregion

        #region public event SelectionChanged;

        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Direct, typeof(SelectionChangedEventHandler),
            typeof(DocumentPicker));

        public event SelectionChangedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        #endregion

        #region public Filter DataSourceFilter { get; set; }

        private Filter _dataSourceFilter;

        public Filter DataSourceFilter
        {
            get
            {
                if (!ApplicationManager.IsInitialized)
                    return Filter.Empty;
                if (this._dataSourceFilter == null)
                {
                    DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                    IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(DataSource);
                    this._dataSourceFilter = dataAdapter.CreateFilter(null, null);
                }
                return this._dataSourceFilter;
            }
            set { this._dataSourceFilter = value; }
        }

        #endregion

        static DocumentPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentPicker), new FrameworkPropertyMetadata(typeof(DocumentPicker)));
        }

        private ButtonEdit _buttonEdit;
        private ButtonInfo _browseButton;
        private ButtonInfo _clearButton;
        private ButtonInfo _editButton;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._buttonEdit = (ButtonEdit)this.GetTemplateChild("buttonEdit");
            foreach (ButtonInfo buttonInfo in this._buttonEdit.Buttons)
            {
                if (buttonInfo.GlyphKind == GlyphKind.Regular)
                {
                    this._browseButton = buttonInfo;
                    buttonInfo.Click += SelectItem_Click;
                }
                else if (buttonInfo.GlyphKind == GlyphKind.Cancel)
                {
                    this._clearButton = buttonInfo;
                    buttonInfo.Click += ClearValue_Click;
                }
                else
                {
                    this._editButton = buttonInfo;
                    buttonInfo.Click += EditItem_Click;
                }
            }
            UpdateButtonText();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        void SelectItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectItem();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        void ClearValue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BindingExpression expression = BindingOperations.GetBindingExpression(this, DocumentPicker.SelectedValueProperty);
                if (expression != null && expression.ResolvedSource != null)
                {
                    PropertyInfo propertyInfo = expression.ResolvedSource.GetType().GetProperty(expression.ResolvedSourcePropertyName, BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo.PropertyType == typeof(int))
                    {
                        SetCurrentValue(SelectedValueProperty, 0);
                        return;
                    }
                }
                SetCurrentValue(SelectedValueProperty, null);
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        void EditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (new WaitCursor())
                {
                    WindowManager.OpenDocument(this.SelectedItem.GetKey());
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void InvokeRequestFilterData()
        {
            OnRequestFilterData(new RequestFilterDataEventArgs(this.DataSource, this.DataSourceFilter));
        }

        protected virtual void OnRequestFilterData(RequestFilterDataEventArgs e)
        {
            if (RequestFilterData != null)
                RequestFilterData(this, e);
        }

        public event EventHandler<RequestFilterDataEventArgs> RequestFilterData;

        private void SelectItem()
        {
            InvokeRequestFilterData();
            SelectorDialogBox dialog = SelectorDialogBox.Create(this.DataSource, this.DataSourceFilter);
            Window parentWindow = Window.GetWindow(this);
            dialog.Owner = parentWindow;
            if (dialog.ShowDialog() == true)
            {
                IDataItem selectedItem = dialog.SelectedItem as IDataItem;
                this.SetCurrentValue(SelectedItemProperty, selectedItem);
            }
        }


        private void UpdateButtonText()
        {
            if (this._buttonEdit != null)
            {
                IDataItem dataItem = this.SelectedItem;
                if (dataItem != null)
                    this._buttonEdit.Text = dataItem.FileAs;
                else
                    this._buttonEdit.Text = string.Empty;
            }
        }

        private void UpdateSelectedItem()
        {
            if (!this._internalChange)
            {
                IDataItem selectedItem = null;
                if (!string.IsNullOrEmpty(this.DataSource))
                {
                    object value = this.SelectedValue;
                    if (value is int)
                    {
                        int intValue = (int)value;
                        if (intValue != 0)
                        {
                            //DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                            //var dataAdapter = documentManager.GetDataAdapterProxy(DataSource);
                            //selectedItem = dataAdapter.GetItem(ItemKey.CreateKey(DataSource, intValue));
                            ListManager listManager = ServiceManager.GetService<ListManager>();
                            selectedItem = listManager.GetItem(ItemKey.CreateKey(DataSource, intValue));
                            System.Diagnostics.Debug.Assert(selectedItem != null, "Item not found Id=" + intValue  + "in DataSource=" + DataSource);
                            System.Diagnostics.Debug.Assert(selectedItem.Id == intValue, "Invalid item selected check browse stored procedure for DataSource=" + DataSource);
                        }
                    }
                }
                SetCurrentValue(SelectedItemProperty, selectedItem);
            }
        }
    }
}
