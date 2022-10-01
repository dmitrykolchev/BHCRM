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
    public enum SelectionMode
    {
        Single,
        MultiplyWithCheckBox
    }
    /// <summary>
    /// Interaction logic for SelectorDialogBox.xaml
    /// </summary>
    public partial class SelectorDialogBox : DataWindowBase, IDataWindow
    {
        private PresentationNode _node;
        private DataViewControlBase _selectorControl;
        private SelectionMode _selectionMode;
        public SelectorDialogBox(string selectorKey)
        {
            WindowManager windowManager = ServiceManager.GetService<WindowManager>();
            PresentationManager presentationManager = windowManager.Windows[WindowManager.SelectorsNode];
            this._node = presentationManager.Children[selectorKey];
            InitializeComponent();
            this.Loaded += SelectorDialogBox_Loaded;
        }
        public SelectorDialogBox(string caption, Type viewControlType)
        {
            this._node = new PresentationNode { Caption = caption, ViewControlType = viewControlType, Key = viewControlType.Name };
            InitializeComponent();
            this.Loaded += SelectorDialogBox_Loaded;
        }
        void SelectorDialogBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= SelectorDialogBox_Loaded;
            this.Closing += SelectorDialogBox_Closing;
        }
        public SelectionMode SelectionMode
        {
            get { return this._selectionMode; }
            set
            {
                this._selectionMode = value;
            }
        }
        void SelectorDialogBox_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ApplicationManager.WindowData.UpdateInstance(PersistentData);
            IControlWithLayout control = this._selectorControl as IControlWithLayout;
            if (control != null)
                control.SaveLayout();
        }
        private void Initialize(Filter filter)
        {
            RecreateView();
            if (filter != null)
            {
                if (string.IsNullOrEmpty(filter.Presentation))
                    filter.Presentation = this._node.Parameter as string;
                this._selectorControl.DataSourceFilter = filter;
            }
            this.Title = this._node.Caption;
            this.Icon = this._node.LargeImage;
        }
        private void RecreateView()
        {
            this._selectorControl = (DataViewControlBase)this._node.CreateViewControl();
            this._selectorControl.SerializeFilter = false;
            this.gridContainer.Content = this._selectorControl;
            OnActiveViewChanged();
        }
        public override IDataView ActiveView
        {
            get
            {
                return (IDataView)this._selectorControl;
            }
        }
        public static SelectorDialogBox Create(string selectorKey, Filter filter = null)
        {
            if (string.IsNullOrWhiteSpace(selectorKey))
                throw new ArgumentNullException("className");
            SelectorDialogBox dialogBox = new SelectorDialogBox(selectorKey);
            try
            {
                dialogBox.Initialize(filter);
                return dialogBox;
            }
            catch
            {
                dialogBox.Close();
                throw;
            }
        }
        public static SelectorDialogBox Create(string title, Type selectorControlType, Filter filter = null)
        {
            SelectorDialogBox dialogBox = new SelectorDialogBox(title, selectorControlType);
            try
            {
                dialogBox.Initialize(filter);
                return dialogBox;
            }
            catch
            {
                dialogBox.Close();
                throw;
            }
        }
        public object SelectedItem
        {
            get
            {
                if (ActiveView != null)
                    return ActiveView.SelectedDataItem;
                return null;
            }
        }
        public IDataItem[] SelectedItems
        {
            get
            {
                if (this._selectorControl is SelectorGridControl)
                    return ((SelectorGridControl)this._selectorControl).GetCheckedItems();
                return this._selectorControl.GetSelectedDataItems();
            }
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                if (command.Id == UICommandId.OK)
                {
                    if (SelectionMode == UI.SelectionMode.Single)
                    {
                        e.CanExecute = SelectedItem != null;
                    }
                    else
                    {
                        e.CanExecute = SelectedItems.Length > 0;
                    }
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.Default)
                {
                    if (SelectionMode == SelectionMode.Single)
                    {
                        e.CanExecute = SelectedItem != null;
                    }
                    else
                    {
                        e.CanExecute = SelectedItem != null;
                    }
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.Cancel)
                {
                    e.CanExecute = true;
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.RecreatePresentation)
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
                if (command.Id == UICommandId.OK)
                {
                    this.DialogResult = true;
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.Default)
                {
                    if (SelectionMode == SelectionMode.Single)
                    {
                        this.DialogResult = true;
                        e.Handled = true;
                    }
                }
                else if (command.Id == UICommandId.Cancel)
                {
                    this.DialogResult = false;
                    e.Handled = true;
                }
                else if (command.Id == UICommandId.RecreatePresentation)
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
