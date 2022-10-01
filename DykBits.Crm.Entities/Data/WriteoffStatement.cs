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
    
    public enum WriteoffStatementState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Draft = 1,
        [XmlEnum("2")]
        Approved = 2,
    }
    public partial class WriteoffStatement : NumberedDataItem
    {
        public const string DataItemClassName = "WriteoffStatement";
        public const string SubjectProperty = "Subject";
        public const string StoragePlaceIdProperty = "StoragePlaceId";
        public const string TotalCostProperty = "TotalCost";
        private string _SubjectField;
        private int _StoragePlaceIdField;
        private decimal _TotalCostField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public WriteoffStatementState State
        {
            get
            {
                return (WriteoffStatementState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="Subject", IsNullable=false, MaximumLength=256)]
        [XmlAttribute()]
        public string Subject
        {
            get
            {
                return this._SubjectField;
            }
            set
            {
                this._SubjectField = value;
                InvokePropertyChanged("Subject");
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
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            NotifyPropertyChangedInternal(e.PropertyName);
            base.OnPropertyChanged(e);
        }

		partial void NotifyPropertyChangedInternal(string propertyName);
    }
}
