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
using DykBits.Crm.Input;

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
    ///     <MyNamespace:DataViewFilterControl/>
    ///
    /// </summary>
    public class DataViewFilterControl : ContentControl
    {
        public static readonly DependencyProperty DocumentTypeProperty = DependencyProperty.Register("DocumentType", typeof(Type), typeof(DataViewFilterControl),
            new PropertyMetadata(null, OnDocumentTypePropertyChanged));

        private static void OnDocumentTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public Type DocumentType
        {
            get { return (Type)GetValue(DocumentTypeProperty); }
            set { SetValue(DocumentTypeProperty, value); }
        }

        public static readonly DependencyProperty StateSelectorVisibilityProperty = DependencyProperty.Register("StateSelectorVisibility", typeof(Visibility), typeof(DataViewFilterControl),
            new PropertyMetadata(Visibility.Visible));

        public Visibility StateSelectorVisibility
        {
            get { return (Visibility)GetValue(StateSelectorVisibilityProperty); }
            set { SetValue(StateSelectorVisibilityProperty, value); }
        }
        static DataViewFilterControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataViewFilterControl), new FrameworkPropertyMetadata(typeof(DataViewFilterControl)));

            CommandManager.RegisterClassCommandBinding(
                typeof(DataViewFilterControl), 
                new CommandBinding(CrmApplicationCommands.ApplyFilter, OnCommandExecuted, OnCanExecuteCommand)
            );
        }
        protected override Size MeasureOverride(Size constraint)
        {
            base.MeasureOverride(constraint);
            return new Size(0, 0);
        }
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            base.ArrangeOverride(arrangeBounds);
            return arrangeBounds;
        }
        internal DataViewControlBase Owner
        {
            get;
            set; 
        }
        static void OnCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!e.Handled)
            {
                DataViewFilterControl filter = sender as DataViewFilterControl;
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    switch (command.Id)
                    {
                        case UICommandId.ApplyFilter:
                            filter.Owner.InvokeRequeryData();
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        static void OnCanExecuteCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!e.Handled)
            {
                DataViewFilterControl filter = sender as DataViewFilterControl;
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    switch (command.Id)
                    {
                        case UICommandId.ApplyFilter:
                            e.CanExecute = filter != null && filter.Owner != null;
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
    }
}
