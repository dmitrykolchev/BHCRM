using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Crm.Data;
using System.Drawing;
using System.Windows;

namespace DykBits.Crm
{
    public class ErrorLogService
    {
        public ErrorLogService()
        {
            CaptureScreen = true;
        }

        public bool CaptureScreen { get; set; }

        public void LogError(Exception ex)
        {
            try
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy("ErrorInformation");
                IErrorInformation errorInfo = (IErrorInformation)dataAdapter.CreateItem(null);
                if (ex.Message.Length > 256)
                    errorInfo.Message = ex.Message.Substring(0, 256);
                else
                    errorInfo.Message = ex.Message;
                errorInfo.Details = ex.ToString();
                if (CaptureScreen)
                    errorInfo.FilePath = GetScreenCapture();
                dataAdapter.Save((IDataItem)errorInfo);
            }
            catch
            {
            }
        }

        private string GetScreenCapture()
        {
            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(t => t.IsActive);
            if (window != null)
            {
                using (Bitmap bitmap = new Bitmap((int)window.Width, (int)window.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new System.Drawing.Point((int)window.Left, (int)window.Top), new System.Drawing.Point(0, 0), new System.Drawing.Size((int)window.Width, (int)window.Height));
                    }
                    string tempDir = Environment.GetEnvironmentVariable("TEMP");
                    string filePath = System.IO.Path.Combine(tempDir, "ScreenCapture.png");
                    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    return filePath;
                }
            }
            return null;
        }
    }
}
