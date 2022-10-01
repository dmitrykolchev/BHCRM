using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(ContractPaymentCalendar))]
    partial class Contract
    {
        private ObservableCollection<ContractPaymentCalendar> _paymentCalendar;

        public ObservableCollection<ContractPaymentCalendar> PaymentCalendar
        {
            get
            {
                if (this._paymentCalendar == null)
                {
                    this._paymentCalendar = new ObservableCollection<ContractPaymentCalendar>();
                    this._paymentCalendar.CollectionChanged += _paymentCalendar_CollectionChanged;
                }
                return this._paymentCalendar;
            }
        }

        void _paymentCalendar_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokePropertyChanged("PaymentCalendar");
        }

        public bool IsContractAnnex
        {
            get { return this.ParentContractId.HasValue; }
        }

        public bool IsContract
        {
            get { return !this.ParentContractId.HasValue; }
        }

    }
}
