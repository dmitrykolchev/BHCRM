using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace DykBits.Crm.Data
{
    public interface IDatabaseContext
    {
        DocumentNumberInfo GetDocumentNumberInfo(string className, int organizationId, DateTime documentDate);
        Stream GetDocumentMetadata();
        IEmployeeInfo GetCurrentEmployee();
        Stream ExecuteQuery(Stream stream);
        int ExecuteNonQuery(Stream stream);
        bool IsRemote { get; }
    }
}
