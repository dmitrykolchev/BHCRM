using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.DocumentServices
{
    partial class DocumentServiceClient
    {
        internal string ApplicationName { get; set; }
        internal string WorkstationId { get; set; }
        internal string CurrentLanguage { get; set; }
    }
}
