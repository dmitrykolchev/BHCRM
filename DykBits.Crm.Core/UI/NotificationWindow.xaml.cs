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
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Interop;
using System.Dynamic;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    /// <summary>
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : Window
    {
        private Storyboard _formHide;
        private Storyboard _formShow;
        private Storyboard _setOpaque;
        private Storyboard _setTransparent;

        private DispatcherTimer _timer;
        private static readonly TimeSpan AnimationTime = TimeSpan.FromMilliseconds(300);
        private static readonly Duration AnimationDuration = new Duration(AnimationTime);

        public NotificationWindow()
        {
            InitializeComponent();
            this.Style = (Style)this.Resources["windowStyle"];
            this._formShow = new Storyboard() { Duration = AnimationDuration };
            this._formShow.Children.Add(CreateAnimation(0, 0.75, Window.OpacityProperty));
            this._formShow.Children.Add(CreateAnimation(0, this.MaxWidth, Window.WidthProperty));
            this._formShow.Children.Add(CreateAnimation(SystemParameters.PrimaryScreenWidth - 10, SystemParameters.PrimaryScreenWidth - this.MaxWidth - 10, Window.LeftProperty));

            this._setOpaque = new Storyboard() { Duration = AnimationDuration };
            this._setOpaque.Children.Add(CreateAnimation(0.75, 1, Window.OpacityProperty));


            this._formHide = new Storyboard() { Duration = AnimationDuration };
            this._formHide.Children.Add(CreateAnimation(0.75, 0, Window.OpacityProperty));
            this._formHide.Children.Add(CreateAnimation(this.MaxWidth, 0, Window.WidthProperty));
            this._formHide.Children.Add(CreateAnimation(SystemParameters.PrimaryScreenWidth - this.MaxWidth - 10, SystemParameters.PrimaryScreenWidth - 10, Window.LeftProperty));

            this._setTransparent = new Storyboard() { Duration = AnimationDuration };
            this._setTransparent.Children.Add(CreateAnimation(1, 0.75, Window.OpacityProperty));

            this._formHide.Completed += _formHide_Completed;
            this.Loaded += NotificationWindow_Loaded;
            this.MouseEnter += NotificationWindow_MouseEnter;
            this.MouseLeave += NotificationWindow_MouseLeave;
        }
        void NotificationWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            this.BeginStoryboard(this._setTransparent);
            StartTimer();
        }
        void NotificationWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            StopTimer();
            this.BeginStoryboard(this._setOpaque);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HideWindowCallback(this, EventArgs.Empty);
        }
        private void HideWindowCallback(object sender, EventArgs e)
        {
            StopTimer();
            this.BeginStoryboard(this._formHide);
        }
        private void StartTimer()
        {
            this._timer = new DispatcherTimer(TimeSpan.FromSeconds(5), DispatcherPriority.ApplicationIdle, HideWindowCallback, this.Dispatcher);
        }
        private void StopTimer()
        {
            if (this._timer != null)
            {
                this._timer.Stop();
                this._timer = null;
            }
        }
        void _formHide_Completed(object sender, EventArgs e)
        {
            this.Close();
        }
        void NotificationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            HwndSource hwndSource = HwndSource.FromHwnd(helper.Handle);
            hwndSource.AddHook(WndProc);

            this.BeginStoryboard(this._formShow);
            StartTimer();
        }
        private DoubleAnimationUsingKeyFrames CreateAnimation(double from, double to, DependencyProperty property)
        {
            DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(from, KeyTime.FromPercent(0)));
            animation.KeyFrames.Add(new EasingDoubleKeyFrame(to, KeyTime.FromTimeSpan(AnimationTime)));
            Storyboard.SetTargetProperty(animation, new PropertyPath(property));
            Storyboard.SetTarget(animation, this);
            return animation;
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_MOUSEACTIVATE = 0x0021;
            const int MA_NOACTIVATE = 3;

            if (msg == WM_MOUSEACTIVATE)
            {
                handled = true;
                return new IntPtr(MA_NOACTIVATE);
            }
            return IntPtr.Zero;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            dynamic data = this.DataContext;
            WindowManager.OpenDocument(((IDataItem)data.TargetDocument).GetKey());
            e.Handled = true;
            HideWindowCallback(this, EventArgs.Empty);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }   
    }
}
