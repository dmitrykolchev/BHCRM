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
    ///     <MyNamespace:ExternalEditorButton/>
    ///
    /// </summary>
    public class ExternalEditorButton : Control
    {
        public static readonly DependencyProperty TargetControlProperty = DependencyProperty.Register("TargetControl", typeof(IExternalEditor), typeof(ExternalEditorButton),
            new PropertyMetadata(null, OnTargetControlPropertyChanged));

        private static void OnTargetControlPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(ExternalEditorButton),
            new PropertyMetadata(null, OnContentPropertyChanged));

        private static void OnContentPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }

        static ExternalEditorButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExternalEditorButton), new FrameworkPropertyMetadata(typeof(ExternalEditorButton)));
        }

        private Button _button;

        public ExternalEditorButton()
        {
        }

        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public IExternalEditor TargetControl
        {
            get { return (IExternalEditor)GetValue(TargetControlProperty); }
            set { SetValue(TargetControlProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._button = (Button)GetTemplateChild("Button_PART");
            this._button.Click += ExternalEditorButton_Click;
        }

        void ExternalEditorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TargetControl != null)
                {
                    TargetControl.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
    }
}
