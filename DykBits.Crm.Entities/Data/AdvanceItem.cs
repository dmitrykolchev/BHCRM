using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class AdvanceItem : XmlSerializableDataItem, IDataItem
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public MoneyOperationState State { get; set; }
        [XmlAttribute]
        public string FileAs { get; set; }
        [XmlAttribute]
        public string Number { get; set; }
        [XmlAttribute]
        public DateTime DocumentDate { get; set; }
        [XmlAttribute]
        public int OrganizationId { get; set; }
        [XmlAttribute]
        public int BankAccountId { get; set; }
        [XmlAttribute]
        public int AccountId { get; set; }
        [XmlAttribute]
        public int EmployeeId { get; set; }
        [XmlAttribute]
        public decimal Value { get; set; }
        [XmlAttribute]
        public Nullable<decimal> ReportedValue { get; set; }
        [XmlIgnore]
        public decimal Delta
        {
            get
            {
                return Value - ReportedValue.GetValueOrDefault();
            }
        }
        public ItemKey GetKey()
        {
            return ItemKey.CreateKey(MoneyOperation.DataItemClassName, this.Id);
        }

        public string DataItemClass
        {
            get { return MoneyOperation.DataItemClassName; }
        }

        public int DataItemClassId
        {
            get { return Metadata.Id; }
        }
        [XmlIgnore]
        public DocumentState CurrentState
        {
            get
            {
                return Metadata.States.GetById(((IDataItem)this).State);
            }
        }
        public DocumentMetadata Metadata
        {
            get { return DocumentManager.GetMetadata(this.DataItemClass); }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        byte IDataItem.State
        {
            get
            {
                return (byte)this.State;
            }
            set
            {
                this.State = (MoneyOperationState)value;
            }
        }
        [XmlAttribute]
        public string Comments
        {
            get;
            set;
        }
        [XmlAttribute]
        public DateTime Created
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
        public DateTime Modified
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
        public bool IsNew
        {
            get { return false; }
        }
    }
}
