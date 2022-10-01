using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Serialization
{
    public abstract class NotifyObject : INotifyPropertyChanged
    {
        protected NotifyObject()
        {
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
    }

    public class SalesOrderLine : NotifyObject
    {
        private decimal _amount;
        private decimal _price;

        [XmlAttribute]
        public Nullable<int> SalesOrderLineId { get; set; }

        [XmlAttribute]
        public Nullable<int> SalesOrderId { get; set; }

        [XmlAttribute]
        public Nullable<int> ProductId { get; set; }
        [XmlAttribute]
        public Nullable<int> UnitOfMeasureId { get; set; }
        [XmlAttribute]
        public decimal Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
                InvokePropertyChanged("Amount");
                InvokePropertyChanged("Total");
            }
        }
        [XmlAttribute]
        public decimal Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
                InvokePropertyChanged("Price");
                InvokePropertyChanged("Total");
            }
        }

        public decimal Total
        {
            get { return Amount * Price; }
        }
    }

    public enum SalesOrderState : byte
    {
        Draft = 0,
        Active = 1,
        Inactive = 2,
    }

    [XmlRoot("SalesOrder")]
    public class SalesOrder : DataItem
    {
        public const string DataItemClassName = "SalesOrder";
        private string _NumberField;
        private SalesOrderState _State;
        private System.DateTime _DocumentDateField;
        private int _OrganizationIdField;
        private int _StoragePlaceIdField;
        private int _CustomerIdField;
        private System.Nullable<int> _ContractIdField;
        private System.Nullable<int> _ProjectIdField;

        public SalesOrder()
        {
        }

        [XmlAttribute]
        public SalesOrderState State
        {
            get
            {
                return this._State;
            }
            set
            {
                this._State = value;
                InvokePropertyChanged("State");
            }
        }
        [XmlAttribute]
        public string Number
        {
            get
            {
                return this._NumberField;
            }
            set
            {
                this._NumberField = value;
                InvokePropertyChanged("Number");
            }
        }
        [XmlAttribute]
        public System.DateTime DocumentDate
        {
            get
            {
                return this._DocumentDateField;
            }
            set
            {
                this._DocumentDateField = value;
                InvokePropertyChanged("DocumentDate");
            }
        }
        [XmlAttribute]
        public int OrganizationId
        {
            get
            {
                return this._OrganizationIdField;
            }
            set
            {
                this._OrganizationIdField = value;
                InvokePropertyChanged("OrganizationId");
            }
        }
        [XmlAttribute]
        public int StoragePlaceId
        {
            get
            {
                return this._StoragePlaceIdField;
            }
            set
            {
                this._StoragePlaceIdField = value;
                InvokePropertyChanged("StoragePlaceId");
            }
        }
        [XmlAttribute]
        public int CustomerId
        {
            get
            {
                return this._CustomerIdField;
            }
            set
            {
                this._CustomerIdField = value;
                InvokePropertyChanged("CustomerId");
            }
        }
        public System.Nullable<int> ContractId
        {
            get
            {
                return this._ContractIdField;
            }
            set
            {
                this._ContractIdField = value;
                InvokePropertyChanged("ContractId");
            }
        }
        public System.Nullable<int> ProjectId
        {
            get
            {
                return this._ProjectIdField;
            }
            set
            {
                this._ProjectIdField = value;
                InvokePropertyChanged("ProjectId");
            }
        }
        
        private ObservableCollection<SalesOrderLine> _lines;

        [XmlElement("Lines")]
        public ObservableCollection<SalesOrderLine> Lines
        {
            get
            {
                if (this._lines == null)
                    this._lines = new ObservableCollection<SalesOrderLine>();
                return this._lines;
            }
        }
    }
}
