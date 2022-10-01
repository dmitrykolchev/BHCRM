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
    
    public enum PayrollState : byte
    {
        [XmlEnum("0")]
        NotExist = 0,
        [XmlEnum("1")]
        Draft = 1,
        [XmlEnum("2")]
        Approved = 2,
    }
    public partial class Payroll : NumberedDataItem
    {
        public const string DataItemClassName = "Payroll";
        public const string OperatingBudgetIdProperty = "OperatingBudgetId";
        public const string SalaryBudgetItemIdProperty = "SalaryBudgetItemId";
        public const string TaxBudgetItemIdProperty = "TaxBudgetItemId";
        public const string CashingBudgetItemIdProperty = "CashingBudgetItemId";
        public const string ExtraCostRateIdProperty = "ExtraCostRateId";
        public const string CalculationStageProperty = "CalculationStage";
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
        [Column(Name="OperatingBudgetId", IsNullable=false)]
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
                InvokePropertyChanged("OperatingBudgetId");
            }
        }
        [Column(Name="SalaryBudgetItemId", IsNullable=false)]
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
                InvokePropertyChanged("SalaryBudgetItemId");
            }
        }
        [Column(Name="TaxBudgetItemId", IsNullable=false)]
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
                InvokePropertyChanged("TaxBudgetItemId");
            }
        }
        [Column(Name="CashingBudgetItemId", IsNullable=false)]
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
                InvokePropertyChanged("CashingBudgetItemId");
            }
        }
        [Column(Name="ExtraCostRateId", IsNullable=false)]
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
                InvokePropertyChanged("ExtraCostRateId");
            }
        }
        [Column(Name="CalculationStage", IsNullable=false)]
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
                InvokePropertyChanged("CalculationStage");
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
