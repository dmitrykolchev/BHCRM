using System;
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
using System.Globalization;

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
    ///     <MyNamespace:MonthEdit/>
    ///
    /// </summary>
    public class MonthEdit : Control
    {
        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(DateTime), typeof(MonthEdit),
            new FrameworkPropertyMetadata(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnSelectedValuePropertyChanged, CoerceSelectedValueProperty));

        private enum MonthEditMode
        {
            Month,
            Year,
            DozenYears
        }

        private static void OnSelectedValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MonthEdit)d).OnSelectedValueChanged();
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
        static MonthEdit()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MonthEdit), new FrameworkPropertyMetadata(typeof(MonthEdit)));
        }

        private IList<MonthEditItem> _items;
        private ListBox _listBox;
        private Button _button;
        private RepeatButton _buttonDown;
        private RepeatButton _buttonUp;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._listBox = (ListBox)GetTemplateChild("PART_ListBox");
            this._items = MonthEditItem.GetMonthes();
            this._listBox.ItemsSource = this._items;
            this._listBox.SelectedItem = this._items[SelectedValue.Month - 1];
            this._listBox.SelectionChanged += _listBox_SelectionChanged;
            this._button = (Button)GetTemplateChild("PART_Button");
            this._button.Click += _button_Click;
            this._buttonDown = (RepeatButton)GetTemplateChild("PART_ButtonDown");
            this._buttonDown.Click += _buttonDown_Click;
            this._buttonUp = (RepeatButton)GetTemplateChild("PART_ButtonUp");
            this._buttonUp.Click += _buttonUp_Click;
        }

        internal void Reset()
        {
            this.Year = - 1;
            Mode = MonthEditMode.Month;
            this._button.Content = SelectedValue.ToString("MMMM yyyy");
        }

        void _buttonUp_Click(object sender, RoutedEventArgs e)
        {
            if (Mode == MonthEditMode.Month)
            {
                Year = Math.Min(9928, Year + 1);
            }
            else if (Mode == MonthEditMode.Year)
            {
                Year = Math.Min(9928, Year + 12);
            }
            else if (Mode == MonthEditMode.DozenYears)
            {
                Year = Math.Min(9928, Year + 12 * 12);
            }
            SetMode(Mode);
        }

        void _buttonDown_Click(object sender, RoutedEventArgs e)
        {
            if (Mode == MonthEditMode.Month)
            {
                Year = Math.Max(73, Year - 1);
            }
            else if (Mode == MonthEditMode.Year)
            {
                Year = Math.Max(73, Year - 12);
            }
            else if (Mode == MonthEditMode.DozenYears)
            {
                Year = Math.Max(73, Year - 12 * 12);
            }
            SetMode(Mode);
        }

        private void OnSelectedValueChanged()
        {
            if (this._button != null)
                this._button.Content = SelectedValue.ToString("MMMM yyyy");
        }

        private bool _internalChange;

        void _listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this._internalChange)
            {
                if (e.AddedItems.Count == 1)
                {
                    this._internalChange = true;
                    MonthEditItem item = this._listBox.SelectedItem as MonthEditItem;
                    if (item is MonthEditItem.DoezenYearsItem)
                    {
                        this.Year = item.Value;
                        this.Mode = MonthEditMode.Year;
                    }
                    else if (item is MonthEditItem.YearItem)
                    {
                        this.Year = item.Value;
                        this.Mode = MonthEditMode.Month;
                    }
                    else if (item is MonthEditItem.MonthItem)
                    {
                        SetCurrentValue(SelectedValueProperty, new DateTime(Year, item.Value, 1));
                        if (SelectionChanged != null)
                            SelectionChanged(this, EventArgs.Empty);
                    }
                    this._internalChange = false;
                }
            }
        }

        public event EventHandler SelectionChanged;

        private MonthEditMode _mode;
        private MonthEditMode Mode
        {
            get { return this._mode; }
            set
            {
                if (this._mode != value)
                {
                    this._mode = value;
                    OnModeChanged();
                }
            }
        }

        private int _year = -1;

        private int Year
        {
            get
            {
                if (this._year == -1)
                    return this.SelectedValue.Year;
                return this._year;
            }
            set
            {
                this._year = value;
            }
        }

        private void OnModeChanged()
        {
            SetMode(this.Mode);
        }

        private void SetMode(MonthEditMode mode)
        {
            this._internalChange = true;
            if (mode == MonthEditMode.Month)
            {
                this._items = MonthEditItem.GetMonthes();
                this._listBox.ItemsSource = this._items;
                this._listBox.SelectedItem = null;
                this._button.Content = Year.ToString();
            }
            else if (mode == MonthEditMode.Year)
            {
                this._items = MonthEditItem.GetYears(Year);
                this._listBox.ItemsSource = this._items;
                this._listBox.SelectedItem = null;
                this._button.Content = string.Format("{0} - {1}", this._items[0].Value, this._items[11].Value);
            }
            else if (mode == MonthEditMode.DozenYears)
            {
                this._items = MonthEditItem.GetDoezensYears(Year);
                this._listBox.ItemsSource = this._items;
                this._listBox.SelectedItem = null;
                this._button.Content = string.Format("{0} - {1}", this._items[0].Value, this._items[11].Value + 11);
            }
            this._internalChange = false;
        }


        void _button_Click(object sender, RoutedEventArgs e)
        {
            if (Mode == MonthEditMode.Month)
                Mode = MonthEditMode.Year;
            else if (Mode == MonthEditMode.Year)
                Mode = MonthEditMode.DozenYears;
        }
    }
}
