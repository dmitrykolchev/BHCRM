using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Core;
using DykBits.Crm.UI;   
namespace DykBits.Crm
{
    class MessageBoxService: IMessageBoxService
    {
        private const string MessageBoxCaption = "Banquet-Hall CRM";

        public void ShowMessage(string message)
        {
            DXMessageBox.Show(message, MessageBoxCaption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool ShowQuestion(string question)
        {
            return DXMessageBox.Show(question, MessageBoxCaption, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public void ShowError(Exception ex)
        {
            IExceptionTranslatorService exceptionTranslatorService = ServiceManager.GetService<IExceptionTranslatorService>();
            ExceptionInformation exceptionInformation;
            if (exceptionTranslatorService != null)
                exceptionInformation = exceptionTranslatorService.Translate(ex);
            else
                exceptionInformation = new ExceptionInformation(ex);
            ExceptionInformationForm dialog = new ExceptionInformationForm();
            dialog.DataContext = exceptionInformation;
            dialog.Owner = Application.Current.Windows.OfType<Window>().Where(t => t.IsActive).FirstOrDefault();
            dialog.ShowDialog();
        }


        public MessageBoxResult ShowQuestion(string question, MessageBoxButton buttons)
        {
            return DXMessageBox.Show(question, MessageBoxCaption, buttons, MessageBoxImage.Question);
        }


        public MessageBoxResult ShowWarning(string warning, MessageBoxButton buttons)
        {
            return DXMessageBox.Show(warning, MessageBoxCaption, buttons, MessageBoxImage.Exclamation);
        }
    }
}
