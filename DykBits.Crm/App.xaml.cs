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
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using DevExpress.Xpf.Editors;
using DykBits.Crm.Data;
using DykBits.Crm.UI;

namespace DykBits.Crm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Version Version
        {
            get
            {
                return new Version("1.0.0.0");
            }
        }

        public static string ProductName
        {
            get
            {
                return "CRM";
            }
        }

        public static System.Globalization.CultureInfo CurrentUICulture
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
        }

        public App()
        {
            this.Startup += App_Startup;
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

                RemoteConnectionStringBuilder connectionStringBuilder = new RemoteConnectionStringBuilder(DykBits.Crm.Properties.Settings.Default.RemoteConnectionString);
                connectionStringBuilder.ApplicationName = string.Format("{0} ({1};{2})", App.ProductName, App.Version, App.CurrentUICulture.IetfLanguageTag);
                connectionStringBuilder.WorkstationID = Environment.MachineName;

                RemoteConnectionStringBuilder blobConnectionStringBuilder = new RemoteConnectionStringBuilder(connectionStringBuilder.ConnectionString);
                blobConnectionStringBuilder.DataSource = DykBits.Crm.Properties.Settings.Default.BlobServiceBaseAddress;

                InitializeApplicationDefaults();
                InitializeTextBoxBehaviour();

                ApplicationManager.Initialize();

                App.Current.MainWindow = new Window();

                bool loginSuccess = false;
                if (Keyboard.GetKeyStates(Key.LeftShift) == KeyStates.None)
                {
                    try
                    {
                        LogonWindow.VerifyConnection(connectionStringBuilder.ConnectionString, DykBits.Crm.Properties.Settings.Default.EndpointIdentity);
                        LogonWindow.VerifyBlobConnection(blobConnectionStringBuilder.ConnectionString, DykBits.Crm.Properties.Settings.Default.EndpointIdentity);
                        loginSuccess = true;
                    }
                    catch
                    {
                    }
                }
                if (!loginSuccess)
                {
                    LogonWindow window = new LogonWindow();
                    window.DataContext = new SigninData(connectionStringBuilder, blobConnectionStringBuilder, DykBits.Crm.Properties.Settings.Default.EndpointIdentity);
                    loginSuccess = window.ShowDialog() == true;
                }
                if (loginSuccess)
                {

                    SplashScreen splashScreen = new SplashScreen("images/CRM2.png");
                    splashScreen.Show(true);
                    BlobServiceConnectionManager blobServiceConnectionManager = new BlobServiceConnectionManager(blobConnectionStringBuilder.ConnectionString, DykBits.Crm.Properties.Settings.Default.EndpointIdentity);
                    ServiceManager.Instance.AddService(typeof(BlobServiceConnectionManager), blobServiceConnectionManager);

                    IExceptionTranslatorService exceptionTranslatorService = new ExceptionTranslatorService();
                    ServiceManager.Instance.AddService(typeof(IExceptionTranslatorService), exceptionTranslatorService);

                    RemoteConnectionManager connectionManager = new RemoteConnectionManager(connectionStringBuilder.ConnectionString, DykBits.Crm.Properties.Settings.Default.EndpointIdentity);
                    ServiceManager.Instance.AddService(typeof(IConnectionManager), connectionManager);

                    ServiceManager.Instance.AddService(typeof(ErrorLogService), new ErrorLogService());
                    if (!connectionManager.IsRemote)
                    {
                        ServiceManager.Instance.AddService(typeof(DykBits.Crm.Data.SqlProcedureManager), new DykBits.Crm.Data.SqlProcedureManager());
                        ServiceManager.Instance.AddService(typeof(IDatabaseContext), new LocalDatabaseContext());
                    }
                    else
                    {
                        ServiceManager.Instance.AddService(typeof(IDatabaseContext), new RemoteDatabaseContext());
                    }
                    ServiceManager.Instance.AddService(typeof(SecurityManager), new SecurityManager());
                    ServiceManager.Instance.AddService(typeof(DocumentManager), DocumentManager.Create());

                    ServiceManager.Instance.AddSingleton<DocumentReportManager>(typeof(CrmReportManager));

                    ServiceManager.Instance.AddService(typeof(ListManager), new ListManager());

                    ICurrentUser currentUser = SecurityManager.CurrentUser;

                    IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();

                    ViewDataManager.RegisterProxy<MoneyOperationReportByOperationTypeDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<ConsolidatedBudgetLineDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<ConsolidatedOperatingBudgetLineDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<ConsolidatedAccrualLineDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<ConsolidatedMoneyOperationLineDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<PresentationNodeTypeDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<PresentationNodeApplicationRoleDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<AdvanceItemDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<ConsolidatedInventoryOperationLineDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<ProfitLossItemDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<CashFlowItemDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<BalanceItemDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<BalanceSheetLineDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<BudgetItemGroupTypeDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<InvoiceByContragentItemDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<InvoicePaymentByContragentItemDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<InvoiceByBudgetItemItemDataAdapterProxy>();
                    ViewDataManager.RegisterProxy<CreditMoneyOperationDataAdapterProxy>();

                    WindowManager windowManager = WindowManagerBuilder.CreateInstance();

                    ServiceManager.Instance.AddService(typeof(WindowManager), windowManager);
                    MainWindow mainWindow = new MainWindow();
                    App.Current.MainWindow = mainWindow;
                    mainWindow.Show();
                }
                else
                {
                    App.Current.MainWindow.Close();
                    App.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.ShowError(ex);
                if (App.Current.MainWindow != null)
                    App.Current.MainWindow.Close();
            }
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ApplicationManager.ShowError(e.Exception);
            e.Handled = true;
        }

        private void InitializeApplicationDefaults()
        {
            DevExpress.Xpf.Grid.GridViewBase.UseAnimationWhenExpandingProperty.OverrideMetadata(typeof(DevExpress.Xpf.Grid.TableView), new FrameworkPropertyMetadata(false));
        }

        private void InitializeTextBoxBehaviour()
        {
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.PreviewMouseLeftButtonDownEvent,
                new MouseButtonEventHandler(SelectivelyIgnoreMouseButton));
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotKeyboardFocusEvent,
                new RoutedEventHandler(SelectAllText));
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.MouseDoubleClickEvent,
                new RoutedEventHandler(SelectAllText));
        }

        void TextEditSelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs e)
        {
            // Find the TextBox
            DependencyObject parent = e.OriginalSource as UIElement;
            while (parent != null && !(parent is TextEdit))
                parent = VisualTreeHelper.GetParent(parent);

            if (parent != null)
            {
                var textBox = (TextEdit)parent;
                if (!textBox.IsKeyboardFocusWithin)
                {
                    // If the text box is not yet focused, give it the focus and
                    // stop further processing of this click event.
                    textBox.Focus();
                    e.Handled = true;
                }
            }
        }

        void SelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs e)
        {
            // Find the TextBox
            DependencyObject parent = e.OriginalSource as UIElement;
            while (parent != null && !(parent is TextBox))
                parent = VisualTreeHelper.GetParent(parent);

            if (parent != null)
            {
                var textBox = (TextBox)parent;
                if (!textBox.IsKeyboardFocusWithin)
                {
                    // If the text box is not yet focused, give it the focus and
                    // stop further processing of this click event.
                    textBox.Focus();
                    e.Handled = true;
                }
            }
        }
        void TextEditSelectAllText(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextEdit;
            if (textBox != null)
                textBox.SelectAll();
        }

        void SelectAllText(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)
                textBox.SelectAll();
        }

        [STAThread]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
