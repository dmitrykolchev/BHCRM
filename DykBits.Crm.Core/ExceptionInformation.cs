using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public class ExceptionInformation
    {
        private Exception _exception;
        private string _message;
        public ExceptionInformation(Exception exception)
        {
            this._exception = exception;
        }

        public Exception Exception
        {
            get { return this._exception; }
        }
        public string Message
        {
            get
            {
                if (string.IsNullOrEmpty(this._message))
                    return this._exception.Message;
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

        public string StackTrace
        {
            get
            {
                return this._exception.ToString();
            }
        }
        public string Description { get; set; }
    }
}
