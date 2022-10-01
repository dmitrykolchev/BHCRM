using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public interface IDocumentReportInfo
    {
        int Id { get; }
        string Code { get; }
        string FileAs { get; }
        string ReportPath { get; }
        string Comments { get; }
    }

    public class DocumentReportInfo : IDocumentReportInfo
    {
        private static int ReportCount;
        public DocumentReportInfo()
        {
            this.Id = System.Threading.Interlocked.Increment(ref ReportCount);
        }
        public int Id { get; private set; }
        public string Code { get; set; }
        public string FileAs { get; set; }
        public string ReportPath { get; set; }
        public string Comments { get; set; }
    }
}
