using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DykBits.Crm.UI
{
    sealed class StandardResources
    {
        private static readonly ResourceDictionary _resourceDictionary;
        public static readonly UserConverter ConvertUserId = new UserConverter();
        public static readonly DocumentIdConverter ConvertDocumentId = new DocumentIdConverter();

        static StandardResources()
        {
            _resourceDictionary = new ResourceDictionary();
            _resourceDictionary.Source = new Uri("/DykBits.Crm.Core;component/UI/Resources/CommonControls.xaml", UriKind.Relative);
        }
        public static ResourceDictionary R
        {
            get { return _resourceDictionary; }
        }

        public static T Get<T>(object key)
        {
            return (T)R[key];
        }
    }
}
