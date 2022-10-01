using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm
{
    public class StatusInfoChangedEventArgs: EventArgs
    {
        public StatusInfoChangedEventArgs(string statusInfo)
        {
            this.StatusInfo = statusInfo;
        }

        public string StatusInfo { get; private set; }
    }
}
