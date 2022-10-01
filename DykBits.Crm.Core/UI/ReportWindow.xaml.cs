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
using System.IO;
using DykBits.Crm.Data;
using Microsoft.Reporting.WinForms;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : DevExpress.Xpf.Core.DXWindow
    {
        private Window _owner;
        private string _title;
        public ReportWindow()
        {
            InitializeComponent();
        }

        public static ReportWindow Create(Window owner, string title, Stream reportDefinition, IEnumerable<ReportDataSourceConverter.DataSet> dataSources)
        {
            ReportWindow window = new ReportWindow();
            window._owner = owner;
            window.Title = title + " - Предварительный просмотр";
            window._title = title;
            window.Initialize(reportDefinition, dataSources);
            return window;
        }

        private Window OwnerWindow
        {
            get { return this._owner; }
        }
        private void Initialize(Stream stream, IEnumerable<ReportDataSourceConverter.DataSet> dataSources)
        {
            if (this.OwnerWindow.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Normal;
                this.Left = this.OwnerWindow.Left;
                this.Top = this.OwnerWindow.Top;
                this.Width = this.OwnerWindow.Width;
                this.Height = this.OwnerWindow.Height;
            }
            else
            {
                this.Left = this.OwnerWindow.RestoreBounds.Left;
                this.Top = this.OwnerWindow.RestoreBounds.Top;
                this.Width = this.OwnerWindow.RestoreBounds.Width;
                this.Height = this.OwnerWindow.RestoreBounds.Height;
                this.WindowState = System.Windows.WindowState.Maximized;
            }

            foreach (var dataSource in dataSources)
            {
                ReportDataSource rds = new ReportDataSource(dataSource.Name, dataSource.Value);
                this._reportViewer.LocalReport.DataSources.Add(rds);
            }
            this._reportViewer.LocalReport.LoadReportDefinition(stream);
            this._reportViewer.LocalReport.DisplayName = this._title;
            this._reportViewer.RefreshReport();
            this._reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            this._reportViewer.ZoomMode = ZoomMode.PageWidth;
            this.Loaded += ReportWindow_Loaded;
            this.Closing += ReportWindow_Closing;
            this.Closed += ReportWindow_Closed;
        }

        void ReportWindow_Closed(object sender, EventArgs e)
        {
            this.OwnerWindow.Show();
        }

        void ReportWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.WindowState != System.Windows.WindowState.Normal)
            {
                this.WindowState = WindowState.Normal;
            }
            this.OwnerWindow.WindowState = System.Windows.WindowState.Normal;
            this.OwnerWindow.Left = this.Left;
            this.OwnerWindow.Top = this.Top;
            this.OwnerWindow.Width = this.Width;
            this.OwnerWindow.Height = this.Height;
        }

        void ReportWindow_Loaded(object sender, RoutedEventArgs e)
        {
            OwnerWindow.Hide();
        }
    }
}
