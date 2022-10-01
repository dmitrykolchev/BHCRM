using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Utils;

namespace DykBits.Crm.UI
{
    class StandardGridColumnSetter
    {
        private GridColumn _column;
        private StandardGridColumnSetter(GridColumn column)
        {
            this._column = column;
        }
        public static StandardGridColumnSetter Get(GridColumn column)
        {
            return new StandardGridColumnSetter(column);
        }
        public StandardGridColumnSetter Name(string name)
        {
            this._column.Name = name;
            return this;
        }
        public StandardGridColumnSetter Width(double value)
        {
            this._column.Width = value;
            return this;
        }
        public StandardGridColumnSetter FixedWidth(bool value = true)
        {
            this._column.FixedWidth = value;
            return this;
        }
        public StandardGridColumnSetter Header(string value)
        {
            this._column.Header = value;
            return this;
        }
        public StandardGridColumnSetter HeaderTemplate(DataTemplate dataTemplate)
        {
            this._column.HeaderTemplate = dataTemplate;
            return this;
        }
        public StandardGridColumnSetter IsVisible(bool value = true)
        {
            this._column.Visible = value;
            return this;
        }
        public StandardGridColumnSetter Binding(string path)
        {
            this._column.Binding = new Binding { Path = new PropertyPath(path), Mode = BindingMode.OneWay };
            return this;
        }
        public StandardGridColumnSetter Binding(string path, IValueConverter converter, object parameter = null)
        {
            this._column.Binding = new Binding { Path = new PropertyPath(path), Converter = converter, ConverterParameter = parameter };
            return this;
        }
        public StandardGridColumnSetter GroupInterval(DevExpress.XtraGrid.ColumnGroupInterval value)
        {
            this._column.GroupInterval = value;
            return this;
        }
        public StandardGridColumnSetter DisplayFormat(ColumnDisplayFormat format)
        {
            switch (format)
            {
                case ColumnDisplayFormat.None:
                    this._column.EditSettings = new TextEditSettings();
                    break;
                case ColumnDisplayFormat.Integer:
                    this._column.EditSettings = new TextEditSettings { DisplayFormat = "#,##0", HorizontalContentAlignment = EditSettingsHorizontalAlignment.Right };
                    break;
                case ColumnDisplayFormat.Money:
                case ColumnDisplayFormat.Decimal:
                    this._column.EditSettings = new TextEditSettings { DisplayFormat = "#,##0.00", HorizontalContentAlignment = EditSettingsHorizontalAlignment.Right };
                    break;
                case ColumnDisplayFormat.Percent:
                    this._column.EditSettings = new TextEditSettings { DisplayFormat = "P", HorizontalContentAlignment = EditSettingsHorizontalAlignment.Right };
                    break;
                case ColumnDisplayFormat.Date:
                    this._column.EditSettings = new TextEditSettings { DisplayFormat = "dd.MM.yyyy"};
                    break;
                case ColumnDisplayFormat.Time:
                    this._column.EditSettings = new TextEditSettings { DisplayFormat = "HH:mm" };
                    break;
                case ColumnDisplayFormat.DateTime:
                    this._column.EditSettings = new TextEditSettings { DisplayFormat = "dd.MM.yyyy HH:mm:ss" };
                    break;
                case ColumnDisplayFormat.Month:
                    this._column.EditSettings = new TextEditSettings { DisplayFormat = "MMMM yyyy" };
                    break;
            }
            return this;
        }
        public StandardGridColumnSetter IsReference(bool value = true)
        {
            if (value)
            {
                this._column.AllowSorting = DefaultBoolean.True;
                this._column.AllowGrouping = DefaultBoolean.True;
                this._column.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
                this._column.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DisplayText;
            }
            return this;
        }
        public StandardGridColumnSetter IsIcon(bool value = true)
        {
            if (value)
            {
                this._column.Width = 24;
                this._column.FixedWidth = true;
                this._column.AllowSorting = DefaultBoolean.False;
                this._column.AllowResizing = DefaultBoolean.False;
                this._column.AllowAutoFilter = false;
                this._column.AllowColumnFiltering = DefaultBoolean.False;
                this._column.HeaderTemplate = StandardResources.Get<DataTemplate>("GridIconColumnHeader");
                this._column.EditSettings = new ImageEditSettings
                {
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = EditSettingsHorizontalAlignment.Center,
                    Stretch = Stretch.None
                };
            }
            return this;
        }
        public StandardGridColumnSetter IsCheckBox(bool value = true)
        {
            if (value)
            {
                this._column.Width = 32;
                this._column.FixedWidth = true;
                this._column.AllowSorting = DefaultBoolean.True;
                this._column.AllowResizing = DefaultBoolean.True;
                this._column.AllowAutoFilter = false;
                this._column.AllowColumnFiltering = DefaultBoolean.False;
                this._column.EditSettings = new CheckEditSettings();
            }
            return this;
        }
    }
}
