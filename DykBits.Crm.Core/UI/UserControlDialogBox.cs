using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Core;

namespace DykBits.Crm.UI
{
    public class UserControlDialogBox
    {
        public static bool? ShowDialog(Window owner, Type userControlType, string title, object dataItem, ResizeMode resizeMode = ResizeMode.NoResize)
        {
            DialogWindow dialog = new DialogWindow(title, DialogButtons.OkCancel);
            dialog.Content = Activator.CreateInstance(userControlType);
            dialog.Owner = owner;
            dialog.DataContext = dataItem;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.SizeToContent = SizeToContent.WidthAndHeight;
            dialog.ResizeMode = resizeMode;
            System.Windows.Media.TextOptions.SetTextFormattingMode(dialog, System.Windows.Media.TextFormattingMode.Display);
            dialog.UseLayoutRounding = true;
            dialog.ShowInTaskbar = false;
            dialog.ShowIcon = false;
            return dialog.ShowDialog();
        }

        public static bool? ShowDialog(Window owner, object control, string title, object dataItem, ResizeMode resizeMode = ResizeMode.NoResize)
        {
            DialogWindow dialog = new DialogWindow(title, DialogButtons.OkCancel);
            dialog.Content = control;
            dialog.Owner = owner;
            dialog.DataContext = dataItem;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.SizeToContent = SizeToContent.WidthAndHeight;
            dialog.ResizeMode = resizeMode;
            System.Windows.Media.TextOptions.SetTextFormattingMode(dialog, System.Windows.Media.TextFormattingMode.Display);
            dialog.UseLayoutRounding = true;
            dialog.ShowInTaskbar = false;
            dialog.ShowIcon = false;
            return dialog.ShowDialog();
        }

        private class DialogWindow : DXDialog
        {
            public DialogWindow(string title, DialogButtons buttons)
                : base(title, buttons)
            {
            }
            protected override void OnButtonClick(bool? result, MessageBoxResult messageBoxResult)
            {
                IDialogControl control = this.Content as IDialogControl;
                if (control != null)
                {
                    result = control.GetDialogResult(messageBoxResult);
                }
                base.OnButtonClick(result, messageBoxResult);
            }
        }
    }
}
