using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Scheduler;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm.UI
{
    public class SchedulerControlBase : DataViewControlBase
    {

        #region SchedulerControl SchedulerView { get; set; }

        public static readonly DependencyProperty SchedulerViewProperty = DependencyProperty.Register("SchedulerView", typeof(SchedulerControl), typeof(SchedulerControlBase),
            new PropertyMetadata(null, OnSchedulerViewPropertyChanged));

        private static void OnSchedulerViewPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            SchedulerControlBase control = (SchedulerControlBase)o;
            control.SchedulerViewInternal = (SchedulerControl)e.NewValue;
        }

        public SchedulerControl SchedulerView
        {
            get { return (SchedulerControl)GetValue(SchedulerViewProperty); }
            set { SetValue(SchedulerViewProperty, value); }
        }

        #endregion


        private SchedulerControl _schedulerView;

        public SchedulerControlBase()
        {
            Uri resourceLocator = new Uri("/DykBits.Crm.Core;component/Themes/SchedulerControlStyles.xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = (ResourceDictionary)System.Windows.Application.LoadComponent(resourceLocator);
            this.Style = (Style)resourceDictionary["schedulerControlStyle"];
            if(ApplicationManager.IsInitialized)
                this.Loaded += SchedulerControlBase_Loaded;
        }

        void SchedulerControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= SchedulerControlBase_Loaded;
            this.RestoreLayout();
            this.RequeryData();
        }

        private SchedulerControl SchedulerViewInternal
        {
            get { return this._schedulerView; }
            set
            {
                if (this._schedulerView != value)
                {
                    UnwireControl();
                    this._schedulerView = value;
                    WireControl();
                }
            }
        }

        private void WireControl()
        {
            if (this._schedulerView != null)
            {
                ItemsSourceInternal = ItemsSource;
            }
        }

        private void UnwireControl()
        {
            if (this._schedulerView != null)
            {
            }
        }

        protected override object ItemsSourceInternal
        {
            get
            {
                if (SchedulerView != null && SchedulerView.Storage != null && SchedulerView.Storage.AppointmentStorage != null)
                    return SchedulerView.Storage.AppointmentStorage.DataSource;
                return null;
            }
            set
            {
                if(SchedulerView != null && SchedulerView.Storage != null && SchedulerView.Storage.AppointmentStorage != null)
                    SchedulerView.Storage.AppointmentStorage.DataSource = value;
            }
        }

        protected virtual IList CreateAppointmentCollection()
        {
            return new ObservableCollection<IDataItem>();
        }

        private IList _dataColl;

        protected override void RequeryData()
        {
            using (new WaitCursor())
            {
                this.SchedulerView.Storage.BeginUpdate();
                try
                {
                    if (this.ItemsSourceInternal == null)
                    {
                        this._dataColl = CreateAppointmentCollection();
                        ItemsSourceInternal = this._dataColl;
                    }
                    this._dataColl.Clear();
                    IList items = this.ViewDataAdapter.Browse(DataSourceFilter.ToXml());
                    foreach (IDataItem item in items)
                    {
                        this._dataColl.Add(item);
                    }
                }
                finally
                {
                    this.SchedulerView.Storage.EndUpdate();
                }
            }
        }

        private string GetLayoutFilePath()
        {
            Window window = Window.GetWindow(this);
            string layoutName = window.Title + "_" + ViewMetadata.ViewName + "_scedulelayout.xml";
            return System.IO.Path.Combine(ApplicationManager.UserAppDataPath, layoutName);
        }
        protected override void SaveLayout()
        {
            string layoutPath = GetLayoutFilePath();
            
        }

        protected override void RestoreLayout()
        {
            string layoutPath = GetLayoutFilePath();
        }

        public override IDataItem[] GetSelectedDataItems()
        {
            return this.SchedulerView.SelectedAppointments.Select(t => (IDataItem)this.SchedulerView.Storage.GetObjectRow(t)).ToArray();
        }

        protected virtual void DeleteItem()
        {
            MessageBoxResult result = ApplicationManager.ShowWarning("Выделенные элементы будут удалены без возможности восстановления.\r\nПродолжить?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var selectedItems = GetSelectedDataItems();

                foreach (var selectedItem in selectedItems)
                {
                    ItemKey itemKey = selectedItem.GetKey();
                    EditorWindow editorWindow = WindowManager.FindWindowByKey(itemKey);
                    if (editorWindow != null)
                    {
                        editorWindow.ActivateWindow();
                        if (editorWindow.Dirty)
                            result = ApplicationManager.ShowQuestion("Документ открыт в отдельном окне и изменен. Продолжить удаление?", MessageBoxButton.YesNo);
                        else
                            result = ApplicationManager.ShowQuestion("Документ открыт в отдельном окне. Продолжить удаление?", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                        else
                        {
                            editorWindow.SilentClose();
                        }
                    }
                    using (new WaitCursor())
                    {
                        
                        DocumentManager.DeleteItem(selectedItem);
                    }
                }
            }
        }


    }
}
