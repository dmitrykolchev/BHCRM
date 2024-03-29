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
    
    public enum BudgetItemGroupState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
        [XmlEnum("2")]
        Inactive = 2,
    }
    public partial class BudgetItemGroup : DataItem
    {
        public const string DataItemClassName = "BudgetItemGroup";
        public const string CodeProperty = "Code";
        public const string BudgetItemGroupTypeProperty = "BudgetItemGroupType";
        public const string IsExpenseGroupProperty = "IsExpenseGroup";
        private string _CodeField;
        private int _BudgetItemGroupTypeField;
        private bool _IsExpenseGroupField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public BudgetItemGroupState State
        {
            get
            {
                return (BudgetItemGroupState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="Code", IsNullable=false, MaximumLength=32)]
        [XmlAttribute()]
        public string Code
        {
            get
            {
                return this._CodeField;
            }
            set
            {
                this._CodeField = value;
                InvokePropertyChanged("Code");
            }
        }
        [Column(Name="BudgetItemGroupType", IsNullable=false)]
        [XmlAttribute()]
        public int BudgetItemGroupType
        {
            get
            {
                return this._BudgetItemGroupTypeField;
            }
            set
            {
                this._BudgetItemGroupTypeField = value;
                InvokePropertyChanged("BudgetItemGroupType");
            }
        }
        [Column(Name="IsExpenseGroup", IsNullable=false)]
        [XmlAttribute()]
        public bool IsExpenseGroup
        {
            get
            {
                return this._IsExpenseGroupField;
            }
            set
            {
                this._IsExpenseGroupField = value;
                InvokePropertyChanged("IsExpenseGroup");
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
