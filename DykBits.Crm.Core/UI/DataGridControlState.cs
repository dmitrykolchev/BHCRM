using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;

namespace DykBits.Crm.UI
{
    interface IGridViewState
    {
        void SaveViewInfo(int count);
        void LoadViewInfo();
    }
    class TreeListViewState: IGridViewState
    {
        private GridControl gridControl;
        private string keyFieldName;
        private Dictionary<int, bool> expanded = new Dictionary<int, bool>();
        public TreeListViewState(GridControl vw, string keyField)
        {
            gridControl = vw;
            keyFieldName = keyField;
        }
        public void SaveViewInfo(int rowCount)
        {
            TreeListView view = gridControl.View as TreeListView;
            SaveNodeExpandedState(view.Nodes);
        }
        public void LoadViewInfo()
        {
            TreeListView view = gridControl.View as TreeListView;
            RestoreExpandedState(view.Nodes);
        }
        private void SaveNodeExpandedState(TreeListNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                if (node.HasChildren)
                {
                    object data = node.Content;
                    Type itemType = data.GetType();
                    var propertyInfo = itemType.GetProperty("Id");
                    int idValue = (int)propertyInfo.GetValue(data);
                    expanded[idValue] = node.IsExpanded;
                    SaveNodeExpandedState(node.Nodes);
                }
            }
        }
        private void RestoreExpandedState(TreeListNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                if (node.HasChildren)
                {
                    object data = node.Content;
                    Type itemType = data.GetType();
                    var propertyInfo = itemType.GetProperty("Id");
                    int idValue = (int)propertyInfo.GetValue(data);
                    if (expanded.ContainsKey(idValue))
                        node.IsExpanded = expanded[idValue];
                    RestoreExpandedState(node.Nodes);
                }
            }
        }
    }

    class DataGridControlState
    {
        private DataGridControlBase _grid;
        private Dictionary<GroupKey, GroupState> _groups;
        private int _selectedRowIndex;

        private class GroupKey
        {
            public object Value { get; set; }
            public override bool Equals(object obj)
            {
                if (obj != null)
                    return object.Equals(this.Value, ((GroupKey)obj).Value);
                return false;
            }

            public override int GetHashCode()
            {
                if (this.Value != null)
                    return this.Value.GetHashCode();
                return 0;
            }
        }

        private class GroupState
        {
            public bool IsExpanded { get; set; }
        }

        public DataGridControlState(DataGridControlBase grid)
        {
            this._grid = grid;
        }

        GridControl Control
        {
            get { return this._grid.GridView; }
        }

        public void Save()
        {
            this._groups = new Dictionary<GroupKey, GroupState>();
            this._selectedRowIndex = 0;
            int[] selectedRowHandles = Control.GetSelectedRowHandles();
            int rowIndex = 0;

            for (int index = 0; index < Control.VisibleRowCount; ++index)
            {
                int rowHandle = Control.GetRowHandleByVisibleIndex(index);
                if (Control.IsGroupRowHandle(rowHandle))
                {
                    object value = Control.GetGroupRowValue(rowHandle);
                    bool expanded = Control.IsGroupRowExpanded(rowHandle);
                    this._groups.Add(new GroupKey { Value = value }, new GroupState { IsExpanded = expanded });
                    SaveEnumerateChildRows(rowHandle);
                }
                if (selectedRowHandles.Length > 0 && selectedRowHandles[0] == rowHandle)
                    this._selectedRowIndex = rowIndex;
                rowIndex++;
            }
        }

        private void SaveEnumerateChildRows(int parentRowHandle)
        {
            for (int index = 0; index < Control.GetChildRowCount(parentRowHandle); ++index)
            {
                int rowHandle = Control.GetChildRowHandle(parentRowHandle, index);
                if (Control.IsGroupRowHandle(rowHandle))
                {
                    object value = Control.GetGroupRowValue(parentRowHandle);
                    bool expanded = Control.IsGroupRowExpanded(parentRowHandle);
                    this._groups.Add(new GroupKey { Value = value }, new GroupState { IsExpanded = expanded });
                    SaveEnumerateChildRows(rowHandle);
                }
            }
        }

        public void Restore()
        {
            for (int index = 0; index < Control.VisibleRowCount; ++index)
            {
                int rowHandle = Control.GetRowHandleByVisibleIndex(index);
                if (Control.IsGroupRowHandle(rowHandle))
                {
                    object value = Control.GetGroupRowValue(rowHandle);
                    bool expanded = Control.IsGroupRowExpanded(rowHandle);
                    GroupKey key = new GroupKey { Value = value };
                    GroupState state;
                    if (this._groups.TryGetValue(key, out state))
                    {
                        if (state.IsExpanded != expanded)
                        {
                            if (state.IsExpanded)
                                Control.ExpandGroupRow(rowHandle);
                            else
                                Control.CollapseGroupRow(rowHandle);
                        }
                    }
                    RestoreEnumerateChildRows(rowHandle);
                }
            }
            int rowIndex = 0;
            for (int index = 0; index < Control.VisibleRowCount; ++index)
            {
                int rowHandle = Control.GetRowHandleByVisibleIndex(index);
                if (this._selectedRowIndex == rowIndex)
                {
                    Control.SelectItem(rowHandle);
                    break;
                }
                rowIndex++;
            }
        }

        private void RestoreEnumerateChildRows(int parentRowHandle)
        {
            for (int index = 0; index < Control.GetChildRowCount(parentRowHandle); ++index)
            {
                int rowHandle = Control.GetChildRowHandle(parentRowHandle, index);
                if (Control.IsGroupRowHandle(rowHandle))
                {
                    object value = Control.GetGroupRowValue(parentRowHandle);
                    bool expanded = Control.IsGroupRowExpanded(parentRowHandle);
                    GroupKey key = new GroupKey { Value = value };
                    GroupState state;
                    if (this._groups.TryGetValue(key, out state))
                    {
                        if (state.IsExpanded != expanded)
                        {
                            if (state.IsExpanded)
                                Control.ExpandGroupRow(parentRowHandle);
                            else
                                Control.CollapseGroupRow(parentRowHandle);
                        }
                    }
                    RestoreEnumerateChildRows(rowHandle);
                }
            }
        }
    }

    public class RowStateHelper: IGridViewState
    {
        private GridControl gridControl;
        private string keyFieldName;

        private int topRowIndex;

        private ArrayList expandedList;
        private ArrayList selectionList;
        private ArrayList masterRowsList;
        private ArrayList groupRowList;

        public RowStateHelper(GridControl vw, string keyField)
        {
            gridControl = vw;
            keyFieldName = keyField;
        }

        public ArrayList ExpandedList
        {
            get
            {
                if (expandedList == null)
                    expandedList = new ArrayList();
                return expandedList;
            }
        }

        public ArrayList SelectionList
        {
            get
            {
                if (selectionList == null)
                    selectionList = new ArrayList();
                return selectionList;
            }
        }

        public ArrayList MasterRowsList
        {
            get
            {
                if (masterRowsList == null)
                    masterRowsList = new ArrayList();
                return masterRowsList;
            }
        }

        public ArrayList GroupRowList
        {
            get
            {
                if (groupRowList == null)
                    groupRowList = new ArrayList();
                return groupRowList;
            }
        }


        #region Saving Information
        public void SaveViewInfo(int dataSourceCount)
        {
            SaveExpandedMasterRows(MasterRowsList, dataSourceCount);
            SaveExpansionView(ExpandedList);
            SaveSelectionView(SelectionList);
            SaveVisibleIndex();
        }

        public void LoadViewInfo()
        {
            LoadExpandedMasterRows(MasterRowsList);
            LoadExpansionView(ExpandedList);
            LoadSelectionView(SelectionList);
            LoadVisibleIndex();
        }

        private void SaveExpandedMasterRows(ArrayList expandedList, int dataSourceCount)
        {
            expandedList.Clear();

            for (int i = 0; i < dataSourceCount; i++)
            {
                int rowHandle = gridControl.GetRowHandleByListIndex(i);
                if (gridControl.IsMasterRowExpanded(rowHandle))
                    expandedList.Add(rowHandle);
            }
        }



        private void SaveExpansionView(ArrayList expandedGroupsList)
        {
            if (gridControl.GroupCount == 0) return;

            GroupRowList.Clear();
            for (int i = -1; i > int.MinValue; i--)
            {
                if (!gridControl.IsValidRowHandle(i)) break;
                if (gridControl.IsGroupRowExpanded(i))
                {
                    GroupRowList.Add(i);
                }
            }
        }

        private void SaveSelectionView(ArrayList selectionList)
        {
            selectionList.Clear();

            int[] selectedRows = gridControl.GetSelectedRowHandles();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectionList.Add(selectedRows[i]);
            }
            selectionList.Add(gridControl.View.FocusedRowHandle);
        }

        public void SaveVisibleIndex()
        {
            topRowIndex = gridControl.View.TopRowIndex;
        }

        #endregion
        #region Loading Information
        private void LoadExpandedMasterRows(ArrayList expandedList)
        {
            gridControl.CollapseAllGroups();
            for (int i = 0; i < expandedList.Count; i++)
            {
                gridControl.ExpandMasterRow((int)expandedList[i]);
            }
        }

        private void LoadExpansionView(ArrayList expandedGroupsList)
        {
            if (gridControl.GroupCount == 0) return;

            gridControl.CollapseAllGroups();

            foreach (int grouIndex in GroupRowList)
            {
                gridControl.ExpandGroupRow(grouIndex);
            }
        }

        private void LoadSelectionView(ArrayList selectionList)
        {
            gridControl.BeginSelection();
            try
            {
                gridControl.UnselectAll();
                for (int i = 0; i < selectionList.Count; i++)
                {
                    if (i == selectionList.Count - 1)
                        ((TableView)gridControl.View).FocusedRowHandle = Convert.ToInt32(selectionList[i]);
                    else
                        gridControl.SelectItem(Convert.ToInt32(selectionList[i]));
                }
            }
            finally
            {
                gridControl.EndSelection();
            }
        }

        public void LoadVisibleIndex()
        {
            gridControl.View.TopRowIndex = topRowIndex;
        }
        #endregion
    }

}
