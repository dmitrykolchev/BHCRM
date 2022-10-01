using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for ProjectMemberBatchChangerControl.xaml
    /// </summary>
    public partial class ProjectMemberBatchChangerControl : UserControl
    {
        public ProjectMemberBatchChangerControl()
        {
            InitializeComponent();
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size(Math.Min(800, constraint.Width), Math.Min(600, constraint.Height));
            base.MeasureOverride(size);
            return size;
        }
    }
}
