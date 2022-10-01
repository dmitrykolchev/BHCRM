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
    ///     <MyNamespace:MasterDetailsControlBase/>
    ///
    /// </summary>
    public class MasterDetailsControlBase : EditorControlBase
    {
        private ContentPresenter _toolbarContentPresenter;
        private DevExpress.Xpf.Bars.BarManager _defaultToolbar;

        static MasterDetailsControlBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MasterDetailsControlBase), new FrameworkPropertyMetadata(typeof(MasterDetailsControlBase)));
        }

        public static readonly DependencyProperty MasterProperty = DependencyProperty.Register("Master", typeof(object), typeof(MasterDetailsControlBase));

        public object Master
        {
            get { return GetValue(MasterProperty); }
            set { SetValue(MasterProperty, value); }
        }

        public static readonly DependencyProperty DetailsProperty = DependencyProperty.Register("Details", typeof(object), typeof(MasterDetailsControlBase));

        public object Details
        {
            get { return GetValue(DetailsProperty); }
            set { SetValue(DetailsProperty, value); }
        }

        public static readonly DependencyProperty DetailsVisibilityProperty = DependencyProperty.Register("DetailsVisibility", typeof(Visibility), typeof(MasterDetailsControlBase));

        public Visibility DetailsVisibility
        {
            get { return (System.Windows.Visibility)GetValue(DetailsVisibilityProperty); }
            set { SetValue(DetailsVisibilityProperty, value); }
        }

        public static readonly DependencyProperty DetailsToolbarProperty = DependencyProperty.Register("DetailsToolbar", typeof(FrameworkElement), typeof(MasterDetailsControlBase),
            new PropertyMetadata(null, OnDetailsToolbarPropertyChanged));

        private static void OnDetailsToolbarPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public FrameworkElement DetailsToolbar
        {
            get { return (FrameworkElement)GetValue(DetailsToolbarProperty); }
            set { SetValue(DetailsToolbarProperty, value); }
        }

        public MasterDetailsControlBase()
        {
            CommandBindings.Add(new CommandBinding(CrmApplicationCommands.AddRow, OnCommandExecuted, OnCanExecuteCommand));
            CommandBindings.Add(new CommandBinding(CrmApplicationCommands.EditRow, OnCommandExecuted, OnCanExecuteCommand));
            CommandBindings.Add(new CommandBinding(CrmApplicationCommands.DeleteRow, OnCommandExecuted, OnCanExecuteCommand));
        }

        private void OnCanExecuteCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddRow:
                        CanAddRow(e);
                        e.Handled = true;
                        break;
                    case UICommandId.EditRow:
                        CanEditRow(e);
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        CanDeleteRow(e);
                        e.Handled = true;
                        break;
                }
            }
        }

        protected virtual void CanAddRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }

        protected virtual void CanEditRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }
        protected virtual void CanDeleteRow(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }

        private void OnCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.AddRow:
                        AddDetailsRow(e);
                        e.Handled = true;
                        break;
                    case UICommandId.EditRow:
                        EditDetailsRow(e);
                        e.Handled = true;
                        break;
                    case UICommandId.DeleteRow:
                        DeleteDetailsRow(e);
                        e.Handled = true;
                        break;
                }
            }
        }

        protected virtual void AddDetailsRow(ExecutedRoutedEventArgs e)
        {
        }
        protected virtual void EditDetailsRow(ExecutedRoutedEventArgs e)
        {
        }
        protected virtual void DeleteDetailsRow(ExecutedRoutedEventArgs e)
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._toolbarContentPresenter = (ContentPresenter)GetTemplateChild("toolbarContentPresenter");
            Border border = (Border)GetTemplateChild("root");
            this._defaultToolbar = (DevExpress.Xpf.Bars.BarManager)border.Resources["defaultToolbar"];
            if (DetailsToolbar == null)
                SetCurrentValue(DetailsToolbarProperty, this._defaultToolbar);
        }
    }
}
