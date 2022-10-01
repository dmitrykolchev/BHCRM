using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DykBits.Crm.UI
{
    public class UIAction: DependencyObject
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(RoutedCommand), typeof(UIAction));
        public RoutedCommand Command
        {
            get { return (RoutedCommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(UIAction));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(UIAction));
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty AccessRightProperty = DependencyProperty.Register("AccessRight", typeof(string), typeof(UIAction));

        public string AccessRight
        {
            get { return (string)GetValue(AccessRightProperty); }
            set { SetValue(AccessRightProperty, value); }
        }
    }
}
