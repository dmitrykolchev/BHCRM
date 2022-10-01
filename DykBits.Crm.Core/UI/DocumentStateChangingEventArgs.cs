using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    public class DocumentStateChangingEventArgs: EventArgs
    {
        internal DocumentStateChangingEventArgs(IDataItem document, DocumentState newState)
        {
            this.Document = document;
            this.NewState = newState;
        }

        public IDataItem Document
        {
            get;
            private set;
        }

        public DocumentState NewState
        {
            get;
            private set;
        }

        public object ApplicationData
        {
            get;
            set;
        }
        public bool Cancel
        {
            get;
            set;
        }
    }
}
