using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DykBits.Crm.Data
{
    public class UABinding: Binding
    {
        public UABinding()
        {
            this.Source = UserAccess.Instance;
            this.Mode = BindingMode.OneTime;
        }

        public UABinding(string path)
            : base(path)
        {
            this.Source = UserAccess.Instance;
            this.Mode = BindingMode.OneTime;
        }
    }
}
