using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DykBits.Crm
{
    public class ColorToImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                int colorValue = (int)value;
                byte b = (byte)(colorValue & 0xFF);
                byte g = (byte)((colorValue >> 8) & 0xFF);
                byte r = (byte)((colorValue >> 16) & 0xFF);
                Color color = Color.FromRgb(r, g, b);
                DrawingVisual visual = new DrawingVisual();
                DrawingContext context = visual.RenderOpen();
                context.DrawRectangle(new SolidColorBrush(color), new Pen(Brushes.Gray, 1), new Rect(0, 0, 16, 16));
                context.Close();
                RenderTargetBitmap bitmap = new RenderTargetBitmap(16, 16, 96, 96, PixelFormats.Default);
                bitmap.Render(visual);
                return bitmap;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
