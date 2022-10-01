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
    /// Interaction logic for ProjectTemplateSelectorControl.xaml
    /// </summary>
    public partial class ProjectTemplateSelectorControl : UserControl, IDialogControl
    {
        public ProjectTemplateSelectorControl()
        {
            InitializeComponent();
        }
        public bool? GetDialogResult(MessageBoxResult button)
        {
            if (button == MessageBoxResult.OK)
            {
                if (list.SelectedItem != null)
                    return true;
                ApplicationManager.ShowWarning("Выберите шаблон проекта из списка", MessageBoxButton.OK);
                return null;
            }
            return false;
        }
    }
}
