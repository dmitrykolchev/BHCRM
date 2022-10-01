using System;
using System.Collections;
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

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class NavigationView : UserControl
    {
        public static readonly DependencyProperty ViewSourceProperty = DependencyProperty.Register("ViewSource", typeof(PresentationNode), typeof(NavigationView),
            new PropertyMetadata(null, OnViewSourcePropertyChanged));

        private PresentationNode _viewSource;
        private static void OnViewSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((NavigationView)o).SetViewSource((PresentationNode)e.NewValue);
        }

        public PresentationNode ViewSource
        {
            get { return this._viewSource; }
            set { SetValue(ViewSourceProperty, value); }
        }

        public NavigationView()
        {
            InitializeComponent();
            this.Loaded += NavigationView_Loaded;
        }

        void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= NavigationView_Loaded;
            this.treeView.SelectedItemChanged += treeView_SelectedItemChanged;
            this.treeView.PreviewMouseLeftButtonDown += treeView_PreviewMouseLeftButtonDown;
            this.listView.SelectionChanged += listView_SelectionChanged;
            this.listView.PreviewMouseLeftButtonDown += listView_PreviewMouseLeftButtonDown;
        }

        private void SetViewSource(PresentationNode value)
        {
            if(this._viewSource != value)
            {
                this._viewSource = value;
                if (value != null)
                    this.treeView.ItemsSource = value.Children;
                else
                    this.treeView.ItemsSource = null;
            }
        }

        private static PresentationNode ItemFromPoint<T, TItem>(T control, Point point) where T : ItemsControl
        {
            HitTestResult result = VisualTreeHelper.HitTest(control, point);
            if (result != null)
            {
                DependencyObject temp = result.VisualHit;
                while (temp != null)
                {
                    if (temp is TItem)
                    {
                        return (PresentationNode)((FrameworkElement)temp).DataContext;
                    }
                    temp = VisualTreeHelper.GetParent(temp);
                }
            }
            return null;
        }

        void listView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PresentationNode item = ItemFromPoint<ListBox, ListBoxItem>(listView, e.GetPosition(listView));
            if (item != null && this.SelectedNode == item)
                InvokeSelectionChanged(new PresentationNode[0], new PresentationNode[] { item });
        }


        void treeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PresentationNode item = ItemFromPoint<TreeView, TreeViewItem>(treeView, e.GetPosition(treeView));
            if (item != null && this.SelectedNode == item)
                InvokeSelectionChanged(new PresentationNode[0], new PresentationNode[] { item });
        }

        void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedTreeNode = (PresentationNode)e.NewValue;
            e.Handled = true;
        }
        void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedNode = (PresentationNode)listView.SelectedItem;
            e.Handled = true;
        }

        private int GetDefaultViewIndex()
        {
            string defaultView = this._selectedTreeNode.DefaultView;
            for (int index = 0; index < this._selectedTreeNode.Views.Count; ++index)
            {
                if (defaultView == this._selectedTreeNode.Views[index].Key)
                    return index;
            }
            return -1;
        }

        private PresentationNode _selectedTreeNode;
        private GridLength _defaultRowHeight = new GridLength(1, GridUnitType.Star);
        private PresentationNode SelectedTreeNode
        {
            get { return this._selectedTreeNode; }
            set
            {
                if (this._selectedTreeNode != value)
                {
                    this._selectedTreeNode = value;
                    this.Dispatcher.BeginInvoke(
                        new Action<PresentationNode>((t) => { SetSelectedTreeNode(t); }), 
                        System.Windows.Threading.DispatcherPriority.Normal, 
                        value
                        );
                }
            }
        }

        void SetSelectedTreeNode(PresentationNode value)
        {
            if (this._selectedTreeNode.Views.Count > 0)
            {
                this.row2.Height = this._defaultRowHeight;
                this.listView.Visibility = System.Windows.Visibility.Visible;
                this.splitter.Visibility = System.Windows.Visibility.Visible;
                this.listView.ItemsSource = value.Views;
                int defaultViewIndex = Math.Max(0, GetDefaultViewIndex());
                if (this.listView.SelectedIndex != defaultViewIndex)
                {
                    this.listView.SelectedIndex = defaultViewIndex;
                }
                else
                {
                    this.SelectedNode = value.Views[defaultViewIndex];
                }
            }
            else
            {
                if (this.splitter.Visibility != System.Windows.Visibility.Collapsed)
                {
                    this._defaultRowHeight = this.row2.Height;
                    this.row2.Height = GridLength.Auto;
                    this.splitter.Visibility = System.Windows.Visibility.Collapsed;
                    this.listView.Visibility = System.Windows.Visibility.Collapsed;
                }
                this.SelectedNode = value;
            }
        }

        private PresentationNode _selectedNode;
        private PresentationNode SelectedNode
        {
            get { return this._selectedNode; }
            set
            {
                if (this._selectedNode != value)
                {
                    PresentationNode[] removed;
                    if (this._selectedNode == null)
                        removed = new PresentationNode[0];
                    else
                        removed = new PresentationNode[] { this._selectedNode };

                    this._selectedNode = value;
                    if (this._selectedNode != null)
                    {
                        this._selectedNode.Parent.DefaultView = this._selectedNode.Key;
                    }

                    PresentationNode[] added;
                    if (this._selectedNode == null)
                        added = new PresentationNode[0];
                    else
                        added = new PresentationNode[] { this._selectedNode };
                    InvokeSelectionChanged(removed, added);
                }
            }
        }

        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(NavigationView));

        public event SelectionChangedEventHandler SelectionChanged
        {
            add
            {
                base.AddHandler(SelectionChangedEvent, value);
            }
            remove
            {
                base.RemoveHandler(SelectionChangedEvent, value);
            }
        }

        private void InvokeSelectionChanged(IList removed, IList added)
        {
            OnSelectionChanged(new SelectionChangedEventArgs(SelectionChangedEvent, removed, added));
        }

        protected virtual void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.RaiseEvent(e);
        }
    }
}
