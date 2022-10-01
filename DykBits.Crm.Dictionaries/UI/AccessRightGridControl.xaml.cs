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
using System.Xml;
using Microsoft.Win32;

using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for AccessRightGridControl.xaml
    /// </summary>
    public partial class AccessRightGridControl : DataGridControlBase
    {
        public AccessRightGridControl()
        {
            InitializeComponent();
        }

        private void BackupSecuritySettings_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void BackupSecuritySettings_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SecuritySchemeDataAdapterProxy dataAdapter = new SecuritySchemeDataAdapterProxy();
            var scheme = dataAdapter.GetItem<SecurityScheme>(1);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "xml";
            dialog.Filter = "Файлы настроек безопасности (*.xml)|*.xml";
            dialog.FileName = "SecuritySettings";
            if(dialog.ShowDialog() == true)
            {
                using(XmlWriter writer = XmlWriter.Create(dialog.FileName))
                {
                    scheme.WriteXml(writer);
                }
            }
        }

        private void RestoreSecuritySettings_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void RestoreSecuritySettings_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "xml";
            dialog.Filter = "Файлы настроек безопасности (*.xml)|*.xml";
            dialog.FileName = "SecuritySettings";
            if (dialog.ShowDialog() == true)
            {
                SecurityScheme scheme = new SecurityScheme();
                using (XmlReader reader = XmlReader.Create(dialog.FileName))
                {
                    scheme.ReadXml(reader);
                }
                SecuritySchemeDataAdapterProxy dataAdapter = new SecuritySchemeDataAdapterProxy();
                dataAdapter.Save(scheme);
            }
        }
    }
}
