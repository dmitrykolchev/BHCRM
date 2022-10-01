using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DykBits.Crm.UI
{
    public class UniformPanel : Panel
    {
        public UniformPanel()
        {
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            int count = InternalChildren.Count;
            if (count > 0)
            {
                Size itemSize = new Size(Math.Max(0, (finalSize.Width - (count + 1) * 2) / count), finalSize.Height);
                Rect rect = new Rect(2, 0, itemSize.Width, itemSize.Height);
                for (int index = 0; index < count; ++index)
                {
                    UIElement child = this.InternalChildren[index];
                    child.Arrange(rect);
                    rect.X += itemSize.Width + 2;
                }
            }
            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            int count = this.InternalChildren.Count;
            double height = 0;
            if (count > 0)
            {
                Size itemSize = new Size(Math.Max(0, (availableSize.Width - (count + 1) * 2) / count), availableSize.Height);
                for (int index = 0; index < count; ++index)
                {
                    UIElement child = this.InternalChildren[index];
                    child.Measure(itemSize);
                    height = Math.Max(height, child.DesiredSize.Height);
                }
            }
            return new Size(0, height);
        }
    }
}
