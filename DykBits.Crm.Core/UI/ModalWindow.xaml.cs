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
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : DXWindow
    {
        public static double GetDefaultWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(DefaultWidthProperty);
        }

        public static void SetDefaultWidth(DependencyObject obj, double value)
        {
            obj.SetValue(DefaultWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for DefaultWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultWidthProperty =
            DependencyProperty.RegisterAttached("DefaultWidth", typeof(double), typeof(ModalWindow), new PropertyMetadata(Double.NaN));

        public static double GetDefaultHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(DefaultHeightProperty);
        }

        public static void SetDefaultHeight(DependencyObject obj, double value)
        {
            obj.SetValue(DefaultHeightProperty, value);
        }

        // Using a DependencyProperty as the backing store for DefaultHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultHeightProperty =
            DependencyProperty.RegisterAttached("DefaultHeight", typeof(double), typeof(ModalWindow), new PropertyMetadata(Double.NaN));

        private ICommandTarget _commandTarget;
        public ModalWindow()
        {
            InitializeComponent();
        }

        public static ModalWindow Create(string title, Control control, object data, Window owner = null)
        {
            ModalWindow window = new ModalWindow();
            window.Initialize(title, control);
            if (owner != null)
                window.Owner = owner;
            else
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.DataContext = data;
            return window;
        }

        private void Initialize(string title, Control control)
        {
            this.Title = title;
            double defaultWidth = GetDefaultWidth(control);
            if (!Double.IsNaN(defaultWidth))
                this.Width = defaultWidth + 32;
            double defaultHeight = GetDefaultHeight(control);
            if (!Double.IsNaN(defaultHeight))
                this.Height = defaultHeight + 96;
            this._commandTarget = control as ICommandTarget;
            this.contentPresenter.Content = control;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this._commandTarget != null)
                this._commandTarget.CanExecute(e);
            if (!e.Handled)
            {
                UICommand command = e.Command as UICommand;
                switch (command.Id)
                {
                    case UICommandId.OK:
                    case UICommandId.Cancel:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                }
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this._commandTarget != null)
                this._commandTarget.Executed(e);
            UICommand command = e.Command as UICommand;
            if (!e.Handled)
            {
                if (command.Id == UICommandId.Cancel)
                {
                    this.DialogResult = false;
                    e.Handled = true;
                }
            }
            else
            {
                if (command.Id == UICommandId.OK)
                {
                    this.DialogResult = true;
                }
            }
        }
    }
}
