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
    
    public partial class BudgetItemLinkView : DataItemView
    {
        public const string DataItemClassName = "BudgetItemLink";
        private int _IncomeBudgetItemIdField;
        private int _ExpenseBudgetItemIdField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public BudgetItemLinkState State
        {
            get
            {
                return (BudgetItemLinkState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public int IncomeBudgetItemId
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
        public int ExpenseBudgetItemId
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
    }
}
