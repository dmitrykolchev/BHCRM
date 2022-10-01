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
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for DocumentSelectorWindow.xaml
    /// </summary>
    public partial class DocumentSelectorWindow : DataWindowBase
    {
        public static readonly DependencyProperty DataControlProperty = DependencyProperty.Register("DataControl", typeof(IDataView), typeof(DocumentSelectorWindow),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnDataControlPropertyChanged));
        private static void OnDataControlPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DocumentSelectorWindow window = (DocumentSelectorWindow)d;
            window.OnDataControlChanged(e);
        }
        public IDataView DataControl
        {
            get { return (IDataView)GetValue(DataControlProperty); }
            set { SetValue(DataControlProperty, value); }
        }
        protected virtual void OnDataControlChanged(DependencyPropertyChangedEventArgs e)
        {
            OnActiveViewChanged();
        }
        public DocumentSelectorWindow()
        {
            InitializeComponent();
            this.Closing += DocumentSelectorWindow_Closing;
        }
        void DocumentSelectorWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Closing -= DocumentSelectorWindow_Closing;
            try
            {
                var controlWithLayout = this.DataControl as IControlWithLayout;
                if (controlWithLayout != null)
                {
                    controlWithLayout.SaveLayout();
                }
            }
            catch { }
        }
        public Action<object> AddItemCallback { get; set; }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.Default:
                        e.CanExecute = this.DataControl != null && this.DataControl.SelectedDataItem != null;
                        e.Handled = true;
                        break;
                    case UICommandId.CloseWindow:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                }
            }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.Default:
                        object item = this.DataControl.SelectedDataItem;
                        if (AddItemCallback != null)
                            this.AddItemCallback(item);
                        e.Handled = true;
                        break;
                    case UICommandId.CloseWindow:
                        this.Close();
                        e.Handled = true;
                        break;
                }
            }
        }
        public override DataPresentationType WindowType
        {
            get { return DataPresentationType.Child; }
        }
        public override IDataView ActiveView
        {
            get { return this.DataControl; }
        }
    }
}
