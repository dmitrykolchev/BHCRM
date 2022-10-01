// Copyright (c) 2014-2015 Dmitry Kolchev
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DykBits.Crm.UI;
using DykBits.Crm.Data;
using DykBits.Crm.Input;

namespace DykBits.Crm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DataWindowBase, IDataWindow
    {
        public static readonly DependencyProperty StatusInfoProperty = DependencyProperty.Register("StatusInfo", typeof(string), typeof(MainWindow),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));

        public string StatusInfo
        {
            get { return (string)GetValue(StatusInfoProperty); }
            set { SetValue(StatusInfoProperty, value); }
        }

        private NotificationManager _notificationManager;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this._notificationManager = new NotificationManager();
            this._notificationManager.Notifications.CollectionChanged += Notifications_CollectionChanged;
            this.listNotifications.ItemsSource = this._notificationManager.Notifications;
            UpdateCaption();
        }
        public override DataPresentationType WindowType
        {
            get { return DataPresentationType.Root; }
        }
        void Notifications_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateCaption();
        }
        private void UpdateCaption()
        {
            if (this._notificationManager.Notifications.Count == 0)
                this.notificationsPanel.Caption = "Уведомления";
            else
                this.notificationsPanel.Caption = "Уведомления (" + this._notificationManager.Notifications.Count + ")";
        }
        public PresentationManager PresentationManager
        {
            get
            {
                WindowManager windowManager = ServiceManager.GetService<WindowManager>();
                return windowManager.Windows[WindowManager.MainWindowNode];
            }
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
            this.dockManager.DockController.Dock(this.foldersPanel);
            this.dockManager.DockItemHidden += dockManager_DockItemHidden;
            this.dockManager.DockItemClosing += dockManager_DockItemClosing;
            this.documentGroup.SelectedItemChanged += documentGroup_SelectedItemChanged;
            InitializeNavigator();
        }
        void dockManager_DockItemClosing(object sender, DevExpress.Xpf.Docking.Base.ItemCancelEventArgs e)
        {
            DocumentPanel panel = e.Item as DocumentPanel;
            if (panel != null)
            {
                IControlWithLayout control = panel.Content as IControlWithLayout;
                control.SaveLayout();
                panel.Content = null;
            }
        }
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                SaveLayout();
                if (!ApplicationManager.CleanUp())
                    e.Cancel = true;
                this._notificationManager.Close();
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                ApplicationManager.ShowError(ex);
            }
        }
        private void SaveLayout()
        {
            this.dockManager
                .GetItems()
                .OfType<DocumentPanel>()
                .Where(t => t.Content is IControlWithLayout)
                .Select(t => (IControlWithLayout)t.Content)
                .ToList()
                .ForEach(t => { try { t.SaveLayout(); } catch { } });
        }
        void documentGroup_SelectedItemChanged(object sender, DevExpress.Xpf.Docking.Base.SelectedItemChangedEventArgs e)
        {
            DocumentPanel panel = e.Item as DocumentPanel;
            if (panel != null)
            {
                IDataView dataView = panel.Content as IDataView;
                ActiveNode = dataView.Node;
            }
            else
            {
                ActiveNode = null;
            }
            OnActiveViewChanged(panel);
        }
        void dockManager_DockItemHidden(object sender, DevExpress.Xpf.Docking.Base.ItemEventArgs e)
        {
            if (e.Item.Parent is AutoHideGroup)
            {
                ((AutoHideGroup)e.Item.Parent).AutoHideSize = new Size(e.Item.ActualWidth, e.Item.ActualHeight);
            }
        }
        private void InitializeNavigator()
        {
            if (PresentationManager != null && this.navigationBar != null)
            {
                foreach (PresentationNode node in PresentationManager.Children)
                {
                    NavBarGroup group = new NavBarGroup();
                    group.Header = node.Caption;
                    group.ImageSource = node.LargeImage;
                    group.DisplaySource = DisplaySource.Content;
                    group.ImageSettings = new ImageSettings { Stretch = System.Windows.Media.Stretch.None, Width = 32, Height = 32 };
                    group.GroupScrollMode = ScrollMode.None;

                    NavigationView view = new NavigationView();
                    view.ViewSource = node;
                    view.SelectionChanged += view_SelectionChanged;
                    group.Content = view;
                    this.navigationBar.Groups.Add(group);
                }
            }
        }
        void view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                ActiveNode = (PresentationNode)e.AddedItems[0];
            else
                ActiveNode = null;
        }
        private bool FindAndActivateView(PresentationNode viewNode)
        {
            var groups = dockManager.GetItems().OfType<DocumentGroup>();
            foreach (DocumentGroup group in groups)
            {
                foreach (DocumentPanel panel in group.Items.OfType<DocumentPanel>())
                {
                    if (object.ReferenceEquals(panel.Tag, viewNode))
                    {
                        this.dockManager.Activate(panel);
                        OnActiveViewChanged(panel);
                        return true;
                    }
                }
            }
            return false;
        }
        private void CreateView(PresentationNode viewNode)
        {
            DocumentPanel panel = new DocumentPanel();
            panel.Caption = viewNode.Caption;
            panel.CaptionImage = viewNode.SmallImage;
            panel.Content = viewNode.CreateViewControl();
            panel.Tag = viewNode;
            this.documentGroup.Items.Add(panel);
            this.dockManager.Activate(panel);
            OnActiveViewChanged(panel);
        }
        private void RecreateView()
        {
            DocumentPanel panel = (DocumentPanel)this.documentGroup.SelectedItem;
            panel.Content = ActiveNode.CreateViewControl();
            OnActiveViewChanged(panel);
        }
        private void OnActiveViewChanged(DocumentPanel panel)
        {
            InitializeActionsMenu(panel != null ? panel.Content as IActionProvider : null);
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
                        string buttonName = "_" + Guid.NewGuid().ToString("N");
                        BarButtonItem item = new BarButtonItem();
                        item.Name = buttonName;
                        item.Content = action.Text;
                        item.Command = action.Command;
                        item.CommandTarget = (IInputElement)actionProvider;
                        barManager.Items.Add(item);
                        BarButtonItemLink link = new BarButtonItemLink();
                        popupMenu.ItemLinks.Add(link);
                        link.BarItemName = buttonName;
                    }
                    splitButton.PopupControl = popupMenu;
                    actionsButton.IsVisible = true;
                }
                else
                {
                    actionsButton.IsVisible = false;
                }
            }
            else
            {
                BarSplitButtonItem splitButton = this.barSplitButtonActions;
                splitButton.PopupControl = null;
                actionsButton.IsVisible = false;
            }
        }

        #region Command handling
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CommandLocks.IsLocked(e.Command))
            {
                e.CanExecute = false;
                e.Handled = true;
                return;
            }
            ICommandTarget activeView = this.ActiveView;
            if (activeView != null)
            {
                activeView.CanExecute(e);
            }
            if (!e.Handled)
            {
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    switch (command.Id)
                    {
                        case UICommandId.SetTheme:
                            e.CanExecute = true;
                            e.Handled = true;
                            break;
                        case UICommandId.RecreatePresentation:
                            e.CanExecute = this.ActiveView is IControlWithLayout;
                            e.Handled = true;
                            break;
                        case UICommandId.DeleteNotification:
                            e.CanExecute = this.listNotifications != null && this.listNotifications.SelectedItem != null;
                            e.Handled = true;
                            break;
                        case UICommandId.OpenNotificationDocument:
                            e.CanExecute = true;
                            e.Handled = true;
                            break;
                        case UICommandId.ClearAll:
                            e.CanExecute = this.listNotifications != null && this.listNotifications.HasItems;
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ICommandTarget activeView = this.ActiveView;
            if (activeView != null)
            {
                activeView.Executed(e);
            }
            if (!e.Handled)
            {
                UICommand command = e.Command as UICommand;
                if (command != null)
                {
                    switch (command.Id)
                    {
                        case UICommandId.SetTheme:
                            using (new WaitCursor())
                            {
                                ApplicationManager.ThemeName = (string)e.Parameter;
                            }
                            ApplicationManager.ShowWarning("После изменения темы рекомендуется перезапустить приложение.", MessageBoxButton.OK);
                            e.Handled = true;
                            break;
                        case UICommandId.RecreatePresentation:
                            RecreateView();
                            e.Handled = true;
                            break;
                        case UICommandId.DeleteNotification:
                            this._notificationManager.Delete((UserNotificationView)(((FrameworkElement)e.OriginalSource).DataContext));
                            e.Handled = true;
                            break;
                        case UICommandId.OpenNotificationDocument:
                            this._notificationManager.OpenDocument((UserNotificationView)(((System.Windows.FrameworkContentElement)e.OriginalSource).DataContext));
                            e.Handled = true;
                            break;
                        case UICommandId.ClearAll:
                            ClearAllNotifications();
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        #endregion
        
        private void ClearAllNotifications()
        {
            if (ApplicationManager.ShowQuestion("Все уведомления будут удалены без возможности восстановления. Продолжить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (new WaitCursor())
                {
                    this._notificationManager.ClearAll();
                }
            }
        }
        public override IDataView ActiveView
        {
            get
            {
                DocumentPanel panel = this.dockManager.ActiveDockItem as DocumentPanel;
                if (panel != null)
                    return panel.Content as IDataView;
                return null;
            }
        }
        private PresentationNode _activeNode;
        private PresentationNode ActiveNode
        {
            get { return this._activeNode; }
            set
            {
                if (value != this._activeNode)
                {
                    using (new WaitCursor())
                    {
                        if (ActiveView != null)
                        {
                            ActiveView.StatusInfoChanged -= ActiveView_StatusInfoChanged;
                            ActiveView.OnDeactivate();
                        }
                        if (value != null && value.ViewControlType != null)
                        {
                            if (!FindAndActivateView(value))
                            {
                                CreateView(value);
                            }
                        }
                        this._activeNode = value;
                        if (ActiveView != null)
                        {
                            ActiveView.StatusInfoChanged += ActiveView_StatusInfoChanged;
                            ActiveView.OnActivate();
                        }
                    }
                }
            }
        }
        void ActiveView_StatusInfoChanged(object sender, StatusInfoChangedEventArgs e)
        {
            SetCurrentValue(StatusInfoProperty, e.StatusInfo);
        }
    }
}
