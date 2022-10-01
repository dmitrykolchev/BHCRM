using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
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
using DevExpress.XtraScheduler;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for AccountEventSchedulerControl.xaml
    /// </summary>
    public partial class AccountEventSchedulerControl : SchedulerControlBase
    {
        public AccountEventSchedulerControl()
        {
            InitializeComponent();
        }

        protected override IList CreateAppointmentCollection()
        {
            return new ObservableCollection<AccountEventView>();
        }

        private void scheduler_AppointmentResized(object sender, DevExpress.XtraScheduler.AppointmentResizeEventArgs e)
        {
            try
            {
                LockRefresh();
                AccountEvent document = DocumentManager.GetItem<AccountEvent>((int)e.EditedAppointment.Id);
                document.EventStart = e.EditedAppointment.Start;
                document.EventEnd = e.EditedAppointment.End;
                DocumentManager.SaveItem(document);
                e.Allow = true;
            }
            catch (Exception ex)
            {
                e.Allow = false;
                ApplicationManager.ShowError(ex);
            }
            finally
            {
                e.Handled = true;
                UnlockRefresh();
            }
        }

        private void scheduler_EditAppointmentFormShowing(object sender, DevExpress.Xpf.Scheduler.EditAppointmentFormEventArgs e)
        {
            if (e.Appointment.Id != null)
            {
                var document = DocumentManager.GetItem<AccountEvent>((int)e.Appointment.Id);
                WindowManager.OpenDocument(document);
            }
            else
            {
                var document = DocumentManager.CreateItem<AccountEvent>(null);
                document.EventStart = e.Appointment.Start;
                document.EventEnd = e.Appointment.End;
                WindowManager.OpenDocument(document);
            }
            e.Cancel =  true;
        }

        private void SchedulerStorage_AppointmentDeleting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            try
            {
                this.DeleteItem();
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
                e.Cancel = true;
            }
        }


    }
}
