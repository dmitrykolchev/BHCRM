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
using System.Windows.Threading;
using DevExpress.Xpf.Core;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : DataWindowBase, IDataWindow
    {
        private PresentationNode _node;
        private DataViewControlBase _viewControl;
        private Filter _filter;
        public DataGridWindow(string caption, Type viewControlType, Filter filter)
        {
            this._node = new PresentationNode { Caption = caption, ViewControlType = viewControlType, Key = viewControlType.Name };
            this._filter = filter;
            InitializeComponent();
            this.Closing += DataGridWindow_Closing;
        }
        void DataGridWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ApplicationManager.WindowData.UpdateInstance(PersistentData);
            IControlWithLayout control = this._viewControl as IControlWithLayout;
            if (control != null)
                control.SaveLayout();
        }
        private void Initialize()
        {
            RecreateView();
            this._viewControl.DataSourceFilter = this._filter;
            this.Title = this._node.Caption;
            this.Icon = this._node.LargeImage;
        }
        private void RecreateView()
        {
            this._viewControl = (DataViewControlBase)this._node.CreateViewControl();
            this._viewControl.SerializeFilter = false;
            this.gridContainer.Content = this._viewControl;
            OnActiveViewChanged();
        }
        public override IDataView ActiveView
        {
            get
            {
                return (IDataView)this._viewControl;
            }
        }
        public static DataGridWindow Create(string caption, Type controlType, Filter filter = null)
        {
            var window = new DataGridWindow(caption, controlType, filter);
            try
            {
                window.Initialize();
                return window;
            }
            catch
            {
                window.Close();
                throw;
            }
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.RecreatePresentation)
                {
                    e.CanExecute = true;
                    e.Handled = true;
                }
            }
            if (!e.Handled && this.ActiveView != null)
            {
                this.ActiveView.CanExecute(e);
            }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.RecreatePresentation)
                {
                    RecreateView();
                    e.Handled = true;
                }
            }
            if (!e.Handled && this.ActiveView != null)
            {
                this.ActiveView.Executed(e);
            }
        }
        public override DataPresentationType WindowType
        {
            get { return DataPresentationType.Child; }
        }
        public override string WindowKey
        {
            get
            {
                return this.GetType().Name + "_" + this._node.Key;
            }
        }
    }
}
