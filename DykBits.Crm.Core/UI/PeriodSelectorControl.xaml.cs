using System;
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
    /// Interaction logic for PeriodSelectorControl.xaml
    /// </summary>
    public partial class PeriodSelectorControl : UserControl
    {
        public static readonly DependencyProperty PeriodSelectorProperty = DependencyProperty.Register("PeriodSelector", typeof(DatePeriod), typeof(PeriodSelectorControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPeriodPropertyChanged));

        public static readonly DependencyProperty PeriodStartProperty = DependencyProperty.Register("PeriodStart", typeof(DateTime), typeof(PeriodSelectorControl),
            new FrameworkPropertyMetadata(DateTime.MinValue, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPeriodPropertyChanged));

        public static readonly DependencyProperty PeriodEndProperty = DependencyProperty.Register("PeriodEnd", typeof(DateTime), typeof(PeriodSelectorControl),
            new FrameworkPropertyMetadata(DateTime.MaxValue, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPeriodPropertyChanged));

        private static void OnPeriodPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PeriodSelectorControl)d).OnPeriodChanged(e);
        }

        public DatePeriod PeriodSelector
        {
            get { return (DatePeriod)GetValue(PeriodSelectorProperty); }
            set { SetValue(PeriodSelectorProperty, value); }
        }

        public DateTime PeriodStart
        {
            get { return (DateTime)GetValue(PeriodStartProperty); }
            set { SetValue(PeriodStartProperty, value); }
        }
        public DateTime PeriodEnd
        {
            get { return (DateTime)GetValue(PeriodEndProperty); }
            set { SetValue(PeriodEndProperty, value); }
        }

        private PeriodSelectorData _data;
        private bool _internalChange;

        public PeriodSelectorControl()
        {
            InitializeComponent();
            this._data = new PeriodSelectorData(DatePeriods.DoesNotMatter, new DatePeriod[] { DatePeriods.DoesNotMatter, DatePeriods.PreviousMonth, DatePeriods.CurrentMonth, DatePeriods.NextMonth,
            DatePeriods.PreviousQuarter, DatePeriods.CurrentQuarter, DatePeriods.NextQuarter, DatePeriods.PreviousYear, DatePeriods.CurrentYear, DatePeriods.NextYear, DatePeriods.Arbitrary });
            this._data.PropertyChanged += _data_PropertyChanged;
        }

        public PeriodSelectorData Data
        {
            get { return this._data; }
        }

        private void OnPeriodChanged(DependencyPropertyChangedEventArgs e)
        {
            if (!this._internalChange)
            {
                this._internalChange = true;
                try
                {
                    if (e.Property == PeriodStartProperty)
                        this._data.Start = this.PeriodStart;
                    else if (e.Property == PeriodEndProperty)
                        this._data.End = this.PeriodEnd;
                    else if (e.Property == PeriodSelectorProperty)
                        Data.Period = (DatePeriod)e.NewValue;
                }
                finally
                {
                    this._internalChange = false;
                }
            }
        }

        void _data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!this._internalChange)
            {
                this._internalChange = true;
                try
                {
                    if (e.PropertyName == "Start")
                        this.SetCurrentValue(PeriodStartProperty, this._data.Start);
                    else if (e.PropertyName == "End")
                        this.SetCurrentValue(PeriodEndProperty, this._data.End);
                }
                finally
                {
                    this._internalChange = false;
                }
            }
        }

        public class PeriodSelectorData : NotifyObject
        {
            private DatePeriod _period;
            private ObservableCollection<DatePeriod> _periods;
            private DateTime _start;
            private DateTime _end;
            private bool _recursive;
            public PeriodSelectorData(DatePeriod period, IEnumerable<DatePeriod> periods)
            {
                this._periods = new ObservableCollection<DatePeriod>(periods);
                Period = period;
                if (period != DatePeriods.Arbitrary)
                {
                    Start = period.Start;
                    End = period.End;
                }
                else
                {
                    Start = DateTime.Today;
                    End = DateTime.Today;
                }
            }
            public ObservableCollection<DatePeriod> Periods
            {
                get
                {
                    return this._periods;
                }
            }
            public DatePeriod Period
            {
                get { return this._period; }
                set
                {
                    this._period = value;
                    if (this._period != DatePeriods.Arbitrary)
                    {
                        if (!this._recursive)
                        {
                            this._recursive = true;
                            try
                            {
                                Start = this._period.Start;
                                End = this._period.End;
                            }
                            finally
                            {
                                this._recursive = false;
                            }
                        }
                    }
                    InvokePropertyChanged();
                }
            }
            public DateTime Start
            {
                get { return this._start; }
                set
                {
                    this._start = value;
                    InvokePropertyChanged();
                    ValidatePeriod();
                }
            }
            public DateTime End
            {
                get { return this._end; }
                set
                {
                    this._end = value;
                    InvokePropertyChanged();
                    ValidatePeriod();
                }
            }

            public bool IsArbitrary
            {
                get { return this.Period == DatePeriods.Arbitrary; }
            }

            private void ValidatePeriod()
            {
                if (!this._recursive)
                {
                    this._recursive = true;
                    try
                    {
                        foreach (var period in Periods)
                        {
                            if (period != DatePeriods.Arbitrary)
                            {
                                if (period.Start == Start && period.End == End)
                                {
                                    this.Period = period;
                                    return;
                                }
                            }
                        }
                        this.Period = DatePeriods.Arbitrary;
                    }
                    finally
                    {
                        this._recursive = false;
                    }
                }
            }
        }
    }
}
