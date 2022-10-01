using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DykBits.Crm
{
    public interface IMessageBoxService
    {
        void ShowMessage(string message);
        bool ShowQuestion(string question);
        MessageBoxResult ShowWarning(string warning, MessageBoxButton buttons);
        MessageBoxResult ShowQuestion(string question, MessageBoxButton buttons);
        void ShowError(Exception ex);

    }
}
