using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Xml.Serialization;

namespace DykBits.Crm.Data
{
    [TypeMapping(typeof(OperatingCalculationLine))]
    partial class OperatingCalculation: ICloneable, IOperatingBudgetDocument
    {
        private OperatingCalculationLineCollection _lines;
        public OperatingCalculationLineCollection Lines
        {
            get
            {
                if (this._lines == null)
                {
                    this._lines = new OperatingCalculationLineCollection(this);
                    this._lines.CollectionChanged += _lines_CollectionChanged;
                }
                return this._lines;
            }
        }
        void _lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            for (int index = 0; index < this.Lines.Count; ++index)
                this.Lines[index].OrdinalPosition = index + 1;
            InvokePropertyChanged("Lines");
        }
        public OperatingCalculation Clone()
        {
            var source = this;
            var that = new OperatingCalculation();

            that.DocumentDate = source.DocumentDate;
            that.OrganizationId = source.OrganizationId;
            that.OperatingBudgetId = source.OperatingBudgetId;
            that.CalculationStage = source.CalculationStage;
            that.BudgetItemId = source.BudgetItemId;
            that.Comments = source.Comments;

            foreach (var line in source.Lines)
            {
                that.Lines.Add(new OperatingCalculationLine
                {
                    OrdinalPosition = line.OrdinalPosition,
                    AccountId = line.AccountId,
                    FileAs = line.FileAs,
                    Comments = line.Comments,
                    Amount = line.Amount,
                    Price = line.Price
                });
            }
            return that;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
