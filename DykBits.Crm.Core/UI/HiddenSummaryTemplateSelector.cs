using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;
using DevExpress.Data;

namespace DykBits.Crm.UI
{
    public sealed class HiddenSummaryTemplateSelector : DataTemplateSelector
    {
        static readonly DataTemplate EmptyTemplate = new DataTemplate();

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return EmptyTemplate;
            GridGroupSummaryData data = item as GridGroupSummaryData;
            if (data.SummaryItem.SummaryType == SummaryItemType.Count)
                return EmptyTemplate;

            return base.SelectTemplate(item, container);
        }
    }

}
