using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DykBits.Crm.UI
{
    public static class Validator
    {
        public static readonly DependencyProperty RequiredFieldAdornerProperty = DependencyProperty.RegisterAttached("RequiredFieldAdorner", typeof(RequiredFieldAdorner), typeof(Validator),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.NotDataBindable));

        public static readonly DependencyProperty RequiredProperty = DependencyProperty.RegisterAttached("Required", typeof(bool), typeof(Validator),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, OnRequiredPropertyChanged));

        private static readonly List<Control> controls = new List<Control>();

        private static void OnRequiredPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control element = d as Control;
            if (element.IsLoaded)
            {
                SetAdorner(element);
            }
            else
            {
                element.Loaded += element_Loaded;
            }
        }

        static void element_Loaded(object sender, RoutedEventArgs e)
        {
            Control element = sender as Control;
            element.Loaded -= element_Loaded;
            SetAdorner(element);
        }

        private static void SetAdorner(Control element)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(element);
            if (adornerLayer != null)
            {
                RequiredFieldAdorner adorner = (RequiredFieldAdorner)element.GetValue(RequiredFieldAdornerProperty);
                bool value = (bool)element.GetValue(RequiredProperty);
                if (value)
                {
                    if (adorner == null)
                    {
                        adorner = new RequiredFieldAdorner(element);
                        adornerLayer.Add(adorner);
                        element.SetValue(RequiredFieldAdornerProperty, adorner);
                    }
                }
                else
                {
                    if (adorner != null)
                    {
                        adornerLayer.Remove(adorner);
                        element.SetValue(RequiredFieldAdornerProperty, null);
                    }
                }
            }
        }

        public static bool GetRequired(UIElement element)
        {
            return (bool)element.GetValue(RequiredProperty);
        }

        public static void SetRequired(UIElement element, bool value)
        {
            element.SetValue(RequiredProperty, value);
        }
    }
}
