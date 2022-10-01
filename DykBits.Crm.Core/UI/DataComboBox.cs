using System;
using System.Collections.Specialized;
using System.Collections;
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
    ///     <MyNamespace:DataComboBox/>
    ///
    /// </summary>
    public class DataComboBox : Control
    {
        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof(string), typeof(DataComboBox),
            new PropertyMetadata(string.Empty, OnDataSourcePropertyChanged));

        private static void OnDataSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DataComboBox control = (DataComboBox)o;
            control.InvokeDataSourceChanged(e);
        }
        public string DataSource
        {
            get { return (string)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }
        private void InvokeDataSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            BindToDataSource();
        }
        private void BindToDataSource()
        {
            if (ApplicationManager.IsInitialized)
            {
                ListManager listManager = ServiceManager.GetService<ListManager>();
                if (string.IsNullOrWhiteSpace(DataSource))
                    SetCurrentValue(ItemsSourceProperty, null);
                else
                    SetCurrentValue(ItemsSourceProperty, listManager.GetList(DataSource));
            }
        }
        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Direct, typeof(SelectionChangedEventHandler), typeof(DataComboBox));
        private class ObjectWithValue : DependencyObject
        {
            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(ObjectWithValue));

            public object Value
            {
                get { return GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
        }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(object), typeof(DataComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedValuePropertyChanged));

        private static void OnSelectedValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataComboBox control = (DataComboBox)d;
            control.SyncSelectedValue();
            control.RaiseEvent(new SelectionChangedEventArgs(SelectionChangedEvent, new object[] { e.OldValue }, new object[] { e.NewValue }));
        }
        public object SelectedValue
        {
            get { return GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(DataComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataComboBox control = (DataComboBox)d;
            control.UpdateItemsSource();
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private List<object> _innerItemSource;

        private Predicate<object> _filter;
        public Predicate<object> Filter
        {
            get { return this._filter; }
            set
            {
                if (this._filter != value)
                {
                    this._filter = value;
                    UpdateItemsSource();
                }
            }
        }
        private int IndexOfValue(object value)
        {
            if (this._innerItemSource != null)
            {
                if (value == null)
                    return IsNullable ? 0 : -1;
                int index = IsNullable ? 1 : 0;
                int intValue = (int)value;
                for (; index < this._innerItemSource.Count; ++index)
                {
                    Binding binding = new Binding("Id");
                    ObjectWithValue objectWithValue = new ObjectWithValue();
                    binding.Source = this._innerItemSource[index];
                    BindingOperations.SetBinding(objectWithValue, ObjectWithValue.ValueProperty, binding);
                    int itemValue = (int)objectWithValue.GetValue(ObjectWithValue.ValueProperty);
                    if (itemValue == intValue)
                        return index;
                }
            }
            return -1;
        }
        private void SyncSelectedValue()
        {
            if (this._comboBox != null)
            {
                this._comboBox.SelectionChanged -= _comboBox_SelectionChanged;
                try
                {
                    this._comboBox.SelectedIndex = IndexOfValue(this.SelectedValue);
                }
                finally
                {
                    this._comboBox.SelectionChanged += _comboBox_SelectionChanged;
                }
            }
        }
        public object SelectedItem
        {
            get
            {
                if (this._comboBox != null)
                {
                    object item = this._comboBox.SelectedItem;
                    if (!(item is NullItem))
                        return item;
                }
                return null;
            }
        }
        public event SelectionChangedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        private INotifyCollectionChanged _originalItemSource;

        private void UpdateItemsSource()
        {
            if(this._originalItemSource != null)
                this._originalItemSource.CollectionChanged -= _originalItemSource_CollectionChanged;
            IEnumerable source = ItemsSource;
            this._originalItemSource = source as INotifyCollectionChanged;
            if(this._originalItemSource != null)
                this._originalItemSource.CollectionChanged += _originalItemSource_CollectionChanged;
            InitializeInnerItemSource(source);
        }

        private void InitializeInnerItemSource(IEnumerable source)
        {
            if (source == null)
            {
                this._innerItemSource = null;
            }
            else
            {
                this._innerItemSource = new List<object>();
                if (IsNullable)
                    this._innerItemSource.Add(new NullItem());
                if (Filter == null && this._innerFilter == null)
                {
                    foreach (object item in source)
                    {
                        this._innerItemSource.Add(item);
                    }
                }
                else
                {
                    foreach (object item in source)
                    {
                        bool addValue = false;
                        if (Filter != null)
                            addValue = Filter(item);
                        if (this._innerFilter != null)
                            addValue = addValue || this._innerFilter(item);
                        if (addValue)
                            this._innerItemSource.Add(item);
                    }
                }
            }
            if (this._comboBox != null)
            {
                this._comboBox.SelectionChanged -= _comboBox_SelectionChanged;
                this._comboBox.ItemsSource = this._innerItemSource;
                this._comboBox.SelectionChanged += _comboBox_SelectionChanged;
                SyncSelectedValue();
            }
        }

        void _originalItemSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InitializeInnerItemSource((IEnumerable)this._originalItemSource);
        }

        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(DataComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnItemTemplatePropertyChanged));

        private static void OnItemTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty NullItemTemplateProperty = DependencyProperty.Register("NullItemTemplate", typeof(DataTemplate), typeof(DataComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnNullItemTemplatePropertyChanged));

        private static void OnNullItemTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        public DataTemplate NullItemTemplate
        {
            get { return (DataTemplate)GetValue(NullItemTemplateProperty); }
            set { SetValue(NullItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty IsNullableProperty = DependencyProperty.Register("IsNullable", typeof(bool), typeof(DataComboBox),
            new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None, OnIsNullablePropertyChanged));

        private static void OnIsNullablePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataComboBox control = (DataComboBox)d;
            control.UpdateItemsSource();
        }
        public bool IsNullable
        {
            get { return (bool)GetValue(IsNullableProperty); }
            set { SetValue(IsNullableProperty, value); }
        }

        public static readonly DependencyProperty FilterPropertyPathProperty = DependencyProperty.Register("FilterPropertyPath", typeof(PropertyPath), typeof(DataComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnFilterPropertyPathPropertyChanged));
        private static void OnFilterPropertyPathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DataComboBox)d).UpdateItemsSourceFilter();
        }
        public PropertyPath FilterPropertyPath
        {
            get { return (PropertyPath)GetValue(FilterPropertyPathProperty); }
            set { SetValue(FilterPropertyPathProperty, value); }
        }

        public static readonly DependencyProperty FilterValueProperty = DependencyProperty.Register("FilterValue", typeof(object), typeof(DataComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnFilterValuePropertyChanged));
        private static void OnFilterValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DataComboBox)d).UpdateItemsSourceFilter();
        }
        public object FilterValue
        {
            get { return GetValue(FilterValueProperty); }
            set { SetValue(FilterValueProperty, value); }
        }

        private Predicate<object> _innerFilter;
        private void UpdateItemsSourceFilter()
        {
            PropertyPath propertyPath = FilterPropertyPath;
            if (propertyPath == null)
                this._innerFilter = null;
            else
            {
                object filterValue = FilterValue;
                this._innerFilter = (t) =>
                {
                    PropertyInfo property = t.GetType().GetProperty(propertyPath.Path);
                    object value = property.GetValue(t);
                    if (filterValue == null)
                        return value == null;
                    return filterValue.Equals(value);
                };
            }
            UpdateItemsSource();
        }
        static DataComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataComboBox), new FrameworkPropertyMetadata(typeof(DataComboBox)));
        }

        private ComboBox _comboBox;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._comboBox = (ComboBox)GetTemplateChild("ComboBox_PART");
            this._comboBox.ItemTemplateSelector = new DataComboBoxItemTemplateSelector(this);
            UpdateItemsSource();
        }

        void _comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = this._comboBox.SelectedItem;
            if (item is NullItem)
                SetCurrentValue(SelectedValueProperty, null);
            else
                SetCurrentValue(SelectedValueProperty, this._comboBox.SelectedValue);
        }
        internal class NullItem
        {
            public Nullable<int> Id { get; set; }
        }
        internal class DataComboBoxItemTemplateSelector : DataTemplateSelector
        {
            private DataComboBox _comboBox;
            public DataComboBoxItemTemplateSelector(DataComboBox comboBox)
            {
                this._comboBox = comboBox;
            }
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                if (item is DataComboBox.NullItem)
                    return this._comboBox.NullItemTemplate;
                return this._comboBox.ItemTemplate;
            }
        }
    }
}
