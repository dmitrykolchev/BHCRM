using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;

namespace DykBits.Crm.UI
{
    public abstract class DataWindowBase: DXWindow, IDataWindow
    {
        protected static readonly DependencyPropertyKey FilterViewPropertyKey = DependencyProperty.RegisterReadOnly(
            "FilterView", 
            typeof(DataViewFilterControl), 
            typeof(DataWindowBase),
            new PropertyMetadata(null)
            );

        public static readonly DependencyProperty FilterViewProperty = FilterViewPropertyKey.DependencyProperty;

        public DataViewFilterControl FilterView
        {
            get { return (DataViewFilterControl)GetValue(FilterViewProperty); }
        }

        protected static readonly DependencyPropertyKey FilterViewVisibilityPropertyKey = DependencyProperty.RegisterReadOnly(
            "FilterViewVisibility", 
            typeof(Visibility),
            typeof(DataWindowBase), 
            new PropertyMetadata(Visibility.Collapsed)
            );

        public static readonly DependencyProperty FilterViewVisibilityProperty = FilterViewVisibilityPropertyKey.DependencyProperty;

        public Visibility FilterViewVisibility
        {
            get { return (Visibility)GetValue(FilterViewVisibilityProperty); }
        }

        private CommandLockerCollection _commandLocks;
        public CommandLockerCollection CommandLocks
        {
            get
            {
                if (this._commandLocks == null)
                    this._commandLocks = new CommandLockerCollection();
                return this._commandLocks;
            }
        }
        public abstract DataPresentationType WindowType
        {
            get;
        }
        public bool IsMainWindow
        {
            get { return this.WindowType == DataPresentationType.Root; }
        }
        public bool IsSecondaryWindow
        {
            get { return this.WindowType != DataPresentationType.Root; }
        }
        public virtual string WindowKey
        {
            get { return this.GetType().Name; }
        }
        private WindowData _persistentData;
        public WindowData PersistentData
        {
            get
            {
                if (this._persistentData == null)
                    this._persistentData = ApplicationManager.WindowData.CreateInstance(WindowKey);
                return this._persistentData;
            }
        }
        public abstract IDataView ActiveView
        {
            get;
        }
        protected virtual void OnActiveViewChanged()
        {
            DataViewControlBase activeView = ActiveView as DataViewControlBase;
            var filterView = activeView != null ? activeView.FilterView : null;
            SetValue(FilterViewPropertyKey, filterView);
            SetValue(FilterViewVisibilityPropertyKey, filterView != null ? Visibility.Visible : Visibility.Collapsed);
        }
    }
}
