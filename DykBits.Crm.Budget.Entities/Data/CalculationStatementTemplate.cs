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
    
    public enum CalculationStatementTemplateState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Active = 1,
    }
    public partial class CalculationStatementTemplate : DataItem
    {
        public const string DataItemClassName = "CalculationStatementTemplate";
        public const string BudgetTemplateIdProperty = "BudgetTemplateId";
        public const string IncomeBudgetItemIdProperty = "IncomeBudgetItemId";
        public const string ExpenseBudgetItemIdProperty = "ExpenseBudgetItemId";
        public const string DependsOnAmountOfPersonsProperty = "DependsOnAmountOfPersons";
        public const string AmountOnlyProperty = "AmountOnly";
        private int _BudgetTemplateIdField;
        private System.Nullable<int> _IncomeBudgetItemIdField;
        private System.Nullable<int> _ExpenseBudgetItemIdField;
        private bool _DependsOnAmountOfPersonsField;
        private bool _AmountOnlyField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public CalculationStatementTemplateState State
        {
            get
            {
                return (CalculationStatementTemplateState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [Column(Name="BudgetTemplateId", IsNullable=false)]
        [XmlAttribute()]
        public int BudgetTemplateId
        {
            get
            {
                return this._BudgetTemplateIdField;
            }
            set
            {
                this._BudgetTemplateIdField = value;
                InvokePropertyChanged("BudgetTemplateId");
            }
        }
        [Column(Name="IncomeBudgetItemId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> IncomeBudgetItemId
        {
            get
            {
                return this._IncomeBudgetItemIdField;
            }
            set
            {
                this._IncomeBudgetItemIdField = value;
                InvokePropertyChanged("IncomeBudgetItemId");
            }
        }
        [Column(Name="ExpenseBudgetItemId", IsNullable=true)]
        [XmlAttribute()]
        public System.Nullable<int> ExpenseBudgetItemId
        {
            get
            {
                return this._ExpenseBudgetItemIdField;
            }
            set
            {
                this._ExpenseBudgetItemIdField = value;
                InvokePropertyChanged("ExpenseBudgetItemId");
            }
        }
        [Column(Name="DependsOnAmountOfPersons", IsNullable=false)]
        [XmlAttribute()]
        public bool DependsOnAmountOfPersons
        {
            get
            {
                return this._DependsOnAmountOfPersonsField;
            }
            set
            {
                this._DependsOnAmountOfPersonsField = value;
                InvokePropertyChanged("DependsOnAmountOfPersons");
            }
        }
        [Column(Name="AmountOnly", IsNullable=false)]
        [XmlAttribute()]
        public bool AmountOnly
        {
            get
            {
                return this._AmountOnlyField;
            }
            set
            {
                this._AmountOnlyField = value;
                InvokePropertyChanged("AmountOnly");
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