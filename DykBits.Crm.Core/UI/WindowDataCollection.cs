using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace DykBits.Crm.UI
{
    public class WindowDataCollection
    {
        private Dictionary<string, WindowData> _stateFromName = new Dictionary<string, WindowData>();

        private WindowDataCollection()
        {
        }
        private WindowDataCollection(IEnumerable<WindowData> windowData)
        {
            foreach (var item in windowData)
                _stateFromName.Add(item.WindowClass, item);
        }
        public WindowData this[string windowClass]
        {
            get
            {
                if (windowClass == null)
                    throw new ArgumentNullException("windowClass");
                WindowData value;
                if (!_stateFromName.TryGetValue(windowClass, out value))
                {
                    value = WindowData.GetDefault(windowClass);
                    _stateFromName.Add(windowClass, value);
                }
                return value;
            }
        }

        public WindowData CreateInstance(string windowClass)
        {
            return this[windowClass].Clone();
        }

        public void UpdateInstance(WindowData source)
        {
            this[source.WindowClass].Update(source);
        }

        public static WindowDataCollection Load()
        {
            try
            {
                string path = Path.Combine(ApplicationManager.UserAppDataPath, "windowdata.xml");
                if (File.Exists(path))
                {
                    using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        return Load(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationManager.LogError(ex);
            }
            return new WindowDataCollection();
        }

        public void Save()
        {
            string path = Path.Combine(ApplicationManager.UserAppDataPath, "windowdata.xml");
            using (FileStream stream = File.Create(path))
            {
                Save(stream);
            }
        }

        public static WindowDataCollection Load(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WindowData[]));
            WindowData[] windowData = (WindowData[])serializer.Deserialize(stream);
            return new WindowDataCollection(windowData);
        }

        public void Save(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WindowData[]));
            serializer.Serialize(stream, this._stateFromName.Values.ToArray());
        }
    }
}
