using System;
using System.ComponentModel;
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
using System.Windows.Shapes;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DykBits.Crm.Input;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class TabbedEditorWindow : EditorWindow
    {
        public TabbedEditorWindow(string windowKey)
            : base(windowKey)
        {
            InitializeComponent();
        }
        protected override void OnSaveLayout()
        {
            foreach (DXTabItem item in this.containerTabs.Items)
            {
                IControlWithLayout control = item.Content as IControlWithLayout;
                if (control != null)
                {
                    try
                    {
                        control.SaveLayout();
                    }
                    catch
                    {
                    }
                }
            }
        }
        protected override void InitializePresentations()
        {
            foreach (PresentationNode item in this.PresentationManager.Children)
            {
                DXTabItem tabItem = new DXTabItem();
                tabItem.Header = item.Caption;
                tabItem.Tag = item;
                this.containerTabs.Items.Add(tabItem);
            }
            ActivateView((DXTabItem)this.containerTabs.Items[0]);
        }
        protected override void OnDataSourceChanged(DataSourceChangedEventArgs e)
        {
            base.OnDataSourceChanged(e);
            foreach (DXTabItem tab in this.containerTabs.Items)
            {
                if (tab.Content is EditorControlBase)
                {
                    EditorControlBase editorControl = (EditorControlBase)tab.Content;
                    editorControl.InvokeWireEvents();
                    editorControl.InvokeDataSourceChanged(e);
                }
            }
        }
        protected override void OnDataSourceChanging(DataSourceChangedEventArgs e)
        {
            base.OnDataSourceChanging(e);
            foreach (DXTabItem tab in this.containerTabs.Items)
            {
                if (tab.Content is EditorControlBase)
                {
                    EditorControlBase editorControl = (EditorControlBase)tab.Content;
                    editorControl.InvokeUnwireEvents();
                }
            }
        }
        protected override void InitializeChangeStateMenu()
        {
            DocumentMetadata metadata = DocumentManager.GetMetadata(this.DataSource.DataItemClassId);
            if (metadata.States.Count > 2)
            {
                PopupMenu popupMenu = new PopupMenu();
                foreach (DocumentState state in metadata.States)
                {
                    if (state.State > 0)
                    {
                        BarButtonItem item = new BarButtonItem();
                        item.Content = state.Caption;
                        item.Command = CrmApplicationCommands.ChangeDocumentState;
                        item.CommandTarget = this;
                        item.CommandParameter = state;
                        popupMenu.Items.Add(item);
                    }
                }
                BarSplitButtonItem splitButton = this.barSplitButtonState;
                splitButton.PopupControl = popupMenu;
                splitButton.IsVisible = true;
            }
            else
            {
                this.barSplitButtonState.IsVisible = false;
            }
        }

        private IDataView __activeView;
        private void SetActiveView(IDataView activeView)
        {
            this.__activeView = activeView;
            this.Grid = activeView as DataGridControlBase;
        }
        public override IDataView ActiveView
        {
            get
            {
                return this.__activeView;
            }
        }

        internal static readonly DependencyPropertyKey GridPropertyKey = DependencyProperty.RegisterReadOnly("Grid", typeof(DataGridControlBase), typeof(TabbedEditorWindow),
            new PropertyMetadata(null));
        public static readonly DependencyProperty GridProperty = GridPropertyKey.DependencyProperty;

        public DataGridControlBase Grid
        {
            get { return (DataGridControlBase)GetValue(GridProperty); }
            private set { SetValue(GridPropertyKey, value); }
        }
        protected override void RecreateView()
        {
            DXTabItem tabItem = this.containerTabs.SelectedTabItem;
            tabItem.Content = null;
            ActivateView(tabItem);
        }
        protected override void ActivateView(object parameter)
        {
            if (ActiveView != null)
                ActiveView.OnDeactivate();
            DXTabItem tabItem = (DXTabItem)parameter;
            PresentationNode viewNode = (PresentationNode)tabItem.Tag;
            Control view;
            if (tabItem.Content == null)
            {
                view = viewNode.CreateViewControl();
                tabItem.Content = view;
                view.Loaded += view_Loaded;
            }
            SetActiveView(tabItem.Content as IDataView);
            InitializeActionsMenu(tabItem.Content as IActionProvider);
            if (ActiveView != null)
                ActiveView.OnActivate();
            OnActiveViewChanged();
        }
        private void InitializeActionsMenu(IActionProvider actionProvider)
        {
            if (actionProvider != null)
            {
                BarSplitButtonItem splitButton = this.barSplitButtonActions;
                if (actionProvider.Actions.Count > 0)
                {
                    PopupMenu popupMenu = new PopupMenu();
                    foreach (var action in actionProvider.Actions)
                    {
                        BarButtonItem item = new BarButtonItem();
                        item.Content = action.Text;
                        item.Command = action.Command;
                        item.CommandTarget = actionProvider as IInputElement;
                        popupMenu.Items.Add(item);
                    }
                    splitButton.PopupControl = popupMenu;
                    actionsButton.IsVisible = true;
                }
                else
                {
                    actionsButton.IsVisible = false;
                }
            }
        }
        void view_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ((Control)sender).Loaded -= view_Loaded;
                ((Control)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
            }
        }

        private void containerTabs_SelectionChanging(object sender, TabControlSelectionChangingEventArgs e)
        {
            try
            {
                if (ActiveView != null)
                {
                    UpdateDataSource();
                    if (!ActiveView.CanDeactivate())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                DXTabItem item = e.NewSelectedItem as DXTabItem;
                CrmApplicationCommands.ActivateView.Execute(item, this);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                ApplicationManager.ShowError(ex);
            }
        }
    }
}
