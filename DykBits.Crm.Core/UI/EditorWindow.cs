using System;
using System.ComponentModel;
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
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    public abstract class EditorWindow : DataWindowBase
    {
        private PresentationManager _viewManager;
        private bool _dirty;
        private List<PresentationExtension> _extensions = new List<PresentationExtension>();

        public EditorWindow(string windowKey)
        {
            WindowManager windowManager = ServiceManager.GetService<WindowManager>();
            this._viewManager = windowManager.Windows[windowKey];
        }
        public override DataPresentationType WindowType
        {
            get { return DataPresentationType.Child; }
        }
        public PresentationManager PresentationManager
        {
            get { return this._viewManager; }
        }
        void EditorWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!ValidateAttachments())
                {
                    e.Cancel = true;
                    return;
                }
                if (ValidateDirtyState(true) == false)
                {
                    e.Cancel = true;
                    return;
                }
                if (this.WindowState == System.Windows.WindowState.Minimized || this.WindowState == System.Windows.WindowState.Maximized)
                    this.WindowState = System.Windows.WindowState.Normal;
                ApplicationManager.WindowData.UpdateInstance(PersistentData);
                OnSaveLayout();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
                e.Cancel = true;
            }
        }
        private bool ValidateAttachments()
        {
            DataItem dataItem = this.DataContext as DataItem;
            if (dataItem != null)
            {
                int count = dataItem.Attachments.Where(t => t.IsModified).Count();
                if (count == 0)
                    return true;
                MessageBoxResult result = ApplicationManager.ShowQuestion("Одно или более вложений были изменены. Хотите обновить измененные вложения?", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var item in dataItem.Attachments)
                    {
                        if (item.IsModified)
                            item.UpdateBlobEntry();
                    }
                    return true;
                }
                return result == MessageBoxResult.No;
            }
            return true;
        }

        protected virtual void OnSaveLayout()
        {
        }

        protected virtual void OnUpdateUI()
        {
        }

        private void InvokeUpdateUI(object sender, EventArgs e)
        {
            try
            {
                OnUpdateUI();
            }
            catch { }
        }

        protected virtual void InitializePresentations()
        {
            throw new NotImplementedException();
        }

        protected virtual void InitializeChangeStateMenu()
        {
            throw new NotImplementedException();
        }

        private void CreateExtensions()
        {
            foreach (PresentationExtensionType extensionType in this._viewManager.ExtensionTypes)
            {
                PresentationExtension viewExtension = PresentationExtension.Create(extensionType, this);
                Extensions.Add(viewExtension);
            }
        }

        private DispatcherTimer _idleTimer;
        private void Initialize(IDataItem dataSource)
        {
            this.InputBindings.Add(new KeyBinding(CrmApplicationCommands.Save, Key.S, ModifierKeys.Control));
            this.InputBindings.Add(new KeyBinding(CrmApplicationCommands.SaveAndClose, Key.S, ModifierKeys.Control | ModifierKeys.Shift));
            this.InputBindings.Add(new KeyBinding(CrmApplicationCommands.Delete, Key.D, ModifierKeys.Control));
            this.InputBindings.Add(new KeyBinding(CrmApplicationCommands.CloseWindow, Key.Escape, ModifierKeys.None));
            InitializePresentations();
            CreateExtensions();

            this._idleTimer = new DispatcherTimer(DispatcherPriority.ApplicationIdle, this.Dispatcher);
            this._idleTimer.Tick += InvokeUpdateUI;
            this._idleTimer.Interval = TimeSpan.FromMilliseconds(100);
            this._idleTimer.Start();

            this.DataSource = dataSource;

            this.Closing += EditorWindow_Closing;
            this.Closed += EditorWindow_Closed;
        }

        void EditorWindow_Closed(object sender, EventArgs e)
        {
            this._idleTimer.Stop();
            this._idleTimer.Tick -= InvokeUpdateUI;
            this.ActiveView.OnWindowClosed();
            this.Content = null;
        }

        private IDataItem _dataSource;
        private INotifyPropertyChanged _dataSourceProxy;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IDataItem DataSource
        {
            get { return this._dataSource; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (this._dataSource != value)
                {
                    
                    DataSourceChangedEventArgs args = new DataSourceChangedEventArgs(this._dataSource, value);
                    OnDataSourceChanging(args);

                    if (this._dataSource != null && this._dataSource.DataItemClass != value.DataItemClass)
                        throw new InvalidOperationException();

                    if (this._dataSourceProxy != null)
                    {
                        this._dataSourceProxy.PropertyChanged -= DataSource_PropertyChanged;
                    }
                    this._dataSource = value;
                    this._dataSourceProxy = value as INotifyPropertyChanged;
                    if (this._dataSourceProxy != null)
                    {
                        this._dataSourceProxy.PropertyChanged += DataSource_PropertyChanged;
                    }
                    this.DataContext = this._dataSource;
                    InitializeChangeStateMenu();
                    OnDataSourceChanged(args);
                }
            }
        }
        protected virtual void OnDataSourceChanging(DataSourceChangedEventArgs e)
        {
        }

        protected virtual void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
            if (this.DataSourceChanged != null)
                this.DataSourceChanged(this, e);
        }

        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        protected IList<PresentationExtension> Extensions
        {
            get { return this._extensions; }
        }
        private bool _messageReadOnly;
        void DataSource_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (DataSource.IsReadOnly)
            {
                if (!_messageReadOnly)
                {
                    var messageBoxService = ServiceManager.GetService<IMessageBoxService>();
                    messageBoxService.ShowWarning("Документ открыт в режиме только для чтения, изменения не будут сохранены!", MessageBoxButton.OK);
                    _messageReadOnly = true;
                }
            }
            else
            {
                Dirty = true;
            }
        }
        protected virtual void RecreateView()
        {
        }
        public static EditorWindow CreateWindow(IDataItem dataSource, string windowKey = null)
        {
            if (string.IsNullOrEmpty(windowKey))
                windowKey = dataSource.DataItemClass;
            EditorWindow window = new TabbedEditorWindow(windowKey);
            try
            {
                window.Initialize(dataSource);
                return window;
            }
            catch
            {
                window.Close();
                throw;
            }
        }
        internal bool CanExecuteCreate()
        {
            if (ActiveView is EditorControlBase)
            {
                return this.DataSource.Metadata.CanCreate;
            }
            return false;
        }
        internal bool CanExecuteDelete()
        {
            if (ActiveView is EditorControlBase)
            {
                if (this.DataSource.IsNew)
                    return true;
                return ((DataItemBase)this.DataSource).CanDelete;
            }
            return false;
        }
        internal bool CanExecuteSave()
        {
            if (ActiveView is EditorControlBase)
            {
                if (this.DataSource.IsNew)
                    return true;
                return !this.DataSource.IsReadOnly;
            }
            return false;
        }
        internal bool CanExecuteChangeDocumentState(DocumentState state)
        {
            if (ActiveView is EditorControlBase && state != null)
            {
                if (this.DataSource.IsNew || this.DataSource.State == state.State)
                    return false;
                return ((DataItemBase)this.DataSource).CanChangeStateTo(state.State);
            }
            return false;
        }
        private void HandleCanExecutedInternal(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null && this.DataSource != null)
            {
                switch (command.Id)
                {
                    case UICommandId.ActivateView:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                    case UICommandId.Create:
                        e.CanExecute = CanExecuteCreate();
                        e.Handled = true;
                        break;
                    case UICommandId.ShowProperties:
                        e.CanExecute = ActiveView is EditorControlBase && !this.DataSource.IsNew;
                        e.Handled = true;
                        break;
                    case UICommandId.Delete:
                        e.CanExecute = CanExecuteDelete();
                        e.Handled = true;
                        break;
                    case UICommandId.Save:
                        e.CanExecute = CanExecuteSave();
                        e.Handled = true;
                        break;
                    case UICommandId.SaveAndClose:
                        e.CanExecute = CanExecuteSave();
                        e.Handled = true;
                        break;
                    case UICommandId.Refresh:
                        e.CanExecute = !this.DataSource.IsNew;
                        e.Handled = true;
                        break;
                    case UICommandId.CloseWindow:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                    case UICommandId.ChangeDocumentState:
                        e.CanExecute = CanExecuteChangeDocumentState(e.Parameter as DocumentState);
                        e.Handled = true;
                        break;
                    case UICommandId.RecreatePresentation:
                        e.CanExecute = this.ActiveView is IControlWithLayout;
                        e.Handled = true;
                        break;
                    case UICommandId.PrintPreview:
                        e.CanExecute = this.DataSource != null && DocumentManager.GetMetadata(this.DataSource.DataItemClassId).Reports.Count > 0;
                        e.Handled = true;
                        break;
                }
            }
        }
        protected void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CommandLocks.IsLocked(e.Command))
            {
                e.CanExecute = false;
                e.Handled = true;
                return;
            }
            foreach (PresentationExtension extension in this.Extensions)
            {
                extension.InvokeCanExecute(e);
                if (e.Handled)
                    break;
            }
            if (!e.Handled)
            {
                ICommandTarget dataView = ActiveView;
                if (dataView != null)
                {
                    dataView.CanExecute(e);
                }
            }
            if (!e.Handled)
            {
                HandleCanExecutedInternal(e);
            }
        }
        protected abstract void ActivateView(object parameter);
        private void HandleExecutedInternal(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.ActivateView:
                        ActivateView(e.Parameter);
                        e.Handled = true;
                        break;
                    case UICommandId.Create:
                        CreateDocument();
                        e.Handled = true;
                        break;
                    case UICommandId.ShowProperties:
                        ShowProperties();
                        e.Handled = true;
                        break;
                    case UICommandId.Delete:
                        DeleteItem();
                        e.Handled = true;
                        break;
                    case UICommandId.Refresh:
                        RefreshItem();
                        e.Handled = true;
                        break;
                    case UICommandId.Save:
                        SaveItem();
                        e.Handled = true;
                        break;
                    case UICommandId.SaveAndClose:
                        SaveItem(false);
                        this.Close();
                        e.Handled = true;
                        break;
                    case UICommandId.CloseWindow:
                        CloseWindow();
                        e.Handled = true;
                        break;
                    case UICommandId.ChangeDocumentState:
                        ChangeDocumentState(e.Parameter as DocumentState);
                        e.Handled = true;
                        break;
                    case UICommandId.RecreatePresentation:
                        RecreateView();
                        e.Handled = true;
                        break;
                }
            }
        }
        protected void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (PresentationExtension extension in this.Extensions)
            {
                extension.InvokeExecute(e);
                if (e.Handled)
                    break;
            }
            if (!e.Handled)
            {
                ICommandTarget dataView = ActiveView;
                if (dataView != null)
                {
                    dataView.Executed(e);
                }
            }
            if (!e.Handled)
            {
                HandleExecutedInternal(e);
            }
        }
        public bool Dirty
        {
            get
            {
                return this._dirty;
            }
            private set
            {
                this._dirty = value;
            }
        }
        private void CreateDocument()
        {
            using (new WaitCursor())
            {
                DocumentMetadata metadata = DocumentManager.GetMetadata(this.DataSource.DataItemClassId);
                WindowManager.CreateDocument(metadata, this.DataSource);
            }
        }
        private void CloseWindow()
        {
            Close();
        }
        private void RefreshItem()
        {
            bool? result = ValidateDirtyState();
            if (result == null)
            {
                using (new WaitCursor())
                {
                    RefreshItemInternal();
                }
            }
        }
        private void RefreshItemInternal()
        {
            this.DataSource = DocumentManager.GetItem(this.DataSource.GetKey());
            this.Dirty = false;
        }
        private void DeleteItem()
        {
            MessageBoxResult result = ApplicationManager.ShowWarning("Данный элемент будет удален.\r\nПродолжить?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (new WaitCursor())
                {
                    CommandLocks[CrmApplicationCommands.Delete].Lock();
                    try
                    {
                        DocumentManager.DeleteItem(this.DataSource);
                        Close();
                    }
                    finally
                    {
                        CommandLocks[CrmApplicationCommands.Delete].Unlock();
                    }
                }
            }
        }
        public void SaveItem(bool rebind = true)
        {
            using (new WaitCursor())
            {
                UpdateDataSource();
                IDataItem result = DocumentManager.SaveItem(this.DataSource);
                if (rebind)
                    this.DataSource = result;
                this.Dirty = false;
            }
        }
        protected void UpdateDataSource()
        {
            IInputElement element = FocusManager.GetFocusedElement(this);
            if (element != null)
            {
                FocusManager.SetFocusedElement(this, null);
                FocusManager.SetFocusedElement(this, element);
            }
        }
        private void ShowProperties()
        {
            ApplicationManager.ShowDocumentProperties(this, this.DataSource);
        }
        private void ChangeDocumentState(DocumentState newState)
        {
            if (ValidateDirtyState() != false)
            {
                DocumentStateChangingEventArgs args = new DocumentStateChangingEventArgs(this.DataSource, newState);
                OnDocumentStateChanging(args);
                if (!args.Cancel)
                {
                    using (new WaitCursor())
                    {
                        DocumentManager.ChangeDocumentState(this.DataSource, newState, args.ApplicationData);
                        RefreshItemInternal();
                    }
                    DocumentStateChangedEventArgs changedArgs = new DocumentStateChangedEventArgs(this.DataSource);
                    OnDocumentStateChanged(changedArgs);
                }
            }
        }
        protected virtual void OnDocumentStateChanging(DocumentStateChangingEventArgs e)
        {
            if (DocumentStateChanging != null)
                DocumentStateChanging(this, e);
        }
        protected virtual void OnDocumentStateChanged(DocumentStateChangedEventArgs e)
        {
            if (DocumentStateChanged != null)
                DocumentStateChanged(this, e);
        }
        public event EventHandler<DocumentStateChangingEventArgs> DocumentStateChanging;
        public event EventHandler<DocumentStateChangedEventArgs> DocumentStateChanged;
        public void ActivateWindow()
        {
            if (this.WindowState == System.Windows.WindowState.Minimized)
                this.WindowState = System.Windows.WindowState.Normal;
            this.Activate();
        }

        public void SilentClose()
        {
            this.Dirty = false;
            this.Close();
        }

        public bool? ValidateDirtyState(bool activate = false)
        {
            UpdateDataSource();
            if (!this.DataSource.IsReadOnly)
            {
                if (Dirty)
                {
                    this.ActivateWindow();
                    MessageBoxResult result = ApplicationManager.ShowQuestion("Данные были изменены. Сохранить изменения?", MessageBoxButton.YesNoCancel);
                    if (result == MessageBoxResult.Cancel)
                        return false;
                    if (result == MessageBoxResult.Yes)
                    {
                        SaveItem();
                        return true;
                    }
                }
            }
            return null;
        }
        public override string WindowKey
        {
            get
            {
                return this._viewManager.Key;
            }
        }
    }
}
