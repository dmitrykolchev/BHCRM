using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ErrorMessage: IErrorMessage
    {
        string IErrorMessage.Code
        {
            get { return this.FileAs; }
        }
        string IErrorMessage.Message
        {
            get { return this.Comments; }
        }
    }
}
