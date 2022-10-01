using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class EmployeeSalary : NotifyObject
    {
        private decimal _value;
        private decimal _cashValue;
        private DateTime _activeFrom;
        private Employee _parent;
        [XmlAttribute]
        public int EmployeeSalaryId { get; set; }
        [XmlAttribute]
        public int EmployeeId { get; set; }
        [XmlAttribute]
        public decimal Value
        {
            get { return this._value; }
            set
            {
                this._value = value;
                InvokePropertyChanged();
                InvokePropertyChanged("TotalValue");
            }
        }
        [XmlAttribute]
        public decimal CashValue
        {
            get { return this._cashValue; }
            set
            {
                this._cashValue = value;
                InvokePropertyChanged();
                InvokePropertyChanged("TotalValue");
            }
        }
        [XmlIgnore]
        public decimal TotalValue
        {
            get { return this._value + this._cashValue; }
        }
        [XmlAttribute]
        public DateTime ActiveFrom
        {
            get { return this._activeFrom; }
            set
            {
                this._activeFrom = value;
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        internal Employee Parent
        {
            get { return this._parent; }
            set
            {
                this._parent = value;
            }
        }
    }

    public class EmployeeSalaryCollection : ObservableCollection<EmployeeSalary>
    {
        private Employee _owner;
        internal EmployeeSalaryCollection(Employee owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, EmployeeSalary item)
        {
            base.InsertItem(index, item);
            item.Parent = this._owner;
        }
    }
}
