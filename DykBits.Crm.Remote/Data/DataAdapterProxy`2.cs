using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace DykBits.Crm.Data
{
    public class DataAdapterProxy<V, T, F> : ViewDataAdapterProxy<V, F>, IDataAdapter<V, T, F>, IDataAdapter
        where T : DataItem, new()
        where V : DataItemView, new()
        where F : Filter, new()
    {
        static readonly T documentInstance = new T();
        private IDataAdapter<V, T, F> _realAdapter;
        public DataAdapterProxy()
        {
        }
        public virtual DocumentMetadata Metadata
        {
            get
            {
                return documentInstance.Metadata;
            }
        }
        private IDataAdapter<V, T, F> RealAdapter
        {
            get
            {
                if (this._realAdapter == null)
                    this._realAdapter = CreateRealDataAdapter();
                return this._realAdapter;
            }
        }
        private IDataAdapter<V, T, F> CreateRealDataAdapter()
        {
            IConnectionManager connectionManager = ServiceManager.GetService<IConnectionManager>();
            if (connectionManager.IsRemote)
            {
                return new RemoteDataAdapter<V, T, F>();
            }
            else
            {
                DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                DocumentMetadata metadata = documentManager.Documents[typeof(T)];
                return (IDataAdapter<V, T, F>)DocumentManager.CreateDataAdapter(metadata);
            }
        }
        protected override IList<V> BrowseOverride(XElement filter)
        {
            return RealAdapter.Browse(filter);
        }
        protected override IList<V> GetListOverride(XElement filter)
        {
            return RealAdapter.GetList(filter);
        }
        public T CreateItem(object dataContext)
        {
            return CreateItemOverride(dataContext);
        }
        protected virtual T CreateItemOverride(object dataContext)
        {
            T item = new T();
            NumberedDataItem numberedDataItem = item as NumberedDataItem;
            if (numberedDataItem != null)
            {
                numberedDataItem.DocumentDate = DateTime.Today;
                IEmployeeInfo employee = SecurityManager.GetCurrentEmployee();
                if (employee != null)
                    numberedDataItem.OrganizationId = employee.OrganizationId;
            }
            return item;
        }
        public T GetItem(ItemKey key)
        {
            VerifyAccess(GenericRight.Get);
            return RealAdapter.GetItem(key);
        }
        protected virtual void OnValidate(T item)
        {
        }
        private static void ValidateCore(T item)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                ValidateProperty(property, item);
            }
        }
        private static void ValidateProperty(PropertyInfo property, T item)
        {
            ColumnAttribute attribute = property.GetCustomAttribute<ColumnAttribute>();
            if (attribute == null)
                return;
            bool isNullable = attribute.IsNullable;
            object value = property.GetValue(item);
            if (!isNullable && value == null)
                throw new InvalidOperationException(string.Format("Поле '{0}' должно иметь значение", property.Name));
            if (property.PropertyType == typeof(string))
            {
                int maximumLength = attribute.MaximumLength;
                int realLength = SafeStringLength((string)value);
                if (maximumLength >= 0 && realLength > maximumLength)
                    throw new InvalidOperationException(string.Format("Длинна строки в поле '{0}' превышает максимально допустимую ({1})", property.Name, maximumLength));
            }
        }
        private static int SafeStringLength(string value)
        {
            if (value == null)
                return 0;
            return value.Length;
        }
        public T Save(T item)
        {
            bool own = (item.IsNew || item.CreatedBy == SecurityManager.CurrentUser.Id);
            VerifyAccess(own ? GenericRight.EditOwn : GenericRight.EditAll);
            NumberedDataItem numberedDataItem = item as NumberedDataItem;
            if (numberedDataItem != null)
                ValidateDocumentNumber(numberedDataItem);
            OnValidate(item);
            ValidateCore(item);
            return RealAdapter.Save(item);
        }
        protected virtual void ValidateDocumentNumber(NumberedDataItem item)
        {
            if (string.IsNullOrEmpty(item.Number))
            {
                IDatabaseContext dbContext = ServiceManager.GetService<IDatabaseContext>();
                DocumentNumberInfo numberInfo = dbContext.GetDocumentNumberInfo(item.DataItemClass, item.OrganizationId, item.DocumentDate);
                item.Number = numberInfo.FormattedNumber;
                item.FileAs = numberInfo.FileAs;
            }
        }
        IDataItem IDataAdapter.CreateItem(object dataContext)
        {
            return CreateItem(dataContext);
        }
        IDataItem IDataAdapter.GetItem(ItemKey key)
        {
            return GetItem(key);
        }
        IDataItem IDataAdapter.Save(IDataItem item)
        {
            return Save((T)item);
        }
        public void Delete(ItemKey key)
        {
            VerifyAccess(GenericRight.DeleteOwn);
            ((IDataAdapter)RealAdapter).Delete(key);
        }
        public void ChangeState(ItemKey key, byte newState, XElement applicationData)
        {
            ((IDataAdapter)RealAdapter).ChangeState(key, newState, applicationData);
        }
        public T FromXml(System.Xml.XmlReader reader)
        {
            return RealAdapter.FromXml(reader);
        }
        IDataItem IDataAdapter.FromXml(System.Xml.XmlReader reader)
        {
            return FromXml(reader);
        }
        public Type DocumentType
        {
            get { return typeof(T); }
        }
        public virtual bool ValidateAccess(ItemKey key)
        {
            return true;
        }
        public virtual ReportDataSourceConverter[] CreateReportDatasource(IDataItem document)
        {
            return new ReportDataSourceConverter[0];
        }
    }
}
