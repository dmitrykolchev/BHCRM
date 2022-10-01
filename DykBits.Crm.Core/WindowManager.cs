using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;
using DykBits.Crm.Data;
using DykBits.Crm.UI;

namespace DykBits.Crm
{
    [ContentProperty("Windows")]
    public class WindowManager
    {
        private PresentationManagerCollection _windows;
        public const string MainWindowNode = "MainWindow";
        public const string SelectorsNode = "Selectors";
        public WindowManager()
        {
            this._windows = new PresentationManagerCollection();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PresentationManagerCollection Windows
        {
            get { return this._windows; }
        }

        public static Window CreateDocument(DocumentMetadata metadata, object dataContext, string windowKey = null, bool show = true)
        {
            using (new WaitCursor())
            {
                if (metadata == null)
                    throw new ArgumentNullException("metadata");

                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                IDataItem item = documentManager.CreateDocument(metadata, dataContext);
                EditorWindow window = EditorWindow.CreateWindow(item, windowKey);
                if (show)
                    window.Show();
                return window;
            }
        }

        public static Window OpenDocument(ItemKey key, string windowKey = null, bool show = true)
        {
            using (new WaitCursor())
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                EditorWindow window = FindWindowByKey(key);
                try
                {
                    if (window == null)
                    {
                        DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                        IDataAdapter dataAdapter = documentManager.CreateDataAdapterProxy(key.DocumentType);
                        if (dataAdapter.ValidateAccess(key))
                        {
                            IDataItem document = dataAdapter.GetItem(key);
                            window = EditorWindow.CreateWindow(document, windowKey);
                            if (show)
                                window.Show();
                        }
                        else
                        {
                            throw new ApplicationException("У вас нет прав для доступа к выбранному документу. Пожалуйста обратитесь к Администратору");
                        }
                    }
                    else
                    {
                        window.ActivateWindow();
                    }
                }
                catch
                {
                    if(window != null)
                        window.Close();
                    throw;
                }
                return window;
            }
        }

        public static Window OpenDocument(IDataItem document, string windowKey = null, bool show = true)
        {
            using (new WaitCursor())
            {
                if (document == null)
                    throw new ArgumentNullException("key");
                EditorWindow window = null;
                if (document.State != 0)
                {
                    ItemKey key = document.GetKey();
                    window = FindWindowByKey(key);
                }
                try
                {
                    if (window == null)
                    {
                        window = EditorWindow.CreateWindow(document, windowKey);
                        if (show)
                            window.Show();
                    }
                    else
                    {
                        window.ActivateWindow();
                    }
                }
                catch
                {
                    if(window != null)
                        window.Close();
                    throw;
                }
                return window;
            }
        }

        public static EditorWindow FindWindowByKey(ItemKey key)
        {
            if(key == null)
                throw new ArgumentNullException("key");
            foreach (EditorWindow window in Application.Current.Windows.OfType<EditorWindow>())
            {
                if (window.DataSource != null && window.DataSource.State != 0)
                {
                    ItemKey windowKey = window.DataSource.GetKey();
                    if (key.Equals(windowKey))
                        return window;
                }
            }
            return null;
        }

        public static bool IsEditorExists(IDataItem dataItem)
        {
            if (dataItem != null)
            {
                WindowManager windowManager = ServiceManager.GetService<WindowManager>();
                return windowManager.Windows.ContainsKey(dataItem.DataItemClass);
            }
            return false;
        }

        public static bool IsEditorExists(DocumentMetadata metadata)
        {
            if (metadata != null)
            {
                WindowManager windowManager = ServiceManager.GetService<WindowManager>();
                return windowManager.Windows.ContainsKey(metadata.ClassName);
            }
            return false;
        }
    }
}
