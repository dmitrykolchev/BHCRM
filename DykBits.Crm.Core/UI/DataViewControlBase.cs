using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    public class DataViewControlBase : UserControl, IDataView, IActionProvider, IControlWithLayout
    {
        #region object FilterProperty { get; set; }

        public static readonly DependencyProperty FilterViewProperty = DependencyProperty.Register("FilterView", typeof(DataViewFilterControl), typeof(DataViewControlBase),
            new PropertyMetadata(null, OnFilterViewPropertyChanged));
        private static void OnFilterViewPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DataViewControlBase control = (DataViewControlBase)o;
            control.FilterViewInternal = (DataViewFilterControl)e.NewValue;
        }
        public DataViewFilterControl FilterView
        {
            get { return (DataViewFilterControl)GetValue(FilterViewProperty); }
            set { SetValue(FilterViewProperty, value); }
        }

        private DataViewFilterControl _filterView;
        internal DataViewFilterControl FilterViewInternal
        {
            get { return this._filterView; }
            set
            {
                if (this._filterView != value)
                {
                    if (this._filterView != null)
                        this._filterView.Owner = null;
                    this._filterView = value;
                    if (this._filterView != null)
                        this._filterView.Owner = this;
                }
            }
        }
        #endregion

        #region object ItemsSource { get; set; }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(object), typeof(DataViewControlBase),
            new PropertyMetadata(null, OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DataViewControlBase control = (DataViewControlBase)o;
            control.OnItemsSourceChanged(e.NewValue);
        }

        protected void OnItemsSourceChanged(object newValue)
        {
            ItemsSourceInternal = newValue;
        }

        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion

        #region Type DataSourceType { get; set; }
        public static readonly DependencyProperty DataSourceTypeProperty = DependencyProperty.Register("DataSourceType", typeof(Type), typeof(DataViewControlBase),
            new PropertyMetadata(null, OnDataSourceTypePropertyChanged));
        private static void OnDataSourceTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DataViewControlBase)d).OnDataSourceTypeChanged(e);
        }
        public Type DataSourceType
        {
            get { return (Type)GetValue(DataSourceTypeProperty); }
            set { SetValue(DataSourceTypeProperty, value); }
        }
        protected virtual void OnDataSourceTypeChanged(DependencyPropertyChangedEventArgs e)
        {
            if (DykBits.Crm.ApplicationManager.IsInitialized)
            {
                if (this.DataSourceType != null)
                {
                    this.ViewMetadata = ViewDataManager.GetMetadata(this.DataSourceType);
                    this.DocumentMetadata = this.ViewMetadata.Document;
                }
                else
                {
                    this.ViewMetadata = null;
                    this.DocumentMetadata = null;
                }
            }
        }
        protected ViewMetadata ViewMetadata
        {
            get;
            private set;
        }
        protected DocumentMetadata DocumentMetadata
        {
            get;
            private set;
        }
        #endregion

        private Filter _filterData;
        public DataViewControlBase()
        {
            if (ApplicationManager.IsInitialized)
            {
                this.Loaded += DataViewControlBase_Loaded;
                this.Unloaded += DataViewControlBase_Unloaded;
            }
            this.SerializeFilter = true;
        }
        [DefaultValue(true)]
        public bool SerializeFilter
        {
            get;
            set;
        }
        void DataViewControlBase_Unloaded(object sender, RoutedEventArgs e)
        {
            DocumentManager.RemoveEventListener(DocumentManager_DocumentOperationComplete);
        }
        void DataViewControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (ApplicationManager.IsInitialized)
            {
                DocumentManager.AddEventListener(DocumentManager_DocumentOperationComplete);
            }
        }
        public void LockRefresh()
        {
            ((IDataWindow)ParentWindow).CommandLocks[CrmApplicationCommands.Refresh].Lock();
        }
        public void UnlockRefresh()
        {
            ((IDataWindow)ParentWindow).CommandLocks[CrmApplicationCommands.Refresh].Unlock();
        }
        public virtual bool HasSelectedItems
        {
            get { return false; }
        }
        public virtual object SelectedItem
        {
            get { return null; }
        }
        public virtual object[] GetSelectedItems
        {
            get { return new object[0]; }
        }
        public virtual IDataItem[] GetSelectedDataItems()
        {
            return new IDataItem[0];
        }
        public virtual IDataItem SelectedDataItem
        {
            get
            {
                return null;
            }
        }
        internal void InvokeRequeryData()
        {
            RequeryData();
        }
        protected virtual void RequeryData()
        {
        }
        protected virtual void RestoreLayout()
        {
        }
        protected virtual void SaveLayout()
        {
        }
        protected virtual void ResetLayout()
        {
        }
        protected virtual object ItemsSourceInternal
        {
            get
            {
                System.Diagnostics.Debug.Fail("base class property called", "this property should be overrided");
                return null;
            }
            set
            {
                System.Diagnostics.Debug.Fail("base class property called", "this property should be overrided");
            }
        }
        protected Window ParentWindow
        {
            get
            {
                return Window.GetWindow(this);
            }
        }
        protected virtual bool RequireRefresh(DocumentOperationCompleteEventArgs e)
        {
            EditorWindow editorWindow = ParentWindow as EditorWindow;
            if (editorWindow != null)
            {
                if (e.Operation == DocumentOperation.Delete && e.Data == editorWindow.DataContext)
                {
                    return false;
                }
            }
            if (e.Data.DataItemClass == ViewMetadata.ClassName)
                return true;
            return false;
        }
        void DocumentManager_DocumentOperationComplete(object sender, DocumentOperationCompleteEventArgs e)
        {
            try
            {
                HandleDocumentOperationComplete(e);
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }
        protected virtual void HandleDocumentOperationComplete(DocumentOperationCompleteEventArgs e)
        {
            if (RequireRefresh(e))
            {
                if (CrmApplicationCommands.Refresh.CanExecute(null, ParentWindow))
                {
                    CrmApplicationCommands.Refresh.Execute(null, ParentWindow);
                }
            }
        }
        IViewDataAdapter _viewDataAdapter;
        protected IViewDataAdapter ViewDataAdapter
        {
            get
            {
                if (this.ViewMetadata != null)
                {
                    if (this._viewDataAdapter == null)
                    {
                        this._viewDataAdapter = ViewDataManager.CreateDataAdapterProxy(this.ViewMetadata);
                    }
                    return this._viewDataAdapter;
                }
                return null;
            }
        }
        public PresentationNode Node
        {
            get;
            set;
        }
        public object Parameter
        {
            get
            {
                if (this.Node != null)
                    return this.Node.Parameter;
                return null;
            }
        }
        protected virtual Filter CreateFilter()
        {
            if (ViewDataAdapter != null)
                return this.ViewDataAdapter.CreateFilter(this.DataContext, Parameter);
            return DykBits.Crm.Data.Filter.Empty;
        }
        public Filter DataSourceFilter
        {
            get
            {
                if (this._filterData == null)
                {
                    this._filterData = CreateFilter();
                    OnFilterDataChanged();
                }
                return this._filterData;
            }
            internal set
            {
                if (this._filterData != value)
                {
                    this._filterData = value;
                    OnFilterDataChanged();
                }
            }
        }
        protected virtual void OnFilterDataChanged()
        {
            if (FilterViewInternal != null)
                FilterViewInternal.DataContext = this._filterData;
        }
        public DataViewType ViewType
        {
            get { return DataViewType.CollectionView; }
        }
        public virtual bool CanDeactivate
        {
            get
            {
                return true;
            }
        }
        bool IDataView.CanDeactivate()
        {
            return CanDeactivate;
        }

        protected virtual bool CanOpenSelectedItem()
        {
            return false;
        }
        protected virtual void OpenSelectedItem()
        {
        }
        protected virtual void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.Default:
                    case UICommandId.Open:
                        e.CanExecute = CanOpenSelectedItem();
                        e.Handled = true;
                        break;
                    case UICommandId.ShowProperties:
                        e.CanExecute = HasSelectedItems;
                        e.Handled = true;
                        break;
                    case UICommandId.Refresh:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                    case UICommandId.SaveLayout:
                    case UICommandId.RestoreLayout:
                    case UICommandId.ResetLayout:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                }
            }
        }
        void ICommandTarget.CanExecute(CanExecuteRoutedEventArgs e)
        {
            CanExecute(e);
        }
        private void ShowProperties(object dataItem)
        {
            ApplicationManager.ShowDocumentProperties(Window.GetWindow(this), dataItem);
        }
        protected virtual void Executed(ExecutedRoutedEventArgs e)
        {
            if (!e.Handled)
            {
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    switch (command.Id)
                    {
                        case UICommandId.Default:
                        case UICommandId.Open:
                            OpenSelectedItem();
                            e.Handled = true;
                            break;
                        case UICommandId.ShowProperties:
                            ShowProperties(SelectedDataItem);
                            e.Handled = true;
                            break;
                        case UICommandId.Refresh:
                            InvokeRequeryData();
                            e.Handled = true;
                            break;
                        case UICommandId.SaveLayout:
                            SaveLayout();
                            e.Handled = true;
                            break;
                        case UICommandId.RestoreLayout:
                            RestoreLayout();
                            e.Handled = true;
                            break;
                        case UICommandId.ResetLayout:
                            ResetLayout();
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        void ICommandTarget.Executed(ExecutedRoutedEventArgs e)
        {
            Executed(e);
        }

        private UIActionCollection _actions;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UIActionCollection Actions
        {
            get
            {
                if (this._actions == null)
                    this._actions = new UIActionCollection();
                return this._actions;
            }
        }

        public virtual object Toolbar
        {
            get { return null; }
        }

        protected virtual void OnActivate()
        {
        }
        protected virtual void OnDeactivate()
        {
        }
        protected virtual void OnWindowClosed()
        {
        }

        void IDataView.OnActivate()
        {
            OnActivate();
        }

        void IDataView.OnDeactivate()
        {
            OnDeactivate();
        }
        void IDataView.OnWindowClosed()
        {
            OnWindowClosed();
        }
        void IControlWithLayout.SaveLayout()
        {
            SaveLayout();
        }
        void IControlWithLayout.RestoreLayout()
        {
            RestoreLayout();
        }
        void IControlWithLayout.ResetLayout()
        {
            ResetLayout();
        }

        protected virtual void OnStatusInfoChanged(StatusInfoChangedEventArgs e)
        {
            if (StatusInfoChanged != null)
                StatusInfoChanged(this, e);
        }

        public event EventHandler<StatusInfoChangedEventArgs> StatusInfoChanged;
    }
}
