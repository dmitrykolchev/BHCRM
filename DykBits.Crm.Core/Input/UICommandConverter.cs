using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;

namespace DykBits.Crm.Input
{
    public class UICommandConverter: TypeConverter
    {
        public UICommandConverter()
        {
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if(destinationType == typeof(string))
            {
                UICommand command = (context != null) ? (context.Instance as UICommand) : null;
                if (((command != null) && (command.OwnerType != null)) && IsKnownType(command.OwnerType))
                {
                    return true;
                }
            }
            return false;
        }

        private void ParseUri(string commandUri, out string typeName, out string localName )
        {
            typeName = null;
            localName = commandUri.Trim();
            int index = localName.LastIndexOf('.');
            if(index >=0)
            {
                typeName = localName.Substring(0, index);
                localName = localName.Substring(index + 1);
            }
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object source)
        {
            if ((source != null) && (source is string))
            {
                string commandText = (string)source;
                if (string.IsNullOrWhiteSpace(commandText))
                    return null;
                string localName;
                string typeName;
                this.ParseUri(commandText, out typeName, out localName);
                UICommand command = ConvertFromHelper(GetTypeFromContext(context, typeName), localName);
                if (command != null)
                {
                    return command;
                }
            }
            throw base.GetConvertFromException(source);
        }

        private Type GetTypeFromContext(ITypeDescriptorContext context, string typeName)
        {
            if ((context != null) && (typeName != null))
            {
                IXamlTypeResolver service = (IXamlTypeResolver)context.GetService(typeof(IXamlTypeResolver));
                if (service != null)
                {
                    return service.Resolve(typeName);
                }
            }
            return null;
        }

        private static UICommand GetKnownCommand(string localName, Type ownerType)
        {
            if(ownerType == typeof(DykBits.Crm.Input.CrmApplicationCommands))
            {
                switch(localName)
                {
                    case "Open":
                        return CrmApplicationCommands.Open;
                    case "Refresh":
                        return CrmApplicationCommands.Refresh;
                    case "Properties":
                        return CrmApplicationCommands.Properties;
                    case "Delete":
                        return CrmApplicationCommands.Delete;
                }
            }
            return null;
        }

        private static UICommand ConvertFromHelper(Type ownerType, string localName)
        {
            UICommand knownCommand = null;
            if (IsKnownType(ownerType) || (ownerType == null))
            {
                knownCommand = GetKnownCommand(localName, ownerType);
            }
            if ((knownCommand == null) && (ownerType != null))
            {
                PropertyInfo property = ownerType.GetProperty(localName, BindingFlags.Public | BindingFlags.Static);
                if (property != null)
                {
                    knownCommand = property.GetValue(null, null) as UICommand;
                }
                if (knownCommand == null)
                {
                    FieldInfo field = ownerType.GetField(localName, BindingFlags.Public | BindingFlags.Static);
                    if (field != null)
                    {
                        knownCommand = field.GetValue(null) as UICommand;
                    }
                }
            }
            return knownCommand;
        }

        private static bool IsKnownType(Type type)
        {
            return type == typeof(DykBits.Crm.Input.CrmApplicationCommands);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if (destinationType != typeof(string))
            {
                throw base.GetConvertToException(value, destinationType);
            }
            UICommand command = value as UICommand;
            if (command != null && command.OwnerType != null && IsKnownType(command.OwnerType))
            {
                return command.Name;
            }
            return string.Empty;
        }
    }
}
