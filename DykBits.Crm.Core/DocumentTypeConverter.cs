using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Reflection;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class DocumentTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
            if (documentManager == null)
                return null;

            if (value is int)
            {
                DocumentMetadata metadata = documentManager.Documents.GetById((int)value);
                if (metadata == null)
                    return null;
                return metadata.Caption;
            }
            else
            {
                if (value is IDynamicProxy)
                    value = ((IDynamicProxy)value).RealObject;
                IDataItem dataItem = value as IDataItem;

                DocumentMetadata metadata = documentManager.Documents[dataItem.DataItemClass];
                if (metadata == null)
                    return null;
                
                if ((string)parameter == "LargeImage")
                    return metadata.LargeImage;
                
                if ((string)parameter == "SmallImage")
                    return metadata.SmallImage;
                
                if ((string)parameter == "StateImage")
                    return metadata.SmallImage;
                
                if (typeof(ImageSource).IsAssignableFrom(targetType))
                    return metadata.LargeImage;
                
                return metadata.Caption;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
