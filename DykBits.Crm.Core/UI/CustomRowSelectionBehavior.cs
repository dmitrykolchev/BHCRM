using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.Native;

namespace DykBits.Crm.UI
{
    public class SelectAllColumnEx : GridColumn
    {
        public const string CheckHeaderTemplate = @"
         <DataTemplate 
xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
xmlns:dxe=""http://schemas.devexpress.com/winfx/2008/xaml/editors""
xmlns:dxg=""http://schemas.devexpress.com/winfx/2008/xaml/grid""
>
            <dxe:CheckEdit IsChecked=""{Binding Path=DataContext.RowSelectionBehavior.IsAllRowsSelected, Mode=TwoWay, 
                                                RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type dxg:GridColumnHeader}}}""
                            HorizontalAlignment=""Center""/>
        </DataTemplate>
";
        public const string CheckCellTemplate = @"
                        <DataTemplate
xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
xmlns:dxe=""http://schemas.devexpress.com/winfx/2008/xaml/editors""
xmlns:dxg=""http://schemas.devexpress.com/winfx/2008/xaml/grid""
>
                            <dxe:CheckEdit IsChecked=""{Binding RowData.IsSelected, Mode=OneWay}""
                                           IsReadOnly=""True""
                                           HorizontalAlignment=""Center""
                                           VerticalAlignment=""Center"" />
                        </DataTemplate>
";

        public static readonly DependencyProperty RowSelectionBehaviorProperty =
            DependencyProperty.Register("RowSelectionBehavior", typeof(RowSelectionBehaviorEx), typeof(SelectAllColumnEx), new PropertyMetadata(null));
        public RowSelectionBehaviorEx RowSelectionBehavior
        {
            get { return (RowSelectionBehaviorEx)GetValue(RowSelectionBehaviorProperty); }
            set { SetValue(RowSelectionBehaviorProperty, value); }
        }
        static SelectAllColumnEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectAllColumnEx), new FrameworkPropertyMetadata(typeof(SelectAllColumnEx)));
        }
        public SelectAllColumnEx()
        {
            FieldName = SelectAllColumn.ColumnFieldName;
            UnboundType = UnboundColumnType.Boolean;
            AllowSorting = DefaultBoolean.False;
            AllowAutoFilter = false;
            AllowBestFit = DefaultBoolean.False;
            AllowColumnFiltering = DefaultBoolean.False;
            AllowGrouping = DefaultBoolean.False;
            AllowFocus = false;
            HeaderTemplate = ParseTemplateString(SelectAllColumnEx.CheckHeaderTemplate);
            CellTemplate = ParseTemplateString(SelectAllColumnEx.CheckCellTemplate);
            AllowResizing = DefaultBoolean.False;
            FixedWidth = true;
            Width = 24;
        }
        DataTemplate ParseTemplateString(string template)
        {
#if !SL
            return (DataTemplate)XamlReader.Parse(template);
#else
                return (DataTemplate)XamlReader.Load(template);
#endif
        }
    }

    public class RowSelectionBehaviorEx : Behavior<GridViewBase>
    {
#if DEBUGTEST
            internal static int BehaviorsCount = 0;
            public RowSelectionBehaviorEx() : base() {
                BehaviorsCount++;
            }
#endif
        public static readonly DependencyProperty IsAllRowsSelectedProperty =
            DependencyProperty.Register("IsAllRowsSelected", typeof(bool?), typeof(RowSelectionBehaviorEx),
            new PropertyMetadata(false, (d, e) => ((RowSelectionBehaviorEx)d).OnIsAllRowsSelectedChanged()));
        public bool? IsAllRowsSelected
        {
            get { return (bool?)GetValue(IsAllRowsSelectedProperty); }
            set { SetValue(IsAllRowsSelectedProperty, value); }
        }
        GridControl GridControl { get { return AssociatedObject.Grid; } }
        ItemsSourceChangedHelperEx ItemsSourceChangedHelperEx { get; set; }
        internal IList Source
        {
            get
            {
#if !SL
                if (GridControl.ItemsSource is DataTable)
                    return ((DataTable)GridControl.ItemsSource).DefaultView;
#endif
                if (GridControl.ItemsSource is IListSource)
                    return ((IListSource)GridControl.ItemsSource).GetList();

                return GridControl.ItemsSource as IList;
            }
        }
        public virtual int ItemsSourceCount { get { return Source == null ? 0 : Source.Count; } }
        protected bool AllowSelectionSynchronize
        {
            get
            {
                if (AssociatedObject is SelectionViewEx)
                {
                    return (AssociatedObject as SelectionViewEx).AllowSelectionSynchronize;
                }
                return false;
            }
        }
        bool lockUpdateIsAllRowsSelected = false;
        bool lockSelectionChanged = false;
        public ObservableCollection<int> SelectedItems = new ObservableCollection<int>();
        void OnIsAllRowsSelectedChanged()
        {
            if (IsAllRowsSelected == null)
                return;
            if (AllowSelectionSynchronize)
            {
                if (IsAllRowsSelected.Value)
                    GridControl.SelectAll();
                else
                    GridControl.UnselectAll();
            }
            else
            {
                lockUpdateIsAllRowsSelected = true;
                SetSelectionColumnCellsValue(false, new Predicate<int>(delegate(int handle) { return IsAllRowsSelected.Value; }));
                GridControl.RefreshData();
                lockUpdateIsAllRowsSelected = false;
            }
        }
        void SetSelectionColumnCellsValue(bool allowSetCellValue, Predicate<int> predicate)
        {
            for (int i = 0; i < ItemsSourceCount; i++)
            {
                int handle = GridControl.GetRowHandleByListIndex(i);
                if (allowSetCellValue)
                {
                    var oldValue = (bool)GridControl.GetCellValue(handle, SelectAllColumn.ColumnFieldName);
                    var newValue = predicate(handle);
                    GridControl.SetCellValue(handle, SelectAllColumn.ColumnFieldName, newValue);
                }
                else
                {
                    if (predicate(handle))
                    {
                        if (!SelectedItems.Contains(i))
                        {
                            SelectedItems.Add(i);
                        }
                    }
                    else
                    {
                        SelectedItems.Remove(i);
                    }
                }
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            GridControl.CustomUnboundColumnData += new GridColumnDataEventHandler(OnCustomUnboundColumnData);
            GridControl.FilterChanged += new RoutedEventHandler(OnFilterChanged);
            GridControl.Columns.CollectionChanged += new NotifyCollectionChangedEventHandler(Columns_CollectionChanged);
            AssociatedObject.CellValueChanging += new CellValueChangedEventHandler(OnCellValueChanging);
            GridControl.SelectionChanged += new GridSelectionChangedEventHandler(OnSelectionChanged);
            UpdateSelectAllColumn();
            if (AssociatedObject is SelectionViewEx)
            {
                ItemsSourceChangedHelperEx = new ItemsSourceChangedHelperEx(this);
                ItemsSourceChangedHelperEx.CollectionChanged += new ListChangedEventHandler(OnItemsSourceCollectionChanged);
                ItemsSourceChangedHelperEx.SubscribeOnItemsSourceChanged(AssociatedObject as SelectionViewEx);
            }
        }
        void Columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateSelectAllColumn();
        }
        void UpdateSelectAllColumn()
        {
            foreach (GridColumn column in GridControl.Columns)
            {
                if (column is SelectAllColumnEx)
                {
                    (column as SelectAllColumnEx).RowSelectionBehavior = this;
                }
            }
        }
        void OnItemsSourceCollectionChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                for (int i = 0; i < SelectedItems.Count; i++)
                {
                    if (SelectedItems[i] >= e.NewIndex)
                    {
                        SelectedItems[i]++;
                    }
                }
                UpdateIsAllRowsSelectedProperty();
            }
            int removedIndex = int.MinValue;
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                for (int i = 0; i < SelectedItems.Count; i++)
                {
                    if (SelectedItems[i] == e.OldIndex)
                    {
                        removedIndex = i;
                    }
                    if (SelectedItems[i] > e.OldIndex)
                    {
                        SelectedItems[i]--;
                    }
                }
                if (removedIndex != int.MinValue)
                    SelectedItems.RemoveAt(removedIndex);
                UpdateIsAllRowsSelectedProperty();
            }
            if (e.ListChangedType == ListChangedType.Reset)
            {
                SelectedItems.Clear();
                UpdateIsAllRowsSelectedProperty();
            }
        }
        void OnSelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (lockSelectionChanged || !AllowSelectionSynchronize)
                return;
            List<int> selectedHandles = new List<int>(GridControl.GetSelectedRowHandles());
            bool hasGroupping = false;
            for (int i = 0; i < selectedHandles.Count; i++)
            {
                if (selectedHandles[i] < 0)
                {
                    hasGroupping = true;
                    break;
                }
            }

            if (e.Action == CollectionChangeAction.Refresh)
            {
                SelectedItems.Clear();
                SetSelectionColumnCellsValue(true, (handle) => { return selectedHandles.Contains(handle); });
            }

            if ((GridControl.VisibleRowCount == selectedHandles.Count) && hasGroupping)
            {
                GridControl.BeginSelection();
                AssociatedObject.DataControl.UnselectAll();
                for (int i = 0; i < ItemsSourceCount; i++)
                {
                    GridControl.SelectItem(i);
                }
                GridControl.EndSelection();
                UpdateIsAllRowsSelectedProperty();
                return;
            }
            SelectedItems.Clear();
            for (int i = selectedHandles.Count - 1; i >= 0; i--)
            {
                if (GridControl.IsGroupRowHandle(selectedHandles[i]))
                {
                    selectedHandles.RemoveAt(i);
                }
                else
                {
                    int visibleIndex = GridControl.GetListIndexByRowHandle(selectedHandles[i]);
                    if (!SelectedItems.Contains(visibleIndex))
                        SelectedItems.Add(visibleIndex);
                }
            }
            SetSelectionColumnCellsValue(true, (handle) => { return selectedHandles.Contains(handle); });

            UpdateIsAllRowsSelectedProperty();
        }
        protected override void OnDetaching()
        {
            if (AssociatedObject is SelectionViewEx)
            {
                ItemsSourceChangedHelperEx.CollectionChanged -= new ListChangedEventHandler(OnItemsSourceCollectionChanged);
                ItemsSourceChangedHelperEx.SubscribeOnItemsSourceChanged(AssociatedObject as SelectionViewEx);
            }
            GridControl.Columns.CollectionChanged -= new NotifyCollectionChangedEventHandler(Columns_CollectionChanged);
            GridControl.CustomUnboundColumnData -= new GridColumnDataEventHandler(OnCustomUnboundColumnData);
            GridControl.FilterChanged -= new RoutedEventHandler(OnFilterChanged);
            AssociatedObject.CellValueChanging -= new CellValueChangedEventHandler(OnCellValueChanging);
            GridControl.SelectionChanged -= new GridSelectionChangedEventHandler(OnSelectionChanged);
            base.OnDetaching();
        }
        void OnCellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == SelectAllColumn.ColumnFieldName)
                AssociatedObject.PostEditor();
        }
        void OnFilterChanged(object sender, RoutedEventArgs e)
        {
            UpdateIsAllRowsSelectedProperty();
        }
        void OnCustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {
            if (e.Column.FieldName == SelectAllColumn.ColumnFieldName)
            {
                if (e.IsGetData)
                {
                    var oldValue = e.Value;
                    e.Value = GetIsSelected(e.ListSourceRowIndex);
                }
                if (e.IsSetData)
                {
                    var oldValue = GetIsSelected(e.ListSourceRowIndex);
                    SetIsSelected(e.ListSourceRowIndex, (bool)e.Value);
                }
            }
        }
        void UpdateIsAllRowsSelectedProperty()
        {
            if (lockUpdateIsAllRowsSelected)
                return;
            bool allSelected = true;
            bool allUnselected = true;
            allSelected = SelectedItems.Count >= ItemsSourceCount;
            allUnselected = SelectedItems.Count == 0;
            if (!allSelected && !allUnselected)
                IsAllRowsSelected = null;
            if (allSelected)
                IsAllRowsSelected = true;
            if (allUnselected)
                IsAllRowsSelected = false;
        }
        bool GetIsSelected(int listIndex)
        {
            return SelectedItems.Contains(listIndex);
        }
        void SetIsSelected(int listIndex, bool value)
        {
            lockSelectionChanged = true;
            if (value)
            {
                if (!SelectedItems.Contains(listIndex))
                {
                    SelectedItems.Add(listIndex);
                    if (AllowSelectionSynchronize)
                    {
                        GridControl.SelectItem(GridControl.GetRowHandleByListIndex(listIndex));
                    }
                }
            }
            else
            {
                if (SelectedItems.Contains(listIndex))
                {
                    SelectedItems.Remove(listIndex);
                    if (AllowSelectionSynchronize)
                    {
                        GridControl.UnselectItem(GridControl.GetRowHandleByListIndex(listIndex));
                    }
                }
            }
            lockSelectionChanged = false;
        }
    }
    public class ItemsSourceChangedHelperEx
    {
        RowSelectionBehaviorEx behavior;
        public ItemsSourceChangedHelperEx(RowSelectionBehaviorEx behavior)
        {
            this.behavior = behavior;
        }
        SelectionViewEx View { get; set; }
        GridControl Grid { get; set; }
        object ItemsSource { get; set; }
        public event ListChangedEventHandler CollectionChanged;
        void RaiseCollectionChanged(ListChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }
        public void SubscribeOnItemsSourceChanged(SelectionViewEx view)
        {
            View = view;
            view.GridChanged += new EventHandler(view_OnGridChanged);
            SubscribeOnNewGrid();
        }
        public void UnsubscribeFromItemsSourceChanged(SelectionViewEx view)
        {
            view.GridChanged -= new EventHandler(view_OnGridChanged);
            UnsubscribeFromOldGrid();
            View = null;
        }
        void view_OnGridChanged(object sender, EventArgs e)
        {
            UnsubscribeFromOldGrid();
            SubscribeOnNewGrid();
        }
        void SubscribeOnNewGrid()
        {
            if (View.Grid != null)
            {
                View.Grid.ItemsSourceChanged += new ItemsSourceChangedEventHandler(Grid_ItemsSourceChanged);
                Grid = View.Grid;
                SubscribeOnGridItemsSourceChanged();
            }
        }
        void UnsubscribeFromOldGrid()
        {
            if (Grid != null)
            {
                Grid.ItemsSourceChanged -= new ItemsSourceChangedEventHandler(Grid_ItemsSourceChanged);
                UnsubscribeFromGridItemsSourceChanged();
                Grid = null;
            }
        }
        void SubscribeOnGridItemsSourceChanged()
        {
            ItemsSource = behavior.Source;
            SubscribeOnCollectionChanged(ItemsSource);
        }
        void UnsubscribeFromGridItemsSourceChanged()
        {
            if (ItemsSource != null)
            {
                UnsubscribeFromCollectionChanged(ItemsSource);
                ItemsSource = null;
            }
        }
        void SubscribeOnCollectionChanged(object itemsSource)
        {
            if (itemsSource is INotifyCollectionChanged)
            {
                (itemsSource as INotifyCollectionChanged).CollectionChanged += new NotifyCollectionChangedEventHandler(ItemsSourceChangedHelper_CollectionChanged);
                return;
            }
            if (itemsSource is IBindingList)
            {
                (itemsSource as IBindingList).ListChanged += new ListChangedEventHandler(ItemsSourceChangedHelper_ListChanged);
                return;
            }
        }
        void UnsubscribeFromCollectionChanged(object itemsSource)
        {
            if (itemsSource is INotifyCollectionChanged)
            {
                (itemsSource as INotifyCollectionChanged).CollectionChanged -= new NotifyCollectionChangedEventHandler(ItemsSourceChangedHelper_CollectionChanged);
                return;
            }
            if (itemsSource is IBindingList)
            {
                (itemsSource as IBindingList).ListChanged -= new ListChangedEventHandler(ItemsSourceChangedHelper_ListChanged);
                return;
            }
        }
        void ItemsSourceChangedHelper_ListChanged(object sender, ListChangedEventArgs e)
        {
            RaiseCollectionChanged(e);
        }
        void ItemsSourceChangedHelper_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ListChangedType listChangedType = ListChangedType.Reset;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                listChangedType = ListChangedType.ItemAdded;
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                listChangedType = ListChangedType.ItemMoved;
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                listChangedType = ListChangedType.ItemDeleted;
            }
            RaiseCollectionChanged(new ListChangedEventArgs(listChangedType, e.NewStartingIndex, e.OldStartingIndex));
        }
        void Grid_ItemsSourceChanged(object sender, ItemsSourceChangedEventArgs e)
        {
            UnsubscribeFromGridItemsSourceChanged();
            SubscribeOnGridItemsSourceChanged();
        }
    }
    public class RowSelectionStrategyEx : SelectionStrategyRow
    {
        public RowSelectionStrategyEx(GridViewBase view) : base(view) { }
        SelectionViewEx SelectionView { get { return view as SelectionViewEx; } }

        protected bool InvertSelection = false;

        public override void OnBeforeMouseLeftButtonDown(DependencyObject originalSource)
        {
            var cell = LayoutHelper.FindLayoutOrVisualParentObject<CellContentPresenter>(originalSource, false);
            if (cell != null && cell.Column is SelectAllColumnEx)
                InvertSelection = true;
            base.OnBeforeMouseLeftButtonDown(originalSource);
        }

        public override void CreateMouseSelectionActions(int rowHandle, bool isIndicator)
        {
            if (InvertSelection)
            {
                InvertSelection = false;
                SelectionAction = new InvertSelectionAction(GridView);
            }
            else
                base.CreateMouseSelectionActions(rowHandle, isIndicator);
        }

    }
    public class SelectionViewEx : TableView
    {
        public static readonly DependencyProperty AllowSelectionSynchronizeProperty =
            DependencyProperty.Register("AllowSelectionSynchronize", typeof(bool), typeof(SelectionViewEx),
            new PropertyMetadata(true, (d, e) => ((SelectionViewEx)d).OnAllowSelectionSynchronizeChanged()));
        public static readonly DependencyProperty DisableStandardSelectionProperty =
            DependencyProperty.Register("DisableStandardSelection", typeof(bool), typeof(SelectionViewEx),
            new PropertyMetadata(false, (d, e) => ((SelectionViewEx)d).OnAllowSelectionSynchronizeChanged()));
        public bool AllowSelectionSynchronize
        {
            get { return (bool)GetValue(AllowSelectionSynchronizeProperty); }
            set { SetValue(AllowSelectionSynchronizeProperty, value); }
        }
        public bool DisableStandardSelection
        {
            get { return (bool)GetValue(DisableStandardSelectionProperty); }
            set { SetValue(DisableStandardSelectionProperty, value); }
        }
        public event EventHandler GridChanged;
        FrameworkElement pressedCell = null;
        bool AllowInternalSelection { get { return (!AllowSelectionSynchronize) && (NavigationStyle == GridViewNavigationStyle.Row); } }
        protected override SelectionStrategyBase CreateSelectionStrategy()
        {
            return new RowSelectionStrategyEx(this);
        }
        void RaiseGridChanged()
        {
            if (GridChanged != null)
            {
                GridChanged(this, EventArgs.Empty);
            }
        }
        DataControlBase oldGrid = null;
        protected override void ResetDataProvider()
        {
            base.ResetDataProvider();
            oldGrid = Grid;
            if (Grid == null)
            {
                RaiseGridChanged();
            }
        }
        protected override void OnDataReset()
        {
            base.OnDataReset();
            Behavior RowSelectionBehaviorEx = null;
            foreach (Behavior behavior in Interaction.GetBehaviors(this))
            {
                if (behavior is RowSelectionBehaviorEx)
                {
                    RowSelectionBehaviorEx = behavior;
                }
            }
            if (oldGrid != Grid)
            {
                oldGrid = Grid;
                if (RowSelectionBehaviorEx != null)
                {
                    Interaction.GetBehaviors(this).Remove(RowSelectionBehaviorEx);
                }
                Interaction.GetBehaviors(this).Add(new RowSelectionBehaviorEx());
                RaiseGridChanged();
            }
        }
        void OnAllowSelectionSynchronizeChanged()
        {
            Grid.UnselectAll();
        }
        internal void SetEditorSetInactiveAfterClick(bool value)
        {
            EditorSetInactiveAfterClick = value;
        }
        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if (!AllowInternalSelection)
                return;
            FrameworkElement element = GetCellElementByMouseEventArgs(e);
            if ((element == null) || (pressedCell != element))
            {
                pressedCell = null;
                return;
            }
            EditGridCellData cellData = element.DataContext as EditGridCellData;
            if ((cellData == null) || (cellData.Column.FieldName != SelectAllColumn.ColumnFieldName))
                return;
            Grid.SetCellValue(cellData.RowData.RowHandle.Value, cellData.Column as GridColumn, !Convert.ToBoolean(Grid.GetCellValue(cellData.RowData.RowHandle.Value, cellData.Column as GridColumn)));
        }
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);
            if (AllowInternalSelection)
            {
                pressedCell = GetCellElementByMouseEventArgs(e);
            }
        }
    }
}
