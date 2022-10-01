using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DykBits.Crm.Data;
using DykBits.Crm.UI;
using DevExpress.Xpf.Core;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Deployment.Application;
using System.Threading;
using System.Globalization;
using System.Dynamic;
namespace DykBits.Crm
{
    public class ApplicationManager
    {
        static ApplicationManager()
        {
            ThemeName = DykBits.Crm.Properties.Settings.Default.ApplicationTheme;
        }

        private ApplicationManager()
        {
        }

        public static string ThemeName
        {
            get { return DevExpress.Xpf.Core.ThemeManager.ApplicationThemeName; }
            set
            {
                DevExpress.Xpf.Core.ThemeManager.ApplicationThemeName = value;
                DykBits.Crm.Properties.Settings.Default.ApplicationTheme = value;
                DykBits.Crm.Properties.Settings.Default.Save();
            }
        }

        public static bool IsInitialized { get; private set; }

        public static void Initialize()
        {
            ServiceManager.Instance.AddService(typeof(IMessageBoxService), new MessageBoxService());
            ServiceManager.Instance.AddService(typeof(ITypeResolver), new TypeResolver());
            IsInitialized = true;
        }

        public static bool CleanUp()
        {
            var windows = Application.Current.Windows.OfType<EditorWindow>().ToList();
            foreach (var window in windows)
            {
                window.Close();
            }
            windows = Application.Current.Windows.OfType<EditorWindow>().ToList();
            if (windows.Count > 0)
            {
                windows[0].Activate();
                return false;
            }
            ApplicationManager.WindowData.Save();
            return true;
        }

        public static void ShowMessage(string message)
        {
            IMessageBoxService service = ServiceManager.GetService<IMessageBoxService>();
            service.ShowMessage(message);
        }

        public static bool ShowQuestion(string question)
        {
            IMessageBoxService service = ServiceManager.GetService<IMessageBoxService>();
            return service.ShowQuestion(question);
        }

        public static void ShowError(Exception ex)
        {
            LogError(ex);
            IMessageBoxService service = ServiceManager.GetService<IMessageBoxService>();
            service.ShowError(ex);
        }

        public static void LogError(Exception ex)
        {
            ErrorLogService errorLogService = ServiceManager.GetService<ErrorLogService>();
            if (errorLogService != null)
                errorLogService.LogError(ex);
        }

        public static MessageBoxResult ShowQuestion(string question, MessageBoxButton buttons)
        {
            IMessageBoxService service = ServiceManager.GetService<IMessageBoxService>();
            return service.ShowQuestion(question, buttons);
        }

        public static MessageBoxResult ShowWarning(string warning, MessageBoxButton buttons)
        {
            IMessageBoxService service = ServiceManager.GetService<IMessageBoxService>();
            return service.ShowWarning(warning, buttons);
        }

        public static Type ResolveType(string typeName)
        {
            ITypeResolver typeResolver = ServiceManager.GetService<ITypeResolver>();
            return typeResolver.ResolveType(typeName);
        }

        public static void ShowDocumentProperties(Window owner, object document)
        {
            DXDialog dialog = new DXDialog("Свойства", DialogButtons.Ok);

            dialog.DataContext = document;
            dialog.Owner = owner;
            dialog.SizeToContent = SizeToContent.WidthAndHeight;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Content = new DocumentPropertiesControl();
            dialog.ShowIcon = false;
            dialog.ShowInTaskbar = false;
            dialog.ResizeMode = ResizeMode.NoResize;
            System.Windows.Media.TextOptions.SetTextFormattingMode(dialog, System.Windows.Media.TextFormattingMode.Display);
            dialog.UseLayoutRounding = true;
            dialog.ShowDialog();
        }

        public static SqlCommand CreateCommand(Type documentType, SqlProcedureType commandRole, SqlConnection connection)
        {
            SqlProcedureManager commandManager = ServiceManager.GetService<SqlProcedureManager>();
            return commandManager.GetProcedure(documentType, commandRole, connection);
        }
        public static SqlCommand CreateCommand(string commandName, SqlConnection connection)
        {
            SqlProcedureManager commandManager = ServiceManager.GetService<SqlProcedureManager>();
            return commandManager.GetProcedure(commandName, connection);
        }


        public static ICurrentUser CurrentUser
        {
            get { return DykBits.Crm.Data.SecurityManager.CurrentUser; }
        }

        public static string CurrentEmployeeName
        {
            get
            {
                if (IsInitialized)
                {
                    return CurrentEmployee.FullName;
                }
                return "Иванов, Иван";
            }
        }

        public static IEmployeeInfo CurrentEmployee
        {
            get { return DykBits.Crm.Data.SecurityManager.GetCurrentEmployee(); }
        }

        public static bool IsCriticalException(Exception ex)
        {
            return ex is NullReferenceException || ex is StackOverflowException || ex is OutOfMemoryException || ex is ThreadAbortException || ex is IndexOutOfRangeException || ex is AccessViolationException;
        }

        public static bool IsSecurityOrCriticalException(Exception ex)
        {
            return ex is SecurityException || IsCriticalException(ex);
        }

        public static string UserAppDataPath
        {
            get
            {
                try
                {
                    if (ApplicationDeployment.IsNetworkDeployed)
                    {
                        string text = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
                        if (text != null)
                        {
                            return text;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (IsSecurityOrCriticalException(ex))
                    {
                        throw;
                    }
                }
                return GetDataPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        private static string GetDataPath(string basePath)
        {
            string directory = string.Format(CultureInfo.CurrentCulture, "{0}\\{1}\\{2}\\{3}", basePath, CompanyName, ProductName, ProductVersion);
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }
            return directory;
        }

        private static string companyName;

        public static string CompanyName
        {
            get
            {
                if (companyName == null)
                {
                    Assembly entryAssembly = Assembly.GetEntryAssembly();
                    if (entryAssembly != null)
                    {
                        object[] customAttributes = entryAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                        if (customAttributes != null && customAttributes.Length > 0)
                        {
                            companyName = ((AssemblyCompanyAttribute)customAttributes[0]).Company;
                        }
                    }
                    if (companyName == null || companyName.Length == 0)
                    {
                        companyName = GetAppFileVersionInfo().CompanyName;
                        if (companyName != null)
                        {
                            companyName = companyName.Trim();
                        }
                    }
                    if (companyName == null || companyName.Length == 0)
                    {
                        Type appMainType = GetAppMainType();
                        if (appMainType != null)
                        {
                            string @namespace = appMainType.Namespace;
                            if (!string.IsNullOrEmpty(@namespace))
                            {
                                int num = @namespace.IndexOf(".");
                                if (num != -1)
                                {
                                    companyName = @namespace.Substring(0, num);
                                }
                                else
                                {
                                    companyName = @namespace;
                                }
                            }
                            else
                            {
                                companyName = ProductName;
                            }
                        }
                    }
                }
                return companyName;
            }
        }

        private static string productName;
        public static string ProductName
        {
            get
            {
                if (productName == null)
                {
                    Assembly entryAssembly = Assembly.GetEntryAssembly();
                    if (entryAssembly != null)
                    {
                        object[] customAttributes = entryAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                        if (customAttributes != null && customAttributes.Length > 0)
                        {
                            productName = ((AssemblyProductAttribute)customAttributes[0]).Product;
                        }
                    }
                    if (string.IsNullOrEmpty(productName))
                    {
                        productName = GetAppFileVersionInfo().ProductName;
                        if (productName != null)
                        {
                            productName = productName.Trim();
                        }
                    }
                    if (string.IsNullOrEmpty(productName))
                    {
                        Type appMainType = GetAppMainType();
                        if (appMainType != null)
                        {
                            string @namespace = appMainType.Namespace;
                            if (!string.IsNullOrEmpty(@namespace))
                            {
                                int num = @namespace.LastIndexOf(".");
                                if (num != -1 && num < @namespace.Length - 1)
                                {
                                    productName = @namespace.Substring(num + 1);
                                }
                                else
                                {
                                    productName = @namespace;
                                }
                            }
                            else
                            {
                                productName = appMainType.Name;
                            }
                        }
                    }
                }
                return productName;
            }
        }

        private static Type mainType;
        private static Type GetAppMainType()
        {
            if (mainType == null)
            {
                Assembly entryAssembly = Assembly.GetEntryAssembly();
                if (entryAssembly != null)
                {
                    mainType = entryAssembly.EntryPoint.ReflectedType;
                }
            }
            return mainType;
        }

        private static FileVersionInfo appFileVersion;

        private static FileVersionInfo GetAppFileVersionInfo()
        {
            if (appFileVersion == null)
            {
                Type appMainType = GetAppMainType();
                if (appMainType != null)
                {
                    new FileIOPermission(PermissionState.None) { AllFiles = FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery }.Assert();
                    try
                    {
                        appFileVersion = FileVersionInfo.GetVersionInfo(appMainType.Module.FullyQualifiedName);
                        return appFileVersion;
                    }
                    finally
                    {
                        CodeAccessPermission.RevertAssert();
                    }
                }
                appFileVersion = FileVersionInfo.GetVersionInfo(ExecutablePath);
            }
            return appFileVersion;
        }

        private static string productVersion;

        public static string ProductVersion
        {
            get
            {
                if (productVersion == null)
                {
                    Assembly entryAssembly = Assembly.GetEntryAssembly();
                    if (entryAssembly != null)
                    {
                        object[] customAttributes = entryAssembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                        if (customAttributes != null && customAttributes.Length > 0)
                        {
                            productVersion = ((AssemblyInformationalVersionAttribute)customAttributes[0]).InformationalVersion;
                        }
                    }
                    if (string.IsNullOrEmpty(productVersion))
                    {
                        productVersion = GetAppFileVersionInfo().ProductVersion;
                        if (productVersion != null)
                        {
                            productVersion = productVersion.Trim();
                        }
                    }
                    if (string.IsNullOrEmpty(productVersion))
                    {
                        productVersion = "1.0.0.0";
                    }
                }
                return productVersion;
            }
        }

        private static string executablePath;

        public static string ExecutablePath
        {
            get
            {
                if (executablePath == null)
                {
                    Assembly entryAssembly = Assembly.GetEntryAssembly();
                    if (entryAssembly == null)
                    {
                        StringBuilder stringBuilder = new StringBuilder(260);
                        NativeMethods.GetModuleFileName(IntPtr.Zero, stringBuilder, stringBuilder.Capacity);
                        executablePath = System.IO.Path.GetFullPath(stringBuilder.ToString());
                    }
                    else
                    {
                        string codeBase = entryAssembly.CodeBase;
                        Uri uri = new Uri(codeBase);
                        if (uri.IsFile)
                        {
                            executablePath = uri.LocalPath + Uri.UnescapeDataString(uri.Fragment);
                        }
                        else
                        {
                            executablePath = uri.ToString();
                        }
                    }
                }
                return executablePath;
            }
        }

        private static WindowDataCollection _windowData;

        public static WindowDataCollection WindowData
        {
            get
            {
                if (_windowData == null)
                {
                    _windowData = WindowDataCollection.Load();
                }
                return _windowData;
            }
        }

        public static IDocumentReportInfo SelectReport(Type documentType, string selector)
        {
            return DocumentReportManager.SelectReport(documentType, selector);
        }
        public static IDocumentReportInfo SelectReport(string documentClass, string selector)
        {
            return DocumentReportManager.SelectReport(documentClass, selector);
        }
        public static IDocumentReportInfo SelectReport<T>(string selector)
        {
            return DocumentReportManager.SelectReport<T>(selector);
        }
    }
}
