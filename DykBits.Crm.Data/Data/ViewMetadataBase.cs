using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace DykBits.Crm.Data
{
    [DebuggerDisplay("{ClassName}")]
    public abstract class ViewMetadataBase
    {
        private Type _dataAdapterType;
        private Type _dataAdapterProxyType;
        private Type _viewItemType;
        private static int CustomId = int.MinValue;
        protected ViewMetadataBase(Type itemType, Type dataAdapterType, Type dataAdapterProxyType)
        {
            this._viewItemType = itemType;
            this._dataAdapterType = dataAdapterType;
            this._dataAdapterProxyType = dataAdapterProxyType;
            this.Id = System.Threading.Interlocked.Increment(ref CustomId);
            this.ClassName = itemType.Name;
            this.ViewName = itemType.Name;
            //this.ClrTypeName = itemType.AssemblyQualifiedName;
            //if (dataAdapterType != null)
            //    this.LocalDataAdapterTypeName = dataAdapterType.AssemblyQualifiedName;
        }
        protected ViewMetadataBase()
        {
        }
        public bool IsAllowed(GenericRight right)
        {
            IGenericRight value;
            if (SecurityManager.CurrentUser.GenericRights.TryGetValue(this.Id, out value))
                return (value.Rights & right) == right;
            return false;
        }
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string ViewName { get; set; }
        [XmlAttribute]
        public string ClassName { get; set; }
        [XmlAttribute]
        public string TableName { get; set; }
        [XmlAttribute]
        public string SchemaName { get; set; }
        [XmlAttribute]
        public string ClrTypeName { get; set; }
        [XmlAttribute("DataAdapterTypeName")]
        public string LocalDataAdapterTypeName { get; set; }
        [XmlAttribute]
        public string Caption { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
        protected virtual void EnsureTypesDefined()
        {
            Type dataAdapterType = DataAdapterProxyType;
            if(dataAdapterType == null)
                dataAdapterType = LocalDataAdapterType;
            var dataAdapter = (IViewDataAdapter)Activator.CreateInstance(dataAdapterType);
            this.ViewItemType = dataAdapter.ViewItemType;
        }
        public virtual Type ViewItemType
        {
            get
            {
                if (this._viewItemType == null)
                    EnsureTypesDefined();
                return this._viewItemType;
            }
            set
            {
                this._viewItemType = value;
            }
        }
        public Type LocalDataAdapterType
        {
            get
            {
                if (this._dataAdapterType == null)
                    this._dataAdapterType = ResolveType(LocalDataAdapterTypeName);
                return this._dataAdapterType;
            }
        }
        public Type DataAdapterProxyType
        {
            get
            {
                if (this._dataAdapterProxyType == null)
                {
                    int index = LocalDataAdapterTypeName.IndexOf(',');
                    this._dataAdapterProxyType = ResolveType(LocalDataAdapterTypeName.Substring(0, index).Trim() + "Proxy" + LocalDataAdapterTypeName.Substring(index));
                }
                return this._dataAdapterProxyType;
            }
        }
        protected Type ResolveType(string typeName)
        {
            ITypeResolver typeResolver = ServiceManager.GetService<ITypeResolver>();
            if(typeResolver != null)
                return typeResolver.ResolveType(typeName);
            return Type.GetType(typeName);
        }
    }
}
