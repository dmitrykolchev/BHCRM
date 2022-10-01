using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DevExpress.Xpf.Grid;
using DykBits.Crm.UI;

namespace DykBits.Crm.Data
{
    public class DataExport
    {
        public static string ExportToExcel(TableView view, string defaultFileName)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = defaultFileName;
            dialog.DefaultExt = "xlsx";
            dialog.Filter = "Microsoft Office Excel (*.xlsx)|*.xlsx";
            if (dialog.ShowDialog() == true)
            {
                using (new WaitCursor())
                {
                    string fileName = dialog.FileName;
                    using (FileStream stream = File.Create(fileName))
                    {
                        view.ExportToXlsx(stream);
                        return fileName;
                    }
                }
            }
            return null;
        }

        public static string ExportToExcel(TreeListView view, string defaultFileName)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = defaultFileName;
            dialog.DefaultExt = "xlsx";
            dialog.Filter = "Microsoft Office Excel (*.xlsx)|*.xlsx";
            if (dialog.ShowDialog() == true)
            {
                using (new WaitCursor())
                {
                    string fileName = dialog.FileName;
                    using (FileStream stream = File.Create(fileName))
                    {
                        view.ExportToXlsx(stream);
                        return fileName;
                    }
                }
            }
            return null;
        }
    }
}
