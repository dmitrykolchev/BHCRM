//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DykBits.Crm.Data
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    public enum SalesOrderState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Draft = 1,
        [XmlEnum("2")]
        Approved = 2,
    }
    public partial class SalesOrder : NumberedDataItem
    {
        public const string DataItemClassName = "SalesOrder";
        public const string StoragePlaceIdProperty = "StoragePlaceId";
        public const string BudgetIdProperty = "BudgetId";
        public const string BudgetItemGroupIdProperty = "BudgetItemGroupId";
        public const string BudgetItemIdProperty = "BudgetItemId";
        public const string CustomerIdProperty = "CustomerId";
        public const string TotalCostProperty = "TotalCost";
        public const string TotalPriceProperty = "TotalPrice";
        private int _StoragePlaceIdField;
        private System.Nullable<int> _BudgetIdField;
        private System.Nullable<int> _BudgetItemGroupIdField;
        private System.Nullable<int> _BudgetItemIdField;
        private int _CustomerIdField;
        private decimal _TotalCostField;
        private decimal _TotalPriceField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public SalesOrderState State
        {
            get
            {
                return (SalesOrderState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="StoragePlaceId", IsNullable=false)]
        [XmlAttribute()]
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
        [Column(Name="BudgetId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> BudgetId
        {
            get
            {
                return this._BudgetIdField;
            }
            set
            {
                this._BudgetIdField = value;
                InvokePropertyChanged("BudgetId");
            }
        }
        [Column(Name="BudgetItemGroupId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> BudgetItemGroupId
        {
            get
            {
                return this._BudgetItemGroupIdField;
            }
            set
            {
                this._BudgetItemGroupIdField = value;
                InvokePropertyChanged("BudgetItemGroupId");
            }
        }
        [Column(Name="BudgetItemId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> BudgetItemId
        {
            get
            {
                return this._BudgetItemIdField;
            }
            set
            {
                this._BudgetItemIdField = value;
                InvokePropertyChanged("BudgetItemId");
            }
        }
        [Column(Name="CustomerId", IsNullable=false)]
        [XmlAttribute()]
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
        [Column(Name="TotalCost", IsNullable=false)]
        [XmlAttribute()]
        public decimal TotalCost
        {
            get
            {
                return this._TotalCostField;
            }
            set
            {
                this._TotalCostField = value;
                InvokePropertyChanged("TotalCost");
            }
        }
        [Column(Name="TotalPrice", IsNullable=false)]
        [XmlAttribute()]
        public decimal TotalPrice
        {
            get
            {
                return this._TotalPriceField;
            }
            set
            {
                this._TotalPriceField = value;
                InvokePropertyChanged("TotalPrice");
            }
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            NotifyPropertyChangedInternal(e.PropertyName);
            base.OnPropertyChanged(e);
        }

		partial void NotifyPropertyChangedInternal(string propertyName);
    }
}
