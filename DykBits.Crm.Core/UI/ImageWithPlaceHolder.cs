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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

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
    ///     <MyNamespace:ImageWithPlaceHolder/>
    ///
    /// </summary>
    public class ImageWithPlaceHolder : Control
    {
        public static readonly DependencyProperty ImageDataProperty = DependencyProperty.Register("ImageData", typeof(byte[]), typeof(ImageWithPlaceHolder),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnImageDataPropertyChanged));

        private static void OnImageDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageWithPlaceHolder i = (ImageWithPlaceHolder)d;
            i.OnImageDataChanged(e);
        }

        static ImageWithPlaceHolder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageWithPlaceHolder), new FrameworkPropertyMetadata(typeof(ImageWithPlaceHolder)));
        }

        private Image _image;

        public ImageWithPlaceHolder()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._image = (Image)GetTemplateChild("image_PART");
            SetImageSource();
        }

        public byte[] ImageData
        {
            get { return (byte[])GetValue(ImageDataProperty); }
            set { SetValue(ImageDataProperty, value); }
        }

        protected virtual void OnImageDataChanged(DependencyPropertyChangedEventArgs e)
        {
            SetImageSource();
        }

        private void SetImageSource()
        {
            if (this._image != null)
            {
                byte[] buffer = ImageData;
                if (buffer != null)
                {
                    BitmapImage imageSource = new BitmapImage();
                    MemoryStream stream = new MemoryStream(buffer);
                    imageSource.BeginInit();
                    imageSource.StreamSource = stream;
                    imageSource.EndInit();
                    this._image.Source = imageSource;
                }
                else
                {
                    this._image.Source = null;
                }
            }
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Все изображения (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                using (FileStream stream = File.OpenRead(dialog.FileName))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        this.SetCurrentValue(ImageDataProperty, memoryStream.ToArray());
                    }
                }
            }
        }
    }
}
