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
    
    public partial class PayrollView : NumberedDataItemView
    {
        public const string DataItemClassName = "Payroll";
        private int _OperatingBudgetIdField;
        private int _SalaryBudgetItemIdField;
        private int _TaxBudgetItemIdField;
        private int _CashingBudgetItemIdField;
        private int _ExtraCostRateIdField;
        private int _CalculationStageField;
        public override string DataItemClass
        {
            get
            {
                return DataItemClassName;
            }
        }
        [XmlAttribute()]
        public PayrollState State
        {
            get
            {
                return (PayrollState)((IDataItem)this).State;
            }
            set
            {
                ((IDataItem)this).State = (byte)value;
            }
        }
        [XmlAttribute()]
        public int OperatingBudgetId
        {
            get
            {
                return this._OperatingBudgetIdField;
            }
            set
            {
                this._OperatingBudgetIdField = value;
            }
        }
        [XmlAttribute()]
        public int SalaryBudgetItemId
        {
            get
            {
                return this._SalaryBudgetItemIdField;
            }
            set
            {
                this._SalaryBudgetItemIdField = value;
            }
        }
        [XmlAttribute()]
        public int TaxBudgetItemId
        {
            get
            {
                return this._TaxBudgetItemIdField;
            }
            set
            {
                this._TaxBudgetItemIdField = value;
            }
        }
        [XmlAttribute()]
        public int CashingBudgetItemId
        {
            get
            {
                return this._CashingBudgetItemIdField;
            }
            set
            {
                this._CashingBudgetItemIdField = value;
            }
        }
        [XmlAttribute()]
        public int ExtraCostRateId
        {
            get
            {
                return this._ExtraCostRateIdField;
            }
            set
            {
                this._ExtraCostRateIdField = value;
            }
        }
        [XmlAttribute()]
        public int CalculationStage
        {
            get
            {
                return this._CalculationStageField;
            }
            set
            {
                this._CalculationStageField = value;
            }
        }
    }
}
