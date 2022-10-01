using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DykBits.Crm.Data
{
    public class BindingEx: System.Windows.Data.Binding
    {
        public BindingEx()
        {
            ValidatesOnDataErrors = true;
            Mode = System.Windows.Data.BindingMode.TwoWay;
            UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
        }
        public BindingEx(string path): base(path)
        {
            ValidatesOnDataErrors = true;
            Mode = System.Windows.Data.BindingMode.TwoWay;
            UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
        }
    }
}
