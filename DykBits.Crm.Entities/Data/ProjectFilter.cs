using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    partial class ProjectFilter
    {
        public override void InitializeDefaults(object dataContext, object parameter)
        {
            base.InitializeDefaults(dataContext, parameter);
            this.States = new byte[] { (byte)ProjectState.Draft, (byte)ProjectState.Accepted, (byte)ProjectState.Canceled, (byte)ProjectState.Completed };
        }
    }
}
