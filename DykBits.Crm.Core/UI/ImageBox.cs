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
    ///     <MyNamespace:ImageBox/>
    ///
    /// </summary>
    public class ImageBox : Control
    {
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ImageBox),
            new FrameworkPropertyMetadata(Stretch.UniformToFill, FrameworkPropertyMetadataOptions.None));

        public static readonly DependencyProperty ImageDataProperty = DependencyProperty.Register("ImageData", typeof(byte[]), typeof(ImageBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnImageDataPropertyChanged));

        private static void OnImageDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ImageBox)d).OnImageDataChanged(e);
        }

        static ImageBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageBox), new FrameworkPropertyMetadata(typeof(ImageBox)));
        }

        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public byte[] ImageData
        {
            get { return (byte[])GetValue(ImageDataProperty); }
            set { SetValue(ImageDataProperty, value); }
        }

        protected virtual void OnImageDataChanged(DependencyPropertyChangedEventArgs e)
        {
            this._imageSource = null;
            if (this._image != null)
                this._image.Source = ImageSource;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._image = (Image)GetTemplateChild("ImagePart");
            this._image.Source = ImageSource;
        }

        private BitmapImage _imageSource;
        private Image _image;

        private BitmapImage ImageSource
        {
            get
            {
                if (this._imageSource == null)
                {
                    byte[] buffer = ImageData;
                    if (buffer != null && buffer.Length != 0)
                    {
                        this._imageSource = new BitmapImage();
                        MemoryStream stream = new MemoryStream(buffer);
                        this._imageSource.BeginInit();
                        this._imageSource.StreamSource = stream;
                        this._imageSource.EndInit();
                    }
                }
                return this._imageSource;
            }
        }
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Изображения (*.jpg, *.png, *.bmp, *.tif)|*.jpg;*.png;*.bmp;*.jpeg;*.tif;*.tiff|Все файлы (*.*)|*.*";
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
