using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Diagnostics;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DykBits.Crm.Data;
using DykBits.Crm.Input;
using DevExpress.Xpf.Bars;

namespace DykBits.Crm.UI
{
    public class DataGridControlBase : DataViewControlBase
    {
        static DataGridControlBase()
        {
            CommandManager.RegisterClassCommandBinding(typeof(DataGridControlBase),
                new CommandBinding(CrmApplicationCommands.ChangeDocumentState, OnCommandExecuted, OnCanExecuteCommand));
            CommandManager.RegisterClassInputBinding(typeof(DataGridControlBase),
                new InputBinding(CrmApplicationCommands.Delete, new KeyGesture(Key.D, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(DataGridControlBase),
                new InputBinding(CrmApplicationCommands.Open, new KeyGesture(Key.O, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(DataGridControlBase),
                new InputBinding(CrmApplicationCommands.Create, new KeyGesture(Key.N, ModifierKeys.Control)));
            CommandManager.RegisterClassInputBinding(typeof(DataGridControlBase),
                new InputBinding(CrmApplicationCommands.Refresh, new KeyGesture(Key.F5, ModifierKeys.None)));
        }

        private static void OnCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((DataGridControlBase)sender).Executed(e);
        }

        private static void OnCanExecuteCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            ((DataGridControlBase)sender).CanExecute(e);
        }

        protected override bool RequireRefresh(DocumentOperationCompleteEventArgs e)
        {
            return (e.Data.DataItemClass == ViewMetadata.ClassName);
        }

        #region bool ShowBorder { get; set; }
        public static readonly DependencyProperty ShowBorderProperty = DependencyProperty.Register("ShowBorder", typeof(bool), typeof(DataGridControlBase),
            new PropertyMetadata(false, OnShowBorderPropertyChanged));
        private static void OnShowBorderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridControl control = ((DataGridControlBase)d).GridView;
            if (control != null)
            {
                control.ShowBorder = (bool)e.NewValue;
            }
        }
        public bool ShowBorder
        {
            get { return (bool)GetValue(ShowBorderProperty); }
            set { SetValue(ShowBorderProperty, value); }
        }
        #endregion

        #region GridControl GridView { get; set; }
        public static readonly DependencyProperty GridViewProperty = DependencyProperty.Register("GridView", typeof(GridControl), typeof(DataGridControlBase),
            new PropertyMetadata(null, OnGridViewPropertyChanged));
        private static void OnGridViewPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DataGridControlBase control = (DataGridControlBase)o;
            control.GridViewInternal = (GridControl)e.NewValue;
            if (control.GridViewInternal != null)
                control.GridViewInternal.ShowBorder = control.ShowBorder;
        }
        public GridControl GridView
        {
            get { return (GridControl)GetValue(GridViewProperty); }
            set { SetValue(GridViewProperty, value); }
        }
        #endregion

        protected override void OnDataSourceTypeChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnDataSourceTypeChanged(e);
            InitializeChangeDocumentStateMenu();
        }

        private void InitializeChangeDocumentStateMenu()
        {
            if (this._changeDocumentState != null)
            {
                if (this.DocumentMetadata != null)
                {
                    this._changeDocumentState.IsVisible = true;
                    foreach (var state in this.DocumentMetadata.States.OrderBy(t => t.OrdinalPosition))
                    {
                        if (state.State > 0)
                        {
                            this._changeDocumentState.Items.Add(new DevExpress.Xpf.Bars.BarButtonItem
                            {
                                Content = state.Caption,
                                Command = CrmApplicationCommands.ChangeDocumentState,
                                CommandParameter = state
                            });
                        }
                    }
                }
                else
                {
                    this._changeDocumentState.Items.Clear();
                    this._changeDocumentState.IsVisible = false;
                }
            }
        }

        protected override object ItemsSourceInternal
        {
            get
            {
                if (this.GridView != null)
                    return this.GridView.ItemsSource;
                return null;
            }
            set
            {
                if (this.GridView != null)
                    this.GridView.ItemsSource = value;
            }
        }
        public DataGridControlBase()
        {
            Uri resourceLocator = new Uri("/DykBits.Crm.Core;component/Themes/DataGridControlStyles.xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = (ResourceDictionary)System.Windows.Application.LoadComponent(resourceLocator);
            this.Style = (Style)resourceDictionary["dataGridControlStyle"];
            BindingOperations.SetBinding(this, ShowBorderProperty, new Binding { RelativeSource = new RelativeSource { AncestorType = typeof(Window) }, Path = new PropertyPath("IsSecondaryWindow") });
            if (ApplicationManager.IsInitialized)
                this.Loaded += DataGridControlBase_Loaded;
        }
        void DataGridControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= DataGridControlBase_Loaded;
            this.RestoreLayout();
            this.RequeryData();
        }
        private GridControl _gridView;
        private GridControl GridViewInternal
        {
            get { return this._gridView; }
            set
            {
                if (this._gridView != value)
                {
                    UnwireControl();
                    this._gridView = value;
                    WireControl();
                }
            }
        }
        private PopupMenu _popupMenu;
        private BarSubItem _changeDocumentState;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._popupMenu = (PopupMenu)GetTemplateChild("PopupMenu_PART");
            this._changeDocumentState = (BarSubItem)GetTemplateChild("ChangeDocumentState_PART");
            InitializeChangeDocumentStateMenu();
        }
        private void WireControl()
        {
            if (this._gridView != null)
            {
                this._gridView.MouseDoubleClick += GridView_MouseDoubleClick;
                this._gridView.PreviewKeyDown += GridView_PreviewKeyDown;
                this._gridView.PropertyChanged += _gridView_PropertyChanged;
                if (this._gridView != null)
                {
                    GridViewBase view = this._gridView.View as GridViewBase;
                    if (view != null)
                    {
                        view.UseAnimationWhenExpanding = false;
                    }
                }
                this._gridView.ItemsSource = ItemsSource;
            }
        }
        void _gridView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "VisibleRowCount")
            {
                InvokeStatusInfoChanged();
            }
        }
        private void InvokeStatusInfoChanged()
        {
            TableView view = this.GridView.View as TableView;
            var property = this.GridView.GetType().GetProperty("GridDataProvider", BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance);
            if (property != null)
            {
                DevExpress.Xpf.Data.GridDataProviderBase dataProvider = property.GetValue(this.GridView) as DevExpress.Xpf.Data.GridDataProviderBase;
                if (dataProvider != null)
                    OnStatusInfoChanged(new StatusInfoChangedEventArgs("Записи: " + dataProvider.DataRowCount));
            }
        }
        private void UnwireControl()
        {
            if (this._gridView != null)
            {
                this._gridView.MouseDoubleClick -= GridView_MouseDoubleClick;
                this._gridView.PreviewKeyDown -= GridView_PreviewKeyDown;
                this._gridView.PropertyChanged -= _gridView_PropertyChanged;
            }
        }
        void GridView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (CrmApplicationCommands.Properties.CanExecute(null, ParentWindow))
                {
                    CrmApplicationCommands.Properties.Execute(null, ParentWindow);
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.Return && Keyboard.Modifiers == ModifierKeys.None)
            {
                if (CrmApplicationCommands.Open.CanExecute(null, ParentWindow))
                {
                    CrmApplicationCommands.Open.Execute(null, ParentWindow);
                    e.Handled = true;
                }
            }
        }
        void GridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = GridView.View.GetRowElementByMouseEventArgs(e);
            int rowHandle = GridView.View.GetRowHandleByMouseEventArgs(e);
            if (rowHandle == GridControl.InvalidRowHandle)
            {
                if (GridView.View is TableView)
                {
                    TableView tableView = GridView.View as TableView;
                    TableViewHitInfo hitInfo = tableView.CalcHitInfo(e.OriginalSource as DependencyObject);
                    if (hitInfo.HitTest == TableViewHitTest.DataArea)
                    {
                        if (CrmApplicationCommands.Create.CanExecute(null, ParentWindow))
                            CrmApplicationCommands.Create.Execute(null, ParentWindow);
                    }
                }
                else if (GridView.View is TreeListView)
                {
                    TreeListView view = GridView.View as TreeListView;
                    var hitInfo = view.CalcHitInfo(e.OriginalSource as DependencyObject);
                    if (hitInfo.HitTest == DevExpress.Xpf.Grid.TreeList.TreeListViewHitTest.DataArea)
                    {
                        if (CrmApplicationCommands.Create.CanExecute(null, ParentWindow))
                            CrmApplicationCommands.Create.Execute(null, ParentWindow);
                    }
                }
            }
            else if (GridView.IsGroupRowHandle(rowHandle))
            {
            }
            else if (GridView.IsValidRowHandle(rowHandle))
            {
                if (CrmApplicationCommands.Default.CanExecute(null, ParentWindow))
                    CrmApplicationCommands.Default.Execute(null, ParentWindow);
            }
        }
        protected override bool CanOpenSelectedItem()
        {
            return DocumentMetadata != null && HasSelectedItems && WindowManager.IsEditorExists(SelectedDataItem);
        }
        protected override void CanExecute(CanExecuteRoutedEventArgs e)
        {
            base.CanExecute(e);
            if (e.Handled)
                return;
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.ExportToExcel:
                        e.CanExecute = this.GridView != null && this.GridView.VisibleRowCount > 0 && (this.GridView.View is TableView || this.GridView.View is TreeListView);
                        e.Handled = true;
                        break;
                    case UICommandId.Create:
                        e.CanExecute = DocumentMetadata != null && WindowManager.IsEditorExists(ViewMetadata.Document);
                        e.Handled = true;
                        break;
                    case UICommandId.Delete:
                        e.CanExecute = DocumentMetadata != null && HasSelectedItems;
                        e.Handled = true;
                        break;
                    case UICommandId.ViewFilter:
                        e.CanExecute = this.FilterViewInternal != null;
                        e.Handled = true;
                        break;
                    case UICommandId.SortAscending:
                    case UICommandId.SortDescending:
                        e.CanExecute = (this.GridView.CurrentColumn is GridColumn) && (this.GridView.CurrentColumn.AllowSorting != DevExpress.Utils.DefaultBoolean.False);
                        e.Handled = true;
                        break;
                    case UICommandId.SortDialog:
                        e.CanExecute = true;
                        e.Handled = true;
                        break;
                    case UICommandId.ExpandAllGroups:
                    case UICommandId.CollapseAllGroups:
                        e.CanExecute = this.GridView.GroupCount > 0 || this.GridView.View is TreeListView;
                        e.Handled = true;
                        break;
                    case UICommandId.Find:
                        e.CanExecute = this.GridView.View is TableView;
                        e.Handled = true;
                        break;
                    case UICommandId.ChangeDocumentState:
                        e.CanExecute = DocumentMetadata != null && this.HasSelectedItems && CanExecuteChangeDocumentState(e.Parameter as DocumentState);
                        e.Handled = true;
                        break;
                }
            }
        }
        internal bool CanExecuteChangeDocumentState(DocumentState state)
        {
            if (SelectedItemsCount == 1)
            {
                if (state.State != this.SelectedDataItem.State)
                    return ((DataItemBase)this.SelectedDataItem).CanChangeStateTo(state.State);
                return false;
            }
            else if (SelectedItemsCount > 1)
            {
                return true;
            }
            return false;
        }

        protected override void Executed(ExecutedRoutedEventArgs e)
        {
            base.Executed(e);
            if (e.Handled)
                return;

            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.ExportToExcel:
                        ExportToExcel();
                        e.Handled = true;
                        break;
                    case UICommandId.Create:
                        CreateItem();
                        e.Handled = true;
                        break;
                    case UICommandId.Delete:
                        DeleteItem();
                        e.Handled = true;
                        break;
                    case UICommandId.SortAscending:
                        this.GridView.SortBy((GridColumn)this.GridView.CurrentColumn, DevExpress.Data.ColumnSortOrder.Ascending);
                        e.Handled = true;
                        break;
                    case UICommandId.SortDescending:
                        this.GridView.SortBy((GridColumn)this.GridView.CurrentColumn, DevExpress.Data.ColumnSortOrder.Descending);
                        e.Handled = true;
                        break;
                    case UICommandId.SortDialog:
                        e.Handled = true;
                        break;
                    case UICommandId.ExpandAllGroups:
                        if (this.GridView.View is TreeListView)
                            ((TreeListView)this.GridView.View).ExpandAllNodes();
                        else
                            this.GridView.ExpandAllGroups();
                        e.Handled = true;
                        break;
                    case UICommandId.CollapseAllGroups:
                        if (this.GridView.View is TreeListView)
                            ((TreeListView)this.GridView.View).CollapseAllNodes();
                        else
                            this.GridView.CollapseAllGroups();
                        e.Handled = true;
                        break;
                    case UICommandId.Find:
                        ShowFindPanel();
                        e.Handled = true;
                        break;
                    case UICommandId.ChangeDocumentState:
                        ChangeDocumentState(e.Parameter as DocumentState);
                        e.Handled = true;
                        break;
                }
            }
        }
        private void ChangeDocumentState(DocumentState newState)
        {
            using (new WaitCursor())
            {
                this.LockRefresh();
                try
                {
                    if (this.SelectedItemsCount > 1)
                    {
                        var selectedItems = this.GetSelectedDataItems();
                        List<Exception> errors = new List<Exception>();
                        foreach (var item in selectedItems)
                        {
                            try
                            {
                                DocumentManager.ChangeDocumentState(item, newState, null);
                            }
                            catch (Exception ex)
                            {
                                errors.Add(ex);
                            }
                        }
                        if (errors.Count > 0)
                        {
                            throw new CrmBatchException("При выполнении операции произошли ошибки", errors);
                        }
                    }
                    else
                    {
                        DocumentManager.ChangeDocumentState(this.SelectedDataItem, newState, null);
                    }
                }
                finally
                {
                    this.UnlockRefresh();
                    this.RequeryData();
                }
            }

        }
        private void ShowFindPanel()
        {
            TableView view = (TableView)this.GridView.View;
            if (view.SearchControl == null)
                view.ShowSearchPanel(true);
            else
                view.SearchControl.Focus();
        }

        #region Save/Restore/Reset Grid Layout
        private string _layoutFilePath;
        private string LayoutFilePath
        {
            get
            {
                if (this._layoutFilePath == null)
                {
                    Window window = ParentWindow;
                    string layoutName;
                    if (Node != null)
                    {
                        if (window.DataContext == null)
                        {
                            layoutName = window.GetType().Name + "_" + Node.Key + "_gridlayout.xml";
                        }
                        else
                        {
                            layoutName = window.GetType().Name + "_" + this.DataContext.GetType().Name + "_" + Node.Key + "_gridlayout.xml";
                        }
                    }
                    else
                    {
                        layoutName = window.GetType().Name + "_" + this.GetType().Name + "_gridlayout.xml";
                    }
                    this._layoutFilePath = System.IO.Path.Combine(ApplicationManager.UserAppDataPath, layoutName);
                }
                return this._layoutFilePath;
            }
        }
        protected override void SaveLayout()
        {
            SaveLayoutToXml(LayoutFilePath);
        }
        protected override void RestoreLayout()
        {
            if (System.IO.File.Exists(LayoutFilePath))
            {
                RestoreLayoutFromXml(LayoutFilePath);
            }
        }
        protected override void ResetLayout()
        {
            if (System.IO.File.Exists(LayoutFilePath))
                System.IO.File.Delete(LayoutFilePath);
            if (CrmApplicationCommands.RecreatePresentation.CanExecute(null, ParentWindow))
                CrmApplicationCommands.RecreatePresentation.Execute(null, ParentWindow);
        }
        private void RestoreLayoutFromXml(string fileName)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(fileName);
                if (document.DocumentElement.LocalName == "GridLayout" && document.DocumentElement.Attributes["Provider"] != null)
                {
                    if (document.DocumentElement.Attributes["Provider"].Value == "DykBits")
                    {
                        XmlNodeList nodes = document.DocumentElement.SelectNodes("Column");
                        var sortedNodes = nodes.OfType<XmlNode>().OrderBy(t => Convert.ToInt32(t.Attributes["VisibleIndex"].Value) >= 0 ? Convert.ToInt32(t.Attributes["VisibleIndex"].Value) : int.MaxValue);
                        this.GridView.BeginInit();
                        try
                        {
                            foreach (XmlNode node in sortedNodes)
                            {
                                string columnName = null;
                                if (node.Attributes["Name"] != null)
                                    columnName = node.Attributes["Name"].Value;
                                string fieldName = node.Attributes["FieldName"].Value;
                                GridColumn column;
                                if (!string.IsNullOrEmpty(columnName))
                                    column = this.GridView.Columns.GetColumnByName(columnName);
                                else
                                    column = this.GridView.Columns.GetColumnByFieldName(fieldName);
                                if (column != null)
                                {
                                    column.VisibleIndex = XmlConvert.ToInt32(node.Attributes["VisibleIndex"].Value);
                                    column.Visible = XmlConvert.ToBoolean(node.Attributes["Visible"].Value);
                                    int sortIndex = XmlConvert.ToInt32(node.Attributes["SortIndex"].Value);
                                    if (sortIndex >= 0)
                                        column.AllowSorting = DevExpress.Utils.DefaultBoolean.True;
                                    column.SortIndex = sortIndex;
                                    int groupIndex = XmlConvert.ToInt32(node.Attributes["GroupIndex"].Value);
                                    if (groupIndex >= 0)
                                    {
                                        column.AllowSorting = DevExpress.Utils.DefaultBoolean.True;
                                        column.AllowGrouping = DevExpress.Utils.DefaultBoolean.True;
                                    }
                                    if (groupIndex == -1 && column.GroupIndex >= 0)
                                        this.GridView.UngroupBy(column);
                                    else
                                        column.GroupIndex = groupIndex;
                                    column.SortOrder = (DevExpress.Data.ColumnSortOrder)Enum.Parse(typeof(DevExpress.Data.ColumnSortOrder), node.Attributes["SortOrder"].Value);
                                    if (node.Attributes["ActualWidth"] != null)
                                        column.Width = XmlConvert.ToDouble(node.Attributes["ActualWidth"].Value);
                                }
                            }
                        }
                        finally
                        {
                            this.GridView.EndInit();
                        }
                        if (this.SerializeFilter)
                        {
                            XmlNode filterNode = document.DocumentElement.SelectSingleNode("DataSourceFilter");
                            if (filterNode != null)
                            {
                                XmlNodeReader reader = new XmlNodeReader(filterNode.FirstChild);
                                XmlSerializer serializer = new XmlSerializer(this.DataSourceFilter.GetType());
                                Filter filter;
                                try
                                {
                                    filter = (Filter)serializer.Deserialize(reader);
                                }
                                catch
                                {
                                    filter = ViewDataAdapter.CreateFilter(null, null);
                                }
                                IDataWindow dataWindow = ParentWindow as IDataWindow;
                                if (dataWindow != null)
                                {
                                    if (dataWindow.WindowType == DataPresentationType.Root)
                                        filter.InitializeViewParameters(dataWindow.DataContext, Node == null ? null : Node.Parameter);
                                    else
                                        filter.InitializeDefaults(dataWindow.DataContext, Node == null ? null : Node.Parameter);
                                }
                                this.DataSourceFilter = filter;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.LogError(ex);
            }
        }
        private void SaveLayoutToXml(string fileName)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    writer.WriteStartElement("GridLayout");
                    writer.WriteAttributeString("Provider", "DykBits");
                    writer.WriteAttributeString("Verson", "1.0");
                    foreach (GridColumn column in this.GridView.Columns)
                    {
                        writer.WriteStartElement("Column");
                        writer.WriteAttributeString("Name", column.Name);
                        writer.WriteAttributeString("FieldName", column.FieldName);
                        writer.WriteAttributeString("Visible", XmlConvert.ToString(column.Visible));
                        if (column.Visible)
                            writer.WriteAttributeString("VisibleIndex", XmlConvert.ToString(column.VisibleIndex));
                        else
                            writer.WriteAttributeString("VisibleIndex", XmlConvert.ToString(-1));
                        writer.WriteAttributeString("SortIndex", XmlConvert.ToString(column.SortIndex));
                        writer.WriteAttributeString("SortOrder", column.SortOrder.ToString());
                        writer.WriteAttributeString("GroupIndex", XmlConvert.ToString(column.GroupIndex));
                        writer.WriteAttributeString("IsGrouped", XmlConvert.ToString(column.IsGrouped));
                        writer.WriteAttributeString("Width", XmlConvert.ToString(column.Width));
                        writer.WriteAttributeString("ActualWidth", XmlConvert.ToString(column.ActualWidth));
                        writer.WriteEndElement();
                    }
                    if (this.SerializeFilter)
                    {
                        writer.WriteStartElement("DataSourceFilter");
                        XmlSerializer serializer = new XmlSerializer(this.DataSourceFilter.GetType());
                        serializer.Serialize(writer, this.DataSourceFilter);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.LogError(ex);
            }
        }
        #endregion
        public int SelectedItemsCount
        {
            get
            {
                if (GridView != null)
                    return GridView.SelectedItems.Count;
                return 0;
            }
        }
        public override bool HasSelectedItems
        {
            get { return SelectedItemsCount > 0; }
        }
        public override IDataItem[] GetSelectedDataItems()
        {
            if (HasSelectedItems)
            {
                int count = GridView.SelectedItems.Count;
                IDataItem[] items = new IDataItem[count];
                for (int index = 0; index < count; ++index)
                {
                    items[index] = GridView.SelectedItems[index] as IDataItem;
                }
                return items;
            }
            return new IDataItem[0];
        }
        public override IDataItem SelectedDataItem
        {
            get
            {
                if (GridView != null && GridView.SelectedItems.Count > 0)
                    return GridView.SelectedItem as IDataItem;
                return null;
            }
        }
        protected virtual void CreateItem()
        {
            using (new WaitCursor())
            {
                Window parentWindow = Window.GetWindow(this);
                WindowManager.CreateDocument(ViewMetadata.Document, parentWindow.DataContext);
            }
        }
        protected override void OpenSelectedItem()
        {
            var selectedItems = this.GetSelectedDataItems();
            if (selectedItems.Length > 1)
            {
                if (ApplicationManager.ShowQuestion("Выбрано несколько элементов. Хотите открыть все?"))
                {
                    foreach (var selectedItem in selectedItems)
                    {
                        using (new WaitCursor())
                        {
                            OnOpenEditorWindow((IDataItem)selectedItem);
                        }
                    }
                }
            }
            else
            {
                using (new WaitCursor())
                {
                    OnOpenEditorWindow((IDataItem)selectedItems[0]);
                }
            }
        }
        protected virtual void OnOpenEditorWindow(IDataItem item)
        {
            WindowManager.OpenDocument(item.GetKey());
        }
        protected virtual void DeleteItem()
        {
            MessageBoxResult result = ApplicationManager.ShowWarning("Выделенные элементы будут удалены без возможности восстановления.\r\nПродолжить?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var selectedItems = GetSelectedDataItems();
                this.LockRefresh();
                try
                {
                    foreach (var selectedItem in selectedItems)
                    {
                        ItemKey itemKey = selectedItem.GetKey();
                        EditorWindow editorWindow = WindowManager.FindWindowByKey(itemKey);
                        if (editorWindow != null)
                        {
                            editorWindow.ActivateWindow();
                            if (editorWindow.Dirty)
                                result = ApplicationManager.ShowQuestion("Документ открыт в отдельном окне и изменен. Продолжить удаление?", MessageBoxButton.YesNo);
                            else
                                result = ApplicationManager.ShowQuestion("Документ открыт в отдельном окне. Продолжить удаление?", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No)
                            {
                                return;
                            }
                            else
                            {
                                editorWindow.SilentClose();
                            }
                        }
                        using (new WaitCursor())
                        {
                            DocumentManager.DeleteItem(selectedItem);
                        }
                    }
                }
                finally
                {
                    this.UnlockRefresh();
                    RequeryData();
                }
            }
        }
        private Predicate<object> _filter;
        public Predicate<object> Filter
        {
            get { return this._filter; }
            set
            {
                this._filter = value;
                if (this._dataColl != null)
                    this._dataColl.Filter = value;
            }
        }
        private DataGridListView _dataColl;
        protected override void RequeryData()
        {
            using (new WaitCursor())
            {
                IGridViewState gridViewState = null;
                if (GridView.ItemsSource != null)
                {
                    if (GridView.View is TableView)
                    {
                        gridViewState = new RowStateHelper(GridView, "Id");
                    }
                    else if (GridView.View is TreeListView)
                    {
                        gridViewState = new TreeListViewState(GridView, "Id");
                    }
                    if (gridViewState != null)
                        gridViewState.SaveViewInfo(((IList)GridView.ItemsSource).Count);
                }

                if (this.ItemsSourceInternal == null)
                {
                    this._dataColl = new DataGridListView();
                    this._dataColl.Filter = this.Filter;
                    ItemsSourceInternal = this._dataColl;
                }
                this.GridView.BeginDataUpdate();
                try
                {
                    IList items = this.ViewDataAdapter.Browse(DataSourceFilter.ToXml());
                    this._dataColl.Refresh(items);
                }
                finally
                {
                    this.GridView.EndDataUpdate();
                }

                if (GridView.ItemsSource != null && gridViewState != null)
                {
                    gridViewState.LoadViewInfo();
                }
            }
        }
        protected virtual void ExportToExcel()
        {
            if (GridView.View is TableView)
                DataExport.ExportToExcel((TableView)GridView.View, ViewMetadata == null ? null : ViewMetadata.Caption);
            else if (GridView.View is TreeListView)
                DataExport.ExportToExcel((TreeListView)GridView.View, ViewMetadata == null ? null : ViewMetadata.Caption);
        }
        protected override void OnActivate()
        {
            base.OnActivate();
            InvokeStatusInfoChanged();
        }
    }
}
