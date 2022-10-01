using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Diagnostics;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(AttachmentItem))]
    [DebuggerDisplay("{FileAs}[{Id}]")]
    public abstract class DataItem : DataItemBase, IDataItem, INotifyPropertyChanged, IDataErrorInfo, INotifyObject
    {
        public const string IdProperty = "Id";
        public const string StateProperty = "State";
        public const string FileAsProperty = "FileAs";
        public const string CommentsProperty = "Comments";

        private int _IdField;
        private byte _StateField;
        private string _FileAsField;
        private string _CommentsField;
        private ObservableCollection<AttachmentItem> _attachments;
        private ObservableCollection<AttachmentItem> _deletedAttachments;
        protected DataItem()
        {
        }
        public override DocumentState GetDocumentState()
        {
            return this.Metadata.States.GetById(((IDataItem)this).State);
        }
        [XmlIgnore]
        public bool IsNew { get { return this._StateField == DocumentState.NotExist; } }
        public override int Id
        {
            get
            {
                return this._IdField;
            }
            set
            {
                this._IdField = value;
                InvokePropertyChanged("Id");
            }
        }
        [XmlIgnore]
        byte IDataItem.State
        {
            get
            {
                return (byte)this._StateField;
            }
            set
            {
                this._StateField = value;
                InvokePropertyChanged("State");
            }
        }
        [Column(Name = "FileAs", IsNullable = false, MaximumLength = 256)]
        [XmlAttribute]
        public string FileAs
        {
            get
            {
                return this._FileAsField;
            }
            set
            {
                this._FileAsField = value;
                InvokePropertyChanged("FileAs");
            }
        }
        [Column(Name = "Comments", IsNullable = true)]
        [XmlAttribute]
        public string Comments
        {
            get
            {
                return this._CommentsField;
            }
            set
            {
                this._CommentsField = value;
                InvokePropertyChanged("Comments");
            }
        }
        void INotifyObject.InvokePropertyChanged(string propertyName)
        {
            InvokePropertyChanged(propertyName);
        }
        protected void InvokePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AttachmentItem> Attachments
        {
            get
            {
                if (this._attachments == null)
                {
                    this._attachments = new ObservableCollection<AttachmentItem>();
                    this._attachments.CollectionChanged += OnAttachmentsCollectionChanged;
                }
                return this._attachments;
            }
        }
        public ObservableCollection<AttachmentItem> DeletedAttachments
        {
            get
            {
                if (this._deletedAttachments == null)
                {
                    this._deletedAttachments = new ObservableCollection<AttachmentItem>();
                }
                return this._deletedAttachments;
            }
        }
        void OnAttachmentsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Attachments");
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (AttachmentItem attachment in e.OldItems)
                {
                    if (!attachment.IsNew)
                    {
                        DeletedAttachments.Add(attachment);
                    }
                }
            }
        }
        public void InvokeDeseriaized()
        {
            this.OnDeserialized();
        }
        protected virtual void OnDeserialized()
        {
        }
        private string ValidateProperty(string propertyName)
        {
            PropertyInfo propertyInfo = this.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo != null)
            {
                ColumnAttribute columnAttribute = propertyInfo.GetCustomAttribute<ColumnAttribute>();
                return ValidateProperty(propertyInfo, columnAttribute);
            }
            return null;
        }
        protected virtual string ValidateProperty(PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            if (columnAttribute != null)
            {
                object value = propertyInfo.GetValue(this);
                if (!columnAttribute.IsNullable && value == null)
                {
                    return "Необходимо ввести значение";
                }
                if (propertyInfo.PropertyType == typeof(string))
                {
                    string strValue = (string)value;
                    if (string.IsNullOrWhiteSpace(strValue))
                    {
                        if (!columnAttribute.IsNullable)
                            return "Необходимо ввести значение";
                    }
                    else
                    {
                        strValue = strValue.Trim();
                        if (columnAttribute.MaximumLength > 0 && strValue.Length > columnAttribute.MaximumLength)
                            return "Длина текста превышает " + columnAttribute.MaximumLength + " символов";
                    }
                }
            }
            return null;
        }
        [XmlIgnore]
        string IDataErrorInfo.Error
        {
            get
            {
                var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    ColumnAttribute columnAttrbute = property.GetCustomAttribute<ColumnAttribute>();
                    if (columnAttrbute != null)
                    {
                        string error = ValidateProperty(property, columnAttrbute);
                        if (error != null)
                            return error;
                    }
                }
                return null;
            }
        }
        [XmlIgnore]
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                return ValidateProperty(columnName);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", FileAs, Id);
        }

    }
}
