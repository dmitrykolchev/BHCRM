using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public interface IErrorInformation
    {
        string Message { get; set; }
        string Details { get; set; }

        string FilePath { get; set; }
    }
}
