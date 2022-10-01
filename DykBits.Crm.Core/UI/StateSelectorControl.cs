using System;
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
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DykBits.Crm.UI"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DykBits.Crm.UI;assembly=DykBits.Crm.UI"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:StateSelectorControl/>
    ///
    /// </summary>
    public class StateSelectorControl : Control
    {
        public static readonly DependencyProperty DocumentTypeProperty = DependencyProperty.Register("DocumentType", typeof(Type), typeof(StateSelectorControl),
            new PropertyMetadata(null, OnDocumentTypePropertyChanged));
        private static void OnDocumentTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateSelectorControl control = (StateSelectorControl)d;
            control.BindToData();
        }

        public static readonly DependencyProperty SelectedStatesProperty = DependencyProperty.Register("SelectedStates", typeof(IList<byte>), typeof(StateSelectorControl),
            new FrameworkPropertyMetadata(new byte[0], FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedStatesPropertyChanged, CoerceSelectedStatesProperty));

        private static object CoerceSelectedStatesProperty(DependencyObject o, object value)
        {
            if (value == null)
                value = new byte[0];
            return value;
        }

        private static void OnSelectedStatesPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            StateSelectorControl control = (StateSelectorControl)o;
            control.BindToData();
        }


        static StateSelectorControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StateSelectorControl), new FrameworkPropertyMetadata(typeof(StateSelectorControl)));
        }

        private ListBox _listBox;
        private ObservableCollection<StateItem> _items = new ObservableCollection<StateItem>();
        public Type DocumentType
        {
            get { return (Type)GetValue(DocumentTypeProperty); }
            set { SetValue(DocumentTypeProperty, value); }
        }
        public IList<byte> SelectedStates
        {
            get
            {
                IList<byte> states = (IList<byte>)GetValue(SelectedStatesProperty);
                return states.ToArray();
            }
            set { SetValue(SelectedStatesProperty, value); }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._listBox = (ListBox)GetTemplateChild("ListBox_PART");
            BindToData();
        }
        private void BindToData()
        {
            if (this._listBox != null && ApplicationManager.IsInitialized)
            {
                if (DocumentType != null)
                {
                    DocumentMetadata metadata = DocumentManager.GetMetadata(DocumentType);
                    InitializeData(metadata);
                }
                else
                {
                    this._listBox.ItemsSource = null;
                }
            }
        }
        private void InitializeData(DocumentMetadata metadata)
        {
            this._items.Clear();
            IList<byte> states = SelectedStates;
            metadata.States.Where(t => t.State != 0).OrderBy(t => t.OrdinalPosition).Select(t =>
            {
                var r = new StateItem(t, states.Contains(t.State));
                r.PropertyChanged += state_PropertyChanged;
                return r;
            }).ToList().ForEach(t=>this._items.Add(t));
            this._listBox.ItemsSource = this._items;
        }
        void state_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SetCurrentValue(SelectedStatesProperty, this._items.Where(t => t.IsSelected).Select(t => t.State.State).ToArray());
        }
        public class StateItem : INotifyPropertyChanged
        {
            private DocumentState _state;
            private bool _isSelected;

            public StateItem(DocumentState documentState, bool isSelected)
            {
                this._isSelected = isSelected;
                this._state = documentState;
            }
            public bool IsSelected
            {
                get { return this._isSelected; }
                set
                {
                    if (value != this._isSelected)
                    {
                        this._isSelected = value;
                        OnPropertyChanged(new PropertyChangedEventArgs("IsSelected"));
                    }
                }
            }
            public DocumentState State
            {
                get { return this._state; }
            }
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, e);
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
