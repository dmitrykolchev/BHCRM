using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.UI
{
    [XmlType]
    public class WindowData
    {
        public WindowData()
        {
        }
        public WindowData Clone()
        {
            return new WindowData
            {
                Left = Left,
                Top = Top,
                Width = Width,
                Height = Height,
                State = State,
                WindowClass = WindowClass,
                IsRibbonMinimized = IsRibbonMinimized
            };
        }
        public void Update(WindowData source)
        {
            Left = source.Left;
            Top = source.Top;
            Width = source.Width;
            Height = source.Height;
            IsRibbonMinimized = source.IsRibbonMinimized;
            State = System.Windows.WindowState.Normal;
        }
        [XmlAttribute]
        public string WindowClass { get; set; }
        [XmlAttribute]
        public double Width { get; set; }
        [XmlAttribute]
        public double Height { get; set; }
        [XmlAttribute]
        public double Left { get; set; }
        [XmlAttribute]
        public double Top { get; set; }
        [XmlAttribute]
        public System.Windows.WindowState State { get; set; }
        [XmlAttribute]
        public bool IsRibbonMinimized { get; set; }

        public static WindowData GetDefault(string windowClass)
        {
            return new WindowData
            {
                Width = 800,
                Height = 600,
                Left = 100,
                Top = 100,
                State = System.Windows.WindowState.Normal,
                WindowClass = windowClass,
                IsRibbonMinimized = false
            };
        }
    }
}
