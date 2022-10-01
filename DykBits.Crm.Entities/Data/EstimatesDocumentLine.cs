using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class EstimatesDocumentLine : NotifyObject
    {
        private Nullable<int> _productId;
        private string _fileAs;
        private string _comments;
        private Nullable<int> _unitOfMeasureId;
        private decimal _amount;
        private decimal _price;
        private decimal _cashCost;
        private decimal _nonCashCost;

        [XmlIgnore]
        public bool ReadOnly
        {
            get;
            internal set;
        }
        [XmlIgnore]
        public EstimatesDocument Parent
        {
            get;
            internal set;
        }
        [XmlAttribute]
        public int EstimatesDocumentLineId { get; set; }
        [XmlAttribute]
        public int EstimatesDocumentSectionId { get; set; }
        [XmlAttribute]
        public int EstimatesDocumentId { get; set; }
        [XmlAttribute]
        public int OrdinalPosition { get; set; }
        [XmlAttribute]
        public Nullable<int> ProductId
        {
            get { return this._productId; }
            set
            {
                this._productId = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public virtual string FileAs
        {
            get { return this._fileAs; }
            set
            {
                this._fileAs = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public string Comments
        {
            get { return this._comments; }
            set
            {
                this._comments = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public Nullable<int> UnitOfMeasureId
        {
            get { return this._unitOfMeasureId; }
            set
            {
                this._unitOfMeasureId = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public decimal Amount
        {
            get { return this._amount; }
            set
            {
                this._amount = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public decimal Price
        {
            get { return this._price; }
            set
            {
                this._price = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public decimal CashCost
        {
            get { return this._cashCost; }
            set
            {
                this._cashCost = value;
                InvokePropertyChanged();
            }
        }
        [XmlAttribute]
        public decimal NonCashCost
        {
            get { return this._nonCashCost; }
            set
            {
                this._nonCashCost = value;
                InvokePropertyChanged();
            }
        }
        internal class Commission : EstimatesDocumentLine
        {
            public Commission()
            {
                this.ReadOnly = true;
            }
            public override string FileAs
            {
                get
                {
                    return "Агентское вознаграждение " + Parent.Commission.ToString("P");
                }
                set
                {
                }
            }
        }
        internal class VAT : EstimatesDocumentLine
        {
            public VAT()
            {
                this.ReadOnly = true;
            }
            public override string FileAs
            {
                get { return this.Parent.VATRate.FileAs; }
                set
                {
                }
            }
        }
    }
}
