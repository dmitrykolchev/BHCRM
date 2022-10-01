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
    ///     <MyNamespace:PersonNameBox/>
    ///
    /// </summary>
    public class PersonNameBox : Control, IExternalEditor
    {
        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string), typeof(PersonNameBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnNameChanged));

        public static readonly DependencyProperty MiddleNameProperty = DependencyProperty.Register("MiddleName", typeof(string), typeof(PersonNameBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnNameChanged));

        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register("LastName", typeof(string), typeof(PersonNameBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnNameChanged));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(PersonNameBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged));

        public static readonly RoutedEvent PersonNameChangedEvent = EventManager.RegisterRoutedEvent("PersonNameChanged", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(PersonNameBox));

        public event RoutedEventHandler PersonNameChanged
        {
            add { AddHandler(PersonNameChangedEvent, value); }
            remove { RemoveHandler(PersonNameChangedEvent, value); }
        }

        private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }

        static PersonNameBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PersonNameBox), new FrameworkPropertyMetadata(typeof(PersonNameBox)));
        }

        private static void OnNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            PersonNameBox control = (PersonNameBox)o;
            control.OnPersonNameChanged(new RoutedEventArgs(PersonNameChangedEvent, control));
        }

        public PersonNameBox()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateControl();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public string MiddleName
        {
            get { return (string)GetValue(MiddleNameProperty); }
            set { SetValue(MiddleNameProperty, value); }
        }

        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public string[] GetSuggestedNames()
        {
            List<string> names = new List<string>();
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    names.Add(string.Format("{0}, {1}", LastName, FirstName));
                    if (!string.IsNullOrWhiteSpace(MiddleName))
                        names.Add(string.Format("{0}, {1} {2}", LastName, FirstName, MiddleName));
                }
                else
                    names.Add(LastName);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(MiddleName))
                    names.Add(string.Format("{0} {1}", FirstName, MiddleName));
                else if(!string.IsNullOrWhiteSpace(FirstName))
                    names.Add(string.Format("{0}", FirstName));
            }
            return names.ToArray();
        }

        protected virtual void OnPersonNameChanged(RoutedEventArgs e)
        {
            UpdateControl();
            RaiseEvent(e);
        }

        public bool ShowDialog()
        {
            PersonNameData data = new PersonNameData
            {
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName
            };
            if (UserControlDialogBox.ShowDialog(Window.GetWindow(this), typeof(PersonNameControl), "Проверка имени", data) == true)
            {
                this.SetCurrentValue(FirstNameProperty, data.FirstName);
                this.SetCurrentValue(MiddleNameProperty, data.MiddleName);
                this.SetCurrentValue(LastNameProperty, data.LastName);
                return true;
            }
            return false;
        }

        private void UpdateControl()
        {
            SetCurrentValue(TextProperty, new PersonNameData
                {
                    FirstName = this.FirstName,
                    MiddleName = this.MiddleName,
                    LastName = this.LastName
                }.ToString());
        }
    }
}
