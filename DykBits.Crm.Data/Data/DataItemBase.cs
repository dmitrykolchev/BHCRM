using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [DebuggerDisplay("{DataItemClass}[{Id}]")]
    public abstract class DataItemBase : XmlSerializableDataItem
    {
        public const string CreatedProperty = "Created";
        public const string CreatedByProperty = "CreatedBy";
        public const string ModifiedProperty = "Modified";
        public const string ModifiedByProperty = "ModifiedBy";
        public const string RowVersionProperty = "RowVersion";

        private DocumentMetadata _metadata;
        protected DataItemBase()
        {
        }
        [XmlIgnore]
        public virtual bool IsReadOnly
        {
            get { return GetDocumentState().IsReadOnly; }
        }
        [XmlIgnore]
        public virtual bool CanDelete
        {
            get
            {
                if (Metadata.SupportsTransitionTemplates)
                {
                    return GetDocumentState().CanDelete;
                }
                else
                {
                    if (this.CreatedBy == SecurityManager.CurrentUser.Id)
                    {
                        if (Metadata.IsAllowed(GenericRight.DeleteOwn))
                            return true;
                    }
                    return Metadata.IsAllowed(GenericRight.DeleteAll);
                }
            }
        }
        public virtual bool CanChangeStateTo(byte newState)
        {
            return GetDocumentState().CanChangeStateTo(newState);
        }
        [XmlIgnore]
        public abstract string DataItemClass { get; }
        [XmlIgnore]
        public DocumentMetadata Metadata
        {
            get
            {
                if (this._metadata == null)
                {
                    DocumentManager documentManager = ServiceManager.GetService<DocumentManager>();
                    this._metadata = documentManager.Documents[DataItemClass];
                }
                return this._metadata;
            }
        }
        [XmlIgnore]
        public DocumentState CurrentState
        {
            get
            {
                return Metadata.States.GetById(((IDataItem)this).State);
            }
        }
        public abstract DocumentState GetDocumentState();
        [XmlIgnore]
        public int DataItemClassId
        {
            get
            {
                return this.Metadata.Id;
            }
        }
        public ItemKey GetKey()
        {
            if (((IDataItem)this).State != 0)
                return ItemKey.CreateKey(DataItemClass, Id);
            throw new InvalidOperationException();
        }
        [XmlAttribute]
        public virtual int Id { get; set; }
        [XmlAttribute]
        public System.DateTime Created
        {
            get;
            set;
        }
        [XmlAttribute]
        public int CreatedBy
        {
            get;
            set;
        }
        [XmlAttribute]
        public System.DateTime Modified
        {
            get;
            set;
        }
        [XmlAttribute]
        public int ModifiedBy
        {
            get;
            set;
        }
        [XmlAttribute]
        public byte[] RowVersion
        {
            get;
            set;
        }
    }
}
