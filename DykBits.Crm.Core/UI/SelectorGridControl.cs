using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DykBits.Crm.Data;

namespace DykBits.Crm.UI
{
    public class SelectorGridControl: DataGridControlBase
    {
        public SelectorGridControl()
        {
        }
        public virtual bool HascheckedItems
        {
            get
            {
                if (this.GridView != null && this.GridView.ItemsSource != null)
                {
                    foreach (ISelectableDataItem item in (IEnumerable)this.GridView.ItemsSource)
                    {
                        if (item.Selected)
                            return true;
                    }
                }
                return false;
            }
        }
        public virtual IDataItem[] GetCheckedItems()
        {
            if(this.GridView != null && this.GridView.ItemsSource != null)
                return ((IEnumerable)this.GridView.ItemsSource).OfType<IDataItem>().Where(t => ((ISelectableDataItem)t).Selected).ToArray();
            return new IDataItem[0];
        }
    }
}
