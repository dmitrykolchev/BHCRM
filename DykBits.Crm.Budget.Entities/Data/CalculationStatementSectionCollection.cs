using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementSectionCollection: ObservableCollection<CalculationStatementSection>
    {
        private CalculationStatement _owner;

        internal CalculationStatementSectionCollection(CalculationStatement owner)
        {
            this._owner = owner;
        }
        protected override void InsertItem(int index, CalculationStatementSection item)
        {
            base.InsertItem(index, item);
            item.Parent = this._owner;
        }
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            for (int index = 0; index < this.Count; ++index)
            {
                this[index].OrdinalPosition = index + 1;
            }
            base.OnCollectionChanged(e);
        }
        internal void MoveUp(CalculationStatementSection section)
        {
            int index = this.IndexOf(section);
            this.Move(index, index - 1);
        }
        internal void MoveDown(CalculationStatementSection section)
        {
            int index = this.IndexOf(section);
            this.Move(index, index + 1);
        }
    }
}
