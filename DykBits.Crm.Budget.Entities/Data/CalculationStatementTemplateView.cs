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
    using System.Xml.Serialization;
    
    public partial class CalculationStatementTemplateView : DataItemView
    {
        public const string DataItemClassName = "CalculationStatementTemplate";
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
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
            }
        }
    }
}