using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public interface IExceptionTranslatorService
    {
        ExceptionInformation Translate(Exception exception);
        Exception LastException { get; }
    }
}
