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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Crm.UI;
using System.Dynamic;
using System.Windows;
using System.Windows.Threading;

namespace DykBits.Crm.Data
{
    public class NotificationManager: DependencyObject
    {
        private ObservableCollection<UserNotificationView> _notifications = new ObservableCollection<UserNotificationView>();
        private int _lastId;
        private NotificationWindow _window;
        private DispatcherTimer _timer;

        public NotificationManager()
        {
            Initialize();
        }
        private void Initialize()
        {
            UserNotificationDataAdapterProxy dataAdapter = new UserNotificationDataAdapterProxy();
            UserNotificationFilter filter = (UserNotificationFilter)dataAdapter.CreateFilter(null, null);
            GetUpdates(dataAdapter, filter);
            this._timer = new DispatcherTimer(DispatcherPriority.SystemIdle, this.Dispatcher);
            this._timer.Tick += _timer_Tick;
            this._timer.Interval = TimeSpan.FromSeconds(60);
            this._timer.Start();
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        public void Close()
        {
            this._timer.Stop();
        }
        public ObservableCollection<UserNotificationView> Notifications
        {
            get
            {
                return this._notifications;
            }
        }
        public void ClearAll()
        {
            var notifications = this._notifications.ToArray();
            UserNotificationDataAdapterProxy dataAdapter = new UserNotificationDataAdapterProxy();
            foreach (var notification in notifications)
            {
                dataAdapter.Delete(notification.GetKey());
            }
            this._notifications.Clear();
            Refresh();
        }
        public void Delete(UserNotificationView item)
        {
            UserNotificationDataAdapterProxy dataAdapter = new UserNotificationDataAdapterProxy();
            dataAdapter.Delete(item.GetKey());
            this._notifications.Remove(item);
        }
        public void OpenDocument(UserNotificationView item)
        {
            WindowManager.OpenDocument(item.TargetDocument.GetKey());
        }
        private void GetUpdates(UserNotificationDataAdapterProxy dataAdapter, UserNotificationFilter filter)
        {
            IList<UserNotificationView> notifications = dataAdapter.Browse(filter.ToXml());
            foreach (var item in notifications)
            {
                this._notifications.Add(item);
                this._lastId = Math.Max(item.Id, this._lastId);
            }
            if (notifications.Count > 0)
            {
                if (this._window == null)
                {
                    this._window = new NotificationWindow();
                    dynamic data = new ExpandoObject();
                    if (notifications.Count == 1)
                    {
                        data.Caption = "Получено уведомление";
                        data.Description = notifications[0].Caption;
                        data.Item = notifications[0];
                        // TODO: изменить логику
                        try
                        {
                            data.TargetDocument = notifications[0].TargetDocument;
                        }
                        catch { }
                    }
                    else
                    {
                        data.Caption = "Получены уведомления";
                        if (notifications.Count < 5 || (notifications.Count > 20 && notifications.Count % 10 < 5))
                            data.Description = string.Format("Получено {0} уведомления", notifications.Count);
                        else
                            data.Description = string.Format("Получено {0} уведомлений", notifications.Count);
                    }
                    this._window.DataContext = data;
                    this._window.Closed += _window_Closed;
                    this._window.Show();
                }
            }
        }
        void _window_Closed(object sender, EventArgs e)
        {
            this._window = null;
        }
        public void Refresh()
        {
            UserNotificationDataAdapterProxy dataAdapter = new UserNotificationDataAdapterProxy();
            UserNotificationFilter filter = (UserNotificationFilter)dataAdapter.CreateFilter(null, null);
            filter.LastId = this._lastId;
            GetUpdates(dataAdapter, filter);
        }
    }
}
