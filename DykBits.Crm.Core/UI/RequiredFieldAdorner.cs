using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DykBits.Crm.UI
{
    public class RequiredFieldAdorner: Adorner
    {
        private Brush _brush;

        public RequiredFieldAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
        }

        private Brush Fill
        {
            get
            {
                if (this._brush == null)
                {
                    ResourceDictionary resourceDictionary = new ResourceDictionary();
                    resourceDictionary.Source = new Uri("/DykBits.Crm.Core;component/Themes/Generic.xaml", UriKind.Relative);
                    this._brush = (Brush)resourceDictionary["requiredFieldBrush"];
                }
                return this._brush;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Control control = this.AdornedElement as Control;
            if (control != null)
            {
                Rect rect = new Rect(2, control.ActualHeight - 6, control.ActualWidth - 4, 4);
                drawingContext.DrawRectangle(this.Fill, null, rect);
            }
        }
    }
}
