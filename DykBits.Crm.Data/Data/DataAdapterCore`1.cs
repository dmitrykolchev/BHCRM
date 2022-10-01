using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace DykBits.Crm.Data
{
    public abstract class DataAdapterCore<V, T, F> : ViewDataAdapterCore<V, F>, IDataAdapter<V, T, F>, IDataAdapter
        where T : DataItem, new()
        where V : new()
        where F : Filter, new()
    {
        protected DataAdapterCore()
        {
        }
        public Type DocumentType
        {
            get { return typeof(T); }
        }
        public T CreateItem(object dataContext)
        {
            return CreateItemOverride(dataContext);
        }
        protected virtual T CreateItemOverride(object dataContext)
        {
            return new T();
        }
        public virtual void Delete(ItemKey key)
        {
            VerifyAccess(GenericRight.DeleteOwn);
            DeleteOverride(key);
        }
        protected virtual void DeleteOverride(ItemKey key)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.Delete, connection))
                {
                    command.Parameters["@Id"].Value = key.Id;
                    command.ExecuteNonQuery();
                }
            }
        }
        protected virtual void OnValidate(T item)
        {
        }
        public T GetItem(ItemKey key)
        {
            VerifyAccess(GenericRight.Get);
            return GetItemOverride(key);
        }
        protected abstract T GetItemOverride(ItemKey key);
        protected abstract T InsertItem(T item);
        protected abstract T UpdateItem(T item);
        private T SaveInternal(T item)
        {
            VerifyAccess(GenericRight.EditOwn);
            OnValidate(item);
            T result;
            if (item.IsNew)
            {
                result = InsertItem(item);
            }
            else
            {
                foreach (AttachmentItem deletedAttachment in item.DeletedAttachments)
                {
                    deletedAttachment.Delete();
                }
                result = UpdateItem(item);
            }
            result.Attachments.Clear();
            foreach (AttachmentItem attachment in item.Attachments)
            {
                if (attachment.IsNew)
                    attachment.Create(result);
                result.Attachments.Add(attachment);
            }
            return result;
        }
        public T Save(T item)
        {
            return SaveInternal(item);
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
        void IDataAdapter.ChangeState(ItemKey key, byte newState, XElement applicationData)
        {
            using (SqlConnection connection = DataHelper.CreateLocalConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(typeof(T), SqlProcedureType.ChangeState, connection))
                {
                    command.Parameters["@Id"].Value = key.Id;
                    command.Parameters["@NewState"].Value = newState;
                    if (command.Parameters.Contains("@Data"))
                    {
                        if (applicationData != null)
                            command.Parameters["@Data"].Value = applicationData.ToString(SaveOptions.DisableFormatting);
                        else
                            command.Parameters["@Data"].Value = DBNull.Value;
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        public T FromXml(XmlReader reader)
        {
            T item = new T();
            ((IXmlSerializable)item).ReadXml(reader);
            return item;
        }
        IDataItem IDataAdapter.FromXml(XmlReader reader)
        {
            return FromXml(reader);
        }
        public virtual bool ValidateAccess(ItemKey key)
        {
            return true;
        }
    }
}
