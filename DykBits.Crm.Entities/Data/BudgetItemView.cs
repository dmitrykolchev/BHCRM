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
    
    public partial class BudgetItemView : DataItemView
    {
        public const string DataItemClassName = "BudgetItem";
        private string _CodeField;
        private int _BudgetItemGroupIdField;
        private int _BudgetItemGroupTypeField;
        private bool _IsExpenseGroupField;
        private int _BudgetItemTypeField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public BudgetItemState State
        {
            get
            {
                return (BudgetItemState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
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
            }
        }
        [XmlAttribute()]
        public int BudgetItemGroupId
        {
            get
            {
                return this._BudgetItemGroupIdField;
            }
            set
            {
                this._BudgetItemGroupIdField = value;
            }
        }
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
            }
        }
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
            }
        }
        [XmlAttribute()]
        public int BudgetItemType
        {
            get
            {
                return this._BudgetItemTypeField;
            }
            set
            {
                this._BudgetItemTypeField = value;
            }
        }
    }
}
