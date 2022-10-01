using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class ContractPaymentCalendar: NotifyObject
    {
        private DateTime _paymentDate;
        private decimal _amount;
        private decimal _vat;
        private string _comments;
        public ContractPaymentCalendar()
        {
            this._paymentDate = DateTime.Today;
        }
        [XmlAttribute]
        public Nullable<int> Id { get; set; }
        [XmlAttribute]
        public Nullable<int> ContractId { get; set; }
        [XmlAttribute]
        public DateTime PaymentDate
        {
            get { return this._paymentDate; }
            set
            {
                this._paymentDate = value;
                InvokePropertyChanged("PaymentDate");
            }
        }
        [XmlAttribute]
        public decimal Amount
        {
            get { return this._amount; }
            set
            {
                this._amount = value;
                InvokePropertyChanged("Amount");
            }
        }
        [XmlAttribute]
        public decimal VAT
        {
            get { return this._vat; }
            set
            {
                this._vat = value;
                InvokePropertyChanged("VAT");
            }
        }
        [XmlAttribute]
        public string Comments
        {
            get { return this._comments; }
            set
            {
                this._comments = value;
                InvokePropertyChanged("Comments");
            }
        }
    }
}
