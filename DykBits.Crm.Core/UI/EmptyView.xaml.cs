using System;
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
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for EmptyView.xaml
    /// </summary>
    public sealed partial class EmptyView : UserControl, IDataView
    {
        public EmptyView()
        {
            InitializeComponent();
        }

        void ICommandTarget.CanExecute(CanExecuteRoutedEventArgs e)
        {
        }

        void ICommandTarget.Executed(ExecutedRoutedEventArgs e)
        {
        }

        private static readonly IDataItem[] none = new IDataItem[0];

        public IDataItem SelectedItem
        {
            get { return null; }
        }
        public PresentationNode Node { get; set; }
        public DataViewType ViewType
        {
            get { return DataViewType.ItemView; }
        }
        PresentationNode IDataView.Node
        {
            get
            {
                return this.Node;
            }
            set
            {
                this.Node = value;
            }
        }
        IDataItem IDataView.SelectedDataItem
        {
            get { return this.SelectedItem; }
        }
        DataViewType IDataView.ViewType
        {
            get { return this.ViewType; }
        }
        bool IDataView.CanDeactivate()
        {
            return true;
        }
        void IDataView.OnActivate()
        {
        }
        void IDataView.OnDeactivate()
        {
        }
        void IDataView.OnWindowClosed()
        {
        }
        public event EventHandler<StatusInfoChangedEventArgs> StatusInfoChanged
        {
            add { }
            remove { }
        }
    }
}
