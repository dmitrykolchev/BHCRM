using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DykBits.Crm.UI
{
    public enum ElementCategory
    {
        General,
        ContainsCost,
        ContainsPrice
    }
    public class UICategory: FrameworkElement
    {
        public static readonly DependencyProperty CategoryProperty = DependencyProperty.RegisterAttached("Category", typeof(ElementCategory), typeof(UICategory),
            new PropertyMetadata(ElementCategory.General, OnCategoryPropertyChanged));

        private static void OnCategoryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetVisibilityDependsOnAccessRights(d, (ElementCategory)e.NewValue);
        }

        public static void SetCategory(DependencyObject d, ElementCategory category)
        {
            d.SetValue(CategoryProperty, category);
        }

        public static ElementCategory GetCategory(DependencyObject d)
        {
            return (ElementCategory)d.GetValue(CategoryProperty);
        }

        public UICategory()
        {
        }

        private static void SetVisibilityDependsOnAccessRights(DependencyObject o, ElementCategory category)
        {
        }
    }
}
