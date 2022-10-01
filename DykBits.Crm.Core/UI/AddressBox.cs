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
    ///     <MyNamespace:AddressBox/>
    ///
    /// </summary>
    public class AddressBox : Control, IExternalEditor
    {
        public static readonly DependencyProperty StreetProperty = DependencyProperty.Register("Street", typeof(string), typeof(AddressBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnAddressChanged));
        
        public static readonly DependencyProperty CityProperty = DependencyProperty.Register("City", typeof(string), typeof(AddressBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnAddressChanged));

        public static readonly DependencyProperty RegionProperty = DependencyProperty.Register("Region", typeof(string), typeof(AddressBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnAddressChanged));

        public static readonly DependencyProperty PostalCodeProperty = DependencyProperty.Register("PostalCode", typeof(string), typeof(AddressBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnAddressChanged));

        public static readonly DependencyProperty CountryProperty = DependencyProperty.Register("Country", typeof(string), typeof(AddressBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnAddressChanged));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(AddressBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged));

        private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnAddressChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            AddressBox control = (AddressBox)o;
            control.OnAddressChanged(e);
        }

        static AddressBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddressBox), new FrameworkPropertyMetadata(typeof(AddressBox)));
        }

        public AddressBox()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateControl();
        }

        protected virtual void OnAddressChanged(DependencyPropertyChangedEventArgs e)
        {
            UpdateControl();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Street
        {
            get { return (string)GetValue(StreetProperty); }
            set { SetValue(StreetProperty, value); }
        }

        public string City
        {
            get { return (string)GetValue(CityProperty); }
            set { SetValue(CityProperty, value); }
        }

        public string PostalCode
        {
            get { return (string)GetValue(PostalCodeProperty); }
            set { SetValue(PostalCodeProperty, value); }
        }

        public string Region
        {
            get { return (string)GetValue(RegionProperty); }
            set { SetValue(RegionProperty, value); }
        }

        public string Country
        {
            get { return (string)GetValue(CountryProperty); }
            set { SetValue(CountryProperty, value); }
        }

        public AddressData GetAddressData()
        {
            return new AddressData
                {
                    Street = this.Street,
                    City = this.City,
                    PostalCode = this.PostalCode,
                    Region = this.Region,
                    Country = this.Country
                };
        }

        private void UpdateControl()
        {
            this.SetCurrentValue(TextProperty, GetAddressData().ToString());
        }

        public bool ShowDialog()
        {
            AddressData data = GetAddressData();
            if (UserControlDialogBox.ShowDialog(Window.GetWindow(this), typeof(AddressControl), "Проверка адреса", data) == true)
            {
                this.SetCurrentValue(StreetProperty, data.Street);
                this.SetCurrentValue(CityProperty, data.City);
                this.SetCurrentValue(PostalCodeProperty, data.PostalCode);
                this.SetCurrentValue(RegionProperty, data.Region);
                this.SetCurrentValue(CountryProperty, data.Country);
                return true;
            }
            return false;
        }
    }
}
