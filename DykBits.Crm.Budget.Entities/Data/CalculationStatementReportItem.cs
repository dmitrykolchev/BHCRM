using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementReportItem
    {
        private CalculationStatementItem _source;
        public CalculationStatementReportItem(CalculationStatementItem source)
        {
            this._source = source;
        }
        public bool IsSection
        {
            get { return this.Level == 0; }
        }
        public string FileAs
        {
            get { return this._source.FileAs; }
        }
        public string Comments
        {
            get { return this._source.Comments; }
        }
        public Nullable<DateTime> StartTime
        {
            get { return this._source.StartTime; }
        }
        public Nullable<DateTime> EndTime
        {
            get { return this._source.EndTime; }
        }
        public Nullable<decimal> Duration
        {
            get { return this._source.Duration; }
        }
        public Nullable<decimal> Amount
        {
            get { return this._source.Amount; }
        }
        public Nullable<decimal> Price
        {
            get { return this._source.Price; }
        }
        public Nullable<decimal> TotalPrice
        {
            get { return this._source.TotalPrice; }
        }
        public Nullable<decimal> Cost
        {
            get { return this._source.Cost; }
        }
        public Nullable<decimal> TotalCost
        {
            get { return this._source.TotalCost; }
        }
        public Nullable<decimal> Income
        {
            get { return this._source.Income; }
        }
        public int Level
        {
            get { return this._source.Level; }
        }
    }
}
