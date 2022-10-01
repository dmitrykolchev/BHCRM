using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.InteropServices;
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
    ///     <MyNamespace:DropDownSelector/>
    ///
    /// </summary>
    public class DropDownSelector : MultiSelector
    {
        private class ObjectWithValue: DependencyObject
        {
            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(ObjectWithValue));

            public object Value
            {
                get { return GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
        }

        #region private class EmptyList
        private class EmptyList : IList
        {
            public int Add(object value)
            {
                throw new NotSupportedException();
            }

            public void Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(object value)
            {
                throw new NotSupportedException();
            }

            public int IndexOf(object value)
            {
                return -1;
            }

            public void Insert(int index, object value)
            {
                throw new NotSupportedException();
            }

            public bool IsFixedSize
            {
                get { return true; }
            }

            public bool IsReadOnly
            {
                get { return true; }
            }

            public void Remove(object value)
            {
                throw new NotSupportedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            public object this[int index]
            {
                get
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                set
                {
                    throw new ArgumentOutOfRangeException("index");
                }
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotSupportedException();
            }

            public int Count
            {
                get { return 0; }
            }

            public bool IsSynchronized
            {
                get { return true; }
            }

            public object SyncRoot
            {
                get { return this; }
            }

            public IEnumerator GetEnumerator()
            {
                return new object[0].GetEnumerator();
            }
        }
        #endregion

        private static readonly EmptyList Empty = new EmptyList();

        #region bool IsDropDownOpen { get; set; }

        public static readonly DependencyProperty IsDropDownOpenProperty = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(DropDownSelector),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIsDropDownOpenChanged), new CoerceValueCallback(CoerceIsDropDownOpen)));

        public bool IsDropDownOpen
        {
            get { return (bool)GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }

        private static void OnIsDropDownOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DropDownSelector control = (DropDownSelector)d;
            control.HandleIsDropDownOpenChanged(e);
        }

        private void HandleIsDropDownOpenChanged(DependencyPropertyChangedEventArgs e)
        {
            bool flag = (bool)e.NewValue;
            bool oldValue = !flag;
            if (flag)
            {
                Mouse.Capture(this, CaptureMode.SubTree);
            }
            else
            {
                if (this.IsKeyboardFocusWithin)
                {
                    this.Focus();
                }
                if (Mouse.Captured == this)
                {
                    Mouse.Capture(null);
                }
            }
        }

        private static object CoerceIsDropDownOpen(DependencyObject d, object value)
        {
            if ((bool)value)
            {
                DropDownSelector control = (DropDownSelector)d;
                if (!control.IsLoaded)
                {
                    control.RegisterToOpenOnLoad();
                    return false;
                }
            }
            return value;
        }

        #endregion

        #region object SelectionBoxItem { get; private set; }

        private static readonly DependencyPropertyKey SelectionBoxItemPropertyKey = DependencyProperty.RegisterReadOnly("SelectionBoxItem", typeof(object), typeof(DropDownSelector),
            new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty SelectionBoxItemProperty = SelectionBoxItemPropertyKey.DependencyProperty;

        public object SelectionBoxItem
        {
            get { return base.GetValue(SelectionBoxItemProperty); }
            private set { base.SetValue(SelectionBoxItemPropertyKey, value); }
        }

        #endregion

        #region double MaxDropDownHeight { get; set; }

        public static readonly DependencyProperty MaxDropDownHeightProperty = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(DropDownSelector),
            new PropertyMetadata(SystemParameters.PrimaryScreenHeight / 3.0, OnMaxDropDownHeightPropertyChanged));

        private static void OnMaxDropDownHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        [Bindable(true)]
        [TypeConverter(typeof(LengthConverter))]
        public double MaxDropDownHeight
        {
            get { return (double)GetValue(MaxDropDownHeightProperty); }
            set { SetValue(MaxDropDownHeightProperty, value); }
        }

        #endregion

        #region Style SeparatorStyle { get; set; }

        public static readonly DependencyProperty SeparatorStyleProperty = DependencyProperty.Register("SeparatorStyle", typeof(Style), typeof(DropDownSelector),
            new PropertyMetadata(null, OnSeparatorStylePropertyChanged));

        private static void OnSeparatorStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public Style SeparatorStyle
        {
            get { return (Style)GetValue(SeparatorStyleProperty); }
            set { SetValue(SeparatorStyleProperty, value); }
        }

        #endregion

        #region string DataSource { get; set; }

        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof(string), typeof(DropDownSelector),
            new PropertyMetadata(string.Empty, OnDataSourcePropertyChanged));

        private static void OnDataSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DropDownSelector control = (DropDownSelector)d;
            control.UpdateItemsSource();
        }

        public string DataSource
        {
            get { return (string)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        private void UpdateItemsSource()
        {
            if (string.IsNullOrEmpty(DataSource))
            {
                this.ItemsSource = null;
            }
            else
            {
                if (ApplicationManager.IsInitialized)
                {
                    ListManager listManager = ServiceManager.GetService<ListManager>();
                    DocumentRecordCollection list = listManager.GetList(DataSource);
                    this.ItemsSource = list;
                }
            }
        }


        #endregion

        #region int SelectedFlags { get; set; }
        
        public static readonly DependencyProperty SelectedFlagsProperty = DependencyProperty.Register("SelectedFlags", typeof(int), typeof(DropDownSelector),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedFlagsPropertyChanged));

        private static void OnSelectedFlagsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DropDownSelector control = (DropDownSelector)d;
            control.SynchronizeSelectedItems((int)e.NewValue);
        }

        private void SynchronizeSelectedItems(int value)
        {
            BeginUpdateSelectedItems();
            try
            {
                this.SelectedItems.Clear();
                foreach (var item in this.Items)
                {
                    Binding binding = new Binding("Id");
                    ObjectWithValue objectWithValue = new ObjectWithValue();
                    binding.Source = item;
                    BindingOperations.SetBinding(objectWithValue, ObjectWithValue.ValueProperty, binding);

                    int flag = 1 << ((int)objectWithValue.GetValue(ObjectWithValue.ValueProperty) - 1);
                    if ((value & flag) != 0)
                    {
                        this.SelectedItems.Add(item);
                    }
                }
            }
            finally
            {
                EndUpdateSelectedItems();
            }
        }


        public int SelectedFlags
        {
            get { return (int)GetValue(SelectedFlagsProperty); }
            set { SetValue(SelectedFlagsProperty, value); }
        }
        #endregion


        static DropDownSelector()
        {
            EventManager.RegisterClassHandler(typeof(DropDownSelector), Mouse.LostMouseCaptureEvent, new MouseEventHandler(OnLostMouseCapture));
            EventManager.RegisterClassHandler(typeof(DropDownSelector), Mouse.MouseDownEvent, new MouseButtonEventHandler(OnMouseButtonDown), true);
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownSelector), new FrameworkPropertyMetadata(typeof(DropDownSelector)));
        }

        private static DependencyObject FindParent(DependencyObject o)
        {
            DependencyObject dependencyObject = o as Visual;
            ContentElement contentElement = (dependencyObject == null) ? (o as ContentElement) : null;
            if (contentElement != null)
            {
                o = ContentOperations.GetParent(contentElement);
                if (o != null)
                    return o;
                FrameworkContentElement frameworkContentElement = contentElement as FrameworkContentElement;
                if (frameworkContentElement != null)
                    return frameworkContentElement.Parent;
            }
            else if (dependencyObject != null)
            {
                o = VisualTreeHelper.GetParent(dependencyObject);
                if (o != null)
                    return o;
                FrameworkElement frameworkElement = dependencyObject as FrameworkElement;
                if (frameworkElement != null)
                    return frameworkElement.Parent;
            }
            return null;
        }

        private static bool IsDescendant(DependencyObject reference, DependencyObject node)
        {
            bool result = false;
            DependencyObject dependencyObject = node;
            while (dependencyObject != null)
            {
                if (dependencyObject == reference)
                {
                    result = true;
                    break;
                }
                dependencyObject = FindParent(dependencyObject);
            }
            return result;
        }

        private static void OnLostMouseCapture(object sender, MouseEventArgs e)
        {
            DropDownSelector control = (DropDownSelector)sender;
            if (Mouse.Captured != control)
            {
                if (e.OriginalSource == control)
                {
                    if (Mouse.Captured == null || !IsDescendant(control, Mouse.Captured as DependencyObject))
                    {
                        control.Close();
                    }
                }
                else
                {
                    if (IsDescendant(control, e.OriginalSource as DependencyObject))
                    {
                        if (control.IsDropDownOpen && Mouse.Captured == null && NativeMethods.GetCapture() == IntPtr.Zero)
                        {
                            Mouse.Capture(control, CaptureMode.SubTree);
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        control.Close();
                    }
                }
            }
        }

        private static void OnMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            DropDownSelector control = (DropDownSelector)sender;
            if (!control.IsKeyboardFocusWithin)
            {
                control.Focus();
            }
            e.Handled = true;
            if (Mouse.Captured == control && e.OriginalSource == control)
            {
                control.Close();
            }
        }

        public DropDownSelector()
        {
            this.CanSelectMultipleItems = true;
        }

        private void Close()
        {
            if (this.IsDropDownOpen)
            {
                SetCurrentValue(IsDropDownOpenProperty, false);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Update();
        }

        private void Update()
        {
            UpdateSelectionBoxItems();
        }

        private UIElement GetVisualElement(object item)
        {
            ContentControl contentControl = item as ContentControl;
            object content;
            if (contentControl != null)
                content = contentControl.Content;
            else
                content = item;
            UIElement element = content as UIElement;
            if (element != null)
            {
                VisualBrush brush = new VisualBrush(element);
                brush.Stretch = Stretch.None;
                brush.ViewboxUnits = BrushMappingMode.Absolute;
                brush.Viewbox = new Rect(element.RenderSize);
                brush.ViewportUnits = BrushMappingMode.Absolute;
                brush.Viewport = new Rect(element.RenderSize);
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = brush;
                rectangle.Width = element.RenderSize.Width;
                rectangle.Height = element.RenderSize.Height;
                return rectangle;
            }
            else
            {
                ContentControl control = new ContentControl();
                control.ContentTemplate = this.ItemTemplate;
                control.Content = content;
                control.Focusable = false;
                return control;
            }
        }

        private void UpdateSelectionBoxItems()
        {
            if (this.SelectedItems != null && this.SelectedItems.Count > 0)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                bool addSeparator = false;
                foreach (var item in this.SelectedItems)
                {
                    if (addSeparator)
                    {
                        DropDownSelectorSeparator separator = new DropDownSelectorSeparator();
                        separator.Focusable = false;
                        if (SeparatorStyle != null)
                            separator.Style = SeparatorStyle;
                        stackPanel.Children.Add(separator);
                    }
                    UIElement visualElement = GetVisualElement(item);
                    stackPanel.Children.Add(visualElement);
                    addSeparator = true;
                }
                SelectionBoxItem = stackPanel;
            }
            else
            {
                SelectionBoxItem = string.Empty;
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DropDownSelectorItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DropDownSelectorItem;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }

        private void RegisterToOpenOnLoad()
        {
            base.Loaded += new RoutedEventHandler(this.OpenOnLoad);
        }

        private void OpenOnLoad(object sender, RoutedEventArgs e)
        {
            base.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Func<object, object>(delegate(object param)
                {
                    base.CoerceValue(IsDropDownOpenProperty);
                    return null;
                }), null);
        }

        private void UpdateSelectedValue()
        {
            if (this.SelectedItems.Count > 0)
            {
                int selectedValue = 0;
                foreach (object item in this.SelectedItems)
                {
                    Binding binding = new Binding("Id");
                    binding.Source = item;
                    ObjectWithValue objectWithValue = new ObjectWithValue();
                    BindingOperations.SetBinding(objectWithValue, ObjectWithValue.ValueProperty, binding);
                    int itemValue = (int)objectWithValue.GetValue(ObjectWithValue.ValueProperty);
                    selectedValue |= (1 << (itemValue - 1));
                }
                SetCurrentValue(SelectedFlagsProperty, selectedValue);
            }
            else
            {
                SetCurrentValue(SelectedFlagsProperty, 0);
            }
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            UpdateSelectedValue();
            UpdateSelectionBoxItems();
        }

    }
}
