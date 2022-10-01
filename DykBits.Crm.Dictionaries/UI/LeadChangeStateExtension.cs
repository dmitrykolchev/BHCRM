using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    public class LeadChangeStateExtension: PresentationExtension
    {
        public LeadChangeStateExtension()
        {
        }

        protected override void Initialize(object parameter)
        {

        }

        protected override void CanExecute(CanExecuteRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.ChangeDocumentState:
                        break;
                }
            }
        }

        protected override void Execute(ExecutedRoutedEventArgs e)
        {
            UICommand command = e.Command as UICommand;
            if (command != null)
            {
                switch (command.Id)
                {
                    case UICommandId.ChangeDocumentState:
                        EditorWindow window = (EditorWindow)this.Owner;
                        object dataSource = window.DataSource;
                        ChangeDocumentState((Lead)dataSource, (DocumentState)e.Parameter);
                        e.Handled = true;
                        break;
                }
            }
        }

        private void ChangeDocumentState(Lead dataSource, DocumentState state)
        {
            if (state.State == (byte)LeadState.Converted)
            {
                ConvertLead(dataSource);
            }
        }

        private void ConvertLead(Lead dataSource)
        {
            LeadConvertControl control = new LeadConvertControl();
            control.DataSource = dataSource;
            ModalWindow window = ModalWindow.Create("Конвертация интереса", control, dataSource, this.Owner as Window);
            window.ShowDialog();
        }
    }
}
