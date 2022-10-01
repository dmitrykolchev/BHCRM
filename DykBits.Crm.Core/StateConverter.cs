using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DykBits.Crm.Data;

namespace DykBits.Crm
{
    public class StateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            if (value is IDataItem)
            {
                IDataItem dataItem = (IDataItem)value;
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                DocumentMetadata metadata;
                DocumentState state;
                if (!string.IsNullOrEmpty(DocumentTypeIdProperty) && !string.IsNullOrEmpty(StateProperty))
                {
                    Type type = dataItem.GetType();
                    int dataItemClass = (int)type.GetProperty(DocumentTypeIdProperty).GetValue(dataItem);
                    metadata = documentManager.Documents.GetById(dataItemClass);
                    byte stateValue = (byte)type.GetProperty(StateProperty).GetValue(dataItem);
                    state = metadata.States.GetById(stateValue);
                }
                else
                {
                    metadata = documentManager.Documents.GetById(dataItem.DataItemClassId);
                    state = metadata.States.GetById(dataItem.State);
                }
                if ("Description".Equals(parameter))
                {
                    if (state.State == 0)
                        return "Новый документ. Необходимо сохранить в базе данных.";
                    return string.IsNullOrEmpty(state.Description) ? state.Caption : state.Description;
                }
                return state.Caption;
            }
            else
            {
                string className = (string)parameter;
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                DocumentMetadata metadata = documentManager.Documents[className];
                DocumentState state = metadata.States.GetById((byte)value);
                return state.Caption;
            }
        }

        public string DocumentTypeIdProperty { get; set; }
        public string StateProperty { get; set; }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
