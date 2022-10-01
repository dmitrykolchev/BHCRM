using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    public enum CommonFields
    {
        None,
        Comments,
        Attachments,
        All
    }
    public class EditorControlBase : UserControl, IDataView, IActionProvider, IControlWithLayout
    {
        static EditorControlBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditorControlBase), new FrameworkPropertyMetadata(typeof(EditorControlBase)));
        }
        #region string Comments { get; set; }
        public static readonly DependencyProperty CommentsProperty = DependencyProperty.Register("Comments", typeof(string), typeof(EditorControlBase),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnCommentsPropertyChanged, CoerceCommentsProperty));

        private static void OnCommentsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceCommentsProperty(DependencyObject d, object baseValue)
        {
            if (baseValue != null)
                return baseValue;
            return string.Empty;
        }

        public string Comments
        {
            get { return (string)GetValue(CommentsProperty); }
            set { SetValue(CommentsProperty, value); }
        }
        #endregion
        #region CommonFields CommonFields { get; set; }
        public static readonly DependencyProperty CommonFieldsProperty = DependencyProperty.Register("CommonFields", typeof(CommonFields), typeof(EditorControlBase),
            new FrameworkPropertyMetadata(CommonFields.All, FrameworkPropertyMetadataOptions.None, OnCommonFieldsPropertyChanged));

        private static void OnCommonFieldsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public CommonFields CommonFields
        {
            get { return (CommonFields)GetValue(CommonFieldsProperty); }
            set { SetValue(CommonFieldsProperty, value); }
        }
        #endregion

        public EditorControlBase()
        {
            this.Focusable = false;
            if (ApplicationManager.IsInitialized)
            {
                this.Loaded += EditorControlBase_Loaded;
            }
            this.DataContextChanged += EditorControlBase_DataContextChanged;
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                this.Background = Brushes.Transparent;
            }
        }

        void EditorControlBase_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                InvokeUnwireEvents();
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

        private bool _initialized;
        void EditorControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= EditorControlBase_Loaded;
            Initialize();
            this._initialized = true;
            InvokeWireEvents();
        }

        private Button _attachmentButton;
        private AttachmentList _attachmentList;
        private TextBox _commentsTextBox;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._commentsTextBox = (TextBox)GetTemplateChild("CommentsTextBox_Part");
            this._attachmentButton = (Button)GetTemplateChild("AttachmentButton_Part");
            this._attachmentButton.Click += _attachmentButton_Click;
            this._attachmentList = (AttachmentList)GetTemplateChild("AttachmentList_Part");
            this._attachmentList.AllowDrop = true;
            this._attachmentList.PreviewDragEnter += _attachmentList_PreviewDragEnter;
            this._attachmentList.PreviewDragOver += _attachmentList_PreviewDragOver;
            this._attachmentList.PreviewDrop += _attachmentList_PreviewDrop;
        }
        void _attachmentList_PreviewDrop(object sender, DragEventArgs e)
        {
            DoDrop(e);
            e.Handled = true;
        }
        void _attachmentList_PreviewDragOver(object sender, DragEventArgs e)
        {
            DoDragOver(e);
            e.Handled = true;
        }
        void _attachmentList_PreviewDragEnter(object sender, DragEventArgs e)
        {
            DoDragEnter(e);
            e.Handled = true;
        }
        private bool CanEditAttachments()
        {
            return true;
        }
        private void DoDragEnter(DragEventArgs e)
        {
            if (CanEditAttachments() && e.Data != null)
            {
                if (e.Data.GetDataPresent("FileNameW") || e.Data.GetDataPresent("FileGroupDescriptorW") || e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    e.Effects = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effects = DragDropEffects.None;
        }
        private void DoDragOver(DragEventArgs e)
        {
            if (CanEditAttachments() && e.Data != null)
            {
                if (e.Data.GetDataPresent("FileNameW") || e.Data.GetDataPresent("FileGroupDescriptorW") || e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    e.Effects = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effects = DragDropEffects.None;
        }
        private void DoDrop(DragEventArgs e)
        {
            if (!CanEditAttachments() || e.Data == null)
                return;
            using (WaitCursor cursor = new WaitCursor())
            {
                if (e.Data.GetDataPresent("FileNameW"))
                {
                    string[] files = (string[])e.Data.GetData("FileNameW");
                    if (files.Length > 0)
                    {
                        foreach (string file in files)
                        {
                            AttachmentItem item = AttachmentItem.CreateInstance(file);
                            DataItem dataItem = this.DataSource as DataItem;
                            if (dataItem != null)
                                dataItem.Attachments.Add(item);
                        }
                    }
                }
                else if (e.Data.GetDataPresent("FileGroupDescriptorW") || e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    FileGroupDescriptorHelper fgdh = new FileGroupDescriptorHelper(e.Data);
                    for (int index = 0; index < fgdh.GetFileCount(); ++index)
                    {
                        FileGroupDescriptorHelper.FileContent content = fgdh.ReadFileContent(index);
                        AttachmentItem item = AttachmentItem.CreateInstance(content.FileName, content.Stream);
                        DataItem dataItem = this.DataSource as DataItem;
                        if (dataItem != null)
                            dataItem.Attachments.Add(item);
                    }
                }
            }
        }
        void _attachmentButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                AttachmentItem item = AttachmentItem.CreateInstance(dialog.FileName);
                DataItem dataItem = this.DataSource as DataItem;
                if (dataItem != null)
                {
                    dataItem.Attachments.Add(item);
                }
            }
        }
        protected virtual void Initialize()
        {
        }
        public PresentationNode Node
        {
            get;
            set;
        }
        void ICommandTarget.CanExecute(CanExecuteRoutedEventArgs e)
        {
            CanExecute(e);
        }
        void ICommandTarget.Executed(ExecutedRoutedEventArgs e)
        {
            Execute(e);
        }
        protected virtual void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.PrintPreview:
                    case UICommandId.Print:
                        e.CanExecute = this.DataSource != null && DocumentManager.GetMetadata(this.DataSource.GetType()).Reports.Count > 0;
                        e.Handled = true;
                        break;
                }
            }
        }
        protected virtual void Execute(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.PrintPreview:
                    case UICommandId.Print:
                        ShowPrintPreview();
                        e.Handled = true;
                        break;
                }
            }
        }
        public virtual string GetReportSelector()
        {
            return null;
        }
        private void ShowPrintPreview()
        {
            IDocumentReportInfo documentReportInfo = ApplicationManager.SelectReport(DataSource.DataItemClass, GetReportSelector());
            if (documentReportInfo != null)
            {
                using (new WaitCursor())
                {
                    DocumentReportManager reportManager = ServiceManager.GetService<DocumentReportManager>();

                    Stream stream = reportManager.GetReportStream(documentReportInfo);
                    var documentItem = DocumentManager.GetItem(this.DataSource.GetKey());
                    var reportDataSource = reportManager.ConvertToReportDataSource(documentItem);
                    ReportWindow window = ReportWindow.Create(this.ParentWindow, this.DataSource.FileAs, stream, reportDataSource.GetReportData());
                    window.Show();
                }
            }
        }

        public IDataItem DataSource
        {
            get
            {
                return (IDataItem)this.DataContext;
            }
        }
        public virtual IDataItem SelectedDataItem
        {
            get
            {
                return this.DataSource;
            }
        }
        public DataViewType ViewType
        {
            get { return DataViewType.ItemView; }
        }
        public EditorWindow ParentWindow
        {
            get
            {
                return Window.GetWindow(this) as EditorWindow;
            }
        }
        bool IDataView.CanDeactivate()
        {
            return this.CanDeactivate();
        }
        protected virtual bool CanDeactivate()
        {
            if (ParentWindow != null)
            {
                if (ParentWindow.Dirty)
                {
                    MessageBoxButton buttons = this.DataSource.IsNew ? MessageBoxButton.YesNo : MessageBoxButton.YesNoCancel;
                    MessageBoxResult result = ApplicationManager.ShowQuestion("Для продолжения операции необходимо сохранить измененные данные. Продолжить?", buttons);
                    if (result == MessageBoxResult.Yes)
                    {
                        CrmApplicationCommands.Save.Execute(null, ParentWindow);
                        return !ParentWindow.Dirty;
                    }
                    else if (result == MessageBoxResult.Cancel || (result == MessageBoxResult.No && this.DataSource.IsNew))
                    {
                        return false;
                    }
                }
                else if (DataSource != null && DataSource.IsNew)
                {
                    ApplicationManager.ShowWarning("Необходимо сохранить документ в базе данных.", MessageBoxButton.OK);
                    return false;
                }
            }
            return true;
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
        internal void InvokeDataSourceChanged(DataSourceChangedEventArgs e)
        {
            OnDataSourceChanged(e);
        }
        protected virtual void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
        }
        protected virtual void OnStatusInfoChanged(StatusInfoChangedEventArgs e)
        {
            if (StatusInfoChanged != null)
                StatusInfoChanged(this, e);
        }

        public event EventHandler<StatusInfoChangedEventArgs> StatusInfoChanged;
        void IControlWithLayout.SaveLayout()
        {
            OnSaveLayout();
        }
        void IControlWithLayout.RestoreLayout()
        {
            OnRestoreLayout();
        }
        void IControlWithLayout.ResetLayout()
        {
            OnResetLayout();
        }
        protected virtual void OnSaveLayout()
        {
        }
        protected virtual void OnRestoreLayout()
        {
        }
        protected virtual void OnResetLayout()
        {
        }
        private bool _wired;
        internal void InvokeWireEvents()
        {
            if (this._initialized)
            {
                if (!this._wired)
                {
                    WireEvents();
                    this._wired = true;
                }
            }
        }
        protected virtual void WireEvents()
        {
        }
        internal void InvokeUnwireEvents()
        {
            UnwireEvents();
            this._wired = false;
        }
        protected virtual void UnwireEvents()
        {
        }

    }
}
