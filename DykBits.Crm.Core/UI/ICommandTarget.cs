using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DykBits.Crm.UI
{
    public interface ICommandTarget
    {
        void CanExecute(CanExecuteRoutedEventArgs e);
        void Executed(ExecutedRoutedEventArgs e);
    }
}
