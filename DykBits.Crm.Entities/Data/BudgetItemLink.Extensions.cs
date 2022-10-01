using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DykBits.Crm.Data
{
    partial class BudgetItemLink
    {
        private int _incomeBudgetItemGroupId;
        private int _expenseBudgetItemGroupId;
        [XmlIgnore]
        public int IncomeBudgetItemGroupId
        {
            get
            {
                if (this._incomeBudgetItemGroupId == 0)
                    this._incomeBudgetItemGroupId = GetGroupForItem(this.IncomeBudgetItemId);
                return this._incomeBudgetItemGroupId;
            }
            set
            {
                this._incomeBudgetItemGroupId = value;
                InvokePropertyChanged();
            }
        }
        [XmlIgnore]
        public int ExpenseBudgetItemGroupId
        {
            get
            {
                if (this._expenseBudgetItemGroupId == 0)
                    this._expenseBudgetItemGroupId = GetGroupForItem(this.ExpenseBudgetItemId);
                return this._expenseBudgetItemGroupId;
            }
            set
            {
                this._expenseBudgetItemGroupId = value;
                InvokePropertyChanged();
            }
        }

        private int GetGroupForItem(int budgetItemId)
        {
            ListManager listManager = ServiceManager.GetService<ListManager>();
            var list = listManager.GetList(BudgetItem.DataItemClassName);
            return ((BudgetItemView)list[budgetItemId]).BudgetItemGroupId;
        }
    }
}
