using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class OperatingCalculationLineCollection : DetailDataItemCollection<OperatingCalculation, OperatingCalculationLine>
    {
        internal OperatingCalculationLineCollection(OperatingCalculation owner)
            : base(owner)
        {
        }
        public bool MoveUp(OperatingCalculationLine item)
        {
            int index = this.IndexOf(item);
            if (index > 0)
            {
                this.Move(index, index - 1);
                return true;
            }
            return false;
        }
        public bool MoveDown(OperatingCalculationLine item)
        {
            int index = this.IndexOf(item);
            if (index < this.Count - 1)
            {
                this.Move(index, index + 1);
                return true;
            }
            return false;
        }
    }
    public class OperatingCalculationLine: DetailDataItem<OperatingCalculation>
    {
        private string _fileAs;
        private string _comments;
        private decimal _amount;
        private decimal _price;
        [XmlAttribute]
        public int OrdinalPosition { get; set; }
        [XmlAttribute]
        public Nullable<int> AccountId { get; set; }
        [XmlAttribute]
        public string FileAs
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
        public decimal Amount
        {
            get { return this._amount; }
            set
            {
                this._amount = value;
                InvokePropertyChanged();
                InvokePropertyChanged("TotalPrice");
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
                InvokePropertyChanged("TotalPrice");
            }
        }
        public decimal TotalPrice
        {
            get { return this.Amount * this.Price; }
        }
        public bool CanMoveUp
        {
            get
            {
                return Parent.Lines.IndexOf(this) > 0;
            }
        }
        public bool CanMoveDown
        {
            get
            {
                return Parent.Lines.IndexOf(this) < Parent.Lines.Count - 1;
            }
        }
    }
}
