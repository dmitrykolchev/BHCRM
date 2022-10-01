using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DevExpress.Xpf.Grid;

namespace DykBits.Crm.UI
{
    public class StandardGridControl: GridControl
    {
        public StandardGridControl()
            : base()
        {
            this.SelectionMode = MultiSelectMode.Row;
        }
    }
}
