using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    public class BudgetTemplateLineProxy : NotifyObject
    {
        private Nullable<decimal> _standardValue;
        private Nullable<decimal> _standardPercentage;

        public int BudgetItemId { get; set; }
        public int Id { get; set; }
        public int Level { get; set; }
        public int ParentId { get; set; }
        public string FileAs { get; set; }
        public Nullable<decimal> StandardValue
        {
            get { return this._standardValue; }
            set
            {
                this._standardValue = value;
                InvokePropertyChanged();
            }
        }

        public Nullable<decimal> StandardPercentage
        {
            get { return this._standardPercentage; }
            set
            {
                this._standardPercentage = value;
                InvokePropertyChanged();
            }
        }
    }
    public class BudgetTemplateLine
    {
        private BudgetItemView _budgetItem;
        private BudgetItemGroupView _budgetItemGroup;
        [XmlAttribute]
        public int BudgetTemplateLineId { get; set; }
        [XmlAttribute]
        public int BudgetTemplateId { get; set; }
        [XmlAttribute]
        public int BudgetItemId { get; set; }
        [XmlAttribute]
        public Nullable<decimal> StandardValue { get; set; }
        [XmlIgnore]
        public string FileAs
        {
            get { return BudgetItem.FileAs; }
        }
        [XmlIgnore]
        public BudgetTemplate Parent
        {
            get;
            internal set;
        }
        [XmlIgnore]
        public BudgetItemView BudgetItem
        {
            get
            {
                if (this._budgetItem == null)
                    this._budgetItem = (BudgetItemView)this.Parent.BudgetItems[this.BudgetItemId];
                return this._budgetItem;
            }
        }
        [XmlIgnore]
        public BudgetItemGroupView BudgetItemGroup
        {
            get
            {
                if (this._budgetItemGroup == null)
                    this._budgetItemGroup = (BudgetItemGroupView)this.Parent.BudgetItemGroups[this.BudgetItem.BudgetItemGroupId];
                return this._budgetItemGroup;
            }
        }
    }
}
