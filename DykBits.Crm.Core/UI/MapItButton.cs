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
    ///     <MyNamespace:MapItButton/>
    ///
    /// </summary>
    public class MapItButton : ContentControl
    {
        public static readonly DependencyProperty TargetControlProperty = DependencyProperty.Register("TargetControl", typeof(AddressBox), typeof(MapItButton),
            new PropertyMetadata(null, OnTargetControlPropertyChanged));

        static MapItButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MapItButton), new FrameworkPropertyMetadata(typeof(MapItButton)));
        }

        private static void OnTargetControlPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }

        private Button _button;

        public MapItButton()
        {
        }

        public AddressBox TargetControl
        {
            get { return (AddressBox)GetValue(TargetControlProperty); }
            set { SetValue(TargetControlProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._button = (Button)GetTemplateChild("Button_PART");
            this._button.Click += _button_Click;
        }

        void _button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TargetControl != null)
                {
                    AddressData address = TargetControl.GetAddressData();
                    string url;
                    if (!address.IsEmpty())
                    {
                        url = string.Format("http://maps.yandex.ru/?text={0}", Uri.EscapeDataString(address.ToString().Replace("\r\n", ",")));
                    }
                    else
                    {
                        url = "http://maps.yandex.ru";
                    }
                    System.Diagnostics.Process.Start(url);
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
    }
}
