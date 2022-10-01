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
using DevExpress.Xpf.Core;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    public class DialogBase: Window
    {
        public static readonly DependencyProperty IsCancelButtonVisibleProperty = DependencyProperty.Register("IsCancelButtonVisible", typeof(bool), typeof(DialogBase),
            new PropertyMetadata(true, OnIsCancelButtonVisiblePropertyChanged));

        private static void OnIsCancelButtonVisiblePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }

        static DialogBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DialogBase), new FrameworkPropertyMetadata(typeof(DialogBase)));
        }

        public DialogBase()
        {
            this.CommandBindings.Add(new CommandBinding(CrmApplicationCommands.OK, HandleExecuted, HandleCanExecute));
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
        }

        private void HandleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OnExecuted(e);
        }

        private void HandleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            OnCanExecute(e);
        }

        protected virtual void OnExecuted(ExecutedRoutedEventArgs e)
        {
            if (!e.Handled)
            {
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    if (command.Id == UICommandId.OK)
                    {
                        this.DialogResult = true;
                        e.Handled = true;
                    }
                }
            }
        }

        protected virtual void OnCanExecute(CanExecuteRoutedEventArgs e)
        {
            if (!e.Handled)
            {
                e.CanExecute = true;
            }
        }

        public bool IsCancelButtonVisible
        {
            get { return (bool)GetValue(IsCancelButtonVisibleProperty); }
            set { SetValue(IsCancelButtonVisibleProperty, value); }
        }
    }
}
