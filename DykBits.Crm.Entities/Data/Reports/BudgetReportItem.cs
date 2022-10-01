using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data.Reports
{
    public class BudgetReportItem
    {
        private BudgetReport _parent;
        private BudgetLineProxy _item;
        internal BudgetReportItem(BudgetReport parent, BudgetLineProxy item)
        {
            this._parent = parent;
            this._item = item;
        }
        public BudgetReport Parent
        {
            get { return this._parent; }
        }
        public BudgetLineProxy Item
        {
            get { return this._item; }
        }
        public string FileAs
        {
            get { return this.Item.FileAs; }
        }
        public bool IsSection
        {
            get { return Level < 2; }
        }
        public int Level
        {
            get { return this.Item.Level; }
        }
        public Nullable<decimal> StandardValue
        {
            get { return this.Item.StandardValue; }
        }
        public Nullable<decimal> ActualValue
        {
            get { return this.Item.ActualValue; }
        }
        public Nullable<decimal> PlannedValue
        {
            get { return this.Item.PlannedValue; }
        }
        public Nullable<decimal> InvoiceValue
        {
            get { return this.Item.InvoiceValue; }
        }
        public Nullable<decimal> PaymentValue
        {
            get { return this.Item.PaymentValue; }
        }
    }
}
