using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    public class DocumentStateChangedEventArgs: EventArgs
    {
        internal DocumentStateChangedEventArgs(IDataItem document)
        {
            this.Document = document;
        }

        public IDataItem Document
        {
            get;
            private set;
        }
    }
}
