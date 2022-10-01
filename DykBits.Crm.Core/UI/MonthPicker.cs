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
using System.Windows.Controls.Primitives;

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
    ///     <MyNamespace:MonthPicker/>
    ///
    /// </summary>
    public class MonthPicker : Control, INotifyPropertyChanged
    {
        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(DateTime), typeof(MonthPicker),
            new FrameworkPropertyMetadata(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnSelectedValuePropertyChanged, CoerceSelectedValueProperty));

        private static void OnSelectedValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MonthPicker)d).OnSelectedValueChanged();
        }
        private void OnSelectedValueChanged()
        {
            this.InvokePropertyChanged("FormattedText");
        }
        private static object CoerceSelectedValueProperty(DependencyObject d, object baseValue)
        {
            DateTime value = (DateTime)baseValue;
            if (value.Day > 1)
                return new DateTime(value.Year, value.Month, 1);
            return baseValue;
        }
        public DateTime SelectedValue
        {
            get { return (DateTime)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        public string FormattedText
        {
            get { return SelectedValue.ToString(DisplayFormatString); }
        }

        public static readonly DependencyProperty DisplayFormatStringProperty = DependencyProperty.Register("DisplayFormatString", typeof(string), typeof(MonthPicker),
            new FrameworkPropertyMetadata("MMMM yyyy", FrameworkPropertyMetadataOptions.None, OnDisplayFormatStringPropertyChanged));

        private static void OnDisplayFormatStringPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MonthPicker)d).InvokePropertyChanged("FormattedText");
        }

        public string DisplayFormatString
        {
            get { return (string)GetValue(DisplayFormatStringProperty); }
            set { SetValue(DisplayFormatStringProperty, value); }
        }

        static MonthPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MonthPicker), new FrameworkPropertyMetadata(typeof(MonthPicker)));
        }

        private MonthEdit _monthEdit;
        private Popup _popup;
        private ToggleButton _popupButton;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._monthEdit = (MonthEdit)GetTemplateChild("PART_MonthEdit");
            this._popup = (Popup)GetTemplateChild("PART_Popup");
            this._popup.Opened += _popup_Opened;
            this._popupButton = (ToggleButton)GetTemplateChild("PART_PopupButton");
            this._monthEdit.SelectionChanged += _monthEdit_SelectionChanged;
        }

        void _popup_Opened(object sender, EventArgs e)
        {
            this._monthEdit.Reset();
        }

        void _monthEdit_SelectionChanged(object sender, EventArgs e)
        {
            this._popupButton.IsChecked = false;
        }

        private void InvokePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
