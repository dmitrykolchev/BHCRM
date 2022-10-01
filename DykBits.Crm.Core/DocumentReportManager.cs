using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DykBits.Crm.UI;
using DykBits.Crm.Data;
using System.Dynamic;
using System.Reflection;

namespace DykBits.Crm
{
    public abstract class DocumentReportManager
    {
        public abstract Stream GetReportStream(IDocumentReportInfo reportInfo);
        public ReportDataSourceConverter ConvertToReportDataSource(IDataItem document)
        {
            if (document == null)
                throw new ArgumentNullException("document");
            ReportDataSourceAttribute attribute = document.GetType().GetCustomAttribute<ReportDataSourceAttribute>();
            if(attribute == null)
                return new SimpleDataSourceConverter(document);
            Type dataSourceConverterType = attribute.DataSourceType;
            return (ReportDataSourceConverter)Activator.CreateInstance(dataSourceConverterType, document);
        }

        public static IDocumentReportInfo SelectReport<T>(string selector)
        {
            return SelectReport(typeof(T), selector);
        }

        private static IDocumentReportInfo SelectReport(DocumentMetadata metadata, string selector)
        {
            if (metadata.Reports.Count == 0)
                return null;
            IList<IDocumentReportInfo> reports;

            if (!string.IsNullOrEmpty(selector))
                reports = metadata.Reports.Where(t => t.Code == selector).ToList();
            else
                reports = metadata.Reports;

            if (reports.Count == 1)
                return reports[0];
            ReportSelectorControl control = new ReportSelectorControl();
            dynamic data = new ExpandoObject();
            data.Reports = reports;
            data.SelectedReport = (IDocumentReportInfo)null;
            ModalWindow modalWindow = ModalWindow.Create("Выбор шаблона отчета", control, data);
            try
            {
                if (modalWindow.ShowDialog() == true)
                {
                    return data.SelectedReport;
                }
                return null;
            }
            finally
            {
                modalWindow.Close();
            }
        }
        public static IDocumentReportInfo SelectReport(string documentClass, string selector)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            DocumentMetadata metadata = documentManager.Documents[documentClass];
            return SelectReport(metadata, selector);
        }

        public static IDocumentReportInfo SelectReport(Type documentType, string selector)
        {
            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            DocumentMetadata metadata = documentManager.Documents[documentType];
            return SelectReport(metadata, selector);
        }

        private class SimpleDataSourceConverter : ReportDataSourceConverter
        {
            public SimpleDataSourceConverter(IDataItem document)
                : base(document)
            {
            }
            public override DataSet[] GetReportData()
            {
                return new DataSet[1] { new DataSet { Name = "DataSet1", Value = new object[] { this.Source } } };
            }
        }}
}
