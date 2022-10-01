using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DykBits.Crm.Input;
using DykBits.Crm.UI;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public interface IDataView: ICommandTarget
    {
        PresentationNode Node { get; set; }
        IDataItem SelectedDataItem { get; }
        DataViewType ViewType { get; }
        event EventHandler<StatusInfoChangedEventArgs> StatusInfoChanged;
        bool CanDeactivate();
        void OnActivate();
        void OnDeactivate();
        void OnWindowClosed();
    }
}
