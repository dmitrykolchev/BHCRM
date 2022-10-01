using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using DykBits.Xml;
using DykBits.Xml.Serialization;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public class EmptyFilter : Filter
    {
        public EmptyFilter()
        {
            AllStates = true;
        }
    }

    [Serializable]
    public abstract class Filter : ISupportsWriteXml
    {
        public static readonly Filter Empty = new EmptyFilter();
        public static readonly XElement EmptyXml = Empty.ToXml();

        protected Filter()
        {
        }
        public bool AllStates
        {
            get;
            set;
        }
        public byte[] States
        {
            get;
            set;
        }
        public Nullable<int> Id
        {
            get;
            set;
        }
        public string ContextDocumentClass { get; set; }
        public string Presentation { get; set; }
        public System.Xml.Linq.XElement ToXml()
        {
            XDocument doc = new XDocument();

            using (XmlWriter writer = doc.CreateWriter())
            {
                ((ISupportsWriteXml)this).WriteXml(writer);
            }
            return doc.Root;
        }
        public virtual void InitializeViewParameters(object dataContext, object parameter)
        {
            if (parameter is string)
                this.Presentation = (string)parameter;
            if (dataContext is IDataItem)
                this.ContextDocumentClass = ((IDataItem)dataContext).DataItemClass;
        }
        public virtual void InitializeDefaults(object dataContext, object parameter)
        {
            InitializeViewParameters(dataContext, parameter);
        }
        protected void WriteContent(XmlWriter writer)
        {
            SerializeDocumentContent(writer, this);
        }
        protected virtual string DocumentElement
        {
            get { return "Filter"; }
        }
        void ISupportsWriteXml.WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(DocumentElement);
            writer.WriteAttributeString("TypeName", this.GetType().Name);
            if (States != null)
            {
                foreach (var item in States)
                {
                    writer.WriteElementString("State", XmlConvert.ToString(item));
                }
            }
            WriteContent(writer);
            writer.WriteEndElement();
        }
        private void SerializeScalarProperty(XmlWriter writer, string propertyName, Type propertyType, object propertyValue)
        {
            TypeCode typeCode = Type.GetTypeCode(propertyType);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((bool)propertyValue));
                    break;
                case TypeCode.Byte:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((byte)propertyValue));
                    break;
                case TypeCode.Char:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((char)propertyValue));
                    break;
                case TypeCode.DateTime:
                    DateTime dateValue = (DateTime)propertyValue;
                    string dateText = XmlConvert.ToString(dateValue, XmlDateTimeSerializationMode.Unspecified);
                    writer.WriteElementString(propertyName, dateText);
                    break;
                case TypeCode.Decimal:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((decimal)propertyValue));
                    break;
                case TypeCode.Double:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((double)propertyValue));
                    break;
                case TypeCode.Int16:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((Int16)propertyValue));
                    break;
                case TypeCode.Int32:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((Int32)propertyValue));
                    break;
                case TypeCode.Int64:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((Int64)propertyValue));
                    break;
                case TypeCode.SByte:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((SByte)propertyValue));
                    break;
                case TypeCode.Single:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((Single)propertyValue));
                    break;
                case TypeCode.String:
                    string value = (string)propertyValue;
                    if (!string.IsNullOrEmpty(value))
                        writer.WriteElementString(propertyName, value);
                    break;
                case TypeCode.UInt16:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((UInt16)propertyValue));
                    break;
                case TypeCode.UInt32:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((UInt32)propertyValue));
                    break;
                case TypeCode.UInt64:
                    writer.WriteElementString(propertyName, XmlConvert.ToString((UInt64)propertyValue));
                    break;
            }
        }
        private static bool IsScalarType(Type type)
        {
            TypeCode typeCode = Type.GetTypeCode(type);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.String:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
            }
            return false;
        }
        private bool CanSerialize(PropertyInfo property)
        {
            XmlIgnoreAttribute ignoreAttribure = property.GetCustomAttribute<XmlIgnoreAttribute>();
            if (ignoreAttribure != null)
                return false;

            if (property.CanRead && property.CanWrite)
                return true;

            Type propertyType = property.PropertyType;
            if (typeof(IList).IsAssignableFrom(propertyType))
                return !property.CanWrite;

            return false;
        }
        private void SerializeDocumentContent(XmlWriter writer, object document)
        {
            Type documentType = document.GetType();
            PropertyInfo[] properties = documentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(t => t.Name != "States").ToArray();

            Dictionary<PropertyInfo, object> listProperties = new Dictionary<PropertyInfo, object>();

            foreach (PropertyInfo property in properties)
            {
                if (CanSerialize(property))
                {
                    Type propertyType = property.PropertyType;
                    object propertyValue = property.GetValue(document);
                    if (propertyValue != null)
                    {
                        if (IsScalarType(propertyType))
                        {
                            SerializeScalarProperty(writer, property.Name, propertyType, propertyValue);
                        }
                        else if (propertyType.IsArray)
                        {
                            string elementName;
                            var arrayItem = property.GetCustomAttribute<XmlArrayItemAttribute>();
                            if (arrayItem != null)
                                elementName = arrayItem.ElementName;
                            else
                                elementName = property.Name;

                            Type elementType = propertyType.GetElementType();
                            if (elementType.IsEnum)
                            {
                                foreach (var item in (IEnumerable)propertyValue)
                                {
                                    var memberName = Enum.GetName(elementType, item);
                                    var members = elementType.GetMember(memberName);
                                    var enumAttr = members[0].GetCustomAttribute<XmlEnumAttribute>();
                                    if (enumAttr != null)
                                        writer.WriteElementString(elementName, enumAttr.Name);
                                    else
                                        writer.WriteElementString(elementName, item.ToString());
                                }
                            }
                            else if(typeof(IConvertible).IsAssignableFrom(elementType))
                            {
                                foreach (IConvertible item in (IEnumerable)propertyValue)
                                {
                                    writer.WriteElementString(elementName, item.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                }
                            }
                            else
                                throw new InvalidOperationException();
                        }
                        else if (propertyType.IsEnum)
                        {
                            Type underlyingType = Enum.GetUnderlyingType(propertyType);
                            SerializeScalarProperty(writer, property.Name, underlyingType, propertyValue);
                        }
                        else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            Type underlyingType = Nullable.GetUnderlyingType(propertyType);
                            if (IsScalarType(underlyingType))
                            {
                                object underlyingValue = propertyType.GetProperty("Value").GetValue(propertyValue);
                                SerializeScalarProperty(writer, property.Name, underlyingType, underlyingValue);
                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }
                        }
                        else if (propertyType == typeof(Guid))
                        {
                            writer.WriteAttributeString(property.Name, XmlConvert.ToString((Guid)propertyValue));
                        }
                        else if (propertyType == typeof(TimeSpan))
                        {
                            writer.WriteAttributeString(property.Name, XmlConvert.ToString((TimeSpan)propertyValue));
                        }
                        else if (typeof(IList).IsAssignableFrom(propertyType) && !property.CanWrite)
                        {
                            listProperties.Add(property, propertyValue);
                        }
                        else
                            throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
