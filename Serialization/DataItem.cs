using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public class DataItem
    {
        private int _IdField;
        private string _FileAsField;
        private string _CommentsField;
        private System.DateTime _CreatedField;
        private int _CreatedByField;
        private System.DateTime _ModifiedField;
        private int _ModifiedByField;
        private byte[] _RowVersionField;
        private ObservableCollection<AttachmentItem> _attachments;

        protected DataItem()
        {
        }

        [XmlAttribute]
        public int Id
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
        [XmlAttribute]
        public System.DateTime Created
        {
            get
            {
                return this._CreatedField;
            }
            set
            {
                this._CreatedField = value;
                InvokePropertyChanged("Created");
            }
        }
        [XmlAttribute]
        public int CreatedBy
        {
            get
            {
                return this._CreatedByField;
            }
            set
            {
                this._CreatedByField = value;
                InvokePropertyChanged("CreatedBy");
            }
        }
        [XmlAttribute]
        public System.DateTime Modified
        {
            get
            {
                return this._ModifiedField;
            }
            set
            {
                this._ModifiedField = value;
                InvokePropertyChanged("Modified");
            }
        }
        [XmlAttribute]
        public int ModifiedBy
        {
            get
            {
                return this._ModifiedByField;
            }
            set
            {
                this._ModifiedByField = value;
                InvokePropertyChanged("ModifiedBy");
            }
        }
        [XmlAttribute]
        public byte[] RowVersion
        {
            get
            {
                return this._RowVersionField;
            }
            set
            {
                this._RowVersionField = value;
                InvokePropertyChanged("RowVersion");
            }
        }
        protected void InvokePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlElement("Attachments")]
        public ObservableCollection<AttachmentItem> Attachments
        {
            get
            {
                if (this._attachments == null)
                {
                    this._attachments = new ObservableCollection<AttachmentItem>();
                    this._attachments.CollectionChanged += OnAattachmentsCollectionChanged;
                }
                return this._attachments;
            }
        }

        void OnAattachmentsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("Attachments");
        }
    }
}
