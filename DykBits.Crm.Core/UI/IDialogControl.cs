using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DykBits.Crm.UI
{
    public interface IDialogControl
    {
        bool? GetDialogResult(MessageBoxResult button);
    }
}
