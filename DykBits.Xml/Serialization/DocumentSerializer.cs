using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;

namespace DykBits.Xml.Serialization
{
    public class DocumentSerializer
    {
        private Type _documentType;
        private Dictionary<string, Type> _typeMapping = new Dictionary<string, Type>();
        private Dictionary<Type, string> _elementMappding = new Dictionary<Type, string>();

        public DocumentSerializer(Type documentType)
        {
            this._documentType = documentType;
            XmlTypeAttribute xmlRoot = documentType.GetCustomAttribute<XmlTypeAttribute>(true);
            if (xmlRoot != null)
                AddMapping(xmlRoot.TypeName, documentType);
            else
                AddMapping(documentType.Name, documentType);
            foreach (var attribute in this._documentType.GetCustomAttributes().OfType<TypeMappingAttribute>())
            {
                AddMapping(attribute.ElementName, attribute.Type);
            }
        }

        public DocumentSerializer(Type documentType, params Type[] knownTypes)
            : this(documentType)
        {
            foreach (Type knownType in knownTypes)
                AddMapping(knownType.Name, knownType);
        }

        public static Stream Serialize(object data, params Type[] knownTypes)
        {
            MemoryStream stream = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                if (data is ISupportsWriteXml)
                {
                    ((ISupportsWriteXml)data).WriteXml(writer);
                }
                else
                {
                    DocumentSerializer serializer = new DocumentSerializer(data.GetType(), knownTypes);
                    serializer.Serialize(writer, data);
                }
            }
            stream.Position = 0;
            return stream;
        }

        public static List<V> DeserializeCollection<V>(Stream stream) where V : new()
        {
            DocumentSerializer serializer = new DocumentSerializer(typeof(V));
            using (XmlReader reader = XmlReader.Create(stream))
            {
                List<V> list = new List<V>();
                reader.MoveToContent();
                if (!reader.IsEmptyElement)
                {
                    reader.ReadStartElement();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        V item = new V();
                        serializer.DeserializeObject(item, reader);
                        list.Add(item);
                    }
                    reader.ReadEndElement();
                }
                return list;
            }
        }
        private Type MapToType(string elementName)
        {
            return this._typeMapping[elementName];
        }
        private string MapToElementName(Type type)
        {
            return this._elementMappding[type];
        }
        public void AddMapping(Type knownType)
        {
            this._typeMapping.Add(knownType.Name, knownType);
            this._elementMappding.Add(knownType, knownType.Name);
        }
        public void AddMapping(string elementName, Type knownType)
        {
            if (!this._elementMappding.ContainsKey(knownType))
            {
                this._typeMapping.Add(elementName, knownType);
                this._elementMappding.Add(knownType, elementName);
            }
        }
        private void SerializeScalarProperty(XmlWriter writer, string propertyName, Type propertyType, object propertyValue)
        {
            TypeCode typeCode = Type.GetTypeCode(propertyType);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((bool)propertyValue));
                    break;
                case TypeCode.Byte:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((byte)propertyValue));
                    break;
                case TypeCode.Char:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((char)propertyValue));
                    break;
                case TypeCode.DateTime:
                    DateTime dateValue = (DateTime)propertyValue;
                    string dateText = XmlConvert.ToString(dateValue, XmlDateTimeSerializationMode.Unspecified);
                    writer.WriteAttributeString(propertyName, dateText);
                    break;
                case TypeCode.Decimal:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((decimal)propertyValue));
                    break;
                case TypeCode.Double:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((double)propertyValue));
                    break;
                case TypeCode.Int16:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((Int16)propertyValue));
                    break;
                case TypeCode.Int32:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((Int32)propertyValue));
                    break;
                case TypeCode.Int64:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((Int64)propertyValue));
                    break;
                case TypeCode.SByte:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((SByte)propertyValue));
                    break;
                case TypeCode.Single:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((Single)propertyValue));
                    break;
                case TypeCode.String:
                    string value = (string)propertyValue;
                    if (!string.IsNullOrWhiteSpace(value))
                        writer.WriteAttributeString(propertyName, value.Trim());
                    break;
                case TypeCode.UInt16:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((UInt16)propertyValue));
                    break;
                case TypeCode.UInt32:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((UInt32)propertyValue));
                    break;
                case TypeCode.UInt64:
                    writer.WriteAttributeString(propertyName, XmlConvert.ToString((UInt64)propertyValue));
                    break;
            }
        }
        private void DeserializeScalarProperty(object document, PropertyInfo property, Type propertyType, string value)
        {
            switch (Type.GetTypeCode(propertyType))
            {
                case TypeCode.Boolean:
                    property.SetValue(document, XmlConvert.ToBoolean(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Byte:
                    property.SetValue(document, XmlConvert.ToByte(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Char:
                    property.SetValue(document, XmlConvert.ToChar(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.DateTime:
                    DateTime dateValue = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Unspecified);
                    property.SetValue(document, dateValue, BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Decimal:
                    property.SetValue(document, XmlConvert.ToDecimal(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Double:
                    property.SetValue(document, XmlConvert.ToDouble(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Int16:
                    property.SetValue(document, XmlConvert.ToInt16(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Int32:
                    property.SetValue(document, XmlConvert.ToInt32(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Int64:
                    property.SetValue(document, XmlConvert.ToInt64(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.SByte:
                    property.SetValue(document, XmlConvert.ToSByte(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.Single:
                    property.SetValue(document, XmlConvert.ToSingle(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.String:
                    property.SetValue(document, value, BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.UInt16:
                    property.SetValue(document, XmlConvert.ToUInt16(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.UInt32:
                    property.SetValue(document, XmlConvert.ToUInt32(value), BindingFlags.Default, null, null, null);
                    break;
                case TypeCode.UInt64:
                    property.SetValue(document, XmlConvert.ToUInt64(value), BindingFlags.Default, null, null, null);
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
        public void Serialize(TextWriter writer, object document)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(writer))
            {
                Serialize(xmlWriter, document);
            }
        }
        public void Serialize(XmlWriter writer, object document)
        {
            Type documentType = document.GetType();
            string elementName = MapToElementName(documentType);
            writer.WriteStartElement(elementName);
            SerializeDocumentContent(writer, document);
            writer.WriteEndElement();
        }
        private bool CanDeserialize(PropertyInfo property)
        {
            bool? result = DocumentPropertyCache.Instance.IsDeserializable(property);
            if (result == null)
            {
                bool value = CanDeserializeInternal(property);
                DocumentPropertyCache.Instance.AddToDeserializable(property, value);
                return value;
            }
            return result.Value;
        }
        private bool CanDeserializeInternal(PropertyInfo property)
        {
            XmlIgnoreAttribute ignoreAttribure = property.GetCustomAttribute<XmlIgnoreAttribute>();
            if (ignoreAttribure != null)
                return false;

            Type propertyType = property.PropertyType;
            if (propertyType == typeof(byte[]) && property.CanWrite)
                return true;

            if (typeof(IList).IsAssignableFrom(propertyType))
                return !property.CanWrite;

            return property.CanWrite;
        }
        private bool CanSerialize(PropertyInfo property)
        {
            bool? result = DocumentPropertyCache.Instance.IsSerializable(property);
            if (result == null)
            {
                bool value = CanSerializeInternal(property);
                DocumentPropertyCache.Instance.AddToSerializable(property, value);
                return value;
            }
            return result.Value;
        }
        private bool CanSerializeInternal(PropertyInfo property)
        {
            XmlIgnoreAttribute ignoreAttribure = property.GetCustomAttribute<XmlIgnoreAttribute>();
            if (ignoreAttribure != null)
                return false;

            Type propertyType = property.PropertyType;
            if (propertyType == typeof(byte[]) && property.CanRead && property.CanWrite)
                return true;

            if (typeof(IList).IsAssignableFrom(propertyType))
                return !property.CanWrite;

            if (property.CanRead && property.CanWrite)
                return true;

            return false;
        }
        private object DeserializeElement(Type documentType, XmlReader reader)
        {
            object document = Activator.CreateInstance(documentType);
            DeserializeObjectInternal(document, reader);
            return document;
        }
        private void DeserializeObjectInternal(object document, XmlReader reader)
        {
            Type documentType = document.GetType();
            string elementName = MapToElementName(documentType);
            reader.MoveToContent();
            if (reader.NodeType != XmlNodeType.Element || reader.LocalName != elementName)
                throw new InvalidOperationException("Unknown node");

            while (reader.MoveToNextAttribute())
            {
                string attributeName = reader.LocalName;
                PropertyInfo property = documentType.GetProperty(attributeName);
                if (property == null)
                    throw new InvalidOperationException("unknown property '" + attributeName + "'");
                if (CanDeserialize(property))
                {
                    Type propertyType = property.PropertyType;
                    if (IsScalarType(propertyType))
                    {
                        DeserializeScalarProperty(document, property, propertyType, reader.Value);
                    }
                    else if (propertyType.IsArray && propertyType == typeof(byte[]))
                    {
                        property.SetValue(document, Convert.FromBase64String(reader.Value), BindingFlags.Default, null, null, null);
                    }
                    else if (propertyType.IsEnum)
                    {
                        Type underlyingType = Enum.GetUnderlyingType(propertyType);
                        DeserializeScalarProperty(document, property, underlyingType, reader.Value);
                    }
                    else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        Type underlyingType = Nullable.GetUnderlyingType(propertyType);
                        if (IsScalarType(underlyingType))
                        {
                            DeserializeScalarProperty(document, property, underlyingType, reader.Value);
                        }
                        else
                            throw new InvalidOperationException();
                    }
                    else if (propertyType == typeof(Guid))
                    {
                        property.SetValue(document, XmlConvert.ToGuid(reader.Value), BindingFlags.Default, null, null, null);
                    }
                    else if (propertyType == typeof(TimeSpan))
                    {
                        property.SetValue(document, XmlConvert.ToTimeSpan(reader.Value), BindingFlags.Default, null, null, null);
                    }
                    else
                        throw new InvalidOperationException();
                }
            }
            reader.MoveToElement();
            if (reader.IsEmptyElement)
            {
                reader.Skip();
                return;
            }
            reader.ReadStartElement();
            reader.MoveToContent();
            while (reader.NodeType != XmlNodeType.EndElement && reader.NodeType != XmlNodeType.None)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    PropertyInfo property = documentType.GetProperty(reader.LocalName);
                    if (CanDeserialize(property))
                    {
                        Type propertyType = property.PropertyType;
                        if (typeof(IList).IsAssignableFrom(propertyType))
                        {
                            IList propertyValue = (IList)property.GetValue(document, BindingFlags.Default, null, null, null);
                            reader.ReadStartElement();
                            reader.MoveToContent();
                            EnumerateList(propertyValue, reader);
                            reader.ReadEndElement();
                        }
                        else
                            throw new InvalidOperationException();
                    }
                }
            }
            reader.ReadEndElement();
        }
        private void EnumerateList(IList listProperty, XmlReader reader)
        {
            while (reader.NodeType != XmlNodeType.EndElement && reader.NodeType != XmlNodeType.None)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Type nodeType = MapToType(reader.LocalName);
                    listProperty.Add(DeserializeElement(nodeType, reader));
                }
            }
        }
        public object Deserialize(Type documentType, XmlReader reader)
        {
            return DeserializeElement(documentType, reader);
        }
        public T Deserialize<T>(XmlReader reader)
        {
            return (T)Deserialize(typeof(T), reader);
        }
        public T Deserialize<T>(Stream stream)
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                return (T)Deserialize(typeof(T), reader);
            }
        }
        public void DeserializeObject(object document, XmlReader reader)
        {
            DeserializeObjectInternal(document, reader);
        }
        private void SerializeDocumentContent(XmlWriter writer, object document)
        {
            Type documentType = document.GetType();
            PropertyInfo[] properties = documentType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Dictionary<PropertyInfo, object> listProperties = new Dictionary<PropertyInfo, object>();

            foreach (PropertyInfo property in properties)
            {
                if (CanSerialize(property))
                {
                    Type propertyType = property.PropertyType;
                    object propertyValue = property.GetValue(document, BindingFlags.Default, null, null, null);
                    if (propertyValue != null)
                    {
                        if (IsScalarType(propertyType))
                        {
                            SerializeScalarProperty(writer, property.Name, propertyType, propertyValue);
                        }
                        else if (propertyType.IsArray && propertyType == typeof(byte[]))
                        {
                            writer.WriteAttributeString(property.Name, Convert.ToBase64String((byte[])propertyValue));
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
                                object underlyingValue = propertyType.GetProperty("Value").GetValue(propertyValue, BindingFlags.Default, null, null, null);
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

            if (listProperties.Count > 0)
            {
                foreach (KeyValuePair<PropertyInfo, object> item in listProperties)
                {
                    IList list = (IList)item.Value;
                    if (list.Count > 0)
                    {
                        PropertyInfo listProperty = item.Key;
                        writer.WriteStartElement(listProperty.Name);
                        for (int index = 0; index < list.Count; ++index)
                        {
                            Serialize(writer, list[index]);
                        }
                        writer.WriteEndElement();
                    }
                }
            }
        }
    }
}
