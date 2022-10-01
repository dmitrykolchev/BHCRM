using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public class CrmBatchException: CrmApplicationException
    {
        private Exception[] _innerExceptions;
        public CrmBatchException(string message, IList<Exception> innerExceptions): base(message, innerExceptions[0])
        {
            this._innerExceptions = innerExceptions.ToArray();
        }
        public IReadOnlyCollection<Exception> BatchExceptions
        {
            get
            {
                return new ReadOnlyCollection<Exception>(this._innerExceptions);
            }
        }
    }
}
