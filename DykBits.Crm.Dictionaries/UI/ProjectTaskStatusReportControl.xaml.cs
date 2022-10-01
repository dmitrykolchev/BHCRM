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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProjectTaskStatusReportControl.xaml
    /// </summary>
    public partial class ProjectTaskStatusReportControl : DataGridControlBase
    {
        private ProjectTaskStatusReportData _data;
        public ProjectTaskStatusReportControl()
        {
            InitializeComponent();
        }

        protected override void RequeryData()
        {
            using (new WaitCursor())
            {
                this.gridView.ItemsSource = null;
                while (this.gridView.Columns.Count > 1)
                    this.gridView.Columns.RemoveAt(this.gridView.Columns.Count - 1);
                ProjectTaskDataAdapterProxy dataAdapter = new ProjectTaskDataAdapterProxy();
                this._data = dataAdapter.BrowseProjectTaskStatusReport((ProjectTaskStatusReport)this.DataSourceFilter);
                for (int index = 0; index < this._data.Columns.Count; ++index)
                {
                    GridColumn column = CreateColumn(this._data.Columns[index]);
                    gridView.Columns.Add(column);
                }
                this.gridView.ItemsSource = this._data.Rows;
            }
        }

        protected override Filter CreateFilter()
        {
            return new ProjectTaskStatusReport { PeriodStart = DateTime.MinValue, PeriodEnd = DateTime.MaxValue };
        }

        protected override void SaveLayout()
        {
        }

        protected override void RestoreLayout()
        {
        }

        public override IDataItem[] GetSelectedDataItems()
        {
            if (HasSelectedItems)
                return new IDataItem[] { SelectedDataItem };
            return new IDataItem[0];
        }

        private ProjectTaskView _selectedTask;

        public override IDataItem SelectedDataItem
        {
            get
            {
                if (Item == null)
                {
                    this._selectedTask = null;
                }
                else
                {
                    if (this._selectedTask != null)
                    {
                        if (this._selectedTask.Id != Item.Id)
                            this._selectedTask = null;
                    }
                    if (this._selectedTask == null)
                        this._selectedTask = new ProjectTaskView { Id = Item.Id, State = (ProjectTaskState)Item.TaskState, FileAs = Item.TaskSubject };
                }
                return this._selectedTask;
            }
        }

        private ProjectTaskStatusReportItem Item
        {
            get
            {
                return gridView.CurrentCellValue as ProjectTaskStatusReportItem;
            }
        }

        public override bool HasSelectedItems
        {
            get
            {
                return Item != null;
            }
        }

        protected override void HandleDocumentOperationComplete(DocumentOperationCompleteEventArgs e)
        {
            if (e.Data != null && e.Data.DataItemClass == ProjectTask.DataItemClassName)
            {
                if (CrmApplicationCommands.Refresh.CanExecute(null, ParentWindow))
                {
                    CrmApplicationCommands.Refresh.Execute(null, ParentWindow);
                }
            }
        }

        private GridColumn CreateColumn(ProjectTaskStatusReportData.ServiceRequestInfo data)
        {
            GridColumn column = new GridColumn();
            column.Width = 48;
            column.FixedWidth = true;
            column.Visible = true;
            column.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            column.ReadOnly = true;
            column.HorizontalHeaderContentAlignment = System.Windows.HorizontalAlignment.Center;
            column.AllowAutoFilter = false;
            column.AllowResizing = DevExpress.Utils.DefaultBoolean.False;
            column.AllowMoving = DevExpress.Utils.DefaultBoolean.False;
            column.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
            column.AllowSorting = DevExpress.Utils.DefaultBoolean.False;
            column.AllowColumnFiltering = DevExpress.Utils.DefaultBoolean.False;
            column.Header = data;
            column.HeaderTemplate = this.Resources["headerTemplate"] as DataTemplate;
            column.CellTemplate = this.Resources["cellTemplate"] as DataTemplate;
            column.Tag = data;
            column.FieldName = Guid.NewGuid().ToString();
            data.Tag = column;
            return column;
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.Xpf.Grid.GridColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                e.Value = this._data.GetItem(this._data.Rows[e.ListSourceRowIndex], (ProjectTaskStatusReportData.ServiceRequestInfo)e.Column.Tag);
            }
        }

        private void gridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TableView view = (TableView)gridView.View;
            var element = view.GetCellElementByMouseEventArgs(e);
            var column = (GridColumn)view.GetColumnByMouseEventArgs(e);
            if (element != null)
            {
                EditGridCellData data = element.DataContext as EditGridCellData;
                if (data != null)
                {
                    ProjectTaskStatusReportItem value = gridView.GetCellValue(data.RowData.RowHandle.Value, column) as ProjectTaskStatusReportItem;
                    if (value != null)
                    {
                        using (new WaitCursor())
                        {
                            var document = DocumentManager.GetItem<ProjectTask>(value.Id);
                            WindowManager.OpenDocument(document);
                        }
                    }
                }
            }
        }
    }
}
