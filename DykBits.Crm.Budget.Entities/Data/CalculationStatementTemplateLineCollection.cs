using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Data
{
    public class CalculationStatementTemplateLineCollection: ObservableCollection<CalculationStatementTemplateLine>
    {
        private CalculationStatementTemplate _owner;
        internal CalculationStatementTemplateLineCollection(CalculationStatementTemplate owner)
        {
            this._owner = owner;
        }

        protected override void InsertItem(int index, CalculationStatementTemplateLine item)
        {
            base.InsertItem(index, item);
            item.Parent = this._owner;
        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            for (int index = 0; index < Count; ++index)
            {
                this[index].OrdinalPosition = index + 1;
            }
            base.OnCollectionChanged(e);
        }
    }
}
