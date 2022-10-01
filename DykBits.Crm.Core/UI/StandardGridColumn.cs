using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DevExpress.Xpf.Grid;

namespace DykBits.Crm.UI
{
    public enum DataColumnType
    {
        None,
        Id,
        Icon,
        State,
        DocumentDate,
        Number,
        Code,
        FileAs,
        Comments,
        Created,
        CreatedBy,
        Modified,
        ModifiedBy,
        IsReference,
        IsIcon,
        IsCheckBox
    }
    public enum ColumnDisplayFormat
    {
        None,
        Integer,
        Money,
        Date,
        Time,
        DateTime,
        Month,
        Decimal,
        Percent
    }
    public class StandardGridColumn : DependencyObject
    {
        public static readonly DependencyProperty DisplayFormatProperty = DependencyProperty.RegisterAttached("DisplayFormat", typeof(ColumnDisplayFormat), typeof(StandardGridColumn),
            new PropertyMetadata(ColumnDisplayFormat.None, OnDisplayFormatPropertyChanged));

        private static void OnDisplayFormatPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = StandardGridColumnSetter.Get((GridColumn)d);
            var displayFormat = (ColumnDisplayFormat)e.NewValue;
            column.DisplayFormat(displayFormat);
        }

        public static ColumnDisplayFormat GetDisplayFormat(GridColumn column)
        {
            return (ColumnDisplayFormat)column.GetValue(DisplayFormatProperty);
        }
        public static void SetDisplayFormat(GridColumn column, ColumnDisplayFormat value)
        {
            column.SetValue(DisplayFormatProperty, value);
        }

        public static readonly DependencyProperty IsReferenceProperty = DependencyProperty.RegisterAttached("IsReference", typeof(bool), typeof(StandardGridColumn),
            new PropertyMetadata(false, OnIsReferencePropertyChanged));

        private static void OnIsReferencePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = StandardGridColumnSetter.Get((GridColumn)d);
            bool isIcon = (bool)e.NewValue;
            if (isIcon)
                column.IsReference();
        }
        public static bool GetIsReference(GridColumn column)
        {
            return (bool)column.GetValue(IsReferenceProperty);
        }
        public static void SetIsReference(GridColumn column, bool value)
        {
            column.SetValue(IsReferenceProperty, value);
        }

        public static readonly DependencyProperty IsIconProperty = DependencyProperty.RegisterAttached("IsIcon", typeof(bool), typeof(StandardGridColumn),
            new PropertyMetadata(false, OnIsIconPropertyChanged));

        private static void OnIsIconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = StandardGridColumnSetter.Get((GridColumn)d);
            bool isIcon = (bool)e.NewValue;
            if (isIcon)
                column.IsIcon();
        }
        public static bool GetIsIcon(GridColumn column)
        {
            return (bool)column.GetValue(IsIconProperty);
        }
        public static void SetIsIcon(GridColumn column, bool value)
        {
            column.SetValue(IsIconProperty, value);
        }
        public static readonly DependencyProperty ColumnProperty = DependencyProperty.RegisterAttached("Column", typeof(DataColumnType), typeof(StandardGridColumn),
            new PropertyMetadata(DataColumnType.None, OnColumnPropertyChanged));

        private static void OnColumnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var column = StandardGridColumnSetter.Get((GridColumn)d);
            var dataColumn = (DataColumnType)e.NewValue;
            switch (dataColumn)
            {
                case DataColumnType.None:
                    break;
                case DataColumnType.Id:
                    SetupIdColumn(column);
                    break;
                case DataColumnType.Icon:
                    SetupIconColumn(column);
                    break;
                case DataColumnType.State:
                    SetupStateColumn(column);
                    break;
                case DataColumnType.DocumentDate:
                    SetupDocumentDateColumn(column);
                    break;
                case DataColumnType.Number:
                    SetupNumberColumn(column);
                    break;
                case DataColumnType.Code:
                    SetupCodeColumn(column);
                    break;
                case DataColumnType.FileAs:
                    SetupFileAsColumn(column);
                    break;
                case DataColumnType.Comments:
                    break;
                case DataColumnType.Created:
                    SetupCreatedColumn(column);
                    break;
                case DataColumnType.CreatedBy:
                    SetupCreatedByColumn(column);
                    break;
                case DataColumnType.Modified:
                    SetupModifiedColumn(column);
                    break;
                case DataColumnType.ModifiedBy:
                    SetupModifiedByColumn(column);
                    break;
                case DataColumnType.IsIcon:
                    column.IsIcon(true);
                    break;
                case DataColumnType.IsReference:
                    column.IsReference(true);
                    break;
                case DataColumnType.IsCheckBox:
                    column.IsCheckBox(true);
                    break;
            }
        }

        private static void SetupDocumentDateColumn(StandardGridColumnSetter column)
        {
            column.Header("Дата")
                .Width(100)
                .Binding("DocumentDate")
                .DisplayFormat(ColumnDisplayFormat.Date);
        }
        private static void SetupNumberColumn(StandardGridColumnSetter column)
        {
            column.Header("№")
                .Width(100)
                .Binding("Number");
        }
        private static void SetupIdColumn(StandardGridColumnSetter column)
        {
            column.Header("Id")
                .Binding("Id")
                .Width(50)
                .IsVisible(false);
        }
        private static void SetupIconColumn(StandardGridColumnSetter column)
        {
            column.Header("Изображение")
                .Binding("CurrentState.Image")
                .IsIcon();
        }
        private static void SetupStateColumn(StandardGridColumnSetter column)
        {
            //  Header="Состояние" FieldName="StateCaption" Width="100" Binding="{Binding Path=CurrentState.Caption, Mode=OneWay}" Visible="False" 
            column.Header("Состояние")
                .Width(50)
                .Binding("CurrentState.Caption")
                .IsVisible(false);
        }
        private static void SetupCodeColumn(StandardGridColumnSetter column)
        {
            column.Header("Код")
                .Width(100)
                .Binding("Code");
        }
        private static void SetupFileAsColumn(StandardGridColumnSetter column)
        {
            //  Header="Наименование" Width="500" FieldName="FileAs" Binding="{Binding FileAs, Mode=OneWay}"
            column.Header("Наименование")
                .Width(300)
                .Binding("FileAs");
        }
        private static void SetupCreatedColumn(StandardGridColumnSetter column)
        {
            //<dxg:GridColumn Header="Дата создания" Width="200" Visible="False" Binding="{Binding Created, Mode=OneWay}" GroupInterval="Date">
            //    <dxg:GridColumn.EditSettings>
            //        <dxe:TextEditSettings DisplayFormat="dd.MM.yyyy HH:mm:ss" />
            //    </dxg:GridColumn.EditSettings>
            //</dxg:GridColumn>
            column.Header("Дата создания")
                .Width(100)
                .IsVisible(false)
                .Binding("Created")
                .GroupInterval(DevExpress.XtraGrid.ColumnGroupInterval.Date)
                .DisplayFormat(ColumnDisplayFormat.DateTime);
        }
        private static void SetupCreatedByColumn(StandardGridColumnSetter column)
        {
            // <dxg:GridColumn Header="Создано" Width="200" Visible="False" Binding="{Binding CreatedBy, Mode=OneWay, Converter={StaticResource UserIdConverter}}" />
            column.Header("Создано")
                .Width(100)
                .IsVisible(false)
                .Binding("CreatedBy", StandardResources.ConvertUserId);
        }
        private static void SetupModifiedColumn(StandardGridColumnSetter column)
        {
            column.Header("Дата изменения")
                .Width(100)
                .IsVisible(false)
                .Binding("Created")
                .GroupInterval(DevExpress.XtraGrid.ColumnGroupInterval.Date)
                .DisplayFormat(ColumnDisplayFormat.DateTime);
        }
        private static void SetupModifiedByColumn(StandardGridColumnSetter column)
        {
            column.Header("Изменено")
                .Width(100)
                .IsVisible(false)
                .Binding("CreatedBy", StandardResources.ConvertUserId);
        }
        public static DataColumnType GetColumn(GridColumn column)
        {
            return (DataColumnType)column.GetValue(ColumnProperty);
        }
        public static void SetColumn(GridColumn column, DataColumnType value)
        {
            column.SetValue(ColumnProperty, value);
        }
    }
}
